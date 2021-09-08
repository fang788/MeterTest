using System.IO;
using System.IO.Ports;
using MeterTest.source.dlt645;
using MeterTest.source.dlt645.Message;

namespace MeterTest.Source.Dlt645
{
    public class Dlt645Client
    {
        private readonly Dlt645Transport transport;
        
        private Dlt645Client()
        {

        }
        public Dlt645Client(Dlt645Transport transport)
        {
            this.transport = transport;
        }

        public byte[] Read(MeterAddress address, DataId dataId)
        {
            ReadRequest request = new ReadRequest(address, Dlt645ControlCodes.Read, (byte)dataId.DataBytes, dataId);
            ReadRequest response = transport.UnicastMessage<ReadRequest>(request);
            MemoryStream stream = new MemoryStream(response.DataField.Length - 4);
            stream.Write(response.DataField, 4, response.DataField.Length - 4);
            return stream.ToArray();
        }

        // public void Write(MeterAddress address, DataId dataId, byte[] dataBytes)
        // {
        //     MemoryStream stream = new MemoryStream(dataBytes.Length + dataId.GetDataIdBytes().Length);
            
        //     stream.Write(dataId.GetDataIdBytes(), 0, dataId.GetDataIdBytes().Length);
        //     stream.Write(dataBytes, dataId.GetDataIdBytes().Length, dataBytes.Length);
        //     Message request = new Message(address, 0x14, stream.ToArray());
        //     Message response = transport.UnicastMessage(request);
        // }
    }
}