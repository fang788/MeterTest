namespace MeterTest.Source.Dlt645
{
    internal abstract  class ControlCodeServiceBase
    {
        private readonly byte controlCode;

        public  byte ControlCode 
        { 
            get
            {
                return controlCode;
            } 
        }
    }
}