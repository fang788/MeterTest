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

namespace MeterTest.Source.WinForm
{
    public partial class FormDataIdAddAndChg : Form
    {
        public DataId AddAndChgDataId = new DataId();
        public FormDataIdAddAndChg()
        {
            InitializeComponent();
        }

        public FormDataIdAddAndChg(DataId dataId)
        {
            InitializeComponent();
            textBoxName.Text          = dataId.Name;
            textBoxId.Text            = dataId.Id.ToString("X8");
            textBoxFormat.Text        = dataId.Format   ;
            textBoxUnit.Text          = dataId.Unit     ;
            textBoxGroup.Text         = dataId.GroupName; 
            textBoxLen.Text           = dataId.DataBytes.ToString(); 
            checkBoxReadable.Checked  = dataId.IsReadable;
            checkBoxWriteable.Checked = dataId.IsWritable;
            AddAndChgDataId = dataId;
        }

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < (char)'0') || (e.KeyChar > (char)'9'))
            && ((e.KeyChar < (char)'A') || (e.KeyChar > (char)'F'))
            && ((e.KeyChar < (char)'a') || (e.KeyChar > (char)'f'))
            && (e.KeyChar != (char)Keys.Back)
            && (e.KeyChar != (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            AddAndChgDataId.Name   = textBoxName.Text;
            AddAndChgDataId.Id     = Convert.ToUInt32(textBoxId.Text, 16);
            AddAndChgDataId.Format = textBoxFormat.Text;
            AddAndChgDataId.Unit   = textBoxUnit.Text;
            AddAndChgDataId.GroupName = textBoxGroup.Text; 
            AddAndChgDataId.DataBytes = Convert.ToInt32(textBoxLen.Text); 
            AddAndChgDataId.IsReadable = checkBoxReadable.Checked;
            AddAndChgDataId.IsWritable = checkBoxWriteable.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
