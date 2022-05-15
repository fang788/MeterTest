using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.WindowsForm
{
    public partial class FormLogger : Form, IDlt645CommLog
    {
        private SynchronizationContext m_SyncContext = null;
        public FormLogger()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }
        /// <summary>
        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetTextSafePost(object text)
        {
            string s = text.ToString() + "\n";
            this.RichTextBoxLogger.AppendText(s);
            RichTextBoxLogger.ScrollToCaret();
        }

        private void FormLogger_FormClosed(object sender, FormClosedEventArgs e)
        {
            RichTextBoxLogger.Clear();
        }

        public void Log(string message)
        {
            m_SyncContext.Post(SetTextSafePost, message);
        }
    }
}
