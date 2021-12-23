using System;
using System.IO;
using System.Threading;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Device
{
    public class TypeIITerminal : AbstractDevice
    {
        private const uint SOFTWARE_UPDATE_FLG = 0xAA55A55A;
        private const uint SOFTWARE_RESET_KEY = 0x12345678;
        private const int WRITE_LEN = 185;

        public TypeIITerminal()
        {
        }

        public TypeIITerminal(Dlt645Client client, MeterAddress address, Dlt645Password password, Dlt645OperatorCode operatorCode, IDeviceLog log)
        {
            this.client = client;
            this.Address = address;
            this.Password = password;
            this.OperatorCode = operatorCode;
            this.Log = log;
        }
        private string GetVersion()
        {
            DataId dataId = new DataId(0xA5A01102);
            byte[] bytes = client.ReadRepInogreTimeOut(Address, dataId);
            Array.Reverse<byte>(bytes);
            return System.Text.Encoding.Default.GetString(bytes);
        }
        public void SetUpdateSoftLen(int length)
        {
            DataId dataId = new DataId(0xA5A10001, length);
            client.WriteRepInogreTimeOut(Address, dataId, Password, OperatorCode);
        }
        private void SetUpdateSoftwareCheck(uint check)
        {
            DataId dataId = new DataId(0xA5A10002, check);
            client.WriteRepInogreTimeOut(Address, dataId, Password, OperatorCode);
        }
        private void EraseExFlash(uint address)
        {
            DataId dataId = new DataId(0xA5A10003, address);
            client.WriteRepInogreTimeOut(Address, dataId, Password, OperatorCode);
        }
        public void SetUpdateFlag()
        {
            DataId dataId = new DataId(0xA5A10004, 0xAA55A55A);
            client.WriteRepInogreTimeOut(Address, dataId, Password, OperatorCode);
        }
        public void McuReset()
        {
            DataId dataId = new DataId(0xA5A10005, 0x12345678);
            client.WriteRepInogreTimeOut(Address, dataId, Password, OperatorCode);
        }
        private uint GetCalChk()
        {
            DataId dataId = new DataId(0xA5A10006);
            byte[] data = client.ReadRepInogreTimeOut(Address, dataId);
            uint rst = (uint)(((uint)data[0] * 256 + data[1]) * 256 + data[2]) * 256 + data[3];
            return rst;
        }
        private void StartCalChk()
        {
            DataId dataId = new DataId(0xA5A10007, 0x01);
            client.WriteRepInogreTimeOut(Address, dataId, Password, OperatorCode);
        }
        public void ExFlashWrite(byte[] buff, int offset, int len)
        {
            MemoryStream memoryStream = new MemoryStream(buff, offset, len);
            uint id = (uint)(0xA7000000 + offset + 0x033000);
            DataId dataId = new DataId(id, memoryStream.ToArray());
            client.WriteRepInogreTimeOut(Address, dataId, Password, OperatorCode);
        }
        private bool WriteUpdateSoftware(string updateFilePath)
        {
            byte[] bytes = File.ReadAllBytes(updateFilePath);
            int singleLen = 0;
            for (int i = 0; i < bytes.Length; i += WRITE_LEN)
            {
                if(((i % (4 * 1024)) == 0) || ((i % (4 * 1024) + WRITE_LEN) >= (4 * 1024)))
                {
                    EraseExFlash((uint)(i + WRITE_LEN + 0x52033000));
                }
                singleLen = (bytes.Length > (i + WRITE_LEN))? WRITE_LEN : (bytes.Length - i);
                ExFlashWrite(bytes, i, singleLen);
                Log.SendDeviceLog("正在写入升级程序，已写入" + ((double)i / bytes.Length * 100).ToString("F3") + "%");
            }
            Log.SendDeviceLog("正在写入升级程序，已写入 100%");
            SetUpdateSoftLen(bytes.Length);
            uint check = PublicClass.Crc32(bytes, bytes.Length, 0);
            SetUpdateSoftwareCheck(check);
            StartCalChk();
            Thread.Sleep(5000);
            return check == GetCalChk();
        }
        public override void SoftwareUpdate(string updateFilePath)
        {
            string versionBefore = GetVersion();
            Log.SendDeviceLog("当前软件版本号：" + versionBefore);
            SetFactoryStatus(FactoryStatus.FactoryIn);
            SetUpdateFlag();
            int cnt = 0;
            while((cnt < 5) && (!WriteUpdateSoftware(updateFilePath)))
            {
                cnt++;
            }
            SetUpdateFlag();
            McuReset();

            cnt = 0;
            string versionAft = null;
            while(cnt < 15)
            {
                Thread.Sleep(1000);
                try
                {
                    versionAft = GetVersion();
                    break;
                }
                catch (TimeoutException)
                {
                    Log.SendDeviceLog("等待MCU升级，已等待 " + cnt.ToString() + "s");
                    cnt++;
                }
            }
            if(cnt > 15)
            {
                throw new TimeoutException();
            }
            Log.SendDeviceLog("升级完成，升级后软件版本号：" + versionAft);
            SetFactoryStatus(FactoryStatus.FactoryOut);
        }
    }
}