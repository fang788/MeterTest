using System;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Device
{
    public class TypeIITerminal : AbstractDevice
    {
        private Dlt645Client client;
        private MeterAddress address;
        private Dlt645Password password;
        private Dlt645OperatorCode operatorCode;

        public TypeIITerminal()
        {
        }

        public TypeIITerminal(Dlt645Client client, MeterAddress address, Dlt645Password password, Dlt645OperatorCode operatorCode)
        {
            this.client = client;
            this.address = address;
            this.password = password;
            this.operatorCode = operatorCode;
        }
    }
}