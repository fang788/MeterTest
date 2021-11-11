namespace MeterTest.Source.Dlt645.Message
{
    public interface IDlt645Response: IDlt645Message
    {
        void ValidateResponse(IDlt645Message response);
    }
}