using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using MeterTest.Source.Config;
using MeterTest.Source.Dlt645;
using Newtonsoft.Json;

namespace MeterTest.Source.Emu
{
    public enum EmuVariableType 
    {
        IA,
        IB,
        IC,
        IL,
        VA,
        VB,
        VC,
        PA,
        PB,
        PC,
        QA,
        QB,
        QC,
        ANGLE_A,
        ANGLE_B,
        ANGLE_C,
    };
    public class KpTableBodyVariable
    {
        public int VariableIndex;
        public uint VariablePoint;

        public KpTableBodyVariable(uint variablePoint, int variableIndex)
        {
            VariableIndex = variableIndex;
            VariablePoint = variablePoint;
        }
    }
    public abstract class EmuAdj
    {
        protected Dlt645Client client;
        protected IAdjMeterLogger logger;
        protected MeterAddress address;
        protected KpTableBody kpTableBody;

        private readonly List<KpTableBodyVariable> kpTableBodyVariableList = new List<KpTableBodyVariable>()
        {
            new KpTableBodyVariable(1000, 3), /* A相电流 */
            new KpTableBodyVariable(1000, 4), /* B相电流 */
            new KpTableBodyVariable(1000, 5), /* C相电流 */
            new KpTableBodyVariable(1000, 5), /* 零线电流 */
            new KpTableBodyVariable(10,   0), /* A相电压 */
            new KpTableBodyVariable(10,   1), /* B相电压 */
            new KpTableBodyVariable(10,   2), /* C相电压 */
            new KpTableBodyVariable(10,   11), /* A相有功功率 */
            new KpTableBodyVariable(10,   12), /* B相有功功率 */
            new KpTableBodyVariable(10,   13), /* C相有功功率 */
            new KpTableBodyVariable(10,   14), /* A相无功功率 */
            new KpTableBodyVariable(10,   15), /* B相无功功率 */
            new KpTableBodyVariable(10,   16), /* C相无功功率 */
            new KpTableBodyVariable(10,   11), /* A相角差 */
            new KpTableBodyVariable(10,   12), /* B相角差 */
            new KpTableBodyVariable(10,   13), /* C相角差 */
        };

        protected void GetTableBodyPortName()
        {
            Options opt = null;
            if(File.Exists("Options.txt"))
            {
                opt = JsonConvert.DeserializeObject<Options>(File.ReadAllText("Options.txt"));
            }
            else
            {
                opt = new Options();
            }
            this.kpTableBody = new KpTableBody();
            this.kpTableBody.Dev_Port = Convert.ToInt32(opt.KpTableBodyPortName.Replace("COM", ""));
        }

        public void FactoryOut()
        {
            DataId factoryStatusDataId = new DataId(0xA5A01101);
            factoryStatusDataId.DataBytes = 1;
            factoryStatusDataId.DataArray = new byte[]{0xAA};
            client.Write(address, factoryStatusDataId, new Dlt645Password(0x02, 0x123456), new Dlt645OperatorCode());
        }
        public void FactoryOut(MeterAddress addr)
        {
            DataId factoryStatusDataId = new DataId(0xA5A01101);
            factoryStatusDataId.DataBytes = 1;
            factoryStatusDataId.DataArray = new byte[]{0xAA};
            client.Write(addr, factoryStatusDataId, new Dlt645Password(0x02, 0x123456), new Dlt645OperatorCode());
        }
        
        public MeterAddress ReadMeterAddress()
        {
            DataId readAddress = new DataId(0x04000401);
            byte[] data = client.Read(MeterAddress.Wildcard, readAddress);
            return new MeterAddress(data);
        }
        protected double GetVariableError(EmuVariableType type)
        {
            double error = 0;
            const int MAX_CNT = 3;
            try
            {
                for (int i = 0; i < MAX_CNT; i++)
                {
                    Thread.Sleep(3000);
                    double table = GetTableVariable(type);
                    double emu = GetEmuVariable(type);
                    error += (emu - table) / table;
                }
                error /= MAX_CNT;
                logger.IAdjMeterLog(type + ": error = " + error.ToString("F5"));
                if ((error > 0.2) || (error < -0.2))
                {
                    throw new InvalidOperationException(type.ToString() + "-误差为" + (error * 100).ToString("F2") + "%，已超过20% ");
                } 
            }
            catch (System.Exception e)
            {
                string s = e.ToString();
                throw;
            }
            return error;
        }
        protected double GetKpTableVariable(EmuVariableType type)
        {
            double value = 0;
            string status = this.kpTableBody.KpTableBodyRead();
            string[] s = status.Split(',');
            status = s[kpTableBodyVariableList[(int)type].VariableIndex].Trim(new char[]{'V','A','W','v','a','r','w','+','-','0'});
            value = Convert.ToDouble(status);
            return value;
        }
        public void FactoryIn()
        {
            DataId factoryStatusDataId = new DataId(0xA5A01101);
            factoryStatusDataId.DataBytes = 1;
            factoryStatusDataId.DataArray = new byte[]{0x55};
            client.Write(address, factoryStatusDataId, new Dlt645Password(0x02, 0x123456), new Dlt645OperatorCode());
        }
        protected abstract double GetTableVariable(EmuVariableType type);
        protected abstract double GetEmuVariable(EmuVariableType type);
        public abstract void AdjMeter();
        public abstract void Reset();
        public abstract void AdjDataClr();
        public abstract void RegDataInit();
    }
}