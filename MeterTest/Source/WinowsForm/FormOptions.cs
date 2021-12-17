using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using MeterTest.Source.Config;

namespace MeterTest.Source.WindowsForm
{
    public partial class FormOptions : Form
    {
        private string path = "Options.txt";
        public FormOptions()
        {
            InitializeComponent();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            Options opt = new Options();
            opt.PortName = ComboBoxPort.Text;
            opt.BaudRate = Convert.ToInt32(ComboBoxBaudRate.Text);
            opt.DataBits = Convert.ToInt32(ComboBoxDataBit.Text);
            opt.Parity = (Parity)Enum.Parse(typeof(Parity), ComboBoxCheckBit.Text);
            opt.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ComboBoxStopBit.Text);
            opt.ReadTimeout = Convert.ToInt32(numericUpDownReadTimeOut.Text);
            opt.MeterAddress = textBoxServerAddress.Text;
            opt.Authority = Convert.ToByte(comboBoxAuthority.Text, 10); 
            opt.Password = textBoxPassword.Text;
            opt.OperatorCode = textBoxOperatorCode.Text;
            opt.KpTableBodyPortName = comboBoxTTPort.Text;
            File.WriteAllText(path, JsonConvert.SerializeObject(opt, Formatting.Indented));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ComboBoxPort_DropDown(object sender, EventArgs e)
        {
            ComboBoxPort.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                ComboBoxPort.Items.Add(s);
            }
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            if (!File.Exists(path))
            {
                string json = JsonConvert.SerializeObject(new Options(), Formatting.Indented);
                File.WriteAllText(path, json);
            }

            {
                Options opt = JsonConvert.DeserializeObject<Options>(File.ReadAllText(path));
                ComboBoxPort.Text = opt.PortName;
                ComboBoxBaudRate.Text = opt.BaudRate.ToString();
                ComboBoxDataBit.Text = opt.DataBits.ToString();
                ComboBoxCheckBit.Text = opt.Parity.ToString();
                ComboBoxStopBit.Text = opt.StopBits.ToString();
                numericUpDownReadTimeOut.Text = opt.ReadTimeout.ToString();
                comboBoxAuthority.Text = opt.Authority.ToString("X2"); 
                textBoxPassword.Text = opt.Password;
                textBoxOperatorCode.Text = opt.OperatorCode;
                textBoxServerAddress.Text = opt.MeterAddress;
                comboBoxTTPort.Text = opt.KpTableBodyPortName;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxServerAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(((e.KeyChar < (char)'0') || (e.KeyChar > (char)'9')) 
            && (e.KeyChar != (char)'A')
            && (e.KeyChar != (char)'a')
            && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true; 
            }
        }

        private void comboBoxTTPort_DropDown(object sender, EventArgs e)
        {
            comboBoxTTPort.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                comboBoxTTPort.Items.Add(s);
            }
        }
    }
}
