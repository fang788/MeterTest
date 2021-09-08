using System;
using MeterTest.Source.Dlt645;

namespace MeterTest.source.dlt645.Message
{
    public class ReadRequest : IDlt645Request
    {
        private MeterAddress address;
        private byte controlCode;
        private byte dataFieldLen;
        private byte[] dataField;
        private const byte minimumFrameSize = 12;
        private DataId dataId;

        public ReadRequest()
        {
        }

        public ReadRequest(MeterAddress address, byte controlCode, byte dataFieldLen, DataId dataId)
        {
            Address      = address;
            ControlCode  = controlCode;
            DataFieldLen = dataFieldLen;
            DataId       = dataId;
        }

        public MeterAddress Address 
        { 
            get
            {
                return address;
            } 
            set
            {
                address = value;
            }
        }
        public byte ControlCode 
        { 
            get 
            {
                return controlCode;
            } 
            set
            {
                controlCode = value;
            } 
        }
        public byte DataFieldLen 
        { 
            get
            {
                return dataFieldLen;
            } 
            set
            {
                dataFieldLen = value;
            }
        }
        public byte[] DataField 
        { 
            get
            {
                return dataField;
            } 
            set
            {
                dataField = value;
            }
        }

        public byte MinimumFrameSize
        {
            get
            {
                return minimumFrameSize;
            }
        }

        public DataId DataId
        {
            get
            {
                return dataId;
            }
            set
            {
                dataId = value;
            }
        }

        public void Initialize(byte[] frame)
        {
            if (frame.Length < MinimumFrameSize)
            {
                string msg = $"Message frame must contain at least {MinimumFrameSize} bytes of data.";
                throw new FormatException(msg);
            }
            this.address = new MeterAddress(frame, 1);
            this.controlCode = frame[8];
            this.DataFieldLen = frame[9];
            if(this.DataFieldLen != 0)
            {
                this.dataField = new byte[this.DataFieldLen];
                for (int i = 0; i < this.DataFieldLen; i++)
                {
                    this.dataField[i] = frame[10 + i];
                }
            }
            this.dataId = new DataId(frame, 10);
        }

        public void ValidateResponse(IDlt645Message response)
        {
            ReadResponse typedResponse = (ReadResponse)response;
            if(typedResponse.DataFieldLen < DataId.DataIdBytes)
            {
                throw new ClientException($"Message frame length must over {DataId.DataIdBytes}");
            }
            if(typedResponse.DataId != this.DataId)
            {
                throw new ClientException($"Message frame DataId {typedResponse.DataId} not Equals {DataId.DataIdBytes}");
            }
        }
    }
}