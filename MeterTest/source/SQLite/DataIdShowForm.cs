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

namespace MeterTest.source.SQLite
{
    public partial class DataIdShowForm : Form
    {
        public DataId DataId;
        private int index;
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
            if(dataIdDb.DataIds.ToList<DataId>().Contains(DataId))
            {
                index = dataIdDb.DataIds.ToList<DataId>().IndexOf(DataId);
            }
            else
            {
                index = -1;
            }
        }

        private void buttonCertain_Click(object sender, EventArgs e)
        {
            if(index != -1)
            {
                dataIdDb.DataIds.Remove(dataIdDb.DataIds.ToList<DataId>()[index]);
            }
            dataIdDb.DataIds.AddAsync(DataId);
            dataIdDb.SaveChangesAsync();
            this.DialogResult = DialogResult.OK;
            this.Close();
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
            DataId.Format = textBoxFormat.Text;
        }

        private void numericUpDownDataBytes_ValueChanged(object sender, EventArgs e)
        {
            DataId.DataBytes = Convert.ToInt32(numericUpDownDataBytes.Value);
        }

        private void textBoxUnit_TextChanged(object sender, EventArgs e)
        {
            DataId.Unit = textBoxUnit.Text;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            DataId.Name = textBoxName.Text;
        }

        private void textBoxGroup_TextChanged(object sender, EventArgs e)
        {
            DataId.GroupName = textBoxGroup.Text;
        }

        private void checkBoxIsReadable_CheckedChanged(object sender, EventArgs e)
        {
            DataId.IsReadable = checkBoxIsReadable.Checked;
        }

        private void checkBoxIsWritable_CheckedChanged(object sender, EventArgs e)
        {
            DataId.IsWritable = checkBoxIsWritable.Checked;
        }
    }
}
