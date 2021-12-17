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

        public void Broadcast()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public FactoryStatus GetFactoryStatus()
        {
            throw new NotImplementedException();
        }

        public MeterAddress GetMeterAddress()
        {
            throw new NotImplementedException();
        }

        public void MeterCLear()
        {
            int cnt = 3;
            while(cnt > 0)
            {
                try
                {
                    client.MeterClear(address, password, operatorCode);
                    break;
                }
                catch (TimeoutException)
                {
                    cnt--;
                    if(cnt == 0)
                    {
                        throw;
                    }
                }
            }
        }

        public void SetFactoryStatus(FactoryStatus status)
        {
            throw new NotImplementedException();
        }

        public void SetMeterAddress(MeterAddress address)
        {
            throw new NotImplementedException();
        }

        public void SwitchFactoryStatus()
        {
            DataId dataId = new DataId(0xA5A01101);
            byte[] status = client.ReadRepInogreTimeOut(address, dataId);
            dataId.DataBytes = 1;
            if(status[0] == 0xAA)
            {
                dataId.DataArray = new byte[]
                {
                    0x55,
                };
                client.WriteRepInogreTimeOut(address, dataId, new Dlt645Password(0x02, 0x123456), new Dlt645OperatorCode());
            }
            else
            {
                dataId.DataArray = new byte[]
                {
                    0xAA,
                };
                client.WriteRepInogreTimeOut(address, dataId);
            }
        }
    }
}