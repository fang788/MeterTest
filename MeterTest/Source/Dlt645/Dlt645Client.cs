using System.IO;
using System.IO.Ports;
using MeterTest.Source.Dlt645;
using MeterTest.Source.Dlt645.Message;

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
            ReadRequest request = new ReadRequest(address, Dlt645ControlCodes.Read, (byte)4, dataId);
            ReadResponse response = transport.UnicastMessage<ReadResponse>(request);
            MemoryStream stream = new MemoryStream(response.DataField.Length - 4);
            stream.Write(response.DataField, 4, response.DataField.Length - 4);
            return stream.ToArray();
        }

        public byte[] Read(MeterAddress address, DataId dataId, byte[] dataArray)
        {
            ReadRequest request = new ReadRequest(address, Dlt645ControlCodes.Read, dataId, dataArray);
            ReadResponse response = transport.UnicastMessage<ReadResponse>(request);
            MemoryStream stream = new MemoryStream(response.DataField.Length - 4);
            stream.Write(response.DataField, 4, response.DataField.Length - 4);
            return stream.ToArray();
        }

        public void Write(MeterAddress address, DataId dataId, Dlt645Password password, Dlt645OperatorCode operatorCode)
        {
            WriteRequset requset = new WriteRequset(address, Dlt645ControlCodes.Write, dataId, password, operatorCode);
            WriteResponse response = transport.UnicastMessage<WriteResponse>(requset);
        }
        public void Write(MeterAddress address, DataId dataId)
        {
            WriteRequset requset = new WriteRequset(address, Dlt645ControlCodes.Write, dataId, new Dlt645Password(), new Dlt645OperatorCode());
            WriteResponse response = transport.UnicastMessage<WriteResponse>(requset);
        }
        public void MeterClear(MeterAddress address, Dlt645Password password, Dlt645OperatorCode opCode)
        {
            MeterClearRequset request = new MeterClearRequset(address, password, opCode);
            transport.UnicastMessage<WriteResponse>(request);
        }
    }
}