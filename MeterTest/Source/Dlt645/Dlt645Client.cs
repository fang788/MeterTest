using System;
using System.IO;
using System.IO.Ports;
using MeterTest.Source.Dlt645;
using MeterTest.Source.Dlt645.Message;

namespace MeterTest.Source.Dlt645
{
    public class Dlt645Client
    {
        private readonly Dlt645Transport transport;
        private const int OPT_MAX_CNT = 5;
        
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
            WriteRequest requset = new WriteRequest(address, Dlt645ControlCodes.Write, dataId, password, operatorCode);
            WriteResponse response = transport.UnicastMessage<WriteResponse>(requset);
        }
        public void Write(MeterAddress address, DataId dataId)
        {
            WriteRequest requset = new WriteRequest(address, Dlt645ControlCodes.Write, dataId, new Dlt645Password(), new Dlt645OperatorCode());
            WriteResponse response = transport.UnicastMessage<WriteResponse>(requset);
        }
        public void MeterClear(MeterAddress address, Dlt645Password password, Dlt645OperatorCode opCode)
        {
            MeterClearRequset request = new MeterClearRequset(address, password, opCode);
            transport.UnicastMessage<WriteResponse>(request);
        }
        public byte[] ReadRepInogreTimeOut(MeterAddress address, DataId dataId)
        {
            byte[] rst = null;
            for (int i = 0; i < OPT_MAX_CNT; i++)
            {
                try
                {
                    rst = Read(address, dataId);
                    break;
                }
                catch (TimeoutException)
                {
                    ;
                }
            }
            return rst;
        }

        public void WriteRepInogreTimeOut(MeterAddress address, DataId dataId)
        {
            for (int i = 0; i < OPT_MAX_CNT; i++)
            {
                try
                {
                    Write(address, dataId);
                    break;
                }
                catch (TimeoutException)
                {
                    ;
                }
            }
        }

        public void WriteRepInogreTimeOut(MeterAddress address, DataId dataId, Dlt645Password password, Dlt645OperatorCode operatorCode)
        {
            for (int i = 0; i < OPT_MAX_CNT; i++)
            {
                try
                {
                    Write(address, dataId, password, operatorCode);
                    break;
                }
                catch (TimeoutException)
                {
                    ;
                }
            }
        }
    }
}