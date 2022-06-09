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

namespace MeterTest.Source.WinForm
{
    public partial class FormDataIdTableMng : Form
    {
        private string projectName;
        private bool isConfig;
        private string tableName;
        private string tip;
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
        private void DataGridViewDataIdTableDisplay()
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
                tableName = dataIdTables[0].Name;
                DataGridViewDataIdTableDisplay();
                treeViewDataIdTable.SelectedNode = treeViewDataIdTable.Nodes[0].Nodes[0];
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
                                                                .Single(e => e.Name == tableName);
                    List<DataId> dataIds = context.DataIds.Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableName")  == tableName)
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
                    tableName = treeViewDataIdTable.Nodes[0].Nodes[0].Text;
                    DataGridViewDataIdTableDisplay();
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
            if(form.SelectReadProjectName == null)
            {
                return;
            }
            if(MeterTestDbContext.DataIdTableContains(projectName, form.SelectReadProjectName, isConfig))
            {
                MessageBox.Show("项目《" + projectName + "》已存在表：" + form.SelectReadProjectName + ", 请勿重复添加",
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
                dataIdTable.Name = form.SelectReadProjectName;
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
                tableName = dataIdTable.Name;
                DataGridViewDataIdTableDisplay();
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
            && (treeViewDataIdTable.SelectedNode.Text != tableName))
            {
                tableName = treeViewDataIdTable.SelectedNode.Text;
                DataGridViewDataIdTableDisplay();
            }
        }

        private void textBoxDataId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(((e.KeyChar < (char)'0') || (e.KeyChar > (char)'9')) 
            && ((e.KeyChar < (char)'A') || (e.KeyChar > (char)'F'))
            && ((e.KeyChar < (char)'a') || (e.KeyChar > (char)'f'))
            && (e.KeyChar != (char)Keys.Back)
            && (e.KeyChar != (char)Keys.Delete))
            {
                e.Handled = true; 
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string dataIdSearch = textBoxDataId.Text;
            if(dataIdSearch.Trim() != "")
            {
                foreach (DataGridViewRow item in dataGridViewDataIdTable.Rows)
                {
                    if((item.Cells[1].Value != null) && (item.Cells[1].Value.ToString().ToLower().Equals(dataIdSearch.ToLower())))
                    {
                        dataGridViewDataIdTable.CurrentCell = item.Cells[1];
                        break;
                    }
                }
            }
        }

