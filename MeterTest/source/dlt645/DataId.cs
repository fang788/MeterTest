using System;

namespace MeterTest.Source.Dlt645
{
    /*
     * 数据标识类
     */
    public class DataId : IComparable
    {
        public const int DataIdBytes = 4;
        private string m_Name;
        internal int m_Id;
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

        public int Id
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
        
        public DataId(string name, int id, string format, int dataBytes, byte[] dataArray, string unit, bool isReadAble, bool isWritable)
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
        public DataId(int id, string format, int dataBytes, string unit, bool isWritable, string name)
        {
            Id = id;
            Format = format;
            DataBytes = dataBytes;
            Unit = unit;
            IsWritable = isWritable;
            Name = name;
        }

        public DataId(int id)
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
        public DataId(int id, string format)
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