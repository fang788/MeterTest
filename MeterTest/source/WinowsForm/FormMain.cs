using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeterTest.Source.Config;
using MeterTest.Source.Dlt645;
using Newtonsoft.Json;

namespace MeterTest.Source.WinowsForm
{
    public partial class FormMain : Form
    {
        private FormLogger formLogger = new FormLogger();
        private SerialPort serialPort;
        private Transport transport;
        private ConsoleLogger consoleLogger;
        private Client client;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Options opt = null;
            if(File.Exists("Options.txt"))
            {
                opt = JsonConvert.DeserializeObject<Options>(File.ReadAllText("Options.txt"));
            }
            else
            {
                opt = new Options();
            }
            serialPort = new SerialPort(opt.PortName, opt.BaudRate, opt.Parity, opt.DataBits, opt.StopBits);
            consoleLogger = new ConsoleLogger(formLogger);
            transport = new Transport(serialPort, consoleLogger);
            client = new Client(transport);
        }

        private void 关于MeterTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVersion form = new FormVersion();

            this.AddOwnedForm(form);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void 选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOptions form = new FormOptions();

            this.AddOwnedForm(form);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void 日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(formLogger.Visible)
            {
                formLogger.Show();
            }
            else
            {
                formLogger.StartPosition = FormStartPosition.CenterParent;
                formLogger.Show();
            }
        }
    }
}
