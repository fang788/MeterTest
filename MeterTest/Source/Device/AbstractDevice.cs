using System;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Device
{
    public class AbstractDevice : IDevice
    {
        private Dlt645Client client;
        private MeterAddress address;
        private Dlt645Password password;
        private Dlt645OperatorCode operatorCode;
        public AbstractDevice()
        {
        }

        public AbstractDevice(Dlt645Client client, MeterAddress address, Dlt645Password password, Dlt645OperatorCode operatorCode)
        {
            this.client = client;
            this.address = address;
            this.password = password;
            this.operatorCode = operatorCode;
        }

        public void Broadcast()
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
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

        public FactoryStatus GetFactoryStatus()
        {
            FactoryStatus factoryStatus = FactoryStatus.FactoryIn;
            DataId dataId = new DataId(0xA5A01101);
            byte[] status = client.ReadRepInogreTimeOut(address, dataId);
            dataId.DataBytes = 1;
            if(status[0] == 0xAA)
            {
                factoryStatus = FactoryStatus.FactoryOut;
            }
            else
            {
                factoryStatus = FactoryStatus.FactoryIn;
            }
            return factoryStatus;
        }

        public MeterAddress GetMeterAddress()
        {
            throw new System.NotImplementedException();
        }

        public void SetFactoryStatus(FactoryStatus status)
        {
            throw new System.NotImplementedException();
        }

        public void SetMeterAddress(MeterAddress address)
        {
            throw new System.NotImplementedException();
        }
    }
}