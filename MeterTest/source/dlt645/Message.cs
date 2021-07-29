namespace MeterTest.source.dlt645
{
    public class Message
    {
        // private const byte startCharacter = 0x68;
        // private const byte endCharacter = 0x16;
        // private byte checksum; /* 校验和 */
        private string m_String;
        private byte m_ControlCode;
        private MeterAddress m_Address;
        private byte[] m_DataField;
        public byte ControlCode 
        { 
            get
            {
                return m_ControlCode;
            }
            set
            {
                m_ControlCode = value;
                m_String = null;
            }
        }
        public MeterAddress Address
        { 
            get
            {
                return m_Address;
            }
            set
            {
                m_Address = value;
                m_String = null;
            }
        }
        // public DataId Id { get; }
        // public byte DataLen;
        public byte[] DataField
        {
            get
            {
                return m_DataField;
            }
            set
            {
                m_DataField = value;
                m_String = null;
            }
        }

        private Message()
        {
        }
        
        public Message(MeterAddress address, byte controlCode)
        {
            m_ControlCode = controlCode;
            m_Address = address;
        }

        public Message(MeterAddress address, byte controlCode, byte[] dataField)
        {
            m_Address = address;
            m_ControlCode = controlCode;
            m_DataField = dataField;
        }

        public byte[] MessageFrame
        {
            get
            {
                byte[] frame = new byte[14 + m_DataField.Length];
                frame[0] = 0xFE;
                frame[1] = 0xFE;
                frame[2] = 0xFE;
                frame[3] = 0x68;
                byte[] addressBytes = this.m_Address.GetAddressBytes();
                for (int i = 0; i < addressBytes.Length; i++)
                {
                    frame[4 + i] = addressBytes[i];
                }
                frame[10] = 0x68;
                frame[11] = this.m_ControlCode;
                frame[12] = (byte)this.m_DataField.Length;
                for (int i = 0; i < this.m_DataField.Length; i++)
                {
                    frame[13 + i] = this.m_DataField[i];
                }
                frame[13 + this.m_DataField.Length] = CalCheckSum(frame, 3);
                frame[14 + this.m_DataField.Length] = 0x16;
                return frame;
            }
        }
        private byte CalCheckSum(byte[] buff, int offset)
        {
            byte checksum = 0;
            for (int i = offset; i < buff.Length; i++)
            {
                checksum += buff[i];
            }
            return checksum;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            if(m_String == null)
            {
                foreach (var item in MessageFrame)
                {
                    m_String += item.ToString("X8");
                    m_String += " ";
                }
            }
            return m_String;
        }
    }
}