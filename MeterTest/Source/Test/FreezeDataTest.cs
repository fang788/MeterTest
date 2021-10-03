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
    public class FreezeDataTest
    {
        public const int MAX_FREEZE_CNT = 672;
        private List<FreezeData> freezeDataList = new List<FreezeData>();
        public Dictionary<int, List<byte[]>> FreezeData = new Dictionary<int, List<byte[]>>();
        private Dlt645Client client;
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
        public FreezeDataTest()
        {
        }

        public FreezeDataTest(Dlt645Client client)
        {
            this.client = client;
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
    }
    
    public struct FreezeInfo
    {
        public int Offset;
        public int Length;
        public int PointNum;
        public FreezeInfo(int length, int offset, int pointNum)
        {
            Offset = offset;
            Length = length;
            PointNum = pointNum;
        }
    }
}