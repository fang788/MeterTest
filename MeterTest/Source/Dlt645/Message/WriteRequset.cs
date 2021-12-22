using MeterTest.Source.Dlt645;
using System;

namespace MeterTest.Source.Dlt645.Message
{
    public class WriteRequest : IDlt645Message
    {
        private readonly byte minimumFrameSize = 12;

        public WriteRequest()
        {
        }

        public WriteRequest(MeterAddress address, byte controlCode, DataId dataId, Dlt645Password password, Dlt645OperatorCode operatorCode)
        {
            if((Dlt645Password.PosswordBytes + Dlt645OperatorCode.OperatorCodeBytes + DataId.DataIdBytes + dataId.DataBytes) > 253)
            {
                throw new Exception("dataFieldLen error");
            }
            ControlCode = controlCode;
            Address = address;
            DataFieldLen = (byte)(Dlt645Password.PosswordBytes + Dlt645OperatorCode.OperatorCodeBytes + DataId.DataIdBytes + dataId.DataBytes);
            Password = password;
            OperatorCode = operatorCode;
            DataId = dataId;
            DataField = new byte[DataFieldLen];
            DataFieldLen = 0;
            for (int i = 0; i < dataId.GetDataIdBytes().Length; i++)
            {
                DataField[DataFieldLen + i] = dataId.GetDataIdBytes()[i];
            }
            DataFieldLen = (byte)dataId.GetDataIdBytes().Length;
            for (int i = 0; i < Dlt645Password.PosswordBytes; i++)
            {
                DataField[DataFieldLen + i] = password.GetPosswordBytes()[i];
            }
            DataFieldLen += Dlt645Password.PosswordBytes;
            for (int i = 0; i < Dlt645OperatorCode.OperatorCodeBytes; i++)
            {
                DataField[DataFieldLen + i] = operatorCode.GetOperatorCodeBytes()[i];
            }
            DataFieldLen += Dlt645OperatorCode.OperatorCodeBytes;
            for (int i = 0; i < dataId.DataArray.Length; i++)
            {
                DataField[DataFieldLen + i] = dataId.DataArray[i];
            }
            DataFieldLen += (byte)dataId.DataArray.Length;
        }

        public byte MinimumFrameSize {get {return minimumFrameSize;}}
        public byte ControlCode { get; set; }
        public MeterAddress Address { get; set; }
        public byte DataFieldLen { get; set; }
        public byte[] DataField { get; set; }
        public Dlt645Password Password { get; set; }
        public Dlt645OperatorCode OperatorCode { get; set; }
        public DataId DataId { get; set; }

        public void Initialize(byte[] frame)
        {
            this.Address = new MeterAddress(frame, 1);
            this.ControlCode = frame[8];
            this.DataFieldLen = frame[9];
            if(this.DataFieldLen != 0)
            {
                this.DataField = new byte[this.DataFieldLen];
                for (int i = 0; i < this.DataFieldLen; i++)
                {
                    this.DataField[i] = frame[10 + i];
                }
            }
            this.DataId = new DataId(frame, 10);
        }

        public void ValidateResponse(IDlt645Message response)
        {
            throw new System.NotImplementedException();
        }
    }
}