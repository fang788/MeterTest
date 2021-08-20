using System;
using System.IO;
using System.IO.Ports;
using System.Linq;

namespace MeterTest.Source.Dlt645
{
    public class Transport
    {
        private readonly SerialPort port;
        private readonly ConsoleLogger logger;
        private object syncLock = new object();
        public const int ResponseFrameStartLength = 10;

        public Transport(SerialPort port, ConsoleLogger log)
        {
            this.port = port;
            this.logger = log;
        }

        public Message UnicastMessage(Message msg)
        {
            Message responseMsg = null;
            DateTime dateTime = DateTime.Now;
            try
            {
                lock(syncLock)
                {
                    port.Open();
                    byte[] request = msg.MessageFrame;
                    logger.Log("TX: " + msg.ToString() + dateTime.ToString("yyyy-MM-DD hh:mm:ss fff"));
                    port.Write(request, 0, request.Length);
                    byte[] response = ReadResponse();
                    responseMsg = CreateMessage(response);
                }
            }
            catch(TimeoutException e)
            {
                logger.Log($"{e.GetType().Name}, {e}");
                port.Close();
                throw;
            }
            port.Close();
            int milliseconds = DateTime.Now.Millisecond - dateTime.Millisecond;
                logger.Log("RX: " + responseMsg.ToString() + DateTime.Now.ToString("yyyy-MM-DD hh:mm:ss fff")
                + " 响应时间：" + milliseconds.ToString() + "ms");
            if(responseMsg.ControlCode != (msg.ControlCode | 0x80))
            {
                throw new ClientException("Control code error！" + responseMsg.ControlCode.ToString("X8"));
            }

            return responseMsg;
        }
        private Message CreateMessage(byte[] frame)
        {
            byte[] addressBytes = new byte[MeterAddress.MeterAddressBytes];
            Array.Copy(frame, 1, addressBytes, 0, MeterAddress.MeterAddressBytes);
            MeterAddress address = new MeterAddress(addressBytes);
            MemoryStream stream = new MemoryStream(frame.Length - 12);
            stream.Write(frame, 10, frame.Length - 12);
            Message Msg = new Message(address, frame[8], stream.ToArray());
            return Msg;
        }

        private byte[] BuildMessageFrame(Message message)
        {
            return message.MessageFrame;
        }

        private byte[] ReadResponse()
        {
            byte[] frame = new byte[256];
            while (true)
            {
                if(port.Read(frame, 0, 1) > 0)
                {
                    if((frame[0] == 0x68)
                    && (port.Read(frame, 1, 9) > 0))
                    {
                        if((frame[7] == 0x68)
                        && (frame[9] <= 200)
                        && (port.Read(frame, 10, frame[9] + 2) > 0))
                        {
                            if((Message.CalCheckSum(frame, 0, 10 + frame[9]) == frame[frame[9] + 10])
                            && (frame[frame[9] + 11] == 0x16))
                            {
                                for (int i = 0; i < frame[9]; i++)
                                {
                                    frame[10 + i] -= 0x33;
                                }
                                break;
                            }                            
                        }
                    }
                }
            }
            MemoryStream stream = new MemoryStream(frame[9] + 12);
            stream.Write(frame, 0, frame[9] + 12);
            return stream.ToArray();
        }
    }
}