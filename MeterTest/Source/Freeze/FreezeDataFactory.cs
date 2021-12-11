using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MeterTest.Source.Dlt645;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

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
        // private string excelSavePath;
        private Stream stream;
        public bool stopFlg;
        public  List<FreezeDataBlock> FreezeDataBlocks = new List<FreezeDataBlock>();

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
                                 MeterAddress address,
                                 Stream s)
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
            this.stream = s;
            reader = CreateFreezeDataReader(readerName);
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
                throw new System.Exception("没有相变项目的冻结数据读取器！");
            }
            else
            {
                throw new System.Exception(readerName + ":没有该项目的冻结数据读取器！");
            }
            return reader;
        }

        private void GetFreezeDataListFormTime()
        {
            FreezeReadMsg msg = new FreezeReadMsg();
            int total = (int)((end.Ticks - start.Ticks) / TimeSpan.TicksPerMinute);
            int tmp = 0;
            while((start >= end) && (!stopFlg))
            {
                FreezeDataBlock block = reader.ReadFreezeDataFromTime(start, blockNo);
                start.AddMinutes(time);
                FreezeDataBlocks.Add(block);
                tmp += time;
                msg.ProgressBar = (int)(tmp * 100 / total);
                msg.ToolStripStatusLabel = "正读取的时间点：" + start.ToString("YY-MM-DD HH:mm:ss");
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
        private void SaveFreezeData()
        {
            IWorkbook workbook = null;
            Stream stream   = null;
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
                FreezeDataBlock block = FreezeDataBlocks[0];
                for (int i = 0; i < block.ItemList.Count; i++)
                {
                    row.CreateCell(2 + i).SetCellValue(block.ItemList[i].Name + block.ItemList[i].Unit);
                }
                for (int i = 0; i < FreezeDataBlocks.Count; i++)
                {
                    block = FreezeDataBlocks[i];
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
                    row.CreateCell(1).SetCellValue(block.time.ToString("yyyy-MM-DD HH:mm:ss"));
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
            if(methond == "时间")
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
                SaveFreezeData();
            }
            
            log.End();
        }
        public void  GetFreezeDataListStop()
        {
            lock (this)
            {
                stopFlg = true;
            }
        }
    }
}