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
                device = new TypeIITerminal(client, address, password, operatorCode, log);
            }
            return device;
        }
        public void ExcuteSpecialOrder(string deviceName, string specialOrderName, Object obj)
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
                        device.SetFactoryStatus(FactoryStatus.FactoryOut);
                        log.SendDeviceLog("已切换至厂外状态");
                    }
                }
                else if(specialOrderName == "广播校时")
                {
                    device.Broadcast();
                    log.SendDeviceLog("广播校时完成");
                }
                else if(specialOrderName == "升级")
                {
                    device.SoftwareUpdate((string)obj);
                }
                else if(specialOrderName == "获取打印开关状态")
                {
                    if(device.GetPrintfStatus())
                    {
                        log.SendDeviceLog("当前打印开关状态：打开");
                    }
                    else
                    {
                        log.SendDeviceLog("当前打印开关状态：关闭");
                    }
                }
                else if(specialOrderName == "关闭打印")
                {
                    device.SetPrintfStatus(false);
                    log.SendDeviceLog("已关闭打印");
                }
                else if(specialOrderName == "打开打印")
                {
                    device.SetPrintfStatus(true);
                    log.SendDeviceLog("已打开打印");
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
        public void ExcuteSpecialOrderThread(Object obj)
        {
            String[] arg = (string[]) obj;
            this.ExcuteSpecialOrder(arg[0], arg[1], arg[2]);
        }
    }
}