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
        public int Dlt645DynamicPasswordCal(byte[] puff, int len)
        {
            uint i, j, dynamicPassword = 0;

            for (i = 0; i < len; i++)
            {
                dynamicPassword = dynamicPassword ^ puff[i];
                for (j = 8; j > 0; --j)
                {
                    dynamicPassword = (uint)((dynamicPassword >> 1) ^ (0xEDB88323 & (-(dynamicPassword & 1))));
                }
                i++;
            }
            return (int)(dynamicPassword & 0x00FFFFFF);
        }
        public void DateTimeSet()
        {
            DataId dataId = new DataId(0xA5A01106);
            dataId.DataBytes = 6;
            dataId.DataArray = new byte[dataId.DataBytes];
            dataId.DataArray[5] = PublicClass.ByteHex2Bcd((byte)(DateTime.Now.Year - 2000));
            dataId.DataArray[4] = PublicClass.ByteHex2Bcd((byte)(DateTime.Now.Month)      );
            dataId.DataArray[3] = PublicClass.ByteHex2Bcd((byte)(DateTime.Now.Day)        );
            dataId.DataArray[2] = PublicClass.ByteHex2Bcd((byte)(DateTime.Now.Hour)       );
            dataId.DataArray[1] = PublicClass.ByteHex2Bcd((byte)(DateTime.Now.Minute)     );
            dataId.DataArray[0] = PublicClass.ByteHex2Bcd((byte)(DateTime.Now.Second)     );
            client.WriteRepInogreTimeOut(GetMeterAddress(), dataId, new Dlt645Password(0x66, Dlt645DynamicPasswordCal(dataId.DataArray, dataId.DataArray.Length)), new Dlt645OperatorCode());
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

        public bool GetPrintfStatus()
        {
            DataId readAddress = new DataId(0xA5A01104);
            byte[] data = client.ReadRepInogreTimeOut(MeterAddress.Wildcard, readAddress);
            if(data.Length != 1)
            {
                throw new Exception("返回长度不正确！");
            }
            return (data[0] == 0)? false : true;
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

        public void SetPrintfStatus(bool status)
        {
            DataId dataId = new DataId(0xA5A01104);
            dataId.DataBytes = 1;
            dataId.DataArray = new byte[1];
            dataId.DataArray[0] = (status == false)? (byte)0 : (byte)1;
            client.WriteRepInogreTimeOut(GetMeterAddress(), dataId, new Dlt645Password(0x02, 0x123456), new Dlt645OperatorCode());
        }
        public abstract void SoftwareUpdate(string updateFilePath);
    }
}