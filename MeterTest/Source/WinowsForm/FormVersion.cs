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
    public partial class FormVersion : Form
    {
        public FormVersion()
        {
            InitializeComponent();
            labelBuildDateTime.Text = System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToString("yyyy-MM-dd HH:mm:ss"); 
        }
    }
}
