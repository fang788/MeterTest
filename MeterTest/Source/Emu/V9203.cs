using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using MeterTest.Source.Dlt645;
using MeterTest.Source.Config;
using Newtonsoft.Json;

namespace MeterTest.Source.Emu
{
    public class V9203
    {
        public readonly List<DataId> dataIdRegList = new List<DataId>()
        {
            new DataId("起动/潜动门限值上限寄存器"        , 0xA0000000, 0x00000444),
            new DataId("起动/潜动门限值下限寄存器"        , 0xA0000001, 0x00000416),
            // new DataId("分段0角差寄存器"                  , 0xA0000002, 0x00000000),
            // new DataId("A相全波有功功率比差分段0寄存器"   , 0xA0000003, 0x00000000),
            // new DataId("B相全波有功功率比差分段0寄存器"   , 0xA0000004, 0x00000000),
            // new DataId("C相全波有功功率比差分段0寄存器"   , 0xA0000005, 0x00000000),
            // new DataId("A相全波无功功率比差寄存器"        , 0xA0000006, 0x00000000),
            // new DataId("B相全波无功功率比差寄存器"        , 0xA0000007, 0x00000000),
            // new DataId("C相全波无功功率比差寄存器"        , 0xA0000008, 0x00000000),
            // new DataId("A相全波电流有效值比差寄存器"      , 0xA0000009, 0x00000000),
            // new DataId("B相全波电流有效值比差寄存器"      , 0xA000000A, 0x00000000),
            // new DataId("C相全波电流有效值比差寄存器"      , 0xA000000B, 0x00000000),
            // new DataId("全波零线电流有效值比差寄存器"     , 0xA000000C, 0x00000000),
            // new DataId("A相全波电压有效值比差寄存器"      , 0xA000000D, 0x00000000),
            // new DataId("B相全波电压有效值比差寄存器"      , 0xA000000E, 0x00000000),
            // new DataId("C相全波电压有效值比差寄存器"      , 0xA000000F, 0x00000000),
            // new DataId("A相有功功率二次补偿寄存器"        , 0xA0000010, 0x00000000),
            // new DataId("B相有功功率二次补偿寄存器"        , 0xA0000011, 0x00000000),
            // new DataId("C相有功功率二次补偿寄存器"        , 0xA0000012, 0x00000000),
            // new DataId("A相无功功率二次补偿寄存器"        , 0xA0000013, 0x00000000),
            // new DataId("B相无功功率二次补偿寄存器"        , 0xA0000014, 0x00000000),
            // new DataId("C相无功功率二次补偿寄存器"        , 0xA0000015, 0x00000000),
            // new DataId("A相全波电流有效值二次补偿寄存器"  , 0xA0000016, 0x00000000),
            // new DataId("B相全波电流有效值二次补偿寄存器"  , 0xA0000017, 0x00000000),
            // new DataId("C相全波电流有效值二次补偿寄存器"  , 0xA0000018, 0x00000000),
            // new DataId("全波零线电流有效值二次补偿寄存器" , 0xA0000019, 0x00000000),
            // new DataId("能量累加门限值寄存器高位"         , 0xA000001A, 0x00000000),
            new DataId("能量累加门限值寄存器低位"         , 0xA000001B,  0xE258C4),
            new DataId("模拟控制寄存器0"                  , 0xA000001C, 0x00070000),
            new DataId("计量控制寄存器2"                  , 0xA000001D, 0x0302A033),
        };  
        /*
            220.06V,219.98V,220.00V,
            004.9990A,004.9998A,004.9987A,
            120.02,240.05,000.00,000.00,000.00,
            +01099.99w,+01099.84w,+01099.70w,
            +00000.10Var,-00001.28Var,-00000.33Var,+03299.54W,+00000.00Var,+00000.00VA
         */
        private readonly List<V9203Adj> v9203AdjList = new List<V9203Adj>()
        {
            new V9203Adj(0x02020100, 1000, 0xA0000009, 3), /* A相电流 */
            new V9203Adj(0x02020200, 1000, 0xA000000A, 4), /* B相电流 */
            new V9203Adj(0x02020300, 1000, 0xA000000B, 5), /* C相电流 */
            new V9203Adj(0x02800001, 1000, 0xA000000C, 5), /* 零线电流 */
            new V9203Adj(0x02010100, 10,   0xA000000D, 0), /* A相电压 */
            new V9203Adj(0x02010200, 10,   0xA000000E, 1), /* B相电压 */
            new V9203Adj(0x02010300, 10,   0xA000000F, 2), /* C相电压 */
            new V9203Adj(0x02030100, 10,   0xA0000003, 11), /* A相有功功率 */
            new V9203Adj(0x02030200, 10,   0xA0000004, 12), /* B相有功功率 */
            new V9203Adj(0x02030300, 10,   0xA0000005, 13), /* C相有功功率 */
            new V9203Adj(0x02040100, 10,   0xA0000006, 14), /* A相无功功率 */
            new V9203Adj(0x02040200, 10,   0xA0000007, 15), /* B相无功功率 */
            new V9203Adj(0x02040300, 10,   0xA0000008, 16), /* C相无功功率 */
            new V9203Adj(0x02030100, 10,   0xA0000002, 11), /* A相角差 */
            new V9203Adj(0x02030200, 10,   0xA0000002, 12), /* B相角差 */
            new V9203Adj(0x02030300, 10,   0xA0000002, 13), /* C相角差 */
        }; 
        enum V9203VariableType 
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
        public readonly DataId dataIdClrReg = new DataId("校表数据清零", 0xA0020001, "HEX", 1, new byte[]{0x00}, "", false, true);
        public readonly DataId dataIdReset = new DataId("复位", 0xA0020000, "HEX", 1, new byte[]{0x00}, "", false, true);
        private Dlt645Client client;
        private IAdjMeterLogger logger;
        private MeterAddress address;
        private KpTableBody tableBody;

