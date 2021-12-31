using System;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Device
{
    public abstract class AbstractDevice : IDevice
    {
        public Dlt645Client client;
        public MeterAddress Address;
        public Dlt645Password Password;
        public Dlt645OperatorCode OperatorCode;
        public IDeviceLog Log;
        public AbstractDevice()
        {
        }

        public AbstractDevice(Dlt645Client client, MeterAddress address, Dlt645Password password, Dlt645OperatorCode operatorCode)
        {
            this.client = client;
            this.Address = address;
            this.Password = password;
            this.OperatorCode = operatorCode;
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
                    client.MeterClear(Address, Password, OperatorCode);
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
            byte[] status = client.ReadRepInogreTimeOut(Address, dataId);
            dataId.DataBytes = 1;
            if(status == null)
            {
                throw new Exception("读取工厂状态失败");
            }
            else if(status[0] == 0xAA)
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
            DataId readAddress = new DataId(0x04000401);
            byte[] data = client.Read(MeterAddress.Wildcard, readAddress);
            return new MeterAddress(data);
        }

        public void SetFactoryStatus(FactoryStatus status)
        {
            DataId dataId = new DataId(0xA5A01101);
            dataId.DataBytes = 1;
            dataId.DataArray = new byte[1];
            if(status == FactoryStatus.FactoryOut)
            {
                dataId.DataArray[0] = 0xAA;
            }
            else
            {
                dataId.DataArray[0] = 0x55;
            }
            client.WriteRepInogreTimeOut(GetMeterAddress(), dataId, new Dlt645Password(0x02, 0x123456), new Dlt645OperatorCode());
        }

        public void SetMeterAddress(MeterAddress address)
        {
            throw new System.NotImplementedException();
        }

        public abstract void SoftwareUpdate(string updateFilePath);
    }
}