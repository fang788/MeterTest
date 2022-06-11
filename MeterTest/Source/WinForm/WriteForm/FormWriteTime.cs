using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.WinForm.WriteForm
{
    public partial class FormWriteTime : Form, IWriteForm
    {
        private DataId _dataId;
        private String _writeString;
        public DataId WriteDataId 
        { 
            get 
            {
                return _dataId;
            } 
            set 
            {
                _dataId = value;
            }
        }
        public string WriteString
        { 
            get 
            {
                return _writeString;
            } 
            set 
            {
                _writeString = value;
            }
        }
        private FormWriteTime()
        {
            InitializeComponent();
        }
        public FormWriteTime(DataId dataId)
        {
            InitializeComponent();
            this.Text = dataId.Name;
            WriteDataId = dataId;
        }

        private void FormWriteTime_Load(object sender, EventArgs e)
        {
            textBoxComputeTime.Text = DateTime.Now.ToString("hh:mm:ss");
            radioButton1.Checked = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                _writeString = "AAAAAA";
            }
            else if(radioButton2.Checked)
            {
                _writeString = dateTimePickerSelf.Value.ToString("hhmmss");
            }
            else
            {
                _writeString = textBoxInput.Text.PadRight(6, '0');
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            textBoxComputeTime.Text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
