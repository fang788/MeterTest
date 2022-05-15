﻿using System;
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
using MeterTest.Source.WinForm;
using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace MeterTest.Source.WinForm
{
    public partial class ParaConfigManageForm : Form
    {
        private string projectName;
        private List<DataIdTable> DataIdTables;
        public ParaConfigManageForm()
        {
            InitializeComponent();
        }
        public ParaConfigManageForm(string name)
        {
            InitializeComponent();
            this.projectName = name;
            DataIdTables = MeterTestDbContext.GetParaConfigTables(projectName);
        }
        private void ParaConfigManageForm_Load(object sender, EventArgs e)
        {
            this.Text = "项目：" + projectName + " 参数配置管理";
            List<DataIdTable> paraDataIdTables = MeterTestDbContext.GetParaConfigTables(projectName);
            if(paraDataIdTables != null)
            {
                foreach (var item in paraDataIdTables)
                {
                    treeViewProject.Nodes.Add(projectName);
                    treeViewProject.Nodes[0].Nodes.Clear();
                    treeViewProject.Nodes[0].Nodes.Add(new TreeNode(item.Name));
                }
                TableListUpdate(paraDataIdTables[0]);
            }
        }

        private void TableListUpdate(DataIdTable paraConfigTable)
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
            if(paraConfigTable.DataIdList != null)
            {
                int count = 0;
                foreach (var item in paraConfigTable.DataIdList)
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
        private List<DataId> GetParaConfigTableFromExcel(string excelPath)
        {
            List<DataId> DataIdList = new List<DataId>();
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
                
                for (int i = 1; i < sheet.LastRowNum + 1; i++)
                {
                    IRow row = sheet.GetRow(i);
                    DataId dataId     = new DataId();
                    dataId.Id         = Convert.ToUInt32(row.GetCell(0).StringCellValue, 16);
                    dataId.Name       = row.GetCell(1).StringCellValue;
                    dataId.Format     = row.GetCell(2) == null? null : row.GetCell(2).StringCellValue;
                    dataId.DataBytes  = Convert.ToInt32(row.GetCell(3).NumericCellValue);
                    dataId.Unit       = row.GetCell(4)  == null? null : row.GetCell(4).StringCellValue;
                    dataId.IsReadable = true;
                    dataId.IsWritable = true;
                    dataId.GroupName  = "参变量";
                    dataId.DataArray = dataId.GetByteArray(row.GetCell(5).StringCellValue);
                    DataIdList.Add(dataId);
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
            return DataIdList;
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FormAddName form = new FormAddName("请填写参数表名称", "参数表名: ");
            // form.StartPosition = FormStartPosition.CenterParent;
            // form.ShowDialog();
            // if(form.ProductName == null)
            // {
            //     MessageBox.Show("参数表名不能为空", "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //     return;
            // }
            // DataIdTable DataIdTables = new DataIdTable(form.ProductName, true, DateTime.Now.Ticks, new List<DataId>());
            // if(MeterTestDbContext.GetParaConfigTables(projectName).Contains(DataIdTables))
            // {
            //     MessageBox.Show("已添加：" + DataIdTables.Name, "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //     return;
            // }
            // OpenFileDialog fileDialog = new OpenFileDialog();
            // fileDialog.Multiselect = false;
            // fileDialog.Title = "请选择文件";
            // fileDialog.Filter = "excel文件(*.xlsx,*.xls)|*.xlsx;*.xls"; ;
            // if (fileDialog.ShowDialog() == DialogResult.OK)
            // {
            //     paraDataIdTable.DataIdList = GetParaConfigTableFromExcel(fileDialog.FileName);
            //     using (var context = new MeterTestDbContext())
            //     {
            //         Project project = context.Project.Single(e => e.Name == projectName);
            //         // project.ParaDataIdTableList.Add(paraDataIdTable);
            //         // context.ParaConfigDataIdList.AddRange(paraDataIdTable.DataIdList);
            //         context.SaveChanges();
            //     }
            //     TableListUpdate(paraDataIdTable);
            // }
        }

        // private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        // {
        //     if((treeViewProject.SelectedNode != null) 
        //     && (treeViewProject.Nodes[0].Nodes != null)
        //     && (treeViewProject.Nodes[0].Nodes.Contains(treeViewProject.SelectedNode)))
        //     {
        //         if(MessageBox.Show("是否删除" + treeViewProject.SelectedNode.Text, "Meter Test Tip", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //         {
        //             using var context = new MeterTestDbContext();
        //             // ParaConfigTable table = paraConfigTableDb.ParaConfigTables.ToArray()[treeViewProject.SelectedNode.Index];
        //             Project table = context.Project.Include(e => e.ParaConfigDataIdList).SingleOrDefault(e => e.Name == treeViewProject.SelectedNode.Text);
        //             //List<ParaConfigDataId> dataIdList = table.DataIds;
        //             // ParaConfigTable table = paraConfigTableDb.ParaConfigTables.OrderBy(e => e.Name).Include(e => e.Posts).First();
        //             context.ParaConfigDataIdList.RemoveRange(table.ParaConfigDataIdList);
        //             context.Project.Remove(table);
        //             // paraConfigTableDb.RemoveRange(dataIdList);
        //             // paraConfigTableDb.Remove(table);
        //             context.SaveChanges();
        //             //paraConfigTableDb.Update(paraConfigTableDb.ParaConfigTables);
        //             //paraConfigTableDb.Update(paraConfigTableDb.DataIds);
        //             List<string> nameList = new List<string>();
        //             // List<DataId> list = context.Project.Include(e => e.ReadWriteDataIdList).Single(e => e.Name == context.SelectRwProjectName.First()).ReadWriteDataIdList.ToList();
        //             Project project = context.Project.Include(e => e.ReadWriteDataIdList).SingleOrDefault(e => e.Name == FormMain.GetMeterTestConfig().SelectRwTableName);
        //             if(project == null)
        //             {
        //                 treeViewProject.Nodes[0].Nodes.Clear();
        //                 dataGridViewParaConfigTable.Rows.Clear();
        //             }
        //             else
        //             {
        //                 List<DataId> list = project.ParaConfigDataIdList.ToList();
        //                 foreach (var item in list)
        //                 {
        //                     nameList.Add(item.Name);
        //                 }
        //                 if(nameList.Count > 0)
        //                 {
        //                     ProjectTreeUpdate(nameList);
        //                     treeViewProject.SelectedNode = treeViewProject.Nodes[0].Nodes[0];
        //                     TableListUpdate(context.Project.ToArray()[0]);
        //                 }
        //                 else
        //                 {
        //                     treeViewProject.Nodes[0].Nodes.Clear();
        //                     dataGridViewParaConfigTable.Rows.Clear();
        //                 }
        //             }
        //         }
        //     }
        // }

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
                using var context = new MeterTestDbContext();
                SelectedNode = treeViewProject.SelectedNode;
            }
        }
    }
}
