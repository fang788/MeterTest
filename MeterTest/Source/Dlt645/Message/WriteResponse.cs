using MeterTest.Source.Dlt645;

namespace MeterTest.source.dlt645.Message
{
    public class WriteResponse : IDlt645Message
    {
        private readonly byte minimumFrameSize = 12;

        public WriteResponse()
        {
        }

        public byte MinimumFrameSize {get {return minimumFrameSize;}}
        public byte ControlCode { get; set; }
        public MeterAddress Address { get; set; }
        public byte DataFieldLen { get; set; }
        public byte[] DataField { get; set; }

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
        }
    }
}