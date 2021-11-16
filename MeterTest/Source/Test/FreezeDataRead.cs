using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MeterTest.Source.SQLite;
using MeterTest.Source.Dlt645;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace MeterTest.Source.Test
{
    public class FreezeDataRead
    {
        public const int MAX_FREEZE_CNT = 672;
        private List<FreezeData> freezeDataList = new List<FreezeData>();
        public Dictionary<int, List<byte[]>> FreezeData = new Dictionary<int, List<byte[]>>();
        private Dlt645Client client;

        private IFreezeLog freezeLog;
        private bool isEnd = false;
        private FreezeInfo[] freezeInfoArray = new FreezeInfo[] 
        { 
            new FreezeInfo(5,   5  , 2),   
            new FreezeInfo(5,   10 , 2), 
            new FreezeInfo(5,   15 , 2), 
            new FreezeInfo(5,   20 , 2), 
            new FreezeInfo(5,   25 , 2), 
            new FreezeInfo(5,   30 , 2),  
            new FreezeInfo(3,   35 , 3), 
            new FreezeInfo(3,   38 , 3), 
            new FreezeInfo(5,   41 , 2), 
            new FreezeInfo(5,   46 , 2), 
            new FreezeInfo(5,   51 , 2), 
            new FreezeInfo(5,   56 , 2), 
            new FreezeInfo(5,   61 , 2), 
            new FreezeInfo(5,   66 , 2), 
            new FreezeInfo(3,   71 , 3), 
            new FreezeInfo(3,   74 , 3), 
            new FreezeInfo(5,   77 , 2), 
            new FreezeInfo(5,   82 , 2), 
            new FreezeInfo(5,   87 , 2), 
            new FreezeInfo(5,   92 , 2), 
            new FreezeInfo(5,   97 , 2), 
            new FreezeInfo(5,   102, 2),
            new FreezeInfo(3,   107, 3),
            new FreezeInfo(3,   110, 3),
            new FreezeInfo(5,   113, 2),
            new FreezeInfo(5,   118, 2),
            new FreezeInfo(5,   123, 2),
            new FreezeInfo(5,   128, 2),
            new FreezeInfo(5,   133, 2),
            new FreezeInfo(5,   138, 2),
            new FreezeInfo(3,   143, 3),
            new FreezeInfo(3,   146, 3),
            new FreezeInfo(2,   154, 1),
            new FreezeInfo(2,   156, 1),
            new FreezeInfo(2,   158, 1),
            new FreezeInfo(3,   160, 3),
            new FreezeInfo(3,   163, 3),
            new FreezeInfo(3,   166, 3),
            new FreezeInfo(3,   169, 4),
            new FreezeInfo(3,   172, 4),
            new FreezeInfo(3,   175, 4),
            new FreezeInfo(3,   178, 4),
            new FreezeInfo(3,   181, 4),
            new FreezeInfo(3,   184, 4),
            new FreezeInfo(3,   187, 4),
            new FreezeInfo(3,   190, 4),
            new FreezeInfo(3,   193, 4),
            new FreezeInfo(3,   196, 4),
            new FreezeInfo(3,   199, 4),
            new FreezeInfo(3,   202, 4),
            new FreezeInfo(3,   205, 3),
            new FreezeInfo(2,   208, 2),
            new FreezeInfo(3,   210, 4),
            new FreezeInfo(2,   213, 1),
            new FreezeInfo(3,   215, 3),
        };
        /* 相变项目冻结曲线 */
        private readonly FreezeInfo[] phaseChangeFreezeInfoArray = new FreezeInfo[]
        {
            new FreezeInfo(4, 5  , 2),  /* (当前)正向有功总电能  */
            new FreezeInfo(4, 9  , 2),  /* (当前)反向有功总电能  */
            new FreezeInfo(4, 13 , 2),  /* (当前)A相正向有功电能 */
            new FreezeInfo(4, 17 , 2),  /* (当前)A相反向有功电能 */
            new FreezeInfo(4, 21 , 2),  /* (当前)B相正向有功电能 */
            new FreezeInfo(4, 25 , 2),  /* (当前)B相反向有功电能 */
            new FreezeInfo(4, 29 , 2),  /* (当前)C相正向有功电能 */
            new FreezeInfo(4, 33 , 2),  /* (当前)C相反向有功电能 */
            new FreezeInfo(4, 37 , 2),  /* (当前)正向无功总电能  */
            new FreezeInfo(4, 41 , 2),  /* (当前)反向无功总电能  */
            new FreezeInfo(4, 45 , 2),  /* (当前)A相正向无功电能 */
            new FreezeInfo(4, 49 , 2),  /* (当前)A相反向无功电能 */
            new FreezeInfo(4, 53 , 2),  /* (当前)B相正向无功电能 */
            new FreezeInfo(4, 57 , 2),  /* (当前)B相反向无功电能 */
            new FreezeInfo(4, 61 , 2),  /* (当前)C相正向无功电能 */
            new FreezeInfo(4, 65 , 2),  /* (当前)C相反向无功电能 */
            new FreezeInfo(2, 69 , 1),  /* 电压A                 */
            new FreezeInfo(2, 71 , 1),  /* 电压B                 */
            new FreezeInfo(2, 73 , 1),  /* 电压C                 */
            new FreezeInfo(3, 75 , 3, true),  /* A相电流               */
            new FreezeInfo(3, 78 , 3, true),  /* B相电流               */
            new FreezeInfo(3, 81 , 3, true),  /* C相电流               */
            new FreezeInfo(3, 84 , 4, true),  /* 瞬时总有功功率        */
            new FreezeInfo(3, 87 , 4, true),  /* 瞬时A相有功功率       */
            new FreezeInfo(3, 90 , 4, true),  /* 瞬时B相有功功率       */
            new FreezeInfo(3, 93 , 4, true),  /* 瞬时C相有功功率       */
            new FreezeInfo(3, 96 , 4, true),  /* 瞬时总无功功率        */
            new FreezeInfo(3, 99 , 4, true),  /* 瞬时A相无功功率       */
            new FreezeInfo(3, 102, 4, true),  /* 瞬时B相无功功率       */
            new FreezeInfo(3, 105, 4, true),  /* 瞬时C相无功功率       */
            new FreezeInfo(3, 108, 4, true),  /* 瞬时视在总功率        */
            new FreezeInfo(3, 111, 4, true),  /* 瞬时A相视在功率       */
            new FreezeInfo(3, 114, 4, true),  /* 瞬时B相视在功率       */
            new FreezeInfo(3, 117, 4, true),  /* 瞬时C相视在功率       */
            new FreezeInfo(2, 120, 3, true),  /* 总功率因数            */
            new FreezeInfo(2, 122, 3, true),  /* A相功率因数           */
            new FreezeInfo(2, 124, 3, true),  /* B相功率因数           */
            new FreezeInfo(2, 126, 3, true),  /* C相功率因数           */
            new FreezeInfo(2, 128, 2),  /* 频率                  */
        };

        public static readonly string[] tip = new string[]
        {
            "(当前)总正向有功电能"      ,
            "(当前)总反向有功电能"      ,
            "(当前)A相正向有功电能"     ,
            "(当前)A相反向有功电能 "    ,
            "(当前)B相正向有功电能"     ,
            "(当前)B相反向有功电能"     ,
            "(当前)C相正向有功电能"     ,
            "(当前)C相反向有功电能 "    ,
            "(当前)总正向无功电能 "     ,
            "(当前)总反向无功电能 "     ,
            "(当前)A相正向无功电能 "    ,
            "(当前)A相反向无功电能 "    ,
            "(当前)B相正向无功电能 "    ,
            "(当前)B相反向无功电能 "    ,
            "(当前)C相正向无功电能 "    ,
            "(当前)C相反向无功电能 "    ,
            "电压A "                    ,
            "电压B "                    ,
            "电压C "                    ,
            "A相电流 "                  ,
            "B相电流 "                  ,
            "C相电流 "                  ,
            "瞬时总有功功率"            ,
            "瞬时A相有功功率"           ,
            "瞬时B相有功功率"           ,
            "瞬时C相有功功率"           ,
            "瞬时总无功功率 "           ,
            "瞬时A相无功功率 "          ,
            "瞬时B相无功功率 "          ,
            "瞬时C相无功功率 "          ,
            "瞬时视在总功率 "           ,
            "瞬时A相视在功率 "          ,
            "瞬时B相视在功率 "          ,
            "瞬时C相视在功率 "          ,
            "总功率因数 "               ,
            "A相功率因数 "              ,
            "B相功率因数 "              ,
            "C相功率因数 "              ,
            "频率 "                     ,
        };
        public FreezeDataRead()
        {
        }

        public FreezeDataRead(Dlt645Client client)
        {
            this.client = client;
        }

        public FreezeDataRead(Dlt645Client client, IFreezeLog freezeLog, DateTime start, DateTime end)
        {
            this.freezeDataList = new List<FreezeData>();
            this.client = client;
            this.freezeLog = freezeLog;
            this.start = start;
            this.end = end;
        }

        public void ReadSingle()
        {
            DataId dataId = new DataId();
            MeterAddress address = MeterAddress.Wildcard;
            List<byte[]> bytes = new List<byte[]>();
            for (int i = 1; i <= 672; i++)
            {
                List<byte[]> rst = ReadOnce(i);
                FreezeData.Add(i, rst);
            }
        }
        
        public List<byte[]> ReadOnce(int cnt)
        {
            List<byte[]> bytes = new List<byte[]>();
            for (int i = 0; i < 33; i++)
            {
                DataId dataId = new DataId();
                dataId.Id = (uint)(0xA2100000 + cnt * 256 + i);
                byte[] data = client.Read(MeterAddress.Wildcard, dataId);
                bytes.Add(data);
            }
            for (int i = 0; i < 11; i++)
            {
                DataId dataId = new DataId();
                dataId.Id = (uint)(0xA2200000 + cnt * 256 + i);
                byte[] data = client.Read(MeterAddress.Wildcard, dataId);
                bytes.Add(data);
            }
            return bytes;
        }
        public byte[] ReadBlock(int cnt)
        {
            DataId dataId = new DataId();
            dataId.Id = (uint)(0xA2100000 + cnt * 256 + 0xFF);
            MemoryStream stream = null;
            
            byte[] data1 = client.Read(MeterAddress.Wildcard, dataId);
            dataId.Id = (uint)(0xA2200000 + cnt * 256 + 0xFF);
            byte[] data2 = client.Read(MeterAddress.Wildcard, dataId);
            if((data1.Length != 149) || (data2.Length != 69))
            {
                throw new InvalidOperationException("Lenth Invalid!");
            }
            stream = new MemoryStream(data1.Length + data2.Length);
            stream.Write(data1, 0, data1.Length);
            stream.Write(data2, 0, data2.Length);
            
            return stream.ToArray();
        }
        public byte[] ReadFreeData(DateTime dateTime, int no)
        {
            DataId dataId = new DataId();
            dataId.Id = (uint)(0xA2F00003);
            byte[] array = new byte[6];
            array[5] = (byte)Convert.ToInt32((dateTime.Year % 100).ToString(), 16);
            array[4] = (byte)Convert.ToInt32(dateTime.Month       .ToString(), 16);
            array[3] = (byte)Convert.ToInt32(dateTime.Day         .ToString(), 16);
            array[2] = (byte)Convert.ToInt32(dateTime.Hour        .ToString(), 16);
            array[1] = (byte)Convert.ToInt32(dateTime.Minute      .ToString(), 16);
            array[0] = (byte)no;
            return client.Read(MeterAddress.Wildcard, dataId, array);
        }

        public List<FreezeData> GetFreezeDatas(DateTime startDateTime, int days)
        {
            List<FreezeData> freezeDataList = new List<FreezeData>();
            for (int i = 0; i < (days * 24 * 60); i++)
            {
                
            }
            return freezeDataList;
        }

        public FreezeData PhaseChangFreezeDataConvert(byte[] bytes)
        {
            FreezeData rst = new FreezeData();
            rst.Time = new DateTime(((bytes[4] & 0xF0) >> 4) * 10 + (bytes[4] & 0x0F) + 2000, 
                                    ((bytes[3] & 0xF0) >> 4) * 10 + (bytes[3] & 0x0F), 
                                    ((bytes[2] & 0xF0) >> 4) * 10 + (bytes[2] & 0x0F), 
                                    ((bytes[1] & 0xF0) >> 4) * 10 + (bytes[1] & 0x0F), 
                                    ((bytes[0] & 0xF0) >> 4) * 10 + (bytes[0] & 0x0F), 0);
            Double[] dataArray = new Double[phaseChangeFreezeInfoArray.Length];
            for (int i = 0; i < phaseChangeFreezeInfoArray.Length; i++)
            {
                int smb = 1;
                if(phaseChangeFreezeInfoArray[i].HasSmb)
                {
                    if((bytes[phaseChangeFreezeInfoArray[i].Offset + phaseChangeFreezeInfoArray[i].Length - 1] & 0x80) == 0x80)
                    {
                        bytes[phaseChangeFreezeInfoArray[i].Offset + phaseChangeFreezeInfoArray[i].Length - 1] &= (0x7F);
                        smb = -1;
                    }
                }
                dataArray[i] = BytesConvertToDouble(bytes, phaseChangeFreezeInfoArray[i].Length, phaseChangeFreezeInfoArray[i].Offset, phaseChangeFreezeInfoArray[i].PointNum);
                dataArray[i] *= smb;
                rst.ValueDic.Add(tip[i], dataArray[i]);
            }
            rst.ValueArray = dataArray;
            return rst;
        }
         
        public int GetFreezeCnt()
        {
            int cnt = 0;
            DataId dataId = new DataId();
            dataId.Id = (uint)(0xA2F00000);
            byte[] data1 = client.Read(MeterAddress.Wildcard, dataId);
            for (int i = data1.Length - 1; i >= 0; i--)
            {
                cnt = cnt * 256 + data1[i];
            }
            return cnt;
        }

        public DateTime GetFreezeLastDateTime()
        {
            DateTime dateTime;
            DataId dataId = new DataId();
            dataId.Id = (uint)(0xA2F00001);
            byte[] data1 = client.Read(MeterAddress.Wildcard, dataId);
            dateTime = new DateTime(2000 + Convert.ToInt32(data1[4].ToString("X2")), 
                                    Convert.ToInt32(data1[3].ToString("X2")),  
                                    Convert.ToInt32(data1[2].ToString("X2")),
                                    Convert.ToInt32(data1[1].ToString("X2")),
                                    Convert.ToInt32(data1[0].ToString("X2")),
                                    0);
            return dateTime;
        }

        public FreezeData FreezeDataConvert(byte[] bytes)
        {
            FreezeData rst = new FreezeData();
            rst.Time = new DateTime(((bytes[4] & 0xF0) >> 4) * 10 + (bytes[4] & 0x0F) + 2000, 
                                    ((bytes[3] & 0xF0) >> 4) * 10 + (bytes[3] & 0x0F), 
                                    ((bytes[2] & 0xF0) >> 4) * 10 + (bytes[2] & 0x0F), 
                                    ((bytes[1] & 0xF0) >> 4) * 10 + (bytes[1] & 0x0F), 
                                    ((bytes[0] & 0xF0) >> 4) * 10 + (bytes[0] & 0x0F), 0);
            Double[] dataArray = new Double[55];
            
            
            for (int i = 0; i < freezeInfoArray.Length; i++)
            {
                dataArray[i] = BytesConvertToDouble(bytes, freezeInfoArray[i].Length, freezeInfoArray[i].Offset, freezeInfoArray[i].PointNum);
            }
        
            rst.ValueArray = dataArray;
            return rst;
        }
        public FreezeData FreezeDataConvert(List<byte[]> list)
        {
            FreezeData rst = new FreezeData();
            byte[] bytes = list.ToArray()[0]; 
            rst.Time = new DateTime(((bytes[4] & 0xF0) >> 4) * 10 + (bytes[4] & 0x0F) + 2000 , 
                                    ((bytes[3] & 0xF0) >> 4) * 10 + (bytes[3] & 0x0F), 
                                    ((bytes[2] & 0xF0) >> 4) * 10 + (bytes[2] & 0x0F), 
                                    ((bytes[1] & 0xF0) >> 4) * 10 + (bytes[1] & 0x0F), 
                                    ((bytes[0] & 0xF0) >> 4) * 10 + (bytes[0] & 0x0F), 0);
            Double[] dataArray = new Double[57];
            Double[] doubles;
            for (int i = 1; i < 33; i++)
            {
                bytes = list.ToArray()[i];
                if(bytes.Length == 3)
                {
                    dataArray[i] = BytesConvertToDouble(bytes, 3);
                }
                if(bytes.Length == 5)
                {
                    dataArray[i] = BytesConvertToDouble(bytes, 2);
                }
            }
            
            doubles = BytesConvertToDoubleArray(list.ToArray()[34], 2, 1);
            for (int i = 0; i < doubles.Length; i++)
            {
                dataArray[34 + i] = doubles[i];
            }
            doubles = BytesConvertToDoubleArray(list.ToArray()[35], 3, 3);
            for (int i = 0; i < doubles.Length; i++)
            {
                dataArray[37 + i] = doubles[i];
            }
            doubles = BytesConvertToDoubleArray(list.ToArray()[36], 3, 3);
            for (int i = 0; i < doubles.Length; i++)
            {
                dataArray[40 + i] = doubles[i];
            }
            doubles = BytesConvertToDoubleArray(list.ToArray()[37], 3, 3);
            for (int i = 0; i < doubles.Length; i++)
            {
                dataArray[44 + i] = doubles[i];
            }
            doubles = BytesConvertToDoubleArray(list.ToArray()[38], 3, 3);
            for (int i = 0; i < doubles.Length; i++)
            {
                dataArray[48 + i] = doubles[i];
            }
            dataArray[52] = BytesConvertToDouble(list.ToArray()[39], 3);
            dataArray[53] = BytesConvertToDouble(list.ToArray()[40], 2);
            dataArray[54] = BytesConvertToDouble(list.ToArray()[41], 4);
            dataArray[55] = BytesConvertToDouble(list.ToArray()[42], 1);
            dataArray[56] = BytesConvertToDouble(list.ToArray()[43], 3);
            rst.ValueArray = dataArray;
            return rst;
        }
        
        private Double[] BytesConvertToDoubleArray(byte[] bytes, int cnt, int pointNum)
        {
            Double[] doubles = new Double[bytes.Length / cnt];
            for (int i = 0; i < bytes.Length / cnt; i++)
            {
                for (int j = cnt - 1; j >= 0; j--)
                {
                    doubles[i] = doubles[i] * 100 + ((bytes[i * cnt + j] & 0xF0) >> 4) * 10 + (bytes[i * cnt + j] & 0x0F); //Convert.ToInt32(bytes[i * cnt + j].ToString(), 10);
                }
                for (int j = 0; j < pointNum; j++)
                {
                    doubles[i] /= 10;
                }
            }
            return doubles;
        }
        private Double BytesConvertToDouble(byte[] bytes, int pointNum)
        {
            Double result = 0;
            for (int i = bytes.Length - 1; i >= 0; i--)
            {
                result = result * 100 + ((bytes[i] & 0xF0) >> 4) * 10 + (bytes[i] & 0x0F); // Convert.ToInt32(bytes[i].ToString(), 10) * 100;
            }
            for (int j = 0; j < pointNum; j++)
            {
                result /= 10;
            }
            return result;
        }
        private double BytesConvertToDouble(byte[] bytes, int length, int offset, int pointNum)
        {
            Double result = 0;
            for (int i = length - 1; i >= 0; i--)
            {
                result = result * 100 + ((bytes[i + offset ] & 0xF0) >> 4) * 10 + (bytes[i + offset] & 0x0F); // Convert.ToInt32(bytes[i].ToString(), 10) * 100;
            }
            for (int j = 0; j < pointNum; j++)
            {
                result /= 10;
            }
            return result;
        }
        public void SaveFreezeData(string path, List<FreezeData> freezeDataList)
        {
            List<DataId> list = new List<DataId>();
            IWorkbook workbook = null;
            FileStream fileStream = null;
            Stream stream   = null;
            try
            {
                fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                if(Path.GetExtension(path).Equals(".xlsx"))
                {
                    workbook = new XSSFWorkbook(fileStream);
                }
                else
                {
                    workbook = new HSSFWorkbook(fileStream);
                }
                ISheet sheet = workbook.GetSheetAt(0);
                for (int i = 0; i < freezeDataList.Count; i++)
                {
                    IRow row = sheet.CreateRow(i + 1);
                    row.CreateCell(0).SetCellValue(i);
                    row.CreateCell(1).SetCellValue(freezeDataList.ToArray()[i].Time.ToString());
                    for (int j = 0; j < freezeDataList.ToArray()[i].ValueArray.Length; j++)
                    {
                        row.CreateCell(2 + j).SetCellValue(freezeDataList.ToArray()[i].ValueArray[j].ToString("F4"));
                    }
                }
                string s = System.IO.Directory.GetCurrentDirectory() + "\\冻结数据_" + DateTime.Now.Ticks.ToString() + ".xlsx";
                stream = new FileInfo(s).Create();
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
                if(fileStream != null)
                {
                    fileStream.Close();
                }
                if(stream != null)
                {
                    stream.Close();
                }
            }
        }
        public void SaveFreezeDataFormat1(List<FreezeData> freezeDataList)
        {
            List<DataId> list = new List<DataId>();
            IWorkbook workbook = null;
            FileStream fileStream = null;
            Stream stream   = null;
            try
            {
                // fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                workbook = new XSSFWorkbook();
                // if(Path.GetExtension(path).Equals(".xlsx"))
                // {
                    
                // }
                // else
                // {
                //     workbook = new HSSFWorkbook(fileStream);
                // }
                ISheet sheet = workbook.CreateSheet("冻结数据");
                IRow row = sheet.CreateRow(0);
                row.CreateCell(0).SetCellValue("次数");
                row.CreateCell(1).SetCellValue("时间");
                for (int i = 0; i < tip.Length; i++)
                {
                    row.CreateCell(i + 2).SetCellValue(tip[i]);
                }
                for (int i = 0; i < freezeDataList.Count; i++)
                {
                    row = sheet.CreateRow(i + 1);
                    row.CreateCell(0).SetCellValue(i);
                    row.CreateCell(1).SetCellValue(freezeDataList.ToArray()[i].Time.ToString());
                    for (int j = 0; j < freezeDataList.ToArray()[i].ValueDic.Count; j++)
                    {
                        double value;
                        ICell cell =  row.CreateCell(2 + j);
                        if(freezeDataList.ToArray()[i].ValueDic.TryGetValue(tip[j], out value))
                        {
                            cell.SetCellValue(value.ToString("F" + phaseChangeFreezeInfoArray[j].PointNum.ToString()));
                        }
                    }
                }
                string s = System.IO.Directory.GetCurrentDirectory() + "\\冻结数据_" + DateTime.Now.ToString("yy-MM-dd_HH_mm_ss") + ".xlsx";
                stream = new FileInfo(s).Create();
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
                if(fileStream != null)
                {
                    fileStream.Close();
                }
                if(stream != null)
                {
                    stream.Close();
                }
            }
        }

        private DateTime start;
        private DateTime end;
        public void ReadPhaseChangeFreezeData()
        {
            // FreezeDataRead freezeDataTest = new FreezeDataRead(this.client);
            freezeDataList = new List<FreezeData>();
            try
            {
                DateTime last = GetFreezeLastDateTime();
                FreezeReadMsg msg = null;
                if(start.Ticks > last.Ticks)
                {
                    msg = new FreezeReadMsg("主机最后冻结时间：" + last.ToString("yyyy-MM-dd") + ",晚于开始时间：" + start.ToString("yyyy-MM-dd"), 0);
                    // synchronizationContext.Post(ReadFreezeDataPhaseChangeProgramBar, msg);
                    freezeLog.SendMsg(msg);
                    return;
                }
                else
                {
                    msg = new FreezeReadMsg("冻结数据读取中。。。", 0);
                    freezeLog.SendMsg(msg);
                }
                
                int cnt = (int)((end.Ticks - start.Ticks) / (60 * 10000000)); 
                for (int i = 0; i <= cnt; i++)
                {
                    DateTime dateTimeTmp = start.AddMinutes(i);;
                    byte[] rst = null;
                    FreezeData data = null;
                    try
                    {
                        data = null;
                        rst = ReadFreeData(dateTimeTmp, 0x01);
                        if(rst != null)
                        {
                            data = PhaseChangFreezeDataConvert(rst);
                            freezeDataList.Add(data);
                        }
                        if(isEnd)
                        {
                            return;
                        }
                    }
                    catch (ClientException)
                    {
                        ;
                    }
                    finally
                    {
                        msg = new FreezeReadMsg("冻结数据读取中。。。", (int)(i * 100) / cnt, data);
                        freezeLog.SendMsg(msg);
                    }
                }
                freezeDataList.Sort();
                msg = new FreezeReadMsg("冻结数据读取完成", 100);
                // synchronizationContext.Post(ReadFreezeDataPhaseChangeProgramBar, msg);
                freezeLog.SendMsg(msg);
                SaveFreezeDataFormat1(freezeDataList);
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                // optLock = false;
                freezeLog.End();
            }
        }
        public void EndFreezeDataRead()
        {
            isEnd = true;
        }

    }
    
    public struct FreezeInfo
    {
        public int Offset;
        public int Length;
        public int PointNum;
        public bool HasSmb;
        public FreezeInfo(int length, int offset, int pointNum)
        {
            Offset = offset;
            Length = length;
            PointNum = pointNum;
            HasSmb = false;
        }

        public FreezeInfo(int offset, int length, int pointNum, bool hasSmb)  : this(offset, length, pointNum)
        {
            HasSmb = hasSmb;
        }
    }
}