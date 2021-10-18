using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MeterTest.Source.Dlt645
{
    /*
     * 数据标识类
     */
    public class DataId : IComparable
    {
        public const int DataIdBytes = 4;
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
            get { return m_DataArray; }
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
                    if(this.Format.Contains('N'))
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
                    if(this.Format == "YYMMDDhhmm")
                    {
                        rst = GetDataBytesString(dataBytes, false).Insert(2, "-").Insert(5, "-").Insert(8, " ").Insert(11, ":");
                    }
                    if(this.Format == "YYMMDDWW")
                    {
                        rst = GetDataBytesString(dataBytes, false).Insert(2, "-").Insert(5, "-").Insert(8, " ");
                    }
                    if(this.Format == "hhmmss")
                    {
                        rst = GetDataBytesString(dataBytes, false).Insert(2, ":").Insert(5, ":");
                    }
                    if(this.Format == "ASC")
                    {
                        for (int i = 0; i < dataBytes.Length / 2; i++)
                        {
                            byte tmp = dataBytes[i];
                            dataBytes[i] = dataBytes[dataBytes.Length - 1 - i];
                            dataBytes[dataBytes.Length - 1 - i] = tmp;
                        }
                        rst = System.Text.Encoding.Default.GetString (dataBytes);
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
    }
}