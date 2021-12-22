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
        public static uint Crc32(byte[] Buff, int length, uint crc32)
        {
            int i, j;

            for (i = 0; i < length; i++)
            {
                crc32 = crc32 ^ Buff[i];
                for (j = 8; j > 0; --j)
                {
                    crc32 = (uint)((crc32 >> 1) ^ (0xEDB88320 & (-(crc32 & 1))));
                }
                i++;
            }
            return crc32;
        }
    }
}