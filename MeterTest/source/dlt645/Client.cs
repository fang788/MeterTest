using System.IO;
using System.IO.Ports;

namespace MeterTest.Source.Dlt645
{
    public class Client
    {
        private readonly Transport transport;
        
        private Client()
        {

        }
        public Client(Transport transport)
        {
            this.transport = transport;
        }

        public byte[] Read(MeterAddress address, DataId dataId)
        {
            Message request = new Message(address, 0x11, dataId.GetDataIdBytes());
            Message response = transport.UnicastMessage(request);
            MemoryStream stream = new MemoryStream(response.DataField.Length - 4);
            stream.Write(response.DataField, 4, response.DataField.Length - 4);
            return stream.ToArray();
        }

        public void Write(MeterAddress address, DataId dataId, byte[] dataBytes)
        {
            MemoryStream stream = new MemoryStream(dataBytes.Length + dataId.GetDataIdBytes().Length);
            
            stream.Write(dataId.GetDataIdBytes(), 0, dataId.GetDataIdBytes().Length);
            stream.Write(dataBytes, dataId.GetDataIdBytes().Length, dataBytes.Length);
            Message request = new Message(address, 0x14, stream.ToArray());
            Message response = transport.UnicastMessage(request);
        }
    }
}