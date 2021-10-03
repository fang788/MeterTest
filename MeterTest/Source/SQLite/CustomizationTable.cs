using System;
using System.Collections.Generic;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.SQLite
{
    public class CustomizationTable
    {
        private String name;
        private List<DataId> dataIdList;

        public CustomizationTable()
        {
            
        }
        public CustomizationTable(List<DataId> dataIdList, string name)
        {
            this.dataIdList = dataIdList;
            Name = name;
        }

        public List<DataId> DataId
        {
            get
            {
                return dataIdList;
            }
            set
            {
                dataIdList = value;
            }
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
            return this.Name.Equals(((CustomizationTable)obj).Name);
        }

        public override int GetHashCode()
        {
            return dataIdList.GetHashCode() + Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name + dataIdList.ToString();
        }
    }
}