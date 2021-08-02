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

namespace MeterTest.Source.WinowsForm
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
            File.WriteAllText(path, JsonConvert.SerializeObject(opt, Formatting.Indented));
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
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
