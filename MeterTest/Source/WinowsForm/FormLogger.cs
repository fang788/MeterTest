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

namespace MeterTest.Source.WindowsForm
{
    public partial class FormLogger : Form
    {
        private SynchronizationContext m_SyncContext = null;
        public FormLogger()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }
        public void ThreadProcSafePost(string message)
        {
            //...执行线程任务

            //在线程中更新UI（通过UI线程同步上下文m_SyncContext）
            m_SyncContext.Post(SetTextSafePost, message);

            //...执行线程其他任务
        }
        /// <summary>
        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetTextSafePost(object text)
        {
            string s = text.ToString() + "\n";
            // this.RichTextBoxLogger.Text += text.ToString();
            // this.RichTextBoxLogger.Text += "\n";
            this.RichTextBoxLogger.AppendText(s);
            RichTextBoxLogger.ScrollToCaret();
        }

        private void FormLogger_FormClosed(object sender, FormClosedEventArgs e)
        {
            RichTextBoxLogger.Clear();
        }
    }
}
