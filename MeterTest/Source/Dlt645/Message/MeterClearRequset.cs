using System.IO;

namespace MeterTest.Source.Dlt645.Message
{
    public class MeterClearRequset : IDlt645Request
    {
        private byte minimumFrameSize = 12;

        public MeterClearRequset(MeterAddress address, Dlt645Password password, Dlt645OperatorCode operatorCode)
        {
            ControlCode = 0x1A;
            Address = address;
            Password = password;
            OperatorCode = operatorCode;
            MemoryStream memory = new MemoryStream();
            memory.Write(password.GetPosswordBytes(), 0, Dlt645Password.PosswordBytes);
            memory.Write(OperatorCode.GetOperatorCodeBytes(), 0, Dlt645OperatorCode.OperatorCodeBytes);
            DataField = memory.ToArray();
            DataFieldLen = Dlt645Password.PosswordBytes + Dlt645OperatorCode.OperatorCodeBytes;
        }

        public byte MinimumFrameSize {get {return minimumFrameSize;}}

        public byte ControlCode { get; set; }
        public MeterAddress Address { get; set; }
        public byte DataFieldLen { get; set; }
        public byte[] DataField { get; set; }
        public Dlt645Password Password { get; set; }
        public Dlt645OperatorCode OperatorCode { get; set; }

        public void Initialize(byte[] frame)
        {
            throw new System.NotImplementedException();
        }

        public void ValidateResponse(IDlt645Message response)
        {
            // throw new System.NotImplementedException();
        }
    }
}