using System;
using System.IO;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Dlt645.Message
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
            dataField = dataId.GetDataIdBytes();
        }
        public ReadRequest(MeterAddress address, byte controlCode, DataId dataId, byte[] dataArray)
        {
            Address      = address;
            ControlCode  = controlCode;
            dataFieldLen = (byte)(DataId.DataIdBytes + dataArray.Length);
            DataId       = dataId;
            MemoryStream stream = new MemoryStream(dataArray.Length + DataId.DataIdBytes);
            stream.Write(dataId.GetDataIdBytes(), 0, DataId.DataIdBytes);
            stream.Write(dataArray, 0, dataArray.Length);
            dataField = stream.ToArray();
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
            if((this.controlCode & 0x20) == 0)
            {
                this.dataId = new DataId(frame, 10);
            }
        }

        public void ValidateResponse(IDlt645Message response)
        {
            ReadResponse typedResponse = (ReadResponse)response;
            if(typedResponse.DataFieldLen < DataId.DataIdBytes)
            {
                throw new ClientException($"Message frame length must over {DataId.DataIdBytes}");
            }
            if(typedResponse.DataId.Id != this.DataId.Id)
            {
                throw new ClientException($"Message frame DataId {typedResponse.DataId} not Equals {DataId.DataIdBytes}");
            }
        }
    }
}