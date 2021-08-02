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
    }
}