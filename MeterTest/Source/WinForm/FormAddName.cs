using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeterTest.Source.WindowsForm
{
    public partial class FormAddName : Form
    {
        private string text;
        private string tip;
        private string type;
        public string SelectRwProjectName;
        public FormAddName()
        {
            InitializeComponent();
        }

        public FormAddName(string text, string tip, string type)
        {
            this.text = text;
            this.tip = tip;
            this.type = type;
            InitializeComponent();
        }

        private void FormAddName_Load(object sender, EventArgs e)
        {
            this.Text = text;
            this.labelTip.Text = tip;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text.Trim().Length > 0)
            {
                this.SelectRwProjectName = textBoxName.Text.Trim();
            }
            this.Close();
        }
    }
}
