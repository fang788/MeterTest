using System;

namespace MeterTest.source.dlt645
{
    /*
     * 数据标识类
     */
    public class DataId
    {
        public const int DataIdBytes = 4;
        internal int m_Id;
        internal string m_ToString;
        internal string m_Format;
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
                m_Format   = null;
            }
        }

        public DataId()
        {

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
            m_Format = format;
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
            m_Format = format;
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
            return m_Id.Equals((DataId)obj.Id);
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
            }            
            return m_ToString;
        }
    }
}