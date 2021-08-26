using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeterTest.Source.Dlt645;
using MeterTest.Source.WinowsForm;
using Microsoft.EntityFrameworkCore;

namespace MeterTest.source.SQLite
{
    public partial class DataIdListForm : Form
    {
        DataIdDbContext dataIdDb = FormMain.DataIdDb;
        public DataIdListForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form form = new DataIdAddListForm();
            this.AddOwnedForm(form);
            form.StartPosition = FormStartPosition.CenterParent;
            if(form.ShowDialog() == DialogResult.OK)
            {
                DisplayAll();
                DialogResult = DialogResult.OK;
            }
        }

        private void DataIdListForm_Load(object sender, EventArgs e)
        {
            dataGridViewDataId.Columns.Clear();
            dataGridViewDataId.Columns.Add("No",    "编号"    );
            dataGridViewDataId.Columns.Add("Id",    "数据标识"); 
            dataGridViewDataId.Columns.Add("Format",    "数据格式");
            dataGridViewDataId.Columns.Add("DataBytes",    "数据长度（字节）");
            dataGridViewDataId.Columns.Add("Unit",    "单位");
            dataGridViewDataId.Columns.Add("ReadAble",    "读");
            dataGridViewDataId.Columns.Add("WritAbale",    "写");
            dataGridViewDataId.Columns.Add("Name",    "数据项名称");
            dataGridViewDataId.Columns.Add("Group",    "分组");
            dataGridViewDataId.Columns[3].Width = 160;
            DisplayAll();
        }
        private void DisplayAll()
        {
            DataId[] dataIdArray = dataIdDb.DataIds.ToList().ToArray<DataId>();
            dataGridViewDataId.Rows.Clear();
            for (int i = 0; i < dataIdArray.Length; i++)
            {
                int index = dataGridViewDataId.Rows.Add();
                dataGridViewDataId.Rows[index].Cells[0].Value = (i.ToString());
                dataGridViewDataId.Rows[index].Cells[1].Value = dataIdArray[i].Id.ToString("X8");
                dataGridViewDataId.Rows[index].Cells[2].Value = dataIdArray[i].Format;// == null? null : (dataIdArray[i].Format.ToString());
                dataGridViewDataId.Rows[index].Cells[3].Value = dataIdArray[i].DataBytes;
                dataGridViewDataId.Rows[index].Cells[4].Value = dataIdArray[i].Unit;
                dataGridViewDataId.Rows[index].Cells[5].Value = dataIdArray[i].IsReadable;
                dataGridViewDataId.Rows[index].Cells[6].Value = dataIdArray[i].IsWritable;
                dataGridViewDataId.Rows[index].Cells[7].Value = dataIdArray[i].Name;
                dataGridViewDataId.Rows[index].Cells[8].Value = dataIdArray[i].GroupName;
            }
            dataGridViewDataId.AutoResizeColumns();
        }
        private void DisplayOne()
        {
            int id;
            try
            {
                id = Convert.ToInt32(textBoxDataId.Text, 16);
            }
            catch (System.Exception)
            {
                throw;
            }
            DataId[] dataIdArray = dataIdDb.DataIds.ToList().ToArray<DataId>();
            int i;
            for (i = 0; i < dataIdArray.Length; i++)
            {
                if(dataIdArray[i].Id == id)
                {
                    break;
                }
            }
            if(i < dataIdArray.Length)
            {
                dataGridViewDataId.Rows.Clear();
                int index = dataGridViewDataId.Rows.Add();
                dataGridViewDataId.Rows[index].Cells[0].Value = (i.ToString());
                dataGridViewDataId.Rows[index].Cells[1].Value = dataIdArray[i].Id.ToString("X8");
                dataGridViewDataId.Rows[index].Cells[2].Value = dataIdArray[i].Format;// == null? null : (dataIdArray[i].Format.ToString());
                dataGridViewDataId.Rows[index].Cells[3].Value = dataIdArray[i].DataBytes;
                dataGridViewDataId.Rows[index].Cells[4].Value = dataIdArray[i].Unit;
                dataGridViewDataId.Rows[index].Cells[5].Value = dataIdArray[i].IsReadable;
                dataGridViewDataId.Rows[index].Cells[6].Value = dataIdArray[i].IsWritable;
                dataGridViewDataId.Rows[index].Cells[7].Value = dataIdArray[i].Name;
                dataGridViewDataId.Rows[index].Cells[8].Value = dataIdArray[i].GroupName;
            }
            else
            {
                MessageBox.Show("未找到数据标识：" + id.ToString("X8"), "MeterTest", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            // foreach (var item in dataIdDb.DataIds)
            // {
            //     dataIdDb.DataIds.Remove(item);
            // }
            // dataIdDb.SaveChangesAsync();
            int index;
            try
            {
                index = Convert.ToInt32(dataGridViewDataId.Rows[dataGridViewDataId.CurrentCell.RowIndex].Cells[0].Value.ToString());
            }
            catch (System.Exception)
            {
                throw;
            }
            DataId selectDataId = dataIdDb.DataIds.ToList().ToArray<DataId>()[index];
            if (MessageBox.Show("数据标识 (" + selectDataId.ToString() + ") 将被永久删除", "MeterTest",  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
            {
                dataIdDb.DataIds.Remove(selectDataId);
                dataIdDb.SaveChangesAsync();
                DialogResult = DialogResult.OK;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonChg_Click(object sender, EventArgs e)
        {
            // if(dataGridViewDataId.SelectedRows.Count != 0)
            // {
            int index = dataGridViewDataId.CurrentCell.RowIndex;
            DataId dataIdSelect = dataIdDb.DataIds.ToList().ToArray<DataId>()[index];
            Form form = new DataIdShowForm(dataIdSelect);
            form.StartPosition = FormStartPosition.CenterParent;
            if(form.ShowDialog() == DialogResult.OK)
            {
                if(textBoxDataId.Text == "")
                {
                    DisplayAll();
                }
                else
                {
                    DisplayOne();
                }
                DialogResult = DialogResult.OK;
            }
            // }
            // else
            // {
            //     toolStripStatusLabelOpt.Text = "错误：未选择数据标识！";
            // }
        }

        private void textBoxDataId_TextChanged(object sender, EventArgs e)
        {
            if(textBoxDataId.Text == "")
            {
                DisplayAll();
            }
        }
    }
}
