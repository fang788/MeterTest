using System;
using System.Collections.Generic;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.SQLite
{
    public class DataIdTable
    {
        public string Name;
        public bool IsConfig;
        public string ProjectName;
        public long Ticks;
        public List<DataId> DataIdList = new List<DataId>();

        public DataIdTable()
        {
        }

        public DataIdTable(string name, bool isConfig, string projectName, long ticks, List<DataId> dataIdList)
        {
            Name = name;
            IsConfig = isConfig;
            ProjectName = projectName;
            Ticks = ticks;
            DataIdList = dataIdList;
        }
    }
}