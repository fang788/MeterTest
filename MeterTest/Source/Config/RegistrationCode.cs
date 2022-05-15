using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using MeterTest.Source.SQLite;
using Microsoft.EntityFrameworkCore;

namespace MeterTest.Source.Config
{
    public class RegistrationCode
    {
        public static string Mask = "QECVEXGf";
        private static List<string> SuperCodeList = new List<string>()
        {
            "BFEBFBFF000706E5A280C445", // 方兵
            "BFEBFBFF000906EAC6CA574F", // 方兵
            "BFEBFBFF000906EAEECFD45C", // 胡茂祥
            "BFEBFBFF000806ECA890FD10", // 冯易仕
            "BFEBFBFF000806ECE2073FBB", // 郭杰
            "BFEBFBFF000906EAD0A33A96", // 陆旭青
        };
        public static string getCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }

        public static string GetMachineCode()
        {
            string s = null;
            s = getCpu() + GetDiskVolumeSerialNumber();
            return s;
        }

        /// <summary>
        /// 获取硬盘的参数
        /// </summary>
        /// <returns></returns>
        public static string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }
        
        
        /// <summary>
        /// 根据机器码获取注册码
        /// </summary>
        /// <param name="machineText"></param>
        /// <returns></returns>
        public static string GetResistText(string machineText)
        {
            string strAsciiName = null;
            char[]  charCode = new char[128];//用于存密钥
            for (int i = 0; i < charCode.Length; i++)
            {
                charCode[i] = (char)(i + 10);
            }

            // byte[] byteArray = System.Text.Encoding.ASCII.GetBytes (machineText);
            char[] charArray = machineText.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                charArray[i] ^= charCode[i % (charCode.Length - 1)];
                charArray[i] = (char)('A' + (charArray[i] % 25));
            }
            strAsciiName = new string(charArray);
            
            return strAsciiName;
        }

        static string  licPath = "lic.txt";
        public static bool LicFileSave(string s)
        {
            bool rst = false;
            StreamWriter streamWriter = null;
            try
            {
                if(System.IO.File.Exists(licPath))
                {
                    System.IO.File.Delete(licPath);
                    //System.IO.File.Create(licPath);
                }
                streamWriter = new FileInfo(licPath).AppendText();
                streamWriter.Write(s);
                rst = true;
            }
            catch (System.Exception)
            {
                MessageBox.Show("注册文件保存失败", "注册提示");
            }
            finally
            {
                if(streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
            
            return rst;
        }

        public static bool LicFileChk()
        {
            bool rst = false;
            StreamReader streamReader = null; 
            try
            {
                if(System.IO.File.Exists(licPath))
                {
                    FileInfo file = new FileInfo(licPath);
                    streamReader = file.OpenText();
                    string s = streamReader.ReadToEnd();
                    if(s == GetResistText(GetMachineCode()))
                    {
                        rst = true;
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                if(streamReader != null)
                {
                    streamReader.Close();
                }
            }

            return rst;
        }
        public static bool Check()
        {
            string mCode = GetMachineCode();
            if(SuperCodeList.Contains(mCode))
            {
                return true;
            }
            else
            {
                MeterTestConfig config = MeterTestDbContext.GetMeterTestConfig();
                return GetResistText(GetMachineCode()) == config.ActivationCode;
            }
        }
        public static string GetActivationCode()
        {
            MeterTestConfig config;
            using (var context = new MeterTestDbContext())
            {
                config = context.MeterTestConfigs.FirstOrDefault();
                if(config == null)
                {
                    config = new MeterTestConfig();
                }
            }
            return config.ActivationCode;
        }
        public static void SetActivationCode(string code)
        {
            using (var context = new MeterTestDbContext())
            {
                MeterTestConfig config = context.MeterTestConfigs.FirstOrDefault();
                config.ActivationCode = code;
                config.MachineCode = GetMachineCode();
                context.SaveChanges();
            }
        }
    }
}