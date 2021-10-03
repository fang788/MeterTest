using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

static class Class_kpdev
{
    #region 
    [DllImport("kpdev.dll")] //send the power parameter and power on
    public static extern bool Adjust_UI2(int Phase, Double Rated_Volt, Double Rated_Curr, Double Rate_Freq, int PhaseSequence, int Revers, Double Volt_Per1, Double Volt_Per2, Double Volt_Per3, Double Curr1, Double Curr2, Double Curr3, string IABC, string CosP, string SModel, double MConst, Double MPluse,int Dev_Port);

    [DllImport("kpdev.dll")] //set the voltage angle,if want user-difined,use this function before Adjust_UI2
    public static extern bool Set_UabUac(Double curUab, Double curUac);

    [DllImport("kpdev.dll")] //only power on ,the last power parameter
    public static extern bool Power_On(int Dev_Port);

    [DllImport("kpdev.dll")] //voltage are hold,current are zero
    public static extern bool Power_Pause(int Dev_Port);

    [DllImport("kpdev.dll")] //power off
    public static extern bool Power_Off(int Dev_Port);

    [DllImport("kpdev.dll")] //power off
    public static extern bool StdMeter_Read(ref  StringBuilder SData, string Smodel, int Dev_Port);

    [DllImport("kpdev.dll")] //start to count error
    public static extern bool Error_Start(int Meter_No, Double Constant, int Pulse, int Dev_Port);

    [DllImport("kpdev.dll")] //rest error calculator unit
    public static extern bool Error_Clear(int Dev_Port);

    [DllImport("kpdev.dll")] //read the test error
    public static extern bool Error_Read(ref StringBuilder MError, int Meter_No, int Dev_Port);

    [DllImport("kpdev.dll")] //read the test error
    public static extern bool Set_485_Channel(int Meter_No, int Open_Flag, int Dev_Port);

    #endregion
}
