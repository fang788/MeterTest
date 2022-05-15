using System;
using System.Collections.Generic;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.SQLite
{
    public class Project
    {
        public uint Id{get; set;}
        public bool IsUse{get; set;}
        public long Ticks{get; set;}
        public String Name{get; set;}
        public List<DataIdTable> DataIdTables = new List<DataIdTable>();

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