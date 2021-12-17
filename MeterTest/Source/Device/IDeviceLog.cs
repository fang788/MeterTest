namespace MeterTest.Source.Device
{
    public interface IDeviceLog
    {
        void SendDeviceLog(string msg);
        void DeviceOptEnd();
    }
}