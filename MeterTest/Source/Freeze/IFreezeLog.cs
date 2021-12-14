namespace MeterTest.Source.Freeze
{
    public interface IFreezeLog
    {
        void SendMsg(FreezeReadMsg msg);
        void FreezeReadEnd();
    }
}