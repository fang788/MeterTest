using MeterTest.Source.Dlt645;

namespace MeterTest.source.dlt645
{
    public class CommResult
    {
        private bool result = false;
        private string  error = null;
        private DataId dataId = null;
        private byte[] dataBytes = null;
        
        public CommResult()
        {

        }
        public CommResult(bool result, string error, DataId dataId)
        {
            Result = result;
            Error = error;
            DataId = dataId;
        }

        public bool Result 
        { 
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }
        public string Error
        {
            get
            {
                return error;
            }
            set
            {
                error = value;
            }
        }
        public DataId DataId
        {
            get 
            {
                return dataId;
            }
            set
            {
                dataId = value;
            }
        }
        public byte[] DataBytes
        {
            get 
            {
                return dataBytes;
            }
            set
            {
                dataBytes = value;
            }
        }
    }
}