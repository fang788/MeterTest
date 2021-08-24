using System;
using System.Collections.Generic;

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
            if (idBytes.Length > DataIdBytes)
            {
                throw new ArgumentException("idBytes over DataIdBytes!");
            }
            for (int i = 0; i < idBytes.Length; i++)
            {
                m_Id = m_Id << 8;
                m_Id += idBytes[i];
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
                // for (int i = 0; i < DataIdBytes; i++)
                // {
                //     m_ToString += ((byte)(m_Id & (0x0000000000FF << (i * 8)))).ToString("X2");
                //     m_ToString += " ";
                // }
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
    }
}