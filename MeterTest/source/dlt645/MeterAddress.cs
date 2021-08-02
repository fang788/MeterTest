using System;

namespace MeterTest.Source.Dlt645
{
    public class MeterAddress
    {
        public static readonly MeterAddress Broadcast = new MeterAddress(0x999999999999);
        public static readonly MeterAddress Wildcard = new MeterAddress(0xAAAAAAAAAAAA);
        internal long m_Address;
        internal string m_ToString;
        // internal byte[] m_Bytes = new byte[];

        internal const int MeterAddressBytes = 6;
        internal const long MaxValue = 0xFFFFFFFFFFFF;
        internal const byte AbbreviatedByte = 0xAA;
        
        public long address
        {
            get
            {
                return m_Address;
            }
            set
            {
                if(value > MaxValue)
                {
                    throw new ArgumentException("value over " + MaxValue.ToString());
                }
                else
                {
                    m_Address = value;
                    m_ToString = null;
                }
            }
        }

        
        public MeterAddress()
        {
        }

        public MeterAddress(long newAddress)
        {
            m_Address = newAddress;
        }

        public MeterAddress(byte[] address)
        {
            if(address == null)
            {
                throw new ArgumentNullException("address");
            }

            if(address.Length != MeterAddressBytes)
            {
                throw new ArgumentException(address.Length.ToString(), "address");
            }

            m_Address = 0;
            for (int i = 0; i < MeterAddressBytes; i++)
            {
                m_Address += (m_Address * 256 + address[i]);
            }
        }

        public override bool Equals(object obj)
        {
            MeterAddress comparand = obj as MeterAddress;
            return comparand.m_Address.Equals(this.m_Address);
        }

        public override int GetHashCode()
        {
            return m_Address.GetHashCode();
        }

        public override string ToString()
        {
            // string rst = null;
            if(m_ToString == null)
            {
                for (int i = 0; i < MeterAddressBytes; i++)
                {
                    m_ToString += ((byte)(m_Address & (0x0000000000FF << (i * 8)))).ToString("X2");
                    m_ToString += " ";
                }
            }            
            return m_ToString;
        }

        public byte[] GetAddressBytes() 
        {
            byte[] bytes = new byte[MeterAddressBytes];
            for (int i = 0; i < MeterAddressBytes; i++)
            {
                bytes[i] = (byte)(m_Address >> (i * 8));
            }
            return bytes;
        }

        /*
         * 是否为缩位地址
         */
        public bool IsAbbreviate()
        {
            return ((m_Address >> 40) == 0xAA);
        }

        private static MeterAddress InternalTryParse(string addressString, bool tryParse)
        {
            if(addressString == null)
            {
                if(tryParse)
                {
                    throw new ArgumentNullException("addressString");
                }
            }

            if(addressString.IndexOf(" ") != -1)
            {
                byte[]   bytes = new byte[MeterAddressBytes];
                string[] sArray = addressString.Split(' ');
                if(sArray.Length == MeterAddressBytes)
                {
                    for (int i = 0; i < MeterAddressBytes; i++)
                    {
                        bytes[i] = Convert.ToByte(sArray[i], 16);
                    }
                    return new MeterAddress(bytes);
                }
                else
                {
                    if(tryParse)
                    {
                        throw new FormatException("addressString");
                    }
                }
            }
            else
            {
                if(tryParse)
                {
                    throw new FormatException("addressString");
                }
            }
            return null;
        }

        public static bool TryParse(string addressString, out MeterAddress address)
        {
            address = InternalTryParse(addressString, false);
            return (address != null);
        }

        public static MeterAddress Parse(string addressString)
        {
            return InternalTryParse(addressString, true);
        }
    }
}