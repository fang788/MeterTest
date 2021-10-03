using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeterTest.Source.Config
{
    public partial class FormLicense : Form
    {
        public FormLicense()
        {
            InitializeComponent();
        }

        private void FormLicense_Load(object sender, EventArgs e)
        {
            textBoxLog.Text = RegistrationCode.GetMachineCode();
            if(RegistrationCode.LicFileChk())
            {
                toolStripStatusLabelRegistration.Text = "软件已激活";
                textBoxAuthorization.Text = RegistrationCode.GetResistText(textBoxLog.Text.TrimEnd());
                textBoxAuthorization.ReadOnly = true;
                buttonActivate.Visible = false;
            }
        }

        private void buttonActivate_Click(object sender, EventArgs e)
        {
            if (textBoxLog.Text != "")
            {
                if (textBoxAuthorization.Text.TrimEnd().Equals(RegistrationCode.GetResistText(textBoxLog.Text.TrimEnd())))
                {
                    if (RegistrationCode.LicFileSave(textBoxAuthorization.Text.TrimEnd()) == true)
                    {
                        toolStripStatusLabelRegistration.Text = "注册成功, 请重启！";
                    }
                }
                else
                {
                    toolStripStatusLabelRegistration.Text = "授权码不正确";
                }
            }
            else 
            { 
                toolStripStatusLabelRegistration.Text = "请生成注册码"; 
            }
        }
    }
}
