using System;

namespace MeterTest.Source.Dlt645.Message
{
    public class MeterClearResponse : IDlt645Message
    {
        public byte MinimumFrameSize {get {return 8;}}
        public byte ControlCode { get; set; }
        public MeterAddress Address { get; set; }
        public byte DataFieldLen { get; set; }
        public byte[] DataField { get; set; }
        public void Initialize(byte[] frame)
        {
            if (frame.Length < MinimumFrameSize)
            {
                string msg = $"Message frame must contain at least {MinimumFrameSize} bytes of data.";
                throw new FormatException(msg);
            }
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