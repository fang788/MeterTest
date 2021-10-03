using System;
using System.Text;

namespace MeterTest.Source.Emu
{
    public class KpTableBody
    {
        /*
         相线
          0     3p3w watt
		  1     3p3w 60 var
       	  2     3p3w 90 跨相var 
  		  3     3p3w 90 移相var
		  4     3p3w 自然无功
		  5     3p4w watt 
		  6     3p4w 90跨相var
		  7     3p4w 90移相var
		  8     3p4w 自然无功
		  9     1p2w watt
          10    1p2w var
          11    2p3w watt
          12    1p3w watt
          13    2p3w var
         */
        public int Phase = 5;
        public Double Rated_Volt = 220; // 被校表额定电压 如220V   则为220
        public Double Rated_Curr = 5;  // 被校表额定电流 如1.5(6)A则为1.5
        public Double Rate_Freq = 50;  // 被校表额定频率
        public int PhaseSequence = 0;  // 相序     0-正相序 1-逆相序
        public int Revers = 0;  // 电流方向 0-正相   1-反相
        public Double Volt_Per1 = 100; // 负载点电压百分数 100表示100%
        public Double Volt_Per2 = 100; // 负载点电压百分数 100表示100%
        public Double Volt_Per3 = 100; // 负载点电压百分数 100表示100%
        public Double Curr1 = 100; // 负载点电流百分数 100表示100%
        public Double Curr2 = 100; // 负载点电流百分数 100表示100%
        public Double Curr3 = 100; // 负载点电流百分数 100表示100%
        public string IABC = "H";  // 负载点合分元 H-合元 A-分A B-分B C-分C H-单相
        public string CosP = "1.0";  // 负载点功率因数 取值：1.0 0.5L 0.8C ....
        public string SModel = "";
        public double MConst = 200; // 表常数
        public Double MPluse = 2; // 检定圈数
        public int Dev_Port = 2; /* 装置通讯口 如：COM1则为1,COM2为2,... */

        public void PowerOn()
        {
            bool rst = Class_kpdev.Adjust_UI2(Phase, 
                                          Rated_Volt, 
                                          Rated_Curr, 
                                          Rate_Freq, 
                                          PhaseSequence, 
                                          Revers, 
                                          Volt_Per1, 
                                          Volt_Per2, 
                                          Volt_Per3, 
                                          Curr1, 
                                          Curr2, 
                                          Curr3, 
                                          IABC, 
                                          CosP, 
                                          SModel, 
                                          MConst, 
                                          MPluse,
                                          Dev_Port);
            if(rst == false)
            {
                throw new InvalidOperationException("升源失败，请检查台体！");
            }
        }

        public bool PowerOff()
        {
            return Class_kpdev.Power_Off(Dev_Port);
        }
        public bool PowerPause()
        {
            return Class_kpdev.Power_Pause(Dev_Port);
        }
        public string KpTableBodyRead()
        {
            StringBuilder SData = new StringBuilder(1024);
            Class_kpdev.StdMeter_Read(ref SData, "", Dev_Port);
            return SData.ToString();
        }
    }
}