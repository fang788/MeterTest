using System;
using System.Collections.Generic;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.SQLite.ParaConfig
{
    public class ParaConfigTable
    {
        public static List<DataId> HasCommAddrAutoAddList = new List<DataId>
        {
            new DataId(0x04000401),
            new DataId(0x04000402),
        };
        private String name;
        public List<ParaConfigDataId> DataIds{get; set;}

        public ParaConfigTable()
        {
            
        }
        public ParaConfigTable(List<ParaConfigDataId> dataIdList, string name)
        {
            this.DataIds = dataIdList;
            Name = name;
        }

        
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Name.Equals(((ParaConfigTable)obj).Name);
        }

        public override int GetHashCode()
        {
            return DataIds.GetHashCode() + Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name + DataIds.ToString();
        }
    }
}