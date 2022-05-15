using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.SQLite
{
    public class MeterTestConfig
    {
        public int Id;
        public string Name = "MeterTestConfig";
        public string   SelectRwProjectName = "123";
        public string   SelectRwTableName = "1";
        public string   SelectParaProjectName = "123";
        public string   SelectParaTableName = "1";
        public string   PortName  = "COM1";
        public int      BaudRate  = 9600;
        public int      DataBits = 8; 
        public Parity   Parity    = Parity.Even;
        public StopBits StopBits  = StopBits.One;
        public int      ReadTimeout = 500;
        public string MachineCode = "1";
        public string ActivationCode = "1";
        public string TableBodySerialPortName = "COM1";
        public List<Project> ProjectList = new List<Project>();
        public List<Dlt645Server> Dlt645ServiceList = new List<Dlt645Server>();
        public MeterTestConfig()
        {
            
        }

        public MeterTestConfig(int id, string serialPortName, string selectRWDataIdListProjectName, string selectParaDataIdListProjectName)
        {
            Id = id;
            PortName = serialPortName;
            SelectRwTableName = selectRWDataIdListProjectName;
            SelectParaTableName = selectParaDataIdListProjectName;
        }
    }
}