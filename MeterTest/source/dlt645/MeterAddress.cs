using System;

namespace MeterTest.source.dlt645
{
    public class MeterAddress
    {
        public static readonly MeterAddress Broadcast = new MeterAddress(0x999999999999);
        public static readonly MeterAddress Wildcard = new MeterAddress(0xAAAAAAAAAAAA);
        internal long m_Address;
        internal string m_ToString;

        internal const int MeterAddressBytes = 6;
        internal const long MaxValue = 0xFFFFFFFFFFFF;

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
                throw new ArgumentException(address.Length.ToString(), "address")
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

        /*
         * 是否为通配地址
         */
        public bool IsWildcast()
        {
            return ((m_Address >> 40) == 0xAA);
        }

        // public MeterAddress(byte[] byteAddress)
        // {
        //     this.stringAddress = null;
        //     foreach()
        //     this.byteAddress = byteAddress;
        // }
    }
}