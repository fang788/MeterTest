namespace MeterTest.Source.Dlt645
{
    public static class PublicClass
    {
        public static byte ByteHex2Bcd(byte value)
        {
            return (byte)((((byte)(value / 10)) << 4) | (((byte)(value % 10))));
        }

        public static byte ByteBcd2Hex(byte value)
        {
            return (byte)(((((value) & 0xF0) >> 4) * 10) + ((value) & 0x0F));
        }
    }
}