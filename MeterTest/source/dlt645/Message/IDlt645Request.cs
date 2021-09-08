namespace MeterTest.source.dlt645.Message
{
    public interface IDlt645Request : IDlt645Message
    {
        /// <summary>
        ///     Validate the specified response against the current request.
        /// </summary>
        void ValidateResponse(IDlt645Message response);
    }
}