using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Write
{
    public class ParaConfigMsg
    {
        public ParaConfigMsg()
        {
            DataId = new DataId();
        }

        public ParaConfigMsg(bool isSuccess, string errorLog, DataId dataId)
        {
            IsSuccess = isSuccess;
            ErrorLog = errorLog;
            DataId = dataId;
        }

        public bool IsSuccess {get; set;}
        public string ErrorLog{get; set;}
        public DataId DataId{get; set;}
    }
}