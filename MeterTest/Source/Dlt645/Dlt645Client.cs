using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using MeterTest.Source.Dlt645;
using MeterTest.Source.Dlt645.Message;
using MeterTest.Source.SQLite;
using Microsoft.EntityFrameworkCore;

namespace MeterTest.Source.Dlt645
{
    public class Dlt645Client
    {
        private readonly Dlt645Transport transport;
        private const int OPT_MAX_CNT = 2;
        public Dlt645Client(Dlt645Transport transport)
        {
            this.transport = transport;
        }
        public static Dlt645Client GetDlt645Client(IDlt645CommLog log)
        {
            Dlt645Client dlt645Client;
            MeterTestConfig meterTestConfig = MeterTestDbContext.GetMeterTestConfig();
            SerialPort serialPort = new SerialPort(meterTestConfig.PortName, meterTestConfig.BaudRate, meterTestConfig.Parity, meterTestConfig.DataBits, StopBits.One);
            serialPort.ReadTimeout = meterTestConfig.ReadTimeout;
            Dlt645Transport transportTmp = new Dlt645Transport(serialPort, log);
            dlt645Client = new Dlt645Client(transportTmp);
            return dlt645Client;
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
            MeterClearRequest request = new MeterClearRequest(address, password, opCode);
            transport.UnicastMessage<WriteResponse>(request);
        }
        public byte[] ReadRepInogreTimeOut(MeterAddress address, DataId dataId)
        {
            byte[] rst = null;
            int cnt = 0;
            while (cnt < OPT_MAX_CNT)
            {
                try
                {
                    rst = Read(address, dataId);
                    break;
                }
                catch (TimeoutException)
                {
                    cnt++;
                }
            }
            if(cnt >= OPT_MAX_CNT)
            {
                throw new TimeoutException();
            }
            return rst;
        }
        public byte[] ReadRepInogreTimeOut(MeterAddress address, DataId dataId, byte[] dataArray)
        {
            byte[] rst = null;
            int cnt = 0;
            while (cnt < OPT_MAX_CNT)
            {
                try
                {
                    rst = Read(address, dataId, dataArray);
                    break;
                }
                catch (TimeoutException)
                {
                    cnt++;
                }
            }
            if(cnt >= OPT_MAX_CNT)
            {
                throw new TimeoutException();
            }
            return rst;
        }

        public void WriteRepInogreTimeOut(MeterAddress address, DataId dataId)
        {
            int cnt = 0;
            while (cnt < OPT_MAX_CNT)
            {
                try
                {
                    Write(address, dataId);
                    break;
                }
                catch (TimeoutException)
                {
                    cnt++;
                }
            }
            if(cnt >= OPT_MAX_CNT)
            {
                throw new TimeoutException();
            }
        }

        public void WriteRepInogreTimeOut(MeterAddress address, DataId dataId, Dlt645Password password, Dlt645OperatorCode operatorCode)
        {
            int cnt = 0;
            while (cnt < OPT_MAX_CNT)
            {
                try
                {
                    Write(address, dataId, password, operatorCode);
                    break;
                }
                catch (TimeoutException)
                {
                    cnt++;
                }
            }
            if(cnt >= OPT_MAX_CNT)
            {
                throw new TimeoutException();
            }
        }
        public void DataIdListRead(MeterAddress meterAddress, List<DataId> dataIdList, IDlt645CommLog dlt645CommLog, ref bool stopFlag)
        {            
            for (int i = 0; i < dataIdList.Count; i++)
            {
                string msg = dataIdList[i].Id.ToString();
                msg += "-";
                try
                {
                    byte[] byteArray = Read(meterAddress, dataIdList[i]);
                    msg += (true.ToString() + "-");
                    for (int j = 0; j < byteArray.Length; j++)
                    {
                        msg += byteArray[j].ToString("X2");
                    }
                }
                catch (TimeoutException)
                {
                    msg += (false.ToString() + "-" + "响应超时");
                }
                finally
                {
                    dlt645CommLog.Log(msg);
                }
                if(stopFlag)
                {
                    break;
                }
            }   
        }
        public void DataIdListWrite(Dlt645Server server, List<DataId> dataIdList, IDlt645CommLog dlt645CommLog, ref bool stopFlag)
        {
            foreach (var item in dataIdList)
            {
                Write(server.MeterAddress, item, server.Dlt645Password, server.Dlt645OperatorCode);
                dlt645CommLog.Log(item.Id.ToString());
                if(stopFlag)
                {
                    break;
                }
            }
        }
    }
}