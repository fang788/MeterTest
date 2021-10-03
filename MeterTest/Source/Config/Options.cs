using System.IO.Ports;

namespace MeterTest.Source.Config
{
    public class Options
    {
        private string   portName  = "COM1";
        private int      baudRate  = 9600;
        private int      dataBits = 8; 
        private Parity   parity    = Parity.Even;
        private StopBits stopBits  = StopBits.One;
        private int      readTimeout = 500;
        private string   meterAddress = "AAAAAAAAAAAA";
        private byte     authority = 0x02;
        private string   password = "000000";
        private string   operatorCode = "00000000";
        private string   kpTableBodyPortName = "COM2";

        public Options()
        {
        }

        public string PortName
        {
            get 
            { 
                return portName;
            }
            set
            {
                portName = value;
            }
        }
        public int BaudRate
        {
            get 
            { 
                return baudRate;
            }
            set
            {
                baudRate = value;
            }
        }
        public int DataBits
        {
            get 
            { 
                return dataBits;
            }
            set
            {
                dataBits = value;
            }
        }
        public Parity Parity
        {
            get 
            { 
                return parity;
            }
            set
            {
                parity = value;
            }
        }
        public StopBits StopBits
        {
            get 
            { 
                return stopBits;
            }
            set
            {
                stopBits = value;
            }
        }
        public int ReadTimeout
        {
            get 
            { 
                return readTimeout;
            }
            set
            {
                readTimeout = value;
            }
        }
        public string MeterAddress
        {
            get
            {
                return meterAddress;
            }
            set
            {
                meterAddress = value;
            }
        }
        public byte Authority
        {
            get { return authority;}
            set { authority = value; }
        }
        public string Password
        {
            get { return password;}
            set { password = value; }
        }
        public string OperatorCode
        {
            get { return operatorCode;}
            set { operatorCode = value; }
        }
        public string KpTableBodyPortName 
        {
            get { return kpTableBodyPortName;}
            set { kpTableBodyPortName = value; }
        }
    }
}