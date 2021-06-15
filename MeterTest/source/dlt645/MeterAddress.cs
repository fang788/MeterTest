namespace MeterTest.source.dlt645
{
    public class MeterAddress
    {
        public const string BROADCAST_ADDRESS = "99 99 99 99 99 99";
        public const string WILDCARD_ADDRESS = "AA AA AA AA AA AA AA";

        public const int LENGTH = 6;
        public string stringAddress;

        public byte[] byteAddress = new byte[LENGTH];

        public MeterAddress()
        {
        }

        // public MeterAddress(byte[] byteAddress)
        // {
        //     this.stringAddress = null;
        //     foreach()
        //     this.byteAddress = byteAddress;
        // }
    }
}