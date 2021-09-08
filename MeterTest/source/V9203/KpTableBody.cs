using System;

namespace MeterTest.source.V9203
{
    public class KpTableBody
    {
        public int Phase;
        public Double Rated_Volt;
        public Double Rated_Curr;
        public Double Rate_Freq;
        public int PhaseSequence;
        public int Revers;
        public Double Volt_Per1;
        public Double Volt_Per2;
        public Double Volt_Per3;
        public Double Curr1;
        public Double Curr2;
        public Double Curr3;
        public string IABC;
        public string CosP;
        public string SModel;
        public double MConst;
        public Double MPluse;
        public int Dev_Port;

        public bool PowerOn()
        {
            return true; //Class_kpdev.Adjust_UI2();
        }

        public bool PowerOff()
        {
            return Class_kpdev.Power_Off(Dev_Port);
        }
    }
}