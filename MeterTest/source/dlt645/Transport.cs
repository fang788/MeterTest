using System;
using System.IO.Ports;
using System.Linq;

namespace MeterTest.Source.Dlt645
{
    public class Transport
    {
        private readonly SerialPort port;
        public const int ResponseFrameStartLength = 10;

        public Transport(SerialPort port)
        {
            this.port = port;
        }

        public Message UnicastMessage(Message msg)
        {
            return null;
        }

        public byte[] Read(int count)
        {
            byte[] frameBytes = new byte[count];
            int numBytesRead = 0;

            while (numBytesRead != count)
            {
                numBytesRead += port.Read(frameBytes, numBytesRead, count - numBytesRead);
            }

            return frameBytes;
        }
        

        private byte[] ReadResponse()
        {
            byte[] startBytes = new byte[ResponseFrameStartLength];;
            while (true)
            {
                if((port.Read(startBytes, 0, 1) == 1)
                && (startBytes[0] == 0x68))
                {
                    break;
                }
            }
            byte[] frameStrat = Read(ResponseFrameStartLength - 1);
            byte[] frameEnd   = Read(frameStrat[ResponseFrameStartLength - 2] + 1);
            byte[] frame = new byte[frameStrat.Length + frameEnd.Length + 1];
            frame[0] = 0x68;
            Array.Copy(frameStrat, 0, frame, 1, frameStrat.Length);
            Array.Copy(frameEnd, 0, frame, frameStrat.Length + 1, frameEnd.Length);
            return frame;
        }
        internal int ResponseBytesToRead(byte[] frameStart)
        {
            byte functionCode = frameStart[1];

            if (frameStart.Length < Modbus.ExceptionOffset)
            {
                return 1;
            }

            IModbusFunctionService service = ModbusFactory.GetFunctionServiceOrThrow(functionCode);

            return service.GetRtuResponseBytesToRead(frameStart);
        }
    }
}