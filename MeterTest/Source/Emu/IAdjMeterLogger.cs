namespace MeterTest.Source.Emu
{
    public interface IAdjMeterLogger
    {
        void IAdjMeterLog(string message);
        void CloseLock();
    }
}