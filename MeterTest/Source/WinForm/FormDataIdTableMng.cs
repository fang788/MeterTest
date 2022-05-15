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
using MeterTest.Source.Dlt645;
using MeterTest.Source.SQLite;
using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace MeterTest.Source.WindowsForm
{
    public partial class FormDataIdTableMng : Form
    {
        private string projectName;
        private bool isConfig;
        private string tip;
        private string selectedNode;
        public FormDataIdTableMng()
        {
            InitializeComponent();
        }

        public FormDataIdTableMng(string projectName, bool isConfig)
        {
            this.projectName = projectName;
            this.isConfig = isConfig;
            InitializeComponent();
        }

        private void FormDataIdTableMng_Load(object sender, EventArgs e)
        {
            tip = "项目：" + projectName + "，";
            if(isConfig)
            {
                tip += "参数配置表";
            }
            else
            {
                tip += "读写表";
            }
            this.Text = tip;
            treeViewDataIdTable.Nodes.Add(projectName);
            treeViewDataIdTable.Nodes[0].ContextMenuStrip = contextMenuStripDataIdTableAdd;
            TreeViewUpdate();
        }
        private void DataGridViewDataIdTableDisplay(string tableName)
        {
            List<DataId> dataIdList = MeterTestDbContext.GetDataIdList(projectName, tableName, isConfig);
            if(dataGridViewDataIdTable.Columns.Count == 0)
            {
                dataGridViewDataIdTable.Columns.Clear();
                dataGridViewDataIdTable.Columns.Add("No",    "编号"    );
                dataGridViewDataIdTable.Columns.Add("Id",    "数据标识"); 
                dataGridViewDataIdTable.Columns.Add("Format",    "数据格式");
                dataGridViewDataIdTable.Columns.Add("DataBytes",    "数据长度（字节）");
                dataGridViewDataIdTable.Columns.Add("Unit",    "单位");
                dataGridViewDataIdTable.Columns.Add("Data",    "数据");
                dataGridViewDataIdTable.Columns.Add("ReadAble",    "读");
                dataGridViewDataIdTable.Columns.Add("WritAble",    "写");
                dataGridViewDataIdTable.Columns.Add("Name",    "数据项名称");
                dataGridViewDataIdTable.Columns.Add("Group",    "分组");
                dataGridViewDataIdTable.Columns[3].Width = 160;
            }
            if(dataIdList != null)
            {
                dataGridViewDataIdTable.Rows.Clear();
                for (int i = 0; i < dataIdList.Count; i++)
                {
                    int index = dataGridViewDataIdTable.Rows.Add();
                    dataGridViewDataIdTable.Rows[index].Cells[0].Value = (i.ToString());
                    dataGridViewDataIdTable.Rows[index].Cells[1].Value = dataIdList[i].Id.ToString("X8");
                    dataGridViewDataIdTable.Rows[index].Cells[2].Value = dataIdList[i].Format;// == null? null : (dataIdArray[i].Format.ToString());
                    dataGridViewDataIdTable.Rows[index].Cells[3].Value = dataIdList[i].DataBytes;
                    dataGridViewDataIdTable.Rows[index].Cells[4].Value = dataIdList[i].Unit;
                    if(dataIdList[i].DataArray != null)
                    {
                        dataGridViewDataIdTable.Rows[index].Cells[5].Value = dataIdList[i].GetDataString(dataIdList[i].DataArray);
                    }
                    dataGridViewDataIdTable.Rows[index].Cells[6].Value = dataIdList[i].IsReadable;
                    dataGridViewDataIdTable.Rows[index].Cells[7].Value = dataIdList[i].IsWritable;
                    dataGridViewDataIdTable.Rows[index].Cells[8].Value = dataIdList[i].Name;
                    dataGridViewDataIdTable.Rows[index].Cells[9].Value = dataIdList[i].GroupName;
                }
            }
        }
        private void TreeViewUpdate()
        {
            treeViewDataIdTable.Nodes[0].Nodes.Clear();
            List<DataIdTable> dataIdTables = MeterTestDbContext.GetDataIdTableList(projectName, isConfig);
            if((dataIdTables != null) && (dataIdTables.Count > 0))
            {
                foreach (var item in dataIdTables)
                {
                    TreeNode treeNode = new TreeNode(item.Name);
                    treeNode.ContextMenuStrip = contextMenuStripDataIdTableDel;
                    treeViewDataIdTable.Nodes[0].Nodes.Add(treeNode);
                }
                DataGridViewDataIdTableDisplay(dataIdTables[0].Name);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((treeViewDataIdTable.Nodes[0].Nodes != null)
            && (treeViewDataIdTable.Nodes[0].Nodes.Contains(treeViewDataIdTable.SelectedNode)))
            {
                using(var context = new MeterTestDbContext())
                {
                    DataIdTable dataIdTable = context.DataIdTables.Where(e => e.ProjectName == projectName)
                                                                  .Where(e => e.IsConfig == isConfig)
                                                                  .Single(e => e.Name == treeViewDataIdTable.SelectedNode.Text);
                    List<DataId> dataIds = context.DataIds.Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableName")  == treeViewDataIdTable.SelectedNode.Text)
                                                          .Where(e => EF.Property<bool>(e, "ForeignKey_DataIdTableIsConfig")  == isConfig)
                                                          .Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableProjectName")  == projectName)
                                                          .ToList();
                    context.Remove(dataIdTable);
                    if(dataIds == null)
                    {
                        context.RemoveRange(dataIds);
                    }
                    context.SaveChanges();
                }
                if((treeViewDataIdTable.Nodes[0].Nodes != null)
                && (treeViewDataIdTable.Nodes[0].Nodes.Count > 0))
                {
                    DataGridViewDataIdTableDisplay(treeViewDataIdTable.Nodes[0].Nodes[0].Text);
                    treeViewDataIdTable.SelectedNode = treeViewDataIdTable.Nodes[0].Nodes[0];
                }
                TreeViewUpdate();
            }
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddName form = new FormAddName("请输入" + tip + "名称", "表名称：", "项目");
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            if(form.SelectRwProjectName == null)
            {
                return;
            }
            if(MeterTestDbContext.DataIdTableContains(projectName, form.SelectRwProjectName, isConfig))
            {
                MessageBox.Show("项目《" + projectName + "》已存在表：" + form.SelectRwProjectName + ", 请勿重复添加",
                                "MeterTest",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择excel文件";
            fileDialog.Filter = "excel文件(*.xlsx,*.xls)|*.xlsx;*.xls"; ;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                DataIdTable dataIdTable = new DataIdTable();
                dataIdTable.Name = form.SelectRwProjectName;
                dataIdTable.Ticks = DateTime.Now.Ticks;
                dataIdTable.ProjectName = projectName;
                dataIdTable.IsConfig = isConfig;
                dataIdTable.DataIdList = GetDataIdList(fileDialog.FileName);
                using(var context = new MeterTestDbContext())
                {
                    Project project = context.Projects.Single(e => e.Name == projectName);
                    if(project.DataIdTables == null)
                    {
                        project.DataIdTables = new List<DataIdTable>();
                    }
                    project.DataIdTables.Add(dataIdTable);
                    context.DataIdTables.Add(dataIdTable);
                    foreach (var item in dataIdTable.DataIdList)
                    {
                        context.Entry(item).Property("ForeignKey_DataIdTableName").CurrentValue = dataIdTable.Name;
                        context.Entry(item).Property("ForeignKey_DataIdTableIsConfig").CurrentValue = isConfig;
                        context.Entry(item).Property("ForeignKey_DataIdTableProjectName").CurrentValue = projectName;
                    }
                    context.DataIds.AddRange(dataIdTable.DataIdList);
                    context.SaveChanges();
                }
                DataGridViewDataIdTableDisplay(dataIdTable.Name);
                TreeViewUpdate();
            }
        }
        private List<DataId> GetDataIdList(string excelFilePath)
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
                    if((row.GetCell(5) == null) 
                    || (row.GetCell(5).StringCellValue.Trim().Length < 2))
                    {
                        dataId.DataArray = null;
                    }
                    else
                    {
                        dataId.DataArray = dataId.GetByteArray(row.GetCell(5).StringCellValue);
                    }
                    dataId.IsReadable = row.GetCell(6).StringCellValue == "是";
                    dataId.IsWritable = row.GetCell(7).StringCellValue == "是";
                    dataId.GroupName  = row.GetCell(8).StringCellValue;
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

        private void treeViewDataIdTable_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((treeViewDataIdTable.Nodes[0].Nodes != null)
            && (treeViewDataIdTable.Nodes[0].Nodes.Contains(treeViewDataIdTable.SelectedNode))
            && (selectedNode != treeViewDataIdTable.SelectedNode.Text))
            {
                selectedNode = treeViewDataIdTable.SelectedNode.Text;
                DataGridViewDataIdTableDisplay(selectedNode);
            }
        }
    }
}
