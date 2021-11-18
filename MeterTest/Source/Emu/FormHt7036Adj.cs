using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeterTest.Source.Config;
using MeterTest.Source.Dlt645;
using Newtonsoft.Json;

namespace MeterTest.Source.Emu
{
    public partial class FormHt7036Adj : Form, IAdjMeterLogger
    {
        private Dlt645Client client;
        private SynchronizationContext synchronizationContext = null;
        public FormHt7036Adj(Dlt645Client c)
        {
            InitializeComponent();
            synchronizationContext = SynchronizationContext.Current;
            client = c;
        }

        private void UpdateAdjMeterStatus(object status)
        {
            string s = status.ToString() + "\n";
            richTextBoxAuto.AppendText(s);
            richTextBoxAuto.ScrollToCaret();
        }

        public void IAdjMeterLog(string message)
        {
            synchronizationContext.Post(UpdateAdjMeterStatus, message);
        }

        private void buttonAutoStart_Click(object sender, EventArgs e)
        {
            Ht7036 ht7036 = new Ht7036(client, this);
            Thread th = new Thread(ht7036.AdjMeter);
            th.IsBackground = true;
            th.Start();
        }

        public void CloseLock()
        {
            throw new NotImplementedException();
        }
    }
}
