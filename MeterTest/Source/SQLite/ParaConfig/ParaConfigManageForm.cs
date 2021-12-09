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
using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace MeterTest.Source.SQLite.ParaConfig
{
    public partial class ParaConfigManageForm : Form
    {
        // 数据库
        // private ParaConfigTableDbContext paraConfigTableDb = ParaConfigTableDbContext.GetParaConfigTableDbContextInstance();
        public ParaConfigManageForm()
        {
            InitializeComponent();
        }
        private void ParaConfigManageForm_Load(object sender, EventArgs e)
        {
            List<string> nameList = new List<string>();
            using var context = new ParaConfigTableDbContext();
            List<ParaConfigTable> ParaConfigTableList = context.ParaConfigTables.ToList<ParaConfigTable>();
            if(ParaConfigTableList != null)
            {
                foreach (var item in ParaConfigTableList)
                {
                    nameList.Add(item.Name);
                }
                if(nameList.Count > 0)
                {
                    ProjectTreeUpdate(nameList);
                    treeViewProject.SelectedNode = treeViewProject.Nodes[0].Nodes[0];
                }
            }
            
        }


        private void ProjectTreeUpdate(List<string> nameList)
        {
            treeViewProject.Nodes[0].Nodes.Clear();
            nameList.Sort();
            foreach (var item in nameList)
            {
                treeViewProject.Nodes[0].Nodes.Add(new TreeNode(item));
            }
        }

        private void TableListUpdate(ParaConfigTable paraConfigTable)
        {
            label_para_config_table_name.Text = paraConfigTable.Name;
            if(dataGridViewParaConfigTable.Columns.Count == 0)
            {
                dataGridViewParaConfigTable.Columns.Add("No", "编号");
                dataGridViewParaConfigTable.Columns.Add("Id", "数据标识");
                dataGridViewParaConfigTable.Columns.Add("Name", "名称");
                dataGridViewParaConfigTable.Columns.Add("Format", "格式");
                dataGridViewParaConfigTable.Columns.Add("Unit", "单位");
                dataGridViewParaConfigTable.Columns.Add("Data", "数据");
                dataGridViewParaConfigTable.Columns.Add("DataBytes", "长度");
                dataGridViewParaConfigTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }

            dataGridViewParaConfigTable.Rows.Clear();
            
            if(paraConfigTable.DataIds != null)
            {
                int count = 0;
                foreach (var item in paraConfigTable.DataIds)
                {
                    int index = dataGridViewParaConfigTable.Rows.Add();
                    dataGridViewParaConfigTable.Rows[index].Cells[0].Value = count;
                    dataGridViewParaConfigTable.Rows[index].Cells[1].Value = item.Id.ToString("X8");
                    dataGridViewParaConfigTable.Rows[index].Cells[2].Value = item.Name;
                    dataGridViewParaConfigTable.Rows[index].Cells[3].Value = item.Format;// == null? null : (dataIdArray[i].Format.ToString());
                    dataGridViewParaConfigTable.Rows[index].Cells[4].Value = item.Unit;
                    dataGridViewParaConfigTable.Rows[index].Cells[5].Value = item.GetDataString(item.DataArray);
                    dataGridViewParaConfigTable.Rows[index].Cells[6].Value = item.DataBytes;
                    count++;
                }
            }
            
        }
        private ParaConfigTable GetParaConfigTableFromExcel(string excelPath)
        {
            ParaConfigTable paraConfigTable = new ParaConfigTable();
            paraConfigTable.DataIds = new List<ParaConfigDataId>();
            IWorkbook workbook = null;
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(excelPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                if(Path.GetExtension(excelPath).Equals(".xlsx"))
                {
                    workbook = new XSSFWorkbook(fileStream);
                }
                else
                {
                    workbook = new HSSFWorkbook(fileStream);
                }
                ISheet sheet = workbook.GetSheetAt(0);
                paraConfigTable.Name = sheet.SheetName;
                
                for (int i = 1; i < sheet.LastRowNum + 1; i++)
                {
                    IRow row = sheet.GetRow(i);
                    ParaConfigDataId dataId = new ParaConfigDataId();
                    // dataId.DateTime   = DateTime.Now;
                    dataId.Id         = Convert.ToUInt32(row.GetCell(0).StringCellValue, 16);
                    dataId.Name       = row.GetCell(1).StringCellValue;
                    dataId.Format     = row.GetCell(2) == null? null : row.GetCell(2).StringCellValue;
                    dataId.DataBytes  = Convert.ToInt32(row.GetCell(3).NumericCellValue);
                    dataId.Unit       = row.GetCell(4)  == null? null : row.GetCell(4).StringCellValue;
                    dataId.IsReadable = true;
                    dataId.IsWritable = true;
                    dataId.GroupName  = "参变量";
                    dataId.DataArray = dataId.GetByteArray(row.GetCell(5).StringCellValue);
                    paraConfigTable.DataIds.Add(dataId);
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
            return paraConfigTable;
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "excel文件(*.xlsx,*.xls)|*.xlsx;*.xls"; ;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ParaConfigTable table = GetParaConfigTableFromExcel(fileDialog.FileName);
                // table.DateTime = DateTime.Now;
                using var context = new ParaConfigTableDbContext();
                if(context.ParaConfigTables.Contains(table))
                {
                    MessageBox.Show(table.Name + "已存在，请勿重复添加", "Meter Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                context.ParaConfigTables.Add(table);
                context.SaveChanges();
                List<string> nameList = new List<string>();
                List<ParaConfigTable> List = context.ParaConfigTables.ToList();
                foreach (var item in List)
                {
                    nameList.Add(item.Name);
                }
                if(nameList.Count > 0)
                {
                    ProjectTreeUpdate(nameList);
                    int index = 0;
                    for (int i = 0; i < treeViewProject.Nodes[0].Nodes.Count; i++)
                    {
                        if(treeViewProject.Nodes[0].Nodes[i].Text == table.Name)
                        {
                            index = i;
                            break;
                        }
                    }
                    treeViewProject.SelectedNode = treeViewProject.Nodes[0].Nodes[index];;
                }
                TableListUpdate(table);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if((treeViewProject.SelectedNode != null) 
            && (treeViewProject.Nodes[0].Nodes != null)
            && (treeViewProject.Nodes[0].Nodes.Contains(treeViewProject.SelectedNode)))
            {
                if(MessageBox.Show("是否删除" + treeViewProject.SelectedNode.Name, "Meter Test Tip", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using var context = new ParaConfigTableDbContext();
                    // ParaConfigTable table = paraConfigTableDb.ParaConfigTables.ToArray()[treeViewProject.SelectedNode.Index];
                    ParaConfigTable table = context.ParaConfigTables.Include(e => e.DataIds).Single(e => e.Name == treeViewProject.SelectedNode.Text);
                    //List<ParaConfigDataId> dataIdList = table.DataIds;
                    // ParaConfigTable table = paraConfigTableDb.ParaConfigTables.OrderBy(e => e.Name).Include(e => e.Posts).First();
                    context.DataIds.RemoveRange(table.DataIds);
                    context.ParaConfigTables.Remove(table);
                    // paraConfigTableDb.RemoveRange(dataIdList);
                    // paraConfigTableDb.Remove(table);
                    context.SaveChanges();
                    //paraConfigTableDb.Update(paraConfigTableDb.ParaConfigTables);
                    //paraConfigTableDb.Update(paraConfigTableDb.DataIds);
                    List<string> nameList = new List<string>();
                    List<ParaConfigTable> list = context.ParaConfigTables.ToList();
                    foreach (var item in list)
                    {
                        nameList.Add(item.Name);
                    }
                    if(nameList.Count > 0)
                    {
                        ProjectTreeUpdate(nameList);
                        treeViewProject.SelectedNode = treeViewProject.Nodes[0].Nodes[0];
                        TableListUpdate(context.ParaConfigTables.ToArray()[0]);
                    }
                    else
                    {
                        treeViewProject.Nodes[0].Nodes.Clear();
                        dataGridViewParaConfigTable.Rows.Clear();
                    }
                }
            }
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream ;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        
            saveFileDialog1.Filter = "excel文件(*.xlsx,*.xls)|*.xlsx;*.xls";
            saveFileDialog1.FilterIndex = 2 ;
            saveFileDialog1.RestoreDirectory = true ;
        
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        TreeNode SelectedNode = null;
        private void treeViewProject_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if((treeViewProject.SelectedNode != null) 
            && (treeViewProject.Nodes[0].Nodes.Contains(treeViewProject.SelectedNode))
            && (SelectedNode != treeViewProject.SelectedNode))
            {
                using var context = new ParaConfigTableDbContext();
                SelectedNode = treeViewProject.SelectedNode;
                ParaConfigTable table = context.ParaConfigTables.Include(blog => blog.DataIds).Single(e => e.Name == treeViewProject.SelectedNode.Text);
                TableListUpdate(table);
            }
        }
    }
}