        public V9203()
        {
            GetTableBodyPortName();
        }

        public V9203(Dlt645Client client, IAdjMeterLogger logger)
        {
            this.client = client;
            this.logger = logger;
            GetTableBodyPortName();
        }
        private void GetTableBodyPortName()
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
            this.tableBody = new KpTableBody();
            this.tableBody.Dev_Port = Convert.ToInt32(opt.KpTableBodyPortName.Replace("COM", ""));
            //tableBody.PowerOn();
            //string s = tableBody.KpTableBodyRead();
        }

        // private Dlt645Password password = new Dlt645Password();
        // private Dlt645OperatorCode operatorCode = new Dlt645OperatorCode();
        public void RegDataClr()
        {
            client.Write(address, dataIdClrReg, new Dlt645Password(), new Dlt645OperatorCode());
        }
        public void Reset()
        {
            client.Write(address, dataIdReset, new Dlt645Password(), new Dlt645OperatorCode());
            // Thread.Sleep(2000);
        }
        public void RegDataInit()
        {
            foreach (var item in dataIdRegList)
            {
                client.Write(address, item, new Dlt645Password(), new Dlt645OperatorCode());
                Thread.Sleep(500);
            }
        }
        public MeterAddress ReadMeterAddress()
        {
            DataId readAddress = new DataId(0x04000401);
            byte[] data = client.Read(MeterAddress.Wildcard, readAddress);
            return new MeterAddress(data);
        }
        public void FactoryIn(MeterAddress addr)
        {
            DataId factoryStatusDataId = new DataId(0xA5A01101);
            factoryStatusDataId.DataBytes = 1;
            factoryStatusDataId.DataArray = new byte[]{0x55};
            client.Write(addr, factoryStatusDataId, new Dlt645Password(0x02, 0x123456), new Dlt645OperatorCode());
        }
        public void FactoryIn()
        {
            DataId factoryStatusDataId = new DataId(0xA5A01101);
            factoryStatusDataId.DataBytes = 1;
            factoryStatusDataId.DataArray = new byte[]{0x55};
            client.Write(address, factoryStatusDataId, new Dlt645Password(0x02, 0x123456), new Dlt645OperatorCode());
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
        private double GetVariableError(V9203VariableType type)
        {
            DataId dataId = new DataId(v9203AdjList[(int)type].VariableDataId);
            double zdPA = 0;
            byte[] data;
            double tmp;
            double error = 0;
            string status;
            int i;
            try
            {
                for (i = 0; i < 5; i++)
                {
                    Thread.Sleep(3000);
                    status = this.tableBody.KpTableBodyRead();
                    status = status.Split(',')[v9203AdjList[(int)type].VariableIndex].Trim(new char[]{'V','A','W','v','a','r','w','+','-'});
                    double tb = Convert.ToDouble(status);
                    data = client.Read(address, dataId);
                    tmp = 0;
                    for (int j = data.Length - 1; j >= 0; j--)
                    {
                        tmp = tmp * 100 + (data[j] >> 4) * 10 + (data[j] & 0x0F);
                    }
                    zdPA += tmp;
                    zdPA /= v9203AdjList[(int)type].VariablePoint;
                    zdPA = (zdPA - tb) / tb;
                    error +=  zdPA;
                }
                error /= 5;
                // logger.IAdjMeterLog(type.ToString() + "误差：" + (error * 100).ToString("F2") + "%");
                //Thread.Sleep(5000);
                if ((error > 0.1) || (error < -0.1))
                {
                    throw new InvalidOperationException(type.ToString() + "-误差为" + (error * 100).ToString("F2") + "%，已超过10% ");
                } 
            }
            catch (System.Exception e)
            {
                string s = e.ToString();
                throw;
            }
            
            return error;
        }
        private double[] GetVariableError(V9203VariableType[] array)
        {
            byte[] data;
            double tmp;
            string status;
            double[] error = new double[array.Length];
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    status = this.tableBody.KpTableBodyRead();
                    double[] tb = new double[array.Length];
                    for (int k = 0; k < array.Length; k++)
                    {
                        V9203VariableType type = array[k];
                        string s = status.Split(',')[v9203AdjList[(int)type].VariableIndex].Trim(new char[]{'V','A','W','v','a','r','w','+','-'});
                        tb[k] = Convert.ToDouble(s);
                        DataId dataId = new DataId(v9203AdjList[(int)type].VariableDataId);
                        data = client.Read(address, dataId);
                        tmp = 0;
                        for (int j = data.Length - 1; j >= 0; j--)
                        {
                            tmp = tmp * 100 + (data[j] >> 4) * 10 + (data[j] & 0x0F);
                        }
                        tmp = tmp / v9203AdjList[(int)type].VariablePoint;
                        error[k] += ((tmp - tb[k]) / tb[k]);
                    }
                    Thread.Sleep(2000);
                }
                for (int i = 0; i < array.Length; i++)
                {
                    error[i] /= 5;
                    if((error[i] > 0.1) || (error[i] < -0.1))
                    {
                        throw new InvalidOperationException("当前误差超过±10%，当前误差为" + (error[i] * 100).ToString("F2") + "%");
                    } 
                }                
            }
            catch (System.Exception e)
            {
                string s = e.ToString();
                throw;
            }
            
