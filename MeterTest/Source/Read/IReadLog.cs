using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Read
{
    public interface IReadLog
    {
        void SendMsg(ReadMsg msg);
        void ReadEnd();
        void SendReadDataId(DataId dataId);
    }
}