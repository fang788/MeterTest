using System;

namespace MeterTest.Source.Dlt645
{
    /*
     * 数据标识类
     */
    public class DataId
    {
        public const int DataIdBytes = 4;
        internal int m_Id;
        internal string m_ToString;
        public string Format;
        public int DataBytes; /* 数据长度(字节) */

        public string Unit;   /* 单位 */

        public bool IsWritable; /* false:只读、true: 可读可写 */

        public string Name;    /* 数据相名称 */

        public int Id
        {
            get
            {
                return m_Id;
            }
            set
            {
                m_Id       = value;
                m_ToString = null;
                Format   = null;
            }
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
            if(idBytes.Length > DataIdBytes)
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
            if(idBytes.Length > DataIdBytes)
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
            // obj as DataId;
            return m_Id.Equals(((DataId)obj).Id);
        }

        public override int GetHashCode()
        {
            return m_Id.GetHashCode();
        }

        public override string ToString()
        {
            if(m_ToString == null)
            {
                for (int i = 0; i < DataIdBytes; i++)
                {
                    m_ToString += ((byte)(m_Id & (0x0000000000FF << (i * 8)))).ToString("X2");
                    m_ToString += " ";
                }
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
    }
}