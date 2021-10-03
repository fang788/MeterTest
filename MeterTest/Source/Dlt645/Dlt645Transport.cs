using System;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using MeterTest.Source.Dlt645.Message;

namespace MeterTest.Source.Dlt645
{
    public class Dlt645Transport
    {
        private readonly SerialPort port;
        private readonly ConsoleLogger logger;
        private object syncLock = new object();
        public const int ResponseFrameStartLength = 10;

        public Dlt645Transport(SerialPort port, ConsoleLogger log)
        {
            this.port = port;
            this.logger = log;
        }

        public T UnicastMessage<T>(IDlt645Message request) where T : IDlt645Message, new()
        {
            // IDlt645Message responseMsg = null;
            T responseMsg = new T();
            DateTime dateTime = DateTime.Now;
            try
            {
                lock(syncLock)
                {
                    port.Open();
                    byte[] frame = BuildMessageFrame(request);
                    TxLogger(frame, dateTime);
                    port.Write(frame, 0, frame.Length);
                    frame = ReadResponse();
                    RxLogger(frame, dateTime);
                    responseMsg.Initialize(frame);
                }
                ValidateResponse(request, responseMsg);
            }
            catch(TimeoutException e)
            {
                logger.Log($"{e.GetType().Name}, {e}");
                throw;
            }
            catch(Exception e)
            {
                logger.Log($"{e.GetType().Name}, {e}");
                throw;
            }
            finally
            {
                if(port != null)
                {
                    port.Close();
                }
            }
            
            return responseMsg;
        }
        private Dlt645Message CreateMessage(byte[] frame)
        {
            byte[] addressBytes = new byte[MeterAddress.MeterAddressBytes];
            Array.Copy(frame, 1, addressBytes, 0, MeterAddress.MeterAddressBytes);
            MeterAddress address = new MeterAddress(addressBytes);
            MemoryStream stream = new MemoryStream(frame.Length - 12);
            stream.Write(frame, 10, frame.Length - 12);
            Dlt645Message Msg = new Dlt645Message(address, frame[8], stream.ToArray());
            return Msg;
        }
        private void TxLogger(byte[] frame, DateTime dateTime)
        {
            string msg = null;
            for (int i = 0; i < frame.Length; i++)
            {
                msg += frame[i].ToString("X2");
                msg += " ";
            }
            logger.Log("TX: " + msg + dateTime.ToString("yyyy-MM-dd hh:mm:ss fff"));
        }
        private void RxLogger(byte[] frame, DateTime dateTime)
        {
            string msg = null;
            for (int i = 0; i < frame.Length; i++)
            {
                msg += frame[i].ToString("X2");
                msg += " ";
            }
            DateTime now = DateTime.Now;
            double milliseconds = ((double)(now.Ticks - dateTime.Ticks) / 10000);
            logger.Log("RX: " + msg + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff") + " 响应时间：" + milliseconds.ToString("F2") + "ms");
        }
        public void ValidateResponse(IDlt645Message request, IDlt645Message response)
        {
            // always check the function code and slave address, regardless of transport protocol
            if (response.ControlCode != (request.ControlCode | 0x80))
            {
                string msg = $"Error: {request.ControlCode.ToString("X2")}, received {response.ControlCode.ToString("X2")}.";
                throw new ClientException(msg);
            }

            // message specific validation
            var req = request as IDlt645Request;

            if (req != null)
            {
                req.ValidateResponse(response);
            }
        }

        private byte[] BuildMessageFrame(IDlt645Message msg)
        {
            byte[] frame = new byte[15 + msg.DataFieldLen];
            frame[0] = 0xFE;
            frame[1] = 0xFE;
            frame[2] = 0xFE;
            frame[3] = 0x68;
            byte[] addressBytes = msg.Address.GetAddressBytes();
            for (int i = 0; i < addressBytes.Length; i++)
            {
                frame[4 + i] = addressBytes[i];
            }
            frame[10] = 0x68;
            frame[11] = msg.ControlCode;
            frame[12] = msg.DataFieldLen;
            for (int i = 0; i < msg.DataFieldLen; i++)
            {
                frame[13 + i] = (byte)(msg.DataField[i] + 0x33);
            }
            frame[13 + msg.DataFieldLen] = 0;
            for (int i = 3; i < 13 + msg.DataFieldLen; i++)
            {
                frame[13 + msg.DataFieldLen] += frame[i];
            }
            frame[14 + msg.DataFieldLen] = 0x16;
            return frame;
        }

        private byte[] ReadResponse()
        {
            byte[] frame = new byte[512];
            while (true)
            {
                ReadBytes(frame, 0, 1);
                if(frame[0] == 0x68)
                {
                    ReadBytes(frame, 1, 9);
                    if((frame[7] == 0x68)
                    && (frame[9] <= 200))
                    {
                        ReadBytes(frame, 10, frame[9] + 2);
                        if((Dlt645Message.CalCheckSum(frame, 0, 10 + frame[9]) == frame[frame[9] + 10])
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
            MemoryStream stream = new MemoryStream(frame[9] + 12);
            stream.Write(frame, 0, frame[9] + 12);
            return stream.ToArray();
        }
        private void ReadBytes(byte[] array, int offset, int length)
        {
            int readCnts = 0;
            try
            {
                while (readCnts < length)
                {
                    readCnts += port.Read(array, offset + readCnts, length);
                }
            }
            catch(ArgumentException e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }
    }
}