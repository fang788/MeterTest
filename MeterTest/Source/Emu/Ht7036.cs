using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace MeterTest.Source.Emu
{
    public class Ht7036
    {
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