        private void buttonChg_Click(object sender, EventArgs e)
        {
            if(dataGridViewDataIdTable.SelectedRows.Count > 0)
            {
                using(var context = new MeterTestDbContext())
                {
                    uint id = Convert.ToUInt32(dataGridViewDataIdTable.SelectedRows[0].Cells[1].Value.ToString(), 16);
                    DataId dataId = context.DataIds.Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableName")  == tableName)
                                                        .Where(e => EF.Property<bool>(e, "ForeignKey_DataIdTableIsConfig")  == isConfig)
                                                        .Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableProjectName")  == projectName)
                                                        .Single(e => e.Id == id);
                    FormDataIdAddAndChg form = new FormDataIdAddAndChg(dataId);
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.Text = "在项目：" + projectName + " 读写表：" + tableName + " 中修改单个数据标识";
                    if(form.ShowDialog() == DialogResult.OK)
                    {
                        context.SaveChanges();
                        dataGridViewDataIdTable.SelectedRows[0].Cells[1].Value = dataId.Id.ToString("X8");
                        dataGridViewDataIdTable.SelectedRows[0].Cells[2].Value = dataId.Format;// == null? null : (dataIdArray[i].Format.ToString());
                        dataGridViewDataIdTable.SelectedRows[0].Cells[3].Value = dataId.DataBytes;
                        dataGridViewDataIdTable.SelectedRows[0].Cells[4].Value = dataId.Unit;
                        if(dataId.DataArray != null)
                        {
                            dataGridViewDataIdTable.SelectedRows[0].Cells[5].Value = dataId.GetDataString(dataId.DataArray);
                        }
                        dataGridViewDataIdTable.SelectedRows[0].Cells[6].Value = dataId.IsReadable;
                        dataGridViewDataIdTable.SelectedRows[0].Cells[7].Value = dataId.IsWritable;
                        dataGridViewDataIdTable.SelectedRows[0].Cells[8].Value = dataId.Name;
                        dataGridViewDataIdTable.SelectedRows[0].Cells[9].Value = dataId.GroupName;
                    }
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if(dataGridViewDataIdTable.SelectedRows.Count > 0)
            {
                String tip = "是否删除: ";
                foreach (DataGridViewRow item in dataGridViewDataIdTable.SelectedRows)
                {
                    tip += (item.Cells[1].Value + " ");
                }
                if(MessageBox.Show(tip, "MeterTest", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using(var context = new MeterTestDbContext())
                    {
                        List<DataId> dataIds = new List<DataId>();
                        foreach (DataGridViewRow item in dataGridViewDataIdTable.SelectedRows)
                        {
                            uint id = Convert.ToUInt32(item.Cells[1].Value.ToString(), 16);
                            DataId dataId = context.DataIds.Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableName")  == tableName)
                                                                .Where(e => EF.Property<bool>(e, "ForeignKey_DataIdTableIsConfig")  == isConfig)
                                                                .Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableProjectName")  == projectName)
                                                                .Single(e => e.Id == id);
                            dataIds.Add(dataId);
                            dataGridViewDataIdTable.Rows.Remove(item);
                        }
                        context.RemoveRange(dataIds);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormDataIdAddAndChg form = new FormDataIdAddAndChg();
            form.StartPosition = FormStartPosition.CenterParent;
            form.Text = "在项目：" + projectName + " 读写表：" + tableName + " 中添加单个数据标识";
            if(form.ShowDialog() == DialogResult.OK)
            {
                DataId dataId = form.AddAndChgDataId;
                if(MeterTestDbContext.CheckDataId(projectName, tableName, isConfig, dataId.Id) == false)
                {
                    using(var context = new MeterTestDbContext())
                    {
                        DataIdTable dataIdTable = context.DataIdTables.Where(e => e.ProjectName == projectName)
                                                                    .Where(e => e.IsConfig == isConfig)
                                                                    .Single(e => e.Name == tableName);
                        context.Entry(dataId).Property("ForeignKey_DataIdTableName").CurrentValue = tableName;
                        context.Entry(dataId).Property("ForeignKey_DataIdTableIsConfig").CurrentValue = isConfig;
                        context.Entry(dataId).Property("ForeignKey_DataIdTableProjectName").CurrentValue = projectName;
                        context.DataIds.Add(dataId);
                        context.SaveChanges();
                    }
                    int index = dataGridViewDataIdTable.Rows.Add();
                    dataGridViewDataIdTable.Rows[index].Cells[0].Value = dataGridViewDataIdTable.Rows.Count;
                    dataGridViewDataIdTable.Rows[index].Cells[1].Value = dataId.Id.ToString("X8");
                    dataGridViewDataIdTable.Rows[index].Cells[2].Value = dataId.Format;// == null? null : (dataIdArray[i].Format.ToString());
                    dataGridViewDataIdTable.Rows[index].Cells[3].Value = dataId.DataBytes;
                    dataGridViewDataIdTable.Rows[index].Cells[4].Value = dataId.Unit;
                    if(dataId.DataArray != null)
                    {
                        dataGridViewDataIdTable.Rows[index].Cells[5].Value = dataId.GetDataString(dataId.DataArray);
                    }
                    dataGridViewDataIdTable.Rows[index].Cells[6].Value = dataId.IsReadable;
                    dataGridViewDataIdTable.Rows[index].Cells[7].Value = dataId.IsWritable;
                    dataGridViewDataIdTable.Rows[index].Cells[8].Value = dataId.Name;
                    dataGridViewDataIdTable.Rows[index].Cells[9].Value = dataId.GroupName;
                }
                else
                {
                    MessageBox.Show("项目：" + projectName + " 读写表：" + tableName + "中已添加添加数据标识：" + dataId.Id.ToString("X8"), "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
