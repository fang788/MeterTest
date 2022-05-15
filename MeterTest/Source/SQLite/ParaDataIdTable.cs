using System.Collections.Generic;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.SQLite
{
    public class ParaDataIdTable
    {
        public string Name;
        public uint Id;
        public long Ticks;
        public List<DataId> DataIdList;

        public ParaDataIdTable()
        {
        }

        public ParaDataIdTable(string name, uint id, long ticks, List<DataId> dataIdList)
        {
            Name = name;
            Id = id;
            Ticks = ticks;
            DataIdList = dataIdList;
        }

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