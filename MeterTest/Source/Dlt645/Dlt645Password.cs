using System;

namespace MeterTest.Source.Dlt645
{
    public class Dlt645Password
    {
        public const int PosswordBytes = 4;
        private byte authority;
        private int  password;
        public byte Authority
        {
            get { return authority; }
            set { authority = value; }
        }
        public int Password
        {
            get { return password; }
            set { password = value; }
        }
        public Dlt645Password()
        {
        }

        public Dlt645Password(byte authority, int password)
        {
            this.authority = authority;
            this.password = password;
        }
        public Dlt645Password(string password)
        {
            if(password.Length != (PosswordBytes  * 2))
            {
                throw new ArgumentException($"password{password} length error! ");
            }
            authority = Convert.ToByte(password.Substring(0, 2), 10);
            this.password = 0;
            for (int i = 0; i < PosswordBytes - 1; i++)
            {
                this.password = this.password * 256 + Convert.ToByte(password.Substring(2 + (i * 2), 2), 10);
            }
        }
        public byte[] GetPosswordBytes()
        {
            byte[] bytes = new byte[PosswordBytes];
            bytes[0] = authority;
            for (int i = 1; i < PosswordBytes; i++)
            {
                bytes[i] = (byte)(password >> (8 * (i - 1)));
            }
            return bytes;
        }
    }
}