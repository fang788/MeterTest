using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MeterTest.Source.SQLite;

namespace MeterTest.Source.Dlt645
{
    /*
     * 数据标识类
     */
    public class DataId : IComparable
    {
        public const int DataIdBytes = 4;
        // public Project Project{get; set;}
        public static readonly List<uint> SymbolList = new List<uint>
        {
            0x02020100, //	A相电流
            0x02020200, //	B相电流
            0x02020300, //	C相电流
            0x02030000, //	瞬时总有功功率
            0x02030100, //	瞬时A相有功功率
            0x02030200, //	瞬时B相有功功率
            0x02030300, //	瞬时C相有功功率
            0x02040000, //	瞬时无功功率
            0x02040100, //	瞬时A相无功功率
            0x02040200, //	瞬时B相无功功率
            0x02040300, //	瞬时C相无功功率
            0x02050000, //	瞬时视在总功率
            0x02050100, //	瞬时A相视在功率
            0x02050200, //	瞬时B相视在功率
            0x02050300, //	瞬时C相视在功率
            0x02060000, //	总功率因数
            0x02060100, //	A相功率因数
            0x02060200, //	B相功率因数
            0x02060300, //	C相功率因数
            0x02800004, //  当前有功需量
            0x02800005, //  当前无功需量
            0x02800006, //  当前视在需量
            0x02800007, //  （表箱）表内温度
            0x02800003, //  一分钟有功总平均功率
            0xA3030000, //  瞬时总有功功率
            0xA3030100, //  瞬时A相有功功率
            0xA3030200, //  瞬时B相有功功率
            0xA3030300, //  瞬时C相有功功率
            0xA303FF00, //  瞬时有功功率数据块
            0xA3040000, //  瞬时无功功率
            0xA3040100, //  瞬时A相无功功率
            0xA3040200, //  瞬时B相无功功率
            0xA3040300, //  瞬时C相无功功率
            0xA304FF00, //  瞬时无功功率数据块
            0xA3050000, //  瞬时视在总功率
            0xA3050100, //  瞬时A相视在功率
            0xA3050200, //  瞬时B相视在功率
            0xA3050300, //  瞬时C相视在功率
            0xA305FF00, //  瞬时视在功率数据块
            0xA3800004, //  当前有功需量
            0xA3800005, //  当前无功需量
            0xA3800006, //  当前视在需量
            0xA3900001, //  A相正向有功需量
            0xA3900002, //  A相反向有功需量
            0xA3900003, //  B相正向有功需量
            0xA3900004, //  B相反向有功需量
            0xA3900005, //  C相正向有功需量
            0xA3900006, //  C相反向有功需量
            0xA3900007, //  正向有功需量
            0xA3900008, //  反向有功需量
        };
        private string m_Name;
        internal uint m_Id;
        internal string m_ToString;
        private string m_Format;
        private int m_DataBytes;
        private byte[] m_DataArray;
        private string m_Unit;
        private bool m_IsReadAble;
        private bool m_IsWritable;

        private string m_GroupName;

        public string Format
        {
            get { return m_Format; }
            set { m_Format = value; }
        }
        public int DataBytes /* 数据长度(字节) */
        {
            get { return m_DataBytes; }
            set { m_DataBytes = value; }
        }
        public byte[] DataArray /* 数据长度(字节) */
        {
            get 
            { 
                if((this.Format == "YYMMDDWW") 
                || (this.Format == "hhmmss")
                || (this.Format == "YYMMDDhhmm")
                || (this.Format == "YYMMDDhhmmss"))
                {
                    string tmp = null;
                    for (int i = 0; i < m_DataArray.Length; i++)
                    {
                        tmp = m_DataArray[i].ToString("X2");
                    }
                    if(tmp.Trim('A').Equals(""))
                    {
                        tmp = DateTime.Now.ToString(this.Format.Trim('W').Replace('Y', 'y').Replace('h', 'H').Replace('D', 'd'));
                        if(this.Format.Contains("WW"))
                        {
                            tmp += ((int)(DateTime.Now.DayOfWeek)).ToString("X2");
                        }
                        for (int i = 0; i < m_DataArray.Length; i++)
                        {
                            m_DataArray[i] = Convert.ToByte(tmp.Substring(i * 2, 2), 16);
                        }
                        Array.Reverse(m_DataArray);
                    }
                }
                return m_DataArray; 
            }
            set { m_DataArray = value; }
        }

        public string Unit   /* 单位 */
        {
            get { return m_Unit; }
            set { m_Unit = value; }
        }

