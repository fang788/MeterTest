using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Write
{
    public interface IParaConfigLog
    {
        void SendMsg(ParaConfigMsg msg);
        void ConfigEnd();
        void SendConfigDataId(DataId dataId);
    }
}