using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MeterTest.Source.Dlt645;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace MeterTest.Source.Emu
{
    public enum HT7036_NUM
    {
        HT7036_1,
        HT7036_2,
    }
    public class Ht7036Variable
    {
        public Ht7036Variable(EmuVariableType type, int regAddress, double k, bool isDivide)
        {
            Type = type;
            RegAddress = regAddress;
            K = k;
            IsDivide = isDivide;
        }
        public EmuVariableType Type { get; set; }
        public int RegAddress { get; set; }
        public double K{ get; set;}
        public bool IsDivide{ get; set;}
    }
    public class Ht7036 : EmuAdj
    {
        private const short HFCONST_VALUE = 0x79;
        private const short PSTARTUP_VALUE = 0x81;
        private const int   EC_VALUE = 200;
        private readonly List<Ht7036Variable> VariableList = new List<Ht7036Variable>()
        {
            new Ht7036Variable(EmuVariableType.IA, 0x10, 8192,     true), /* A相电流 */
            new Ht7036Variable(EmuVariableType.IB, 0x11, 8192,     true), /* B相电流 */
            new Ht7036Variable(EmuVariableType.IC, 0x12, 8192,     true), /* C相电流 */
    
            new Ht7036Variable(EmuVariableType.VA, 0x0D, 8192,     true), /* A相电压 */
            new Ht7036Variable(EmuVariableType.VB, 0x0E, 8192,     true), /* B相电压 */
            new Ht7036Variable(EmuVariableType.VC, 0x0F, 8192,     true), /* C相电压 */

            new Ht7036Variable(EmuVariableType.PA, 0x01, 0.128746, false), /* A相有功功率 */
            new Ht7036Variable(EmuVariableType.PB, 0x02, 0.128746, false), /* B相有功功率 */
            new Ht7036Variable(EmuVariableType.PC, 0x03, 0.128746, false), /* C相有功功率 */

            new Ht7036Variable(EmuVariableType.QA, 0x05, 0.128746, false), /* A相有功功率 */
            new Ht7036Variable(EmuVariableType.QB, 0x06, 0.128746, false), /* B相有功功率 */
            new Ht7036Variable(EmuVariableType.QC, 0x07, 0.128746, false), /* C相有功功率 */
        };
        private static readonly List<DataId> AdjDataInitList = new List<DataId>()
        {
            new DataId(0xA0100000, HFCONST_VALUE), /* 高频脉冲输出设置  */
            new DataId(0xA0100001, new byte[]{0x7E, 0xB9}), /* 模式相关控制      */
            new DataId(0xA0100002, new byte[]{0x00, 0x00}), /* ADC增益选择       */
            new DataId(0xA0100003, new byte[]{0x84, 0xF8}), /* EMU模块配置寄存器 */
            new DataId(0xA010001c, PSTARTUP_VALUE), /* 起动功率阈值设置  */
        };

        public Ht7036()
        {
        }

        public Ht7036(Dlt645Client client, IAdjMeterLogger logger)
        {
            this.client = client;
            this.logger = logger;
            GetTableBodyPortName();
        }

        public static List<Ht7036Register> ExcelConvertToRegisterList(string excelFilePath, string sheetName)
        {
            if(excelFilePath == null)
            {
                throw new ArgumentNullException("excelFilePath == null");
            }
            List<Ht7036Register> list = new List<Ht7036Register>();
            IWorkbook workbook = null;
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                if(Path.GetExtension(excelFilePath) == ".xlsx")
                {
                    workbook = new XSSFWorkbook(fileStream);
                }
                else
                {
                    workbook = new HSSFWorkbook(fileStream);
                }
                ISheet sheet = workbook.GetSheet(sheetName);
                for (int i = 1; i < sheet.LastRowNum + 1; i++)
                {
                    IRow row = sheet.GetRow(i);
                    Ht7036Register reg = new Ht7036Register();
                    string tmp = null;
                    ICell cell = row.GetCell(0);
                    if(cell.CellType == CellType.Numeric)
                    {
                        tmp = cell.NumericCellValue.ToString();
                    }
                    else
                    {
                        tmp = cell.StringCellValue;
                    }
                    reg.Address = Convert.ToInt32(tmp, 16);
                    reg.Name = row.GetCell(1).StringCellValue;
                    reg.ValueBytes = (int)row.GetCell(2).NumericCellValue;

                    tmp = row.GetCell(3).StringCellValue;
                    tmp = tmp.Substring(2, tmp.Length - 2).Trim();
                    reg.ResetValue =  Convert.ToInt32(tmp, 16);

                    reg.Describe = row.GetCell(4).StringCellValue;
                    reg.IsEeprom = row.GetCell(5).StringCellValue == "是"? true : false;

                    if(row.GetCell(6) != null)
                    {
                        tmp = row.GetCell(6).StringCellValue;
                        tmp = tmp.Substring(2, tmp.Length - 2).Trim();
                        reg.DefaultValue = Convert.ToInt32(tmp, 16);
                    }

                    list.Add(reg);
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                if(workbook != null)
                {
                    workbook.Close();
                }
                if(fileStream != null)
                {
                    fileStream.Close();
                }
            }
            return list;
        }

        public override void AdjDataClr()
        {
            client.Write(address, new DataId(0xA0120001, 0x00), new Dlt645Password(), new Dlt645OperatorCode());
        }

        public override void AdjMeter()
        {
            try
            {
                logger.IAdjMeterLog("1.正在升源。。。");
                kpTableBody.PowerOn();
                kpTableBody.PowerPause();
                this.address = ReadMeterAddress();
                logger.IAdjMeterLog("2.读取表号完成，表号：" + address.ToString());
                FactoryIn();
                logger.IAdjMeterLog("3.已切换至厂内状态");
                AdjDataClr();
                logger.IAdjMeterLog("4.校表数据清零完成");
                RegDataInit();
                Reset();
                logger.IAdjMeterLog("5.校表数据初始化完成");                
                AdjMeter1_0();
                logger.IAdjMeterLog("6.Un Ib 1.0 校准完成");
                AdjMeter0_5L();
                logger.IAdjMeterLog("7.Un Ib 0.5L 校准完成");
                // AdjMeter0_05();
                // logger.IAdjMeterLog("8.Un 5%Ib 1.0 校准完成");
                Reset();
                Thread.Sleep(1000);
                FactoryOut();
                logger.IAdjMeterLog("8.已切换至厂外状态");
                logger.IAdjMeterLog("校表完成。");
            }
            catch (System.Exception e)
            {
                logger.IAdjMeterLog(e.ToString());
                logger.IAdjMeterLog("校表失败！");
            }
            finally
            {
                kpTableBody.PowerOff();
                logger.CloseLock();
            }
        }
        
        private void AdjMeter1_0()
        {
            kpTableBody.IABC = "H";
            kpTableBody.Curr1 = 100; // 负载点电压百分数 100表示100%
            kpTableBody.Curr2 = 100; //
            kpTableBody.Curr3 = 100;
            kpTableBody.CosP = "1.0";
            kpTableBody.PowerOn();
            Thread.Sleep(3000);
            // logger.IAdjMeterLog("1.0 校准前。。。");
            client.Write(address, new DataId(0xA0100016, CalGain(GetVariableError(EmuVariableType.VA))));
            client.Write(address, new DataId(0xA0100017, CalGain(GetVariableError(EmuVariableType.VB))));
            client.Write(address, new DataId(0xA0100018, CalGain(GetVariableError(EmuVariableType.VC))));

            client.Write(address, new DataId(0xA0100019, CalGain(GetVariableError(EmuVariableType.IA))));
            client.Write(address, new DataId(0xA010001A, CalGain(GetVariableError(EmuVariableType.IB))));
            client.Write(address, new DataId(0xA010001B, CalGain(GetVariableError(EmuVariableType.IC))));
            Reset();
            Thread.Sleep(1000);

            short pGain = CalGain(GetVariableError(EmuVariableType.PA));
            client.Write(address, new DataId(0xA0100004, pGain));
            client.Write(address, new DataId(0xA0100007, pGain));
            client.Write(address, new DataId(0xA010000A, pGain));

            pGain = CalGain(GetVariableError(EmuVariableType.PB));
            client.Write(address, new DataId(0xA0100005, pGain));
            client.Write(address, new DataId(0xA0100008, pGain));
            client.Write(address, new DataId(0xA010000B, pGain));

            pGain = CalGain(GetVariableError(EmuVariableType.PC));
            client.Write(address, new DataId(0xA0100006, pGain));
            client.Write(address, new DataId(0xA0100009, pGain));
            client.Write(address, new DataId(0xA010000C, pGain));
            Reset();
            // Thread.Sleep(1000);
            // logger.IAdjMeterLog("1.0 校准后。。。");
            // GetVariableError(EmuVariableType.VA);
            // GetVariableError(EmuVariableType.VB);
            // GetVariableError(EmuVariableType.VC);
            // GetVariableError(EmuVariableType.IA);
            // GetVariableError(EmuVariableType.IB);
            // GetVariableError(EmuVariableType.IC);
            // GetVariableError(EmuVariableType.PA);
            // GetVariableError(EmuVariableType.PB);
            // GetVariableError(EmuVariableType.PC);
        }
        
        private void AdjMeter0_5L()
        {
            kpTableBody.IABC = "H";
            kpTableBody.CosP = "0.5L";
            kpTableBody.PowerOn();
            Thread.Sleep(5000);
            // logger.IAdjMeterLog("0.5L 校准前。。。");
            short phase = CalPhase(GetVariableError(EmuVariableType.PA));
            client.Write(address, new DataId(0xA010000D, phase));
            client.Write(address, new DataId(0xA0100010, phase));
            client.Write(address, new DataId(0xA0100020, phase));

            phase = CalPhase(GetVariableError(EmuVariableType.PB));
            client.Write(address, new DataId(0xA010000E, phase));
            client.Write(address, new DataId(0xA0100011, phase));
            client.Write(address, new DataId(0xA0100021, phase));

            phase = CalPhase(GetVariableError(EmuVariableType.PC));
            client.Write(address, new DataId(0xA010000F, phase));
            client.Write(address, new DataId(0xA0100012, phase));
            client.Write(address, new DataId(0xA0100022, phase));
            
            // Reset();
            // Thread.Sleep(1000);
            // logger.IAdjMeterLog("0.5L 校准后。。。");
            // GetVariableError(EmuVariableType.VA);
            // GetVariableError(EmuVariableType.VB);
            // GetVariableError(EmuVariableType.VC);
            // GetVariableError(EmuVariableType.IA);
            // GetVariableError(EmuVariableType.IB);
            // GetVariableError(EmuVariableType.IC);
            // GetVariableError(EmuVariableType.PA);
            // GetVariableError(EmuVariableType.PB);
            // GetVariableError(EmuVariableType.PC);
            // GetVariableError(EmuVariableType.QA);
            // GetVariableError(EmuVariableType.QB);
            // GetVariableError(EmuVariableType.QC);
        }

        private void AdjMeter0_05()
        {
            kpTableBody.IABC = "H";
            kpTableBody.Curr1 = 5;
            kpTableBody.Curr2 = 5;
            kpTableBody.Curr3 = 5;
            kpTableBody.CosP = "1.0";
            kpTableBody.PowerOn();
            Thread.Sleep(5000);
            logger.IAdjMeterLog("5% Ib 校准前。。。");
            int offset = GetOffset(GetVariableError(EmuVariableType.PA));
            short data = (short)((offset & 0xFFFF000) >> 16);
            client.Write(address, new DataId(0xA0100013, data));
            client.Write(address, new DataId(0xA010001d, data));

            offset = GetOffset(GetVariableError(EmuVariableType.PB));
            data = (short)((offset & 0xFFFF000) >> 16);
            client.Write(address, new DataId(0xA0100014, data));
            client.Write(address, new DataId(0xA010001E, data));

            offset = GetOffset(GetVariableError(EmuVariableType.PC));
            data = (short)((offset & 0xFFFF000) >> 16);
            client.Write(address, new DataId(0xA0100015, data));
            client.Write(address, new DataId(0xA010001F, data));
            Reset();
            Thread.Sleep(1000);
            logger.IAdjMeterLog("5% Ib 校准后。。。");
            // GetVariableError(EmuVariableType.VA);
            // GetVariableError(EmuVariableType.VB);
            // GetVariableError(EmuVariableType.VC);
            GetVariableError(EmuVariableType.IA);
            GetVariableError(EmuVariableType.IB);
            GetVariableError(EmuVariableType.IC);
            GetVariableError(EmuVariableType.PA);
            GetVariableError(EmuVariableType.PB);
            GetVariableError(EmuVariableType.PC);
            GetVariableError(EmuVariableType.QA);
            GetVariableError(EmuVariableType.QB);
            GetVariableError(EmuVariableType.QC);
        }
        private int GetOffset(double error)
        {
            int value = (int)(0.05 * 5 * 220 * EC_VALUE * Math.Pow(2, 31) * (- error) * HFCONST_VALUE / 2.592 / Math.Pow(10, 10));
            if(value < 0)
            {
                value = (int)(Math.Pow(2, 32) - value);
            }
            return value;
        }

        private short CalGain(double error)
        {
            short value;
            error = -error / (1 + error);
            if(error >= 0)
            {
                value = (short)(error * Math.Pow(2, 15));
            }
            else
            {
                value = (short)(Math.Pow(2, 16) + error * Math.Pow(2, 15));
            }
            return value;
        }
        private short CalPhase(double error)
        {
            short value;
            error = -error / 1.73205;
            if(error >= 0)
            {
                value = (short)(error * Math.Pow(2, 15));
            }
            else
            {
                value = (short)(Math.Pow(2, 16) + error * Math.Pow(2, 15));
            }
            return value;
        }
        
        public bool ChooseHt7036Num(HT7036_NUM Num)
        {
            bool rst = false;
            
            return rst;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void RegDataInit()
        {
            foreach (var item in AdjDataInitList)
            {
                client.Write(address, item, new Dlt645Password(), new Dlt645OperatorCode());
                Thread.Sleep(500);
            }
        }

        public override void Reset()
        {
            client.Write(address, new DataId(0xA0120000, 0x00), new Dlt645Password(), new Dlt645OperatorCode());
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override double GetEmuVariable(EmuVariableType type)
        {
            int i;
            for (i = 0; i < VariableList.Count; i++)
            {
                if(type == VariableList[i].Type)
                {
                    break;
                }
            }
            if(i >= VariableList.Count)
            {
                throw new InvalidOperationException(type + " is not a variable");
            }
            double value = 0;
            byte[] regbytes = client.Read(address, new DataId((uint)(0xA0110000 + VariableList[i].RegAddress)));
            int regValue = 0;
            for (int j = regbytes.Length - 1; j >= 0; j--)
            {
                regValue = (regValue * 256) + regbytes[j];
            }
            if((regValue & 0x800000) != 0)
            {
                regValue = regValue - 0x1000000;
            }
            if(VariableList[i].IsDivide)
            {
                value = regValue / VariableList[i].K;
            }
            else
            {
                value = regValue * VariableList[i].K;
            }
            return value;
        }

        protected override double GetTableVariable(EmuVariableType type)
        {
            return GetKpTableVariable(type);
        }
    }
    public class Ht7036Register
    {
        public string Name{get; set; }
        public int Address{get; set; }
        public int ResetValue{get; set; }
        public int DefaultValue{get; set; }
        public int ValueBytes{get; set; }
        public string Describe{get; set; }
        public bool IsEeprom{get; set; }
        protected Ht7036Register(string name, int address, int resetValue, int defaultValue, int valueBytes, string describe) 
        {
            this.Name = name;
            this.Address = address;
            this.ResetValue = resetValue;
            this.DefaultValue = defaultValue;
            this.ValueBytes = valueBytes;
            this.Describe = describe;
        }

        public Ht7036Register()
        {
        }
        public string GetRegAddressEnum(int padLength)
        {
            string rst = null;
            // char[] splitCharArray = new char[]{' ', '\\', ' '};
            rst += "    HT7036_REG_ADDR_";
            rst += Name.Trim(splitCharArray).ToUpper().PadRight(25).Replace('/', '_');
            rst += "= ";
            rst += ("0x" + this.Address.ToString("X2"));
            rst += ",  ";
            rst += "/* ";
            
            rst += ("0x" + this.ResetValue.ToString("X" + (this.ValueBytes * 2)).PadRight(10));
            rst += this.Describe.PadRight(10 + padLength);
            rst += "*/";
            return rst;
        }
        char[] splitCharArray = new char[]{' ', '\\', ' ', '\n'};
        public string GetRegDefaultValueString(int padLength)
        {
            string rst = null;
            
            rst += "    {HT7036_REG_ADDR_";
            rst += Name.Trim(splitCharArray).ToUpper().PadRight(15);
            rst += ", ";
            rst += ("0x" + this.DefaultValue.ToString("X4").PadRight(9));
            rst += ", }, /* ";
            rst += this.ValueBytes.ToString().PadRight(3);
            rst += this.Describe.PadRight(10 + padLength);
            rst += " */";
            return rst;
        }

        public int GetHanCountDescribe()
        {
            int count = 0;
            for (int i = 0; i < this.Describe.Length; i++)
            {
                ushort s = this.Describe.ToCharArray()[i];
                if((s >= 0x4E00) 
                && (s <= 0x9FA5))
                {
                    count++;
                }
            }
            return count;
        }
    }
}