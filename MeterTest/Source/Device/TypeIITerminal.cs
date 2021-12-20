using System;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Device
{
    public class TypeIITerminal : AbstractDevice
    {

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