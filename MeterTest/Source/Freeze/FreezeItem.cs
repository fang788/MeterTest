namespace MeterTest.Source.Freeze
{
    public class FreezeItem
    {
        public int No; /* 排列顺序 */
        public string Name;
        public double Value;
        public int Offset;
        public int Length;
        public byte[] DataArray;
        public int Point;
        public string Format;
        public string Unit;
        public uint   Id;
        public bool   HasSmy;

        public FreezeItem()
        {

        }
        public FreezeItem(int offset, int length, int point, string format, string unit, string name)
        {
            Name = name;
            Offset = offset;
            Length = length;
            Format = format;
            Unit = unit;
            Point = point;
        }
        // public FreezeItem(int offset, int length, int point, string format, string unit, string name, bool hasSmb)
        // {
        //     Name = name;
        //     Offset = offset;
        //     Length = length;
        //     Format = format;
        //     Unit = unit;
        //     Point = point;
        //     this.HasSmy = hasSmb;
        // }
        public FreezeItem(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}