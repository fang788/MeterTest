using System;

namespace MeterTest.Source.Dlt645
{
    public class Dlt645OperatorCode
    {
        public const int OperatorCodeBytes = 4;
        private int operatorCode;

        public Dlt645OperatorCode()
        {
        }
        public Dlt645OperatorCode(string operatorCode)
        {
            if(operatorCode.Length != (OperatorCodeBytes  * 2))
            {
                throw new ArgumentException($"OperatorCodeBytes {OperatorCodeBytes} length error! ");
            }
            this.operatorCode = 0;
            for (int i = 0; i < OperatorCodeBytes; i++)
            {
                this.operatorCode = this.operatorCode * 256 + Convert.ToByte(operatorCode.Substring((i * 2), 2), 10);
            }
        }

        public int OperatorCode
        {
            get
            {
                return operatorCode;
            }
            set
            {
                operatorCode = value;
            }
        }
        public byte[] GetOperatorCodeBytes()
        {
            byte[] bytes = new byte[OperatorCodeBytes];
            for (int i = 0; i < OperatorCodeBytes; i++)
            {
                bytes[i] = (byte)(operatorCode >> (8 * i));
            }
            return bytes;
        }
    }
}