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
                    logger.Log("TX: " + msg.ToString() + dateTime.ToString("yyyy-MM-dd hh:mm:ss fff"));
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
            catch(Exception)
            {
                port.Close();
                throw;
            }
            port.Close();
            DateTime now = DateTime.Now;
            
            double milliseconds = ((double)(now.Ticks - dateTime.Ticks) / 10000);
                logger.Log("RX: " + responseMsg.ToString() + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff")
                + " 响应时间：" + milliseconds.ToString("F2") + "ms");
            if(responseMsg.ControlCode != (msg.ControlCode | 0x80))
            {
                throw new ClientException("Control code error！" + responseMsg.ControlCode.ToString("X2"));
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
                // if( )
                {
                    ReadBytes(frame, 0, 1);
                    if(frame[0] == 0x68)
                    {
                        ReadBytes(frame, 1, 9);
                        if((frame[7] == 0x68)
                        && (frame[9] <= 200))
                        {
                            ReadBytes(frame, 10, frame[9] + 2);
                            string s = null;
                            for (int i = 0; i < frame[9] + 12; i++)
                            {
                                s += frame[i].ToString("X2") + " ";
                            }
                            logger.Log(s);
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
        private void ReadBytes(byte[] array, int offset, int length)
        {
            int readCnts = 0;
            while (readCnts < length)
            {
                readCnts += port.Read(array, offset + readCnts, length);
            }
        }
    }
}