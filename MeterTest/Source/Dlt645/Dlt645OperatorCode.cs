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
                this.operatorCode = this.operatorCode * 256 + Convert.ToByte(operatorCode.Substring((i * 2), 2), 16);
            }
        }
        public Dlt645OperatorCode(int code)
        {
            operatorCode = code;
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

        public override bool Equals(object obj)
        {
            return this.operatorCode.Equals(((Dlt645OperatorCode)obj).operatorCode);
        }

        public override int GetHashCode()
        {
            return this.operatorCode.GetHashCode();
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

        public override string ToString()
        {
            return operatorCode.ToString("X6");
        }
    }
}