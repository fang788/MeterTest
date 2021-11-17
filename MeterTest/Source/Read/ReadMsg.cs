using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Read
{
    public class ReadMsg
    {
        public ReadMsg()
        {
        }

        public ReadMsg(bool isSuccess, string errorLog, DataId dataId)
        {
            IsSuccess = isSuccess;
            ErrorLog = errorLog;
            DataId = dataId;
        }
        public string MsgLog;
        public bool IsSuccess {get; set;}
        public string ErrorLog{get; set;}
        public DataId DataId{get; set;}
    }
}