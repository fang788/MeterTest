﻿using System;
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

namespace MeterTest.Source.SQLite
{
    public partial class DataIdListForm : Form
    {
        DataIdDbContext dataIdDb = FormMain.DataIdDb;
        public bool IsChg = false;
        public DataIdListForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DataIdAddListForm form = new DataIdAddListForm();
            this.AddOwnedForm(form);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            if(form.IsChg)
            {
                DisplayAll();
                IsChg = true;
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
            int index;
            List<DataId> list = new List<DataId>();
            DataId[] dataIdArray = dataIdDb.DataIds.ToList().ToArray<DataId>();
            // foreach (var item in dataGridViewDataId.SelectedRows)
            for (int i = 0; i < dataGridViewDataId.SelectedRows.Count; i++)
            {
                try
                {
                    index = Convert.ToInt32(dataGridViewDataId.SelectedRows[i].Cells[0].Value.ToString());
                    list.Add(dataIdArray[index]);
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            string s = "数据标识: ";
            s += (list.ToArray()[0].Id.ToString("X8") + "\n");
            if(list.Count > 1)
            {
                s += "...";
            }
            // for (int i = 0; i < 2; i++)
            // {
            //     s += (list.ToArray()[0].Id.ToString("X8") + "\n");
            // }
            s += "将被永久删除";
            if (MessageBox.Show(s, "MeterTest",  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (var item in list)
                {
                    dataIdDb.DataIds.Remove(item);
                }
                dataIdDb.SaveChangesAsync();
                DisplayAll();
                IsChg = true;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int i;
            uint id;
            if((String.IsNullOrEmpty(textBoxDataId.Text))
            || (String.IsNullOrWhiteSpace(textBoxDataId.Text)))
            {
                toolStripStatusLabelOpt.Text = "请输入需要查找的数据标识";
                return;
            } 
            try 
            {
                id = Convert.ToUInt32(textBoxDataId.Text, 16);
            }
            catch(FormatException)
            {
                toolStripStatusLabelOpt.Text = "数据标识格式不正确";
                return;
            }
            for (i = 0; i < dataGridViewDataId.RowCount - 1; i++)
            {
                if(Convert.ToUInt32(dataGridViewDataId.Rows[i].Cells[1].Value.ToString(), 16) == id)
                {
                    dataGridViewDataId.CurrentCell = dataGridViewDataId.Rows[i].Cells[1];
                    break;
                }
            }
            if(i < dataGridViewDataId.RowCount - 1)
            {
                toolStripStatusLabelOpt.Text = "已找到数据标识：" + id.ToString("X8");
            }
            else
            {
                toolStripStatusLabelOpt.Text = "未找到数据标识：" + id.ToString("X8");
            }
        }

        private void buttonChg_Click(object sender, EventArgs e)
        {
            // if(dataGridViewDataId.SelectedRows.Count != 0)
            // {
            int index = dataGridViewDataId.CurrentCell.RowIndex;
            DataId dataIdSelect = dataIdDb.DataIds.ToList().ToArray<DataId>()[index];
            DataIdShowForm form = new DataIdShowForm(dataIdSelect);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            if(form.IsChg)
            {
                if(textBoxDataId.Text == "")
                {
                    DisplayAll();
                }
                else
                {
                    DisplayOne();
                }
                IsChg = true;
                dataIdDb.SaveChanges();
                //DialogResult = DialogResult.OK;
            }
        }

        private void textBoxDataId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(((e.KeyChar < (char)'0') || (e.KeyChar > (char)'9')) 
            && (e.KeyChar != (char)'A')
            && (e.KeyChar != (char)'a')
            && (e.KeyChar != (char)'B')
            && (e.KeyChar != (char)'b')
            && (e.KeyChar != (char)'C')
            && (e.KeyChar != (char)'c')
            && (e.KeyChar != (char)'D')
            && (e.KeyChar != (char)'d')
            && (e.KeyChar != (char)'E')
            && (e.KeyChar != (char)'e')
            && (e.KeyChar != (char)'F')
            && (e.KeyChar != (char)'f')
            && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true; 
            }
        }
    }
}
