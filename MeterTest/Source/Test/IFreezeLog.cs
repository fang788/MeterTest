namespace MeterTest.Source.Test
{
    public interface IFreezeLog
    {
        void SendMsg(FreezeReadMsg msg);
        void End();
    }
}