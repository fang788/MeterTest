﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeterTest.Source.WinForm
{
    public partial class FormVersion : Form
    {
        public static string Version = "V2.2.0";
        public FormVersion()
        {
            InitializeComponent();
            labelBuildDateTime.Text = System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToString("yyyy-MM-dd HH:mm:ss"); 
        }
    }
}
