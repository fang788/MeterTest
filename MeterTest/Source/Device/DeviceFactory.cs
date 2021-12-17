using System;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Device
{
    public class DeviceFactory
    {
        private Dlt645Client client;
        private MeterAddress address;
        private Dlt645Password password;
        private Dlt645OperatorCode operatorCode;
        private IDeviceLog log;

        public DeviceFactory(Dlt645Client client, MeterAddress address, Dlt645Password password, Dlt645OperatorCode operatorCode, IDeviceLog log)
        {
            this.client = client;
            this.address = address;
            this.password = password;
            this.operatorCode = operatorCode;
            this.log = log;
        }

        public IDevice CreateDevice(string deviceName)
        {
            IDevice device = null;
            if(deviceName == "II型终端")
            {
                device = new TypeIITerminal(client, address, password, operatorCode);
            }
            return device;
        }
        public void ExcuteSpecialOrder(string specialOrderName, string deviceName)
        {
            IDevice device = CreateDevice(deviceName);
            try
            {
                if(specialOrderName == "清零")
                {
                    device.Clear();
                    log.SendDeviceLog("清零完成");
                } 
                else if(specialOrderName == "切换工厂状态")
                {
                    FactoryStatus status = device.GetFactoryStatus();
                    if(status == FactoryStatus.FactoryOut)
                    {
                        device.SetFactoryStatus(FactoryStatus.FactoryIn);
                        log.SendDeviceLog("已切换至厂内状态");
                    }
                    else
                    {
                        device.SetFactoryStatus(FactoryStatus.FactoryIn);
                        log.SendDeviceLog("已切换至厂外状态");
                    }
                }
                else if(specialOrderName == "广播校时")
                {
                    device.Broadcast();
                    log.SendDeviceLog("广播校时完成");
                }
            }
            catch (TimeoutException)
            {
                log.SendDeviceLog("响应超时");
            }
            catch(Exception e)
            {
                log.SendDeviceLog(specialOrderName + "失败：" + e.Message);
            }
            finally
            {
                log.DeviceOptEnd();
            }
        }
    }
}