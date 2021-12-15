using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MeterTest.Source.Dlt645;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace MeterTest.Source.Freeze
{
    public class FreezeDataFactory
    {
        private string readerName;
        private string methond;
        private DateTime start;
        private DateTime end;
        private int time;
        private int cnt;
        private int blockNo;
        private IFreezeLog log;
        private Dlt645Client client;
        private MeterAddress address;
        private IReadFreezeData reader;
        public bool stopFlg;
        public  List<FreezeDataBlock> FreezeDataBlocks = new List<FreezeDataBlock>();

        private static List<string> TypeIILeftList = new List<string>
        {
            "电压"       ,    
            "电流"       ,    
            "有功功率"   ,
            "无功功率"   ,
            "视在功率"   ,
            "功率因数"   ,
            "频率"       ,    
            "正向有功电能",
            "反向有功电能",
            "正向无功电能",
            "反向无功电能",
        };

        public FreezeDataFactory()
        {
        }

        public FreezeDataFactory(string readerName, 
                                 string methond, 
                                 DateTime start, 
                                 DateTime end, 
                                 int time, 
                                 int cnt, 
                                 int blockNo, 
                                 IFreezeLog log, 
                                 Dlt645Client client, 
                                 MeterAddress address)
        {
            this.readerName = readerName;
            this.methond = methond;
            this.start = start;
            this.end = end;
            this.time = time;
            this.cnt = cnt;
            this.blockNo = blockNo;
            this.log = log;
            this.client = client;
            this.address = address;
            reader = CreateFreezeDataReader(readerName);
        }
        public static List<string> CreateLiftString(string projectName)
        {
            if(projectName == "II型终端")
            {
                return TypeIILeftList;
            }
            return null;
        }

        private IReadFreezeData CreateFreezeDataReader(string readerName)
        {
            IReadFreezeData reader = null;
            if(readerName == "II型终端")
            {
                reader = new ReadTypeIIFreezeData(client, address);
            }
            else if(readerName == "相变")
            {
                // throw new System.Exception("没有相变项目的冻结数据读取器！");
                MessageBox.Show("没有相变项目的冻结数据读取器！");
            }
            else
            {
                // throw new System.Exception(readerName + ":没有该项目的冻结数据读取器！");
                MessageBox.Show(readerName + ":没有该项目的冻结数据读取器！");
            }
            return reader;
        }

        private void GetFreezeDataListFormTime()
        {
            FreezeReadMsg msg = new FreezeReadMsg();
            int total = (int)((end.Ticks - start.Ticks) / TimeSpan.TicksPerMinute + 1);
            int tmp = 0;
            DateTime timeStart = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, 0);
            while((timeStart <= end) && (!stopFlg))
            {
                FreezeDataBlock block = reader.ReadFreezeDataFromTime(timeStart, blockNo);
                timeStart = timeStart.AddMinutes(time);
                tmp += time;
                FreezeDataBlocks.Add(block);
                //start.AddMinutes(time);
                msg.ProgressBar = (int)(tmp * 100 / total);
                msg.ToolStripStatusLabel = "正读取的时间点：" + timeStart.ToString("yyyy-MM-dd HH:mm:ss");
                log.SendMsg(msg);
            }
            msg.ProgressBar = 100;
            msg.ToolStripStatusLabel = "读取完成";
            log.SendMsg(msg);
        }
        private void GetFreezeDataListFormCntBlock ()
        {
            FreezeReadMsg msg = new FreezeReadMsg();
            for (int i = 0; i < cnt; i++)
            {
                FreezeDataBlock block = reader.ReadFreezeDataFromCntBlk(i, blockNo);
                FreezeDataBlocks.Add(block);
                msg.ProgressBar = (int)(i * 100 / cnt);
                msg.ToolStripStatusLabel = "正读取的上" + i.ToString() + "次的冻结数据";
                log.SendMsg(msg);
                cnt--;
                if(!stopFlg)
                {
                    break;
                }
            }
            msg.ProgressBar = 100;
            msg.ToolStripStatusLabel = "读取完成";
            log.SendMsg(msg);
        }

        private void GetFreezeDataListFromCntOnce()
        {
            FreezeReadMsg msg = new FreezeReadMsg();
            for (int i = 0; i < cnt; i++)
            {
                FreezeDataBlock block = reader.ReadFreezeDataFromCntOnce(i, blockNo);
                FreezeDataBlocks.Add(block);
                msg.ProgressBar = (int)(i * 100 / cnt);
                msg.ToolStripStatusLabel = "正读取的上" + i.ToString() + "次的冻结数据";
                log.SendMsg(msg);
                cnt--;
                if(!stopFlg)
                {
                    break;
                }
            }
            msg.ProgressBar = 100;
            msg.ToolStripStatusLabel = "读取完成";
            log.SendMsg(msg);
        }
        public static void SaveFreezeData(Stream stream, List<FreezeDataBlock> blocks)
        {
            IWorkbook workbook = null;
            try
            {
                workbook = new XSSFWorkbook();
                ISheet originalSheet = workbook.CreateSheet("原始数据");
                IRow row = originalSheet.CreateRow(0);
                row.CreateCell(0).SetCellValue("编号");
                row.CreateCell(1).SetCellValue("原始数据");

                ISheet parsingSheet = workbook.CreateSheet("解析数据");
                row = parsingSheet.CreateRow(0);
                row.CreateCell(0).SetCellValue("编号");
                row.CreateCell(1).SetCellValue("冻结时间");
                FreezeDataBlock block = blocks[0];
                for (int i = 0; i < block.ItemList.Count; i++)
                {
                    row.CreateCell(2 + i).SetCellValue(block.ItemList[i].Name + block.ItemList[i].Unit);
                }
                for (int i = 0; i < blocks.Count; i++)
                {
                    block = blocks[i];
                    row = originalSheet.CreateRow(i + 1);
                    row.CreateCell(0).SetCellValue(i);
                    string dataString = null;
                    for (int j = 0; j < block.ByteArray.Length; j++)
                    {
                        dataString += block.ByteArray[j].ToString("X2");
                        dataString += " ";
                    }
                    row.CreateCell(1).SetCellValue(dataString);

                    row = parsingSheet.CreateRow(i + 1);
                    row.CreateCell(0).SetCellValue(i);
                    row.CreateCell(1).SetCellValue(block.time.ToString("yyyy-MM-dd HH:mm:ss"));
                    for (int j = 0; j < block.ItemList.Count; j++)
                    {
                        string format = "F" + block.ItemList[j].Point.ToString();
                        row.CreateCell(2 + j).SetCellValue(block.ItemList[j].Value.ToString(format));
                    }
                }
                workbook.Write(stream);
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                if(workbook != null)
                {
                    workbook.Close();
                }
            }
        }
        public void GetFreezeDataList()
        {
            lock (this)
            {
                stopFlg = false;
            }
            FreezeReadMsg msg = null;
            try
            {
                if(methond == "时间点")
                {
                    GetFreezeDataListFormTime();
                }
                else if(methond == "次数块")
                {
                    GetFreezeDataListFormCntBlock();
                }
                else if(methond == "次数单次")
                {
                    GetFreezeDataListFromCntOnce();
                }
                if(!stopFlg)
                {
                    // SaveFreezeData();
                }
            }
            catch (ClientException)
            {
                msg = new FreezeReadMsg();
                msg.ToolStripStatusLabel = "错误：从站异常响应帧";
                msg.ProgressBar = 0;
                log.SendMsg(msg);
            }
            catch (TimeoutException)
            {
                msg = new FreezeReadMsg();
                msg.ToolStripStatusLabel = "错误：响应超时";
                msg.ProgressBar = 0;
                log.SendMsg(msg);
            }
            catch (Exception e)
            {
                msg = new FreezeReadMsg();
                msg.ToolStripStatusLabel = e.Message;
                msg.ProgressBar = 0;
                log.SendMsg(msg);
            }
            finally
            {
                log.FreezeReadEnd();
            }
        }
        public void  GetFreezeDataListStop()
        {
            lock (this)
            {
                stopFlg = true;
            }
        }

        // public List<string> GetCharLeft()
        // {
        //     List<string> list = new List<string>();
            
        //     foreach (var item in FreezeDataBlocks[0].ItemList)
        //     {
        //         for (int i = 0; i < LeftList.Count; i++)
        //         {
        //             if(item.Name.Contains(LeftList[i]))
        //             {
        //                 list.Add(LeftList[i]);
        //             }
        //         }
        //     }
        //     return list;
        // }
        public bool FreezeDataBlockListDisplay(string projectName, string leftName, ref PlotModel model)
        {
            double min = 0, max = 0;
            Dictionary<int, LineSeries> lines = new Dictionary<int, LineSeries>();
            LineSeries line = null;
            bool isFirst = true;
            List<string> leftList = CreateLiftString(projectName);

            if((FreezeDataBlocks.Count == 0) || (leftList == null) || (!leftList.Contains(leftName)))
            {
                MessageBox.Show("没有冻结数据");
                return false;
            }
            FreezeDataBlocks.Sort();
            foreach (var item in FreezeDataBlocks)
            {
                for (int i = 0; i < item.ItemList.Count; i++)
                {
                    if(item.ItemList[i].Name.Contains(leftName))
                    {
                        if(!lines.TryGetValue(i, out line))
                        {
                            line = new LineSeries();
                            if(item.ItemList[i].Name.Contains("A"))
                            {
                                line.Color = OxyColors.DarkOrange;
                            }
                            else if(item.ItemList[i].Name.Contains("B"))
                            {
                                line.Color = OxyColors.Blue;
                            }
                            else if(item.ItemList[i].Name.Contains("C"))
                            {
                                line.Color = OxyColors.Red;
                            }
                            else if(item.ItemList[i].Name.Contains("总"))
                            {
                                line.Color = OxyColors.Black;
                            }
                            else
                            {
                                line.Color = OxyColors.LightGreen;
                            }
                            lines.Add(i, line);
                        }
                        line.Points.Add(new DataPoint(DateTimeAxis.ToDouble(item.time), item.ItemList[i].Value));
                        if(isFirst)
                        {
                            min = item.ItemList[i].Value;
                            max = item.ItemList[i].Value;
                        }
                        if(min > item.ItemList[i].Value)
                        {
                            min = item.ItemList[i].Value;
                        }
                        if(max < item.ItemList[i].Value)
                        {
                            max = item.ItemList[i].Value;
                        }
                    }
                }
            }
            model = new PlotModel();
            foreach (var item in lines)
            {
                model.Series.Add(item.Value);
            }
            LinearAxis left = new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = min, 
                Maximum = max, 
                // StringFormat = item.StringFormat,
                IsZoomEnabled = false,
                IsPanEnabled =  false,
                FractionUnit = 1.0,
                FractionUnitSymbol = null,
                FormatAsFractions = false,
                Title = leftName,
            };
            model.Axes.Add(left);
            DateTimeAxis bottom = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = DateTimeAxis.ToDouble(FreezeDataBlocks[0].time),
                Maximum = DateTimeAxis.ToDouble(FreezeDataBlocks[FreezeDataBlocks.Count -1].time),
            };
            model.Axes.Add(bottom);
            return true;
        }
    }
}