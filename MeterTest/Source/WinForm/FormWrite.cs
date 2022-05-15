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
    public partial class FormWrite : Form
    {
        public String DataString = null;
        TextBox box = null;
        public FormWrite()
        {
            InitializeComponent();
        }

        public FormWrite(DataId dataId)
        {
            InitializeComponent();
            this.Text = dataId.Name;
            labelDataIdName.Text = dataId.Name;
            box = new TextBox();
            box.Location = new System.Drawing.Point(100, 100);
            box.Name = "buttonCancel";
            int width = dataId.DataBytes * 20;
            if(width > (15 * 20))
            {
                width = (15 * 20);
            }
            if(width < (5 * 20))
            {
                width = (5 * 20);
            }
            box.Size = new System.Drawing.Size(width, 17);
            box.TabIndex = 3;
            box.MaxLength = dataId.DataBytes * 2;
            Controls.Add(box);
            if(!String.IsNullOrEmpty(dataId.Unit))
            {
                Label unit = new Label();
                unit.AutoSize = true;
                unit.Location = new System.Drawing.Point(100 + width + 20, 100);
                unit.Name = "labelDataIdName";
                unit.Size = new System.Drawing.Size(43, 17);
                unit.TabIndex = 1;
                unit.Text = dataId.Unit;
                Controls.Add(unit);
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            DataString = box.Text;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
