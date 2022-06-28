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
using MeterTest.Source.WinForm.WriteForm;

namespace MeterTest.Source.WinForm
{
    public partial class FormWrite : Form, WriteForm.IWriteForm
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

        protected FormWrite()
        {
            InitializeComponent();
        }

        public static Form GetFormWrite(DataId dataId)
        {
            Form rst = null;
            if(dataId.Id == 0x04000101)
            {
                rst = new FormDate(dataId);
            }
            else if(dataId.Id == 0x04000102)
            {
                rst = new FormWriteTime(dataId);
            }
            else
            {
                rst = new FormWrite(dataId);
            }
            return rst;
        }

        private FormWrite(DataId dataId)
        {
            InitializeComponent();
            WriteDataId = dataId;
            this.Text = dataId.Name;
            labelDataIdName.Text = dataId.Name;
            if(WriteDataId.Format == "ASC")
            {
                textBoxDataIdData.MaxLength = dataId.DataBytes;
            }
            else if(WriteDataId.Format == "float")
            {
                textBoxDataIdData.MaxLength = 8;
            }
            else
            {
                textBoxDataIdData.MaxLength = dataId.DataBytes * 2;
            }
        }
        
        protected String getWriteDataArray(string data)
        {
            string rst = null;
            if(WriteDataId.Format == "ASC")
            {
                if(data.Length < WriteDataId.DataBytes)
                {
                    rst = data.Insert(0, new String('0', WriteDataId.DataBytes - data.Length));
                }
                else
                {
                    rst = data;
                }
            }
            else if(WriteDataId.Format == "float")
            {
                rst = data;
            }
            else
            {
                if(data.Length < (WriteDataId.DataBytes * 2))
                {
                    rst = data.Insert(0, new String('0', WriteDataId.DataBytes * 2 - data.Length));
                }
                else
                {
                    rst = data;
                }
            }
            return rst;
        }
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            WriteString = getWriteDataArray(textBoxDataIdData.Text);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxDataIdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(WriteDataId.Format.Contains("N") 
            && (WriteDataId.Format.Replace('N',' ').Trim() == ""))
            {
                if (((e.KeyChar < (char)'0') || (e.KeyChar > (char)'9'))
                && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }
            }
            else if(WriteDataId.Format.Contains("X") 
                && ((string.IsNullOrEmpty(WriteDataId.Format.TrimEnd('X'))) || (WriteDataId.Format.Replace('X',' ').Trim() == "")))
            {
                if (((e.KeyChar < (char)'0') || (e.KeyChar > (char)'9'))
                && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }
            }
        }

        private void FormWrite_Load(object sender, EventArgs e)
        {

        }
    }
}
