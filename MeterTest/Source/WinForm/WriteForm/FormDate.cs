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
    public partial class FormDate : Form, IWriteForm
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
        protected FormDate()
        {
            InitializeComponent();
        }
        public FormDate(DataId dataId)
        {
            InitializeComponent();
            WriteDataId = dataId;
            this.Text = dataId.Name;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                _writeString = textBoxComputeTime.Text.Replace("-", "").Replace(" ", "");
            }
            else if(radioButton2.Checked)
            {
                _writeString = dateTimePickerSelf.Value.ToString("yyMMdd") + ((int)dateTimePickerSelf.Value.DayOfWeek).ToString("X2");
            }
            else
            {
                _writeString = textBoxInput.Text.PadRight(8, '0');
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormDate_Load(object sender, EventArgs e)
        {
            textBoxComputeTime.Text = DateTime.Now.ToString("yy-MM-dd") + " " + ((int)DateTime.Now.DayOfWeek).ToString("X2");
            radioButton1.Checked = true;
        }
    }
}
