using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Dlt645.Message
{
    public interface IDlt645Message
    {
        byte MinimumFrameSize{get; }
        byte ControlCode{get; set; }
        MeterAddress Address{get; set; }
        byte DataFieldLen{get; set; }
        byte[] DataField{get; set; }
        /// <summary>
        ///     Initializes a dlt645 message from the specified message frame.
        /// </summary>
        /// <param name="frame">Bytes of Modbus frame.</param>
        void Initialize(byte[] frame);
    }
}