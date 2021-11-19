using MeterTest.Source.Dlt645;
using MeterTest.Source.WinowsForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeterTest.Source.SQLite
{
    public partial class DataIdShowForm : Form
    {
        public DataId DataId;
        // private int index;
        public bool IsChg = false;
        private bool optChg = false;
        private DataIdDbContext dataIdDb = FormMain.DataIdDb;
        public DataIdShowForm(DataId id)
        {
            InitializeComponent();
            DataId = id;
        }

        private void DataIdShowForm_Load(object sender, EventArgs e)
        {
            textBoxId.Text = DataId.Id.ToString("X8");
            textBoxFormat.Text = DataId.Format;
            numericUpDownDataBytes.Value = DataId.DataBytes;
            textBoxUnit.Text = DataId.Unit;
            checkBoxIsReadable.Checked = DataId.IsReadable;
            checkBoxIsWritable.Checked = DataId.IsWritable;
            textBoxName.Text = DataId.Name;
            textBoxGroup.Text = DataId.GroupName;
            // if(dataIdDb.DataIds.ToList<DataId>().Contains(DataId))
            // {
            //     index = dataIdDb.DataIds.ToList<DataId>().IndexOf(DataId);
            // }
            // else
            // {
            //     index = -1;
            // }
        }

        private void buttonCertain_Click(object sender, EventArgs e)
        {
            // if(index != -1)
            // {
            //     dataIdDb.DataIds.Remove(dataIdDb.DataIds.ToList<DataId>()[index]);
            // }
            if(optChg)
            {
                IsChg = true;
                this.Close();
            }
            // dataIdDb.DataIds.AddAsync(DataId);
            // dataIdDb.SaveChangesAsync();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataId.Id = Convert.ToUInt32(textBoxId.Text, 16);
            }
            catch(FormatException)
            {
                MessageBox.Show("数据标识格式有误", "MeterTest",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxFormat_TextChanged(object sender, EventArgs e)
        {
            if(DataId.Format != textBoxFormat.Text)
            {
                DataId.Format = textBoxFormat.Text;
                optChg = true;
            }
        }

        private void numericUpDownDataBytes_ValueChanged(object sender, EventArgs e)
        {
            if(DataId.DataBytes != Convert.ToInt32(numericUpDownDataBytes.Value))
            {
                DataId.DataBytes = Convert.ToInt32(numericUpDownDataBytes.Value);
                optChg = true;
            }
        }

        private void textBoxUnit_TextChanged(object sender, EventArgs e)
        {
            if(DataId.Unit != textBoxUnit.Text)
            {
                DataId.Unit = textBoxUnit.Text;
                optChg = true;
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if(DataId.Name != textBoxName.Text)
            {
                DataId.Name = textBoxName.Text;
                optChg = true;
            }
        }

        private void textBoxGroup_TextChanged(object sender, EventArgs e)
        {
            if(DataId.GroupName != textBoxGroup.Text)
            {
                DataId.GroupName = textBoxGroup.Text;
                optChg = true;
            }
        }

        private void checkBoxIsReadable_CheckedChanged(object sender, EventArgs e)
        {
            if(DataId.IsReadable != checkBoxIsReadable.Checked)
            {
                DataId.IsReadable = checkBoxIsReadable.Checked;
                optChg = true;
            }
        }

        private void checkBoxIsWritable_CheckedChanged(object sender, EventArgs e)
        {
            if(DataId.IsWritable != checkBoxIsWritable.Checked)
            {
                DataId.IsWritable = checkBoxIsWritable.Checked;
                optChg = true;
            }
        }
    }
}
