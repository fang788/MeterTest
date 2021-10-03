using System.IO;
using System.Management;
using System.Windows.Forms;

namespace MeterTest.Source.Config
{
    public class RegistrationCode
    {
        public static string Mask = "QECVEXGf";
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
    }
}