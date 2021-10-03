using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeterTest.Source.Emu
{
    public partial class Ht7036Convert : Form
    {
        public Ht7036Convert()
        {
            InitializeComponent();
        }

        private void buttonSelectFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "excel文件(*.xlsx,*.xls)|*.xlsx;*.xls";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxFilePath.Text = fileDialog.FileName;
            }
        }

        private void buttonStartConvert_Click(object sender, EventArgs e)
        {
            if(this.textBoxFilePath.Text.Trim().Length < 2)
            {
                MessageBox.Show("请选择文件路径！", "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(!this.comboBoxRegisterType.Items.Contains(this.comboBoxRegisterType.Text))
            {
                MessageBox.Show("请选择寄存器类型！", "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(!this.comboBoxConvertType.Items.Contains(this.comboBoxConvertType.Text))
            {
                MessageBox.Show("请选择转换类型！", "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            richTextBoxHt7036Reg.Clear();
            List<Ht7036Register> list = Ht7036.ExcelConvertToRegisterList(this.textBoxFilePath.Text, this.comboBoxRegisterType.Text);
            int countMax = 0;
            foreach (Ht7036Register register in list)
            {
                int hanCount = register.GetHanCountDescribe();
                if(hanCount > countMax)
                {
                    countMax = hanCount;
                }
            }
            foreach (var register in list)
            {
                string regString = null;
                if(this.comboBoxConvertType.Text == "地址枚举")
                {
                    regString = register.GetRegAddressEnum(countMax * 2);
                }
                else
                {
                    if(this.comboBoxRegisterType.Text == "校表参数寄存器")
                    {
                        if(checkBoxEeprom.Checked == true)
                        {
                            if(register.IsEeprom)
                            {
                                regString = register.GetRegDefaultValueString(countMax * 2);
                            }
                        }
                        else
                        {
                            if(!register.IsEeprom)
                            {
                                regString = register.GetRegDefaultValueString(countMax * 2);
                            }
                        }
                    }
                }
                if(regString != null)
                {
                    richTextBoxHt7036Reg.AppendText(regString + "\n");
                    richTextBoxHt7036Reg.ScrollToCaret();
                }
                
            }
        }
    }
}
