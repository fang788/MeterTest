using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Device
{
    public interface IDevice
    {
        void SetFactoryStatus(FactoryStatus status);
        FactoryStatus GetFactoryStatus();
        void Clear();
        void Broadcast();
        MeterAddress GetMeterAddress();
        void SetMeterAddress(MeterAddress address);
    }
}