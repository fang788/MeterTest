using MeterTest.Source.Dlt645;
using MeterTest.Source.WindowsForm;
using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeterTest.Source.SQLite
{
    public partial class DataIdAddListForm : Form
    {
        // DataIdDbContext dataIdDb = FormMain.DataIdDb;

        public bool IsChg = false;

        // List<DataId> dataIdList = new List<DataId>();
        public DataIdAddListForm()
        {
            InitializeComponent();
        }

        private void DataIdAddListForm_Load(object sender, EventArgs e)
        {
            //设置数据表格为只读
            dataGridViewDataIdList.ReadOnly = true;
            //不允许添加行
            dataGridViewDataIdList.AllowUserToAddRows = false;
            //背景为白色
            dataGridViewDataIdList.BackgroundColor = Color.White;
            //只允许选中单行
            dataGridViewDataIdList.MultiSelect = false;
            //设置数据表格上显示的列标题
            dataGridViewDataIdList.Columns.Add("No", "编号");
            dataGridViewDataIdList.Columns.Add("Id", "数据标识");
            dataGridViewDataIdList.Columns.Add("Format", "数据格式");
            dataGridViewDataIdList.Columns.Add("DataBytes", "数据长度（字节）");
            dataGridViewDataIdList.Columns.Add("Unit", "单位");
            dataGridViewDataIdList.Columns.Add("ReadAble", "读");
            dataGridViewDataIdList.Columns.Add("WritAbale", "写");
            dataGridViewDataIdList.Columns.Add("Name", "数据项名称");
            dataGridViewDataIdList.Columns.Add("GroupName", "分组");
            dataGridViewDataIdList.Columns[3].Width = 160;
            DisplayAll();
        }
        public List<DataId> GetDataIdList(string excelFilePath)
        {
            List<DataId> list = new List<DataId>();
            IWorkbook workbook = null;
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                if(Path.GetExtension(excelFilePath).Equals(".xlsx"))
                {
                    workbook = new XSSFWorkbook(fileStream);
                }
                else
                {
                    workbook = new HSSFWorkbook(fileStream);
                }
                ISheet sheet = workbook.GetSheetAt(0);
                int i = 1;
                for (; i < sheet.LastRowNum + 1; i++)
                {
                    IRow row = sheet.GetRow(i);
                    DataId dataId = new DataId();
                    dataId.Id         = Convert.ToUInt32(row.GetCell(0).StringCellValue, 16);
                    dataId.Name       = row.GetCell(1).StringCellValue;
                    dataId.Format     = row.GetCell(2) == null? null : row.GetCell(2).StringCellValue;
                    dataId.DataBytes  = Convert.ToInt32(row.GetCell(3).NumericCellValue);
                    dataId.Unit       = row.GetCell(4)  == null? null : row.GetCell(4).StringCellValue;
                    dataId.IsReadable = row.GetCell(5).StringCellValue == "是";
                    dataId.IsWritable = row.GetCell(6).StringCellValue == "是";
                    dataId.GroupName  = row.GetCell(7).StringCellValue;
                    list.Add(dataId);
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
        private void DisplayAll()
        {
            dataGridViewDataIdList.Rows.Clear();
            // using (var context = new MeterTestDbContext())
            // {
            //     List<DataId> dataIdList = context.ReadWriteDataIdList.ToList();
            //     dataIdList.Sort();
            //     DataId[] dataIdArray = dataIdList.ToArray<DataId>();
            //     for (int i = 0; i < dataIdArray.Length; i++)
            //     {
            //         int index = dataGridViewDataIdList.Rows.Add();
            //         dataGridViewDataIdList.Rows[index].Cells[0].Value = (i.ToString());
            //         dataGridViewDataIdList.Rows[index].Cells[1].Value = dataIdArray[i].Id.ToString("X8");
            //         dataGridViewDataIdList.Rows[index].Cells[2].Value = dataIdArray[i].Format;// == null? null : (dataIdArray[i].Format.ToString());
            //         dataGridViewDataIdList.Rows[index].Cells[3].Value = dataIdArray[i].DataBytes;
            //         dataGridViewDataIdList.Rows[index].Cells[4].Value = dataIdArray[i].Unit;
            //         dataGridViewDataIdList.Rows[index].Cells[5].Value = dataIdArray[i].IsReadable;
            //         dataGridViewDataIdList.Rows[index].Cells[6].Value = dataIdArray[i].IsWritable;
            //         dataGridViewDataIdList.Rows[index].Cells[7].Value = dataIdArray[i].Name;
            //         dataGridViewDataIdList.Rows[index].Cells[8].Value = dataIdArray[i].GroupName;                
            //     }
            // }
            
        }
        // private void buttonAddLot_Click(object sender, EventArgs e)
        // {
        //     OpenFileDialog fileDialog = new OpenFileDialog();
        //     fileDialog.Multiselect = false;
        //     fileDialog.Title = "请选择文件";
        //     fileDialog.Filter = "excel文件(*.xlsx,*.xls)|*.xlsx;*.xls"; ;
        //     if (fileDialog.ShowDialog() == DialogResult.OK)
        //     {
        //         textBoxAddLot.Text = fileDialog.FileName;
        //         List<DataId> list = this.GetDataIdList(fileDialog.FileName);
        //         DataId[] dataIdArray = list.ToList().ToArray<DataId>();
        //         using (var context = new MeterTestDbContext())
        //         {
        //             // List<DataId> dataIdList = context.Project.Include(e => e.ReadWriteDataIdList).Single(e => e.Name == context.SelectRwProjectName.First()).ReadWriteDataIdList.ToList();
        //             Project project = context.Project.Include(e => e.ReadWriteDataIdList).SingleOrDefault(e => e.Name == FormMain.GetMeterTestConfig().SelectRwTableName);
        //             if(project == null)
        //             {
        //                 return;
        //             }
        //             List<DataId> dataIdList = project.ReadWriteDataIdList.ToList();
        //             for (int i = 0; i < dataIdArray.Length; i++)
        //             {
        //                 if(!dataIdList.Contains(dataIdArray[i]))
        //                 {
        //                     context.ReadWriteDataIdList.Add(dataIdArray[i]);
        //                     dataIdList.Add(dataIdArray[i]);
        //                     IsChg = true;
        //                 }
        //             }
        //             context.SaveChanges();
        //         }
        //         DisplayAll();
        //     }
        // }

        private void buttonAddOne_Click(object sender, EventArgs e)
        {
            DataIdShowForm form = new DataIdShowForm(new DataId(0x12345678));
            form.StartPosition = FormStartPosition.CenterParent;
            form.Text = "添加单个数据标识";
            if(form.ShowDialog() == DialogResult.OK)
            {
                // using (var context = new MeterTestDbContext())
                // {
                //     context.ReadWriteDataIdList.Add(form.DataId);
                //     context.SaveChanges();
                //     DisplayAll();
                //     IsChg = true;
                // }
            }
        }
    }
}
