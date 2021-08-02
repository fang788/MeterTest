using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeterTest.Source.WinowsForm
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

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
            FormLogger form = new FormLogger();

            form.StartPosition = FormStartPosition.CenterParent;
            form.Show();
        }
    }
}