        public bool IsReadable
        {
            get { return m_IsReadAble;}
            set { m_IsReadAble = value; }
        }
        public bool IsWritable
        {
            get { return m_IsWritable; }
            set { m_IsWritable = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public uint Id
        {
            get
            {
                return m_Id;
            }
            set
            {
                m_Id = value;
            }
        }

        public string GroupName
        {
            get { return m_GroupName; }
            set { m_GroupName = value; }
        }
        
        public DataId(string name, uint id, string format, int dataBytes, byte[] dataArray, string unit, bool isReadAble, bool isWritable)
        {
            Name = name;
            Id = id;
            m_ToString = null;
            Format = format;
            DataBytes = dataBytes;
            DataArray = dataArray;
            Unit = unit;
            IsReadable = isReadAble;
            IsWritable = isWritable;
        }
        public DataId(string name, uint id, int data)
        {
            Name = name;
            Id = id;
            DataBytes = 4;
            DataArray = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                DataArray[i] = (byte)(data >> (8 * i));
            }
        }
        public DataId(string name, uint id, uint data)
        {
            Name = name;
            Id = id;
            DataBytes = 4;
            DataArray = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                DataArray[i] = (byte)(data >> (8 * i));
            }
        }
        public DataId(uint id, int data)
        {
            Id = id;
            DataBytes = 4;
            DataArray = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                DataArray[i] = (byte)(data >> (8 * i));
            }
        }
        public DataId(uint id, uint data)
        {
            Id = id;
            DataBytes = 4;
            DataArray = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                DataArray[i] = (byte)(data >> (8 * i));
            }
        }

        public DataId(uint id, byte[] dataArray)
        {
            Id = id;
            DataBytes = dataArray.Length;
            DataArray = dataArray;
        }

        public DataId(uint id, short data)
        {
            Id = id;
            DataBytes = sizeof(short);
            DataArray = new byte[sizeof(short)];
            for (int i = 0; i < sizeof(short); i++)
            {
                DataArray[i] = (byte)(data >> (8 * i));
            }
        }

        public DataId()
        {

        }
        public DataId(uint id, string format, int dataBytes, string unit, bool isWritable, string name)
        {
            Id = id;
            Format = format;
            DataBytes = dataBytes;
            Unit = unit;
            IsWritable = isWritable;
            Name = name;
        }

        public DataId(uint id)
        {
            m_Id = id;
        }
        public DataId(byte[] idBytes)
        {
            if (idBytes.Length < DataIdBytes)
            {
                throw new ArgumentException("idBytes over DataIdBytes!");
            }
            for (int i = 0; i < DataIdBytes; i++)
            {
                m_Id = m_Id << 8;
                m_Id += idBytes[i];
            }
        }
        public DataId(byte[] idBytes, int offset)
        {
            if (idBytes.Length < (DataIdBytes + offset))
            {
                throw new ArgumentException("idBytes over DataIdBytes!");
            }
            m_Id = 0;
            for (int i = (DataIdBytes - 1); i >= 0; i--)
            {
                m_Id = m_Id << 8;
                m_Id += idBytes[i + offset];
            }
        }
        public DataId(uint id, string format)
        {
            m_Id = id;
            Format = format;
        }

        public DataId(byte[] idBytes, string format)
        {
            if (idBytes.Length > DataIdBytes)
            {
                throw new ArgumentException("idBytes over DataIdBytes!");
            }
            for (int i = 0; i < idBytes.Length; i++)
            {
                m_Id = m_Id << 8;
                m_Id += idBytes[i];
            }
            Format = format;
        }

        public byte[] GetDataIdBytes()
        {
            byte[] bytes = new byte[DataIdBytes];
            for (int i = 0; i < DataIdBytes; i++)
            {
                bytes[i] = (byte)(m_Id >> (i * 8));
            }
            return bytes;
        }

        public override bool Equals(object obj)
        {
            return m_Id.Equals(((DataId)obj).Id);
        }

        public override int GetHashCode()
        {
            return m_Id.GetHashCode();
        }

        public override string ToString()
        {
            if (m_ToString == null)
            {
                m_ToString += m_Id.ToString("X8");
                m_ToString += " ";
                m_ToString += this.Format;
                m_ToString += " ";
                m_ToString += this.DataBytes.ToString();
                m_ToString += " ";
                m_ToString += this.Unit;
                m_ToString += " ";
                m_ToString += this.Name;
            }
            return m_ToString;
        }

        public int CompareTo(object obj)
        {
            return this.m_Id.CompareTo((((DataId)(obj)).m_Id));
        }
        private string GetDataBytesString(byte[] data, bool sort)
        {
            string s = null;
            if(sort)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    s += data[i].ToString("X2");
                }
            }
            else
            {
                for (int i = data.Length - 1; i >= 0; i--)
                {
                    s += data[i].ToString("X2");
                }
            }
            return s;
        }
        public String GetDataString(byte[] dataBytes)
        {
            String rst = null;
            // string dataStr = null;

            // for (int i = 0; i < dataBytes.Length; i++)
            // {
            //     dataStr += dataBytes[i].ToString("X2");
            // }
            try 
            {
                if(string.IsNullOrEmpty(this.Format) == false) 
                {
                    if(this.Format.Contains('X'))
                    {
                        if(string.IsNullOrEmpty(this.Format.TrimEnd('X')))
                        {
                            rst = GetDataBytesString(dataBytes, false);
                        }
                        else if(this.Format.Trim('X') == ".")
                        {
                            int offset = this.Format.IndexOf('.');
                            long lOffset = 10;
                            for (int i = 1; i < this.Format.Length - offset - 1; i++)
                            {
                                    lOffset *= 10;
                            }
                            uint  data = 0;
                            double syb = 1;
                            if(DataId.SymbolList.Contains(this.Id))
                            {
                                if((dataBytes[dataBytes.Length - 1] & 0x80) != 0)
                                {
                                    dataBytes[dataBytes.Length - 1] = (Byte)(dataBytes[dataBytes.Length - 1] & 0x7F);
                                    syb = -1;
                                }
                            }
                            for (int i = dataBytes.Length - 1; i >= 0; i--)
                            {
                                data = data * 100 + Convert.ToUInt32(dataBytes[i].ToString("X2"), 10);
                            }
                            double dData = syb * data / lOffset;
                            rst = dData.ToString("F" + (this.Format.Length - offset - 1));
                        }
                        else if(this.Format == "HEX")
                        {
                            uint  data = 0;
                            for (int i = dataBytes.Length - 1; i >= 0; i--)
                            {
                                data = data * 256 + Convert.ToUInt32(dataBytes[i].ToString("X2"), 16);
                            }
                            rst = data.ToString();
                        }
                        else if(this.Format == "XXX.XXX\nYYMMDDhhmm")
                        {
                            double uintData = 0;
                            uintData = (double)((uint) Convert.ToUInt32(dataBytes[0].ToString("X2"), 10) * 100 * 100 
                            +  Convert.ToUInt32(dataBytes[1].ToString("X2"), 10) * 100 +  Convert.ToUInt32(dataBytes[2].ToString("X2"), 10));
                            rst = (uintData/1000).ToString("F3") + "  ";
                            rst += dataBytes[3].ToString("X2") + "-";
                            rst += dataBytes[4].ToString("X2") + "-";
                            rst += dataBytes[5].ToString("X2") + " ";
                            rst += dataBytes[6].ToString("X2") + ":";
                            rst += dataBytes[7].ToString("X2");
                        }
                        else
                        {
                            rst = GetDataBytesString(dataBytes, false);;
                        }
                    }
                    else if(this.Format == "EVENT_RCD")
                    {
                        rst =  "事件标识码:0x" + dataBytes[0].ToString("X2") + "\n\r";
                        rst += "事件标志:  0x" + dataBytes[1].ToString("X2") + "\n\r";
                        rst += "事件计数器:" + ((((((dataBytes[2] * 256) + dataBytes[3]) * 256) + dataBytes[4]) * 256) + dataBytes[5]).ToString() + "\n\r";
                        rst += "开始时间：" + dataBytes[6].ToString("X2") + "-" + dataBytes[7].ToString("X2") + "-" + dataBytes[8].ToString("X2") + " ";
                        rst += dataBytes[9].ToString("X2") + ":" + dataBytes[10].ToString("X2") + ":" + dataBytes[11].ToString("X2") + "\n\r";
                        rst += "结束时间：" + dataBytes[12].ToString("X2") + "-" + dataBytes[13].ToString("X2") + "-" + dataBytes[14].ToString("X2") + " ";
                        rst += dataBytes[15].ToString("X2") + ":" + dataBytes[16].ToString("X2") + ":" + dataBytes[17].ToString("X2") + "\n\r";
                        
                        MeterTestConfig meterTestConfig = MeterTestDbContext.GetMeterTestConfig();
                        for (int i = 0; i < dataBytes[18]; i++)
                        {
                            int offset = 0;
                            uint dataId = (uint)((((((dataBytes[19 + offset] * 256) + dataBytes[20 + offset]) * 256) + dataBytes[21 + offset]) * 256) + dataBytes[22 + offset]);
                            DataId dataIdTmp = MeterTestDbContext.GetDataId(meterTestConfig.SelectReadProjectName, meterTestConfig.SelectReadTableName, false, dataId);
                            dataIdTmp.DataArray = new byte[dataIdTmp.DataBytes];
                            for (int j = 0; j < dataIdTmp.DataBytes; j++)
                            {
                                dataIdTmp.DataArray[j] = dataBytes[23 + offset + j];
                            }
                            rst += dataIdTmp.Name + "-" + dataIdTmp.Id.ToString("X8") + ": " + dataIdTmp.GetDataString(dataIdTmp.DataArray);
                            if(i < (dataBytes[18] - 1))
                            {
                                rst += "\n\r";
                            }
                            offset += 4 + dataIdTmp.DataBytes;
                        }
                    }
                    else if(this.Format == "EVENT_STATUS_CNT")
                    {
                        rst = "主动上报状态字：0x" + ((((((dataBytes[0] * 256) + dataBytes[1]) * 256) + dataBytes[2]) * 256) + dataBytes[3]).ToString("X8") + "\n\r";
                        for (int i = 0; i < dataBytes.Length - 4; i++)
                        {
                            rst += "事件" + (i + 1).ToString() + "新增次数:" + dataBytes[4 + i].ToString();
                            if(i < dataBytes.Length - 5)
                            {
                                rst += "\n\r";
                            }
                        }
                    }
                    else if(this.Format.Contains('N'))
                    {
                        if(string.IsNullOrEmpty(this.Format.TrimEnd('N')))
                        {
                            rst = GetDataBytesString(dataBytes, false);
                        }
                        else if(this.Format.Trim('N') == ".")
                        {
                            int offset = this.Format.IndexOf('.');
                            long lOffset = 10;
                            for (int i = 1; i < this.Format.Length - offset - 1; i++)
                            {
                                    lOffset *= 10;
                            }
                            uint  data = 0;
                            double syb = 1;
                            if(DataId.SymbolList.Contains(this.Id))
                            {
                                if((dataBytes[dataBytes.Length - 1] & 0x80) != 0)
                                {
                                    dataBytes[dataBytes.Length - 1] = (Byte)(dataBytes[dataBytes.Length - 1] & 0x7F);
                                    syb = -1;
                                }
                            }
                            for (int i = dataBytes.Length - 1; i >= 0; i--)
                            {
                                data = data * 100 + Convert.ToUInt32(dataBytes[i].ToString("X2"), 10);
                            }
                            double dData = syb * data / lOffset;
                            rst = dData.ToString("F" + (this.Format.Length - offset - 1));
                        }
                        else
                        {
                            rst = GetDataBytesString(dataBytes, false);;
                        }
                    }
                    else if(this.Format == "YYMMDDhhmm")
                    {
                        rst = GetDataBytesString(dataBytes, false).Insert(2, "-").Insert(5, "-").Insert(8, " ").Insert(11, ":");
                    }
                    else if(this.Format == "YYMMDDWW")
                    {
                        rst = GetDataBytesString(dataBytes, false).Insert(2, "-").Insert(5, "-").Insert(8, " ");
                    }
                    else if(this.Format == "hhmmss")
                    {
                        rst = GetDataBytesString(dataBytes, false).Insert(2, ":").Insert(5, ":");
                    }
                    else if(this.Format == "ASC")
                    {
                        for (int i = 0; i < dataBytes.Length / 2; i++)
                        {
                            byte tmp = dataBytes[i];
                            dataBytes[i] = dataBytes[dataBytes.Length - 1 - i];
                            dataBytes[dataBytes.Length - 1 - i] = tmp;
                        }
                        rst = System.Text.Encoding.Default.GetString (dataBytes);
                    }
                    else if(this.Format == "YYMMDDhhmmss")
                    {
                        rst = GetDataBytesString(dataBytes, false).Insert(2, "-").Insert(5, "-").Insert(8, " ").Insert(11, ":").Insert(14, ":");
                    }
                    else if(this.Format == "float")
                    {
                        // rst = ((float)(dataBytes[0] | (dataBytes[1] << 8) | (dataBytes[2] << 16) | (dataBytes[3] << 24))).ToString("F4");
                        rst = System.BitConverter.ToSingle(dataBytes, 0).ToString("F4");
                    }
                }
                else
                {
                    rst = GetDataBytesString(dataBytes, false);
                }
                if(this.Unit != null)
                {
                    rst += (" " + this.Unit);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                rst = "格式异常";
            }
            return rst;
        }
    
        public byte[] GetByteArray(string s)
        {
            byte[] byteArray = null;
            try 
            {
                if(string.IsNullOrEmpty(this.Format) == false) 
                {
                    if((this.Format.Contains('X')) 
                    || (this.Format.Contains('N')))
                    {
                        byteArray = new byte[(s.Length + 1) / 2];
                        for (int i = 0; i < (s.Length + 1) / 2; i++)
                        {
                            byteArray[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);
                        }
                    }
                    
                    if((this.Format == "YYMMDDWW") 
                    || (this.Format == "hhmmss")
                    || (this.Format == "YYMMDDhhmm")
                    || (this.Format == "YYMMDDhhmmss"))
                    {
                        byteArray = new byte[(s.Length + 1) / 2];
                        for (int i = 0; i < (s.Length + 1) / 2; i++)
                        {
                            byteArray[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);
                        }
                    }
                    if(this.Format == "ASC")
                    {
                        byteArray = new byte[DataBytes];
                        byte[] tmp = System.Text.Encoding.Default.GetBytes(s);
                        if(tmp.Length > DataBytes)
                        {
                            throw new Exception(Name + Id.ToString("X8") + "-数据长度不正确");
                        }
                        else
                        {
                            for (int i = 0; i < tmp.Length; i++)
                            {
                                byteArray[i] = tmp[i];
                            }
                        }
                    }
                    if(this.Format == "float")
                    {
                        byteArray = BitConverter.GetBytes(Convert.ToSingle(s));
                        Array.Reverse(byteArray);
                    }
                }
                else
                {
                    throw new Exception("格式不能为空");
                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            if(byteArray != null)
            {
                Array.Reverse(byteArray);
            }            
            return byteArray;
        }
        public bool DataCompare(byte[] dataArray)
        {
            bool rst = false;
            int i = 0;
            
            if((dataArray == null) || (dataArray == null) || (DataArray == null) || (dataArray.Length != DataArray.Length))
            {
                return false;
            }
            if(Id == 0x04000102)
            {
                for (i = 0; i < DataArray.Length; i++)
                {
                    if(DataArray[i] != 0xAA)
                    {
                        break;
                    }
                }
                if(i >= DataArray.Length)
                {
                    int hour, minute, second;
                    
                    byte tmp = dataArray[2];
                    hour = (int)((((((tmp) & 0xF0) >> 4) * 10) + ((tmp) & 0x0F)));

                    tmp = dataArray[1];
                    minute = (int)((((((tmp) & 0xF0) >> 4) * 10) + ((tmp) & 0x0F)));

                    tmp = dataArray[0];
                    second = (int)((((((tmp) & 0xF0) >> 4) * 10) + ((tmp) & 0x0F)));

                    DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, second);
                    long de = Math.Abs(DateTime.Now.Ticks - dateTime.Ticks);
                    if(de < 5 * TimeSpan.TicksPerSecond)
                    {
                        return true;
                    }
                }
            }
            if(Id == 0x04000101)
            {
                for (i = 0; i < DataArray.Length; i++)
                {
                    if(DataArray[i] != 0xAA)
                    {
                        break;
                    }
                }
                if(i >= DataArray.Length)
                {
                    int year, month, day, dayOfWeek;
                    
                    byte tmp = dataArray[3];
                    year = (int)((((((tmp) & 0xF0) >> 4) * 10) + ((tmp) & 0x0F)) + 2000);

                    tmp = dataArray[2];
                    month = (int)((((((tmp) & 0xF0) >> 4) * 10) + ((tmp) & 0x0F)));

                    tmp = dataArray[1];
                    day = (int)((((((tmp) & 0xF0) >> 4) * 10) + ((tmp) & 0x0F)));

                    tmp = dataArray[0];
                    dayOfWeek = (int)((((((tmp) & 0xF0) >> 4) * 10) + ((tmp) & 0x0F)));

                    if((year == DateTime.Now.Year) 
                    && (month == DateTime.Now.Month)
                    && (day == DateTime.Now.Day)
                    && (dayOfWeek == (int)DateTime.Now.DayOfWeek))
                    {
                        return true;
                    }
                }
            }

            for (i = 0; i < DataArray.Length; i++)
            {
                if(DataArray[i] != dataArray[i])
                {
                    break;
                }
            }
            rst = (i >= DataArray.Length);
            return rst;
        }
    }
}