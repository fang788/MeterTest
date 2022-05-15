using System.Collections.Generic;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.SQLite
{
    public class RwDataIdTable
    {
        public string Name;
        public uint Id;
        public int Ticks;
        public List<DataId> DataIdList;
        public override bool Equals(object obj)
        {
            return Name.Equals(((Project)obj).Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}