using System;
using System.Collections.Generic;

namespace MeterTest.Source.Freeze
{
    public class FreezeData:IComparable
    {
        public DateTime Time { get; set; }
        public Double[] ValueArray { get; set; }
        public Dictionary<string, Double> ValueDic = new Dictionary<string, double>();

        public FreezeData()
        {
        }

        public int CompareTo(object obj)
        {
            return Time.CompareTo(((FreezeData)obj).Time);
        }
        // public DateTime Time { get; set; }
        // public Double ZKwh;
        // public Double FKwh;
        // public Double Kvarh1;
        // public Double Kvarh2;
        // public Double Kvarh3;
        // public Double Kvarh4;
        // public Double ZPowerDemand;
        // public Double FPowerDemand;
        // public Double ZKwhA;
        // public Double FKwhA;
        // public Double KvarhA1;
        // public Double KvarhA2;
        // public Double KvarhA3;
        // public Double KvarhA4;
        // public Double ZPowerDemandA;
        // public Double FPowerDemandA;
        // public Double ZKwhB;
        // public Double FKwhB;
        // public Double KvarhB1;
        // public Double KvarhB2;
        // public Double KvarhB3;
        // public Double KvarhB4;
        // public Double ZPowerDemandB;
        // public Double FPowerDemandB;
        // public Double ZKwhC;
        // public Double FKwhC;
        // public Double KvarhC1;
        // public Double KvarhC2;
        // public Double KvarhC3;
        // public Double KvarhC4;
        // public Double ZPowerDemandC;
        // public Double FPowerDemandC;
        // public Double VA;
        // public Double VB;
        // public Double VC;
        // public Double IA;
        // public Double IB;
        // public Double IC;
        // public Double PA;
        // public Double PB;
        // public Double PC;
        // public Double QA;
        // public Double QB;
        // public Double QC;
        // public Double SA;
        // public Double SB;
        // public Double SC;
        // public Double IL;
        // public Double F;
        // public Double PDemand;
        // public Double T;
        // public Double IS;
    }
}