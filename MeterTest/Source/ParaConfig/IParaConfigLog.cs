using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Write
{
    public interface IParaConfigLog
    {
        void SendMsg(ParaConfigMsg msg);
        void End();
        void SendConfigDataId(DataId dataId);
    }
}