            return error;
        }

        private void AdjVariableError(V9203VariableType type, uint adj)
        {
            // double error = GetVariableError(type);
            // uint adj = (uint)(2147483648 * ((1 / (1 + error)) - 1));
            // logger.IAdjMeterLog(type.ToString() + "误差：" + (error * 100).ToString("F4") + " 校准值：0x" + adj.ToString("X8"));
            DataId dataId = new DataId(v9203AdjList[(int)type].RegDataId);
            dataId.DataBytes = 4;
            dataId.DataArray = new byte[dataId.DataBytes];
            for (int i = 0; i < dataId.DataBytes; i++)
            {
                dataId.DataArray[i] = (byte)(adj >> (i * 8));
            }
            client.Write(address, dataId);
        }
        private void AdjAngleError(V9203VariableType type, byte adj)
        {
            // double error = GetVariableError(type);
            // byte adj = (byte)(3011 / 2 * error);
            DataId dataId = new DataId(v9203AdjList[(int)type].RegDataId);
            byte[] data = client.Read(address, dataId);
            dataId.DataBytes = 4;
            dataId.DataArray = data;
            if(type == V9203VariableType.ANGLE_A)
            {
                dataId.DataArray[0] = adj;
            }
            if(type == V9203VariableType.ANGLE_B)
            {
                dataId.DataArray[1] = adj;
            }
            if(type == V9203VariableType.ANGLE_C)
            {
                dataId.DataArray[2] = adj;
            }
            client.Write(address, dataId);
        }
        private void AdjMeterA()
        {
            TableBodyError error = new TableBodyError();
            tableBody.IABC = "A";
            tableBody.CosP = "1.0";
            tableBody.PowerOn();
            Thread.Sleep(3000);
            error.P0 = GetVariableError(V9203VariableType.PA);

            tableBody.IABC = "A";
            tableBody.CosP = "0.5L";
            tableBody.PowerOn();
            Thread.Sleep(5000);
            // V9203VariableType[] array = new V9203VariableType[]
            // {
            //     V9203VariableType.PA, 
            //     V9203VariableType.QA,
            //     V9203VariableType.VA,
            //     V9203VariableType.IA,
            // };
            // double[] vError = GetVariableError(array);
            // error.P60 = vError[0];
            // error.Q60 = vError[1];
            // error.V = vError[2];
            // error.I = vError[3];
            error.P60 = GetVariableError(V9203VariableType.PA);
            error.Q60 = GetVariableError(V9203VariableType.QA);
            error.V = GetVariableError(V9203VariableType.VA);
            error.I = GetVariableError(V9203VariableType.IA);
            error.ErrorUpdate();
            AdjVariableError(V9203VariableType.IA, error.GetIAdj());
            AdjVariableError(V9203VariableType.VA, error.GetVAdj());
            AdjVariableError(V9203VariableType.PA, error.GetPAdj());
            AdjVariableError(V9203VariableType.QA, error.GetQAdj());
            AdjAngleError(V9203VariableType.ANGLE_A, error.GetAngleAdj());
        }
        private void AdjMeterB()
        {
            TableBodyError error = new TableBodyError();
            tableBody.IABC = "B";
            tableBody.CosP = "1.0";
            tableBody.PowerOn();
            Thread.Sleep(3000);
            error.P0 = GetVariableError(V9203VariableType.PB);

            tableBody.IABC = "B";
            tableBody.CosP = "0.5L";
            tableBody.PowerOn();
            Thread.Sleep(5000);
            // V9203VariableType[] array = new V9203VariableType[]
            // {
            //     V9203VariableType.PB, 
            //     V9203VariableType.QB,
            //     V9203VariableType.VB,
            //     V9203VariableType.IB,
            // };
            // double[] vError = GetVariableError(array);
            // error.P60 = vError[0];
            // error.Q60 = vError[1];
            // error.V = vError[2];
            // error.I = vError[3];
            error.P60 = GetVariableError(V9203VariableType.PB);
            error.Q60 = GetVariableError(V9203VariableType.QB);
            error.V = GetVariableError(V9203VariableType.VB);
            error.I = GetVariableError(V9203VariableType.IB);
            error.ErrorUpdate();
            AdjVariableError(V9203VariableType.IB, error.GetIAdj());
            AdjVariableError(V9203VariableType.VB, error.GetVAdj());
            AdjVariableError(V9203VariableType.PB, error.GetPAdj());
            AdjVariableError(V9203VariableType.QB, error.GetQAdj());
            AdjAngleError(V9203VariableType.ANGLE_B, error.GetAngleAdj());
        }
        private void AdjMeterC()
        {
            TableBodyError error = new TableBodyError();
            tableBody.IABC = "C";
            tableBody.CosP = "1.0";
            tableBody.PowerOn();
            Thread.Sleep(3000);
            error.P0 = GetVariableError(V9203VariableType.PC);

            tableBody.IABC = "C";
            tableBody.CosP = "0.5L";
            tableBody.PowerOn();
            Thread.Sleep(7000);
            // V9203VariableType[] array = new V9203VariableType[]
            // {
                // V9203VariableType.PC, 
                // V9203VariableType.QC,
                // V9203VariableType.VC,
                // V9203VariableType.IC,
            // };
            // double[] vError = GetVariableError(array);
            // error.P60 = vError[0];
            // error.Q60 = vError[1];
            // error.V = vError[2];
            // error.I = vError[3];
            error.P60 = GetVariableError(V9203VariableType.PC);
            error.Q60 = GetVariableError(V9203VariableType.QC);
            error.V = GetVariableError(V9203VariableType.VC);
            error.I = GetVariableError(V9203VariableType.IC);
            error.ErrorUpdate();
            AdjVariableError(V9203VariableType.IC, error.GetIAdj());
            AdjVariableError(V9203VariableType.VC, error.GetVAdj());
            AdjVariableError(V9203VariableType.PC, error.GetPAdj());
            AdjVariableError(V9203VariableType.QC, error.GetQAdj());
            AdjAngleError(V9203VariableType.ANGLE_C, error.GetAngleAdj());
        }
        public void AdjMeter()
        {
            try
            {
                logger.IAdjMeterLog("1.正在升源。。。");
                tableBody.PowerOn();
                tableBody.PowerPause();
                this.address = ReadMeterAddress();
                logger.IAdjMeterLog("2.读取表号完成，表号：" + address.ToString());
                FactoryIn();
                logger.IAdjMeterLog("3.已切换至厂内状态");
                RegDataClr();
                logger.IAdjMeterLog("4.校表数据清零完成");
                RegDataInit();
                Reset();
                logger.IAdjMeterLog("5.校表数据初始化完成");
                AdjMeterA();
                logger.IAdjMeterLog("6.A相校准完成");
                AdjMeterB();
                logger.IAdjMeterLog("7.B相校准完成");
                AdjMeterC();
                logger.IAdjMeterLog("8.C相校准完成");
                Reset();
                // Thread.Sleep(1000);
                FactoryOut();
                logger.IAdjMeterLog("9.已切换至厂外状态");
                logger.IAdjMeterLog("校表完成。");
            }
            catch (System.Exception e)
            {
                logger.IAdjMeterLog(e.Message);
                logger.IAdjMeterLog("校表失败！");
            }
            finally
            {
                tableBody.PowerOff();
            }
        }
    }
    class V9203Adj
    {
        public int VariableIndex;
        public uint VariableDataId;
        public uint VariablePoint;
        public uint RegDataId;

        public V9203Adj(uint variableDataId, uint variablePoint, uint regDataId, int index)
        {
            VariableDataId = variableDataId;
            VariablePoint = variablePoint;
            RegDataId = regDataId;
            VariableIndex = index;
        }
    }
    class TableBodyError
    {
        public double P0; // 有功功率0°
        public double P60; // 有功功率60°
        public double Q60; // 无功功率60°
        public double I;
        public double V;

        private double M;
        private double x;
        private double xdu;
        private double k;
        private double err60;
        private double err0;
        private double G;
        private double err0v;

        public TableBodyError(double p0, double p60, double q60, double i, double v)
        {
            P0 = p0;
            P60 = p60;
            Q60 = q60;
            I = i;
            V = v;
        }

        public TableBodyError()
        {
        }

        public void ErrorUpdate()
        {
            M = (0.5 + (0.5 * P60))/( 1 + P0);
            double tmp = (1 - 2 * M) / Math.Sqrt(3);
            x = Math.Atan((1 - 2 * M) / Math.Sqrt(3)); // ATAN((1-2*G2)/SQRT(3));
            xdu = x / Math.PI * 180;// G3/PI()*180
            k = (1 + P0) / Math.Cos(x); //(1+D2)/COS(G3)
            err60 = (Math.Cos(Math.PI / 3 + x) - 0.5) / 0.5; // (COS(PI()/3+G3)-0.5)/0.5
            err0 = k - 1;
            G = (Math.Sqrt(3)/2+(Math.Sqrt(3)/2) * Q60)/Math.Sin(Math.PI/3+x); // (SQRT(3)/2+(SQRT(3)/2)*D4)/SIN(PI()/3+G3)
            err0v = G - 1;
        }
        public uint GetIAdj()
        {
           return (uint)(2147483648 * ((1 / (1 + this.I)) - 1));
        }
        public uint GetVAdj()
        {
           return (uint)(2147483648 * ((1 / (1 + this.V)) - 1));
        }
        public uint GetPAdj()
        {
            return (uint)(2147483648 * ((1 / (1 + this.err0)) - 1));
        }
        public uint GetQAdj()
        {
            return (uint)(2147483648 * ((1 / (1 + this.err0v)) - 1));
        }
        public byte GetAngleAdj()
        {
            double adj = ((3011 / 2) * err60 * 819200 / 819200);
            if(adj > 0)
            {
                adj = adj + 128;
            }
            else
            {
                adj = - adj;
            }
            return (byte)adj;
        }
    }
}