
namespace MeterTest.Source.WinowsForm
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理数据标识表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.校表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hT7036校表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于MeterTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.激活ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMainForm = new System.Windows.Forms.TabControl();
            this.tabPageRead = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonReadClyce = new System.Windows.Forms.Button();
            this.buttonReadOne = new System.Windows.Forms.Button();
            this.dataGridViewReadList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择所有ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消所有选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除所有数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageWrite = new System.Windows.Forms.TabPage();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewWrite = new System.Windows.Forms.DataGridView();
            this.tabPageV9203 = new System.Windows.Forms.TabPage();
            this.richTextBoxAdjMeterStatus = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonStartAdjMeter = new System.Windows.Forms.Button();
            this.tabPageChangeCommAddr = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.plotViewFreeze = new OxyPlot.WindowsForms.PlotView();
            this.buttonFreezeRead = new System.Windows.Forms.Button();
            this.statusStrip4 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.buttonReadFreezeData = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.tabControlMainForm.SuspendLayout();
            this.tabPageRead.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReadList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPageWrite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWrite)).BeginInit();
            this.tabPageV9203.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具ToolStripMenuItem,
            this.校表ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1062, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选项ToolStripMenuItem,
            this.日志ToolStripMenuItem,
            this.管理数据标识表ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.选项ToolStripMenuItem.Text = "选项";
            this.选项ToolStripMenuItem.Click += new System.EventHandler(this.选项ToolStripMenuItem_Click);
            // 
            // 日志ToolStripMenuItem
            // 
            this.日志ToolStripMenuItem.Name = "日志ToolStripMenuItem";
            this.日志ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.日志ToolStripMenuItem.Text = "日志";
            this.日志ToolStripMenuItem.Click += new System.EventHandler(this.日志ToolStripMenuItem_Click);
            // 
            // 管理数据标识表ToolStripMenuItem
            // 
            this.管理数据标识表ToolStripMenuItem.Name = "管理数据标识表ToolStripMenuItem";
            this.管理数据标识表ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.管理数据标识表ToolStripMenuItem.Text = "管理数据标识表";
            this.管理数据标识表ToolStripMenuItem.Click += new System.EventHandler(this.管理数据标识表ToolStripMenuItem_Click);
            // 
            // 校表ToolStripMenuItem
            // 
            this.校表ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hT7036校表ToolStripMenuItem});
            this.校表ToolStripMenuItem.Name = "校表ToolStripMenuItem";
            this.校表ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.校表ToolStripMenuItem.Text = "校表";
            // 
            // hT7036校表ToolStripMenuItem
            // 
            this.hT7036校表ToolStripMenuItem.Name = "hT7036校表ToolStripMenuItem";
            this.hT7036校表ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.hT7036校表ToolStripMenuItem.Text = "HT7036校表";
            this.hT7036校表ToolStripMenuItem.Click += new System.EventHandler(this.hT7036校表ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于MeterTestToolStripMenuItem,
            this.激活ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于MeterTestToolStripMenuItem
            // 
            this.关于MeterTestToolStripMenuItem.Name = "关于MeterTestToolStripMenuItem";
            this.关于MeterTestToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.关于MeterTestToolStripMenuItem.Text = "关于 MeterTest";
            this.关于MeterTestToolStripMenuItem.Click += new System.EventHandler(this.关于MeterTestToolStripMenuItem_Click);
            // 
            // 激活ToolStripMenuItem
            // 
            this.激活ToolStripMenuItem.Name = "激活ToolStripMenuItem";
            this.激活ToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.激活ToolStripMenuItem.Text = "激活";
            this.激活ToolStripMenuItem.Click += new System.EventHandler(this.激活ToolStripMenuItem_Click);
            // 
            // tabControlMainForm
            // 
            this.tabControlMainForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMainForm.Controls.Add(this.tabPageRead);
            this.tabControlMainForm.Controls.Add(this.tabPageWrite);
            this.tabControlMainForm.Controls.Add(this.tabPageV9203);
            this.tabControlMainForm.Controls.Add(this.tabPageChangeCommAddr);
            this.tabControlMainForm.Controls.Add(this.tabPage1);
            this.tabControlMainForm.Location = new System.Drawing.Point(10, 25);
            this.tabControlMainForm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControlMainForm.Name = "tabControlMainForm";
            this.tabControlMainForm.SelectedIndex = 0;
            this.tabControlMainForm.Size = new System.Drawing.Size(1052, 487);
            this.tabControlMainForm.TabIndex = 1;
            // 
            // tabPageRead
            // 
            this.tabPageRead.Controls.Add(this.statusStrip1);
            this.tabPageRead.Controls.Add(this.buttonStop);
            this.tabPageRead.Controls.Add(this.buttonReadClyce);
            this.tabPageRead.Controls.Add(this.buttonReadOne);
            this.tabPageRead.Controls.Add(this.dataGridViewReadList);
            this.tabPageRead.Location = new System.Drawing.Point(4, 26);
            this.tabPageRead.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageRead.Name = "tabPageRead";
            this.tabPageRead.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageRead.Size = new System.Drawing.Size(1044, 457);
            this.tabPageRead.TabIndex = 0;
            this.tabPageRead.Text = "读数据";
            this.tabPageRead.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(2, 432);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1040, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabelStatus.Text = "状态栏";
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonStop.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStop.Location = new System.Drawing.Point(586, 386);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(90, 30);
            this.buttonStop.TabIndex = 8;
            this.buttonStop.Text = "停止";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonReadClyce
            // 
            this.buttonReadClyce.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonReadClyce.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonReadClyce.Location = new System.Drawing.Point(305, 386);
            this.buttonReadClyce.Name = "buttonReadClyce";
            this.buttonReadClyce.Size = new System.Drawing.Size(90, 30);
            this.buttonReadClyce.TabIndex = 9;
            this.buttonReadClyce.Text = "循环读取";
            this.buttonReadClyce.UseVisualStyleBackColor = true;
            this.buttonReadClyce.Click += new System.EventHandler(this.buttonReadClyce_Click);
            // 
            // buttonReadOne
            // 
            this.buttonReadOne.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonReadOne.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonReadOne.Location = new System.Drawing.Point(24, 384);
            this.buttonReadOne.Name = "buttonReadOne";
            this.buttonReadOne.Size = new System.Drawing.Size(90, 30);
            this.buttonReadOne.TabIndex = 10;
            this.buttonReadOne.Text = "单次读取";
            this.buttonReadOne.UseVisualStyleBackColor = true;
            this.buttonReadOne.Click += new System.EventHandler(this.buttonReadOne_Click);
            // 
            // dataGridViewReadList
            // 
            this.dataGridViewReadList.AllowUserToAddRows = false;
            this.dataGridViewReadList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReadList.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dataGridViewReadList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReadList.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewReadList.Location = new System.Drawing.Point(5, 6);
            this.dataGridViewReadList.Name = "dataGridViewReadList";
            this.dataGridViewReadList.RowHeadersWidth = 51;
            this.dataGridViewReadList.RowTemplate.Height = 25;
            this.dataGridViewReadList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReadList.Size = new System.Drawing.Size(1026, 374);
            this.dataGridViewReadList.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择ToolStripMenuItem,
            this.取消选择ToolStripMenuItem,
            this.选择所有ToolStripMenuItem,
            this.取消所有选择ToolStripMenuItem,
            this.清除所有数据ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 114);
            // 
            // 选择ToolStripMenuItem
            // 
            this.选择ToolStripMenuItem.Name = "选择ToolStripMenuItem";
            this.选择ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.选择ToolStripMenuItem.Text = "选择";
            this.选择ToolStripMenuItem.Click += new System.EventHandler(this.选择ToolStripMenuItem_Click);
            // 
            // 取消选择ToolStripMenuItem
            // 
            this.取消选择ToolStripMenuItem.Name = "取消选择ToolStripMenuItem";
            this.取消选择ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.取消选择ToolStripMenuItem.Text = "取消选择";
            this.取消选择ToolStripMenuItem.Click += new System.EventHandler(this.取消选择ToolStripMenuItem_Click);
            // 
            // 选择所有ToolStripMenuItem
            // 
            this.选择所有ToolStripMenuItem.Name = "选择所有ToolStripMenuItem";
            this.选择所有ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.选择所有ToolStripMenuItem.Text = "选择所有";
            this.选择所有ToolStripMenuItem.Click += new System.EventHandler(this.选择所有ToolStripMenuItem_Click);
            // 
            // 取消所有选择ToolStripMenuItem
            // 
            this.取消所有选择ToolStripMenuItem.Name = "取消所有选择ToolStripMenuItem";
            this.取消所有选择ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.取消所有选择ToolStripMenuItem.Text = "取消所有选择";
            this.取消所有选择ToolStripMenuItem.Click += new System.EventHandler(this.取消所有选择ToolStripMenuItem_Click);
            // 
            // 清除所有数据ToolStripMenuItem
            // 
            this.清除所有数据ToolStripMenuItem.Name = "清除所有数据ToolStripMenuItem";
            this.清除所有数据ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.清除所有数据ToolStripMenuItem.Text = "清除所有数据";
            this.清除所有数据ToolStripMenuItem.Click += new System.EventHandler(this.清除所有数据ToolStripMenuItem_Click);
            // 
            // tabPageWrite
            // 
            this.tabPageWrite.Controls.Add(this.statusStrip2);
            this.tabPageWrite.Controls.Add(this.button3);
            this.tabPageWrite.Controls.Add(this.button2);
            this.tabPageWrite.Controls.Add(this.button1);
            this.tabPageWrite.Controls.Add(this.dataGridViewWrite);
            this.tabPageWrite.Location = new System.Drawing.Point(4, 26);
            this.tabPageWrite.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageWrite.Name = "tabPageWrite";
            this.tabPageWrite.Size = new System.Drawing.Size(1044, 457);
            this.tabPageWrite.TabIndex = 1;
            this.tabPageWrite.Text = "写数据";
            // 
            // statusStrip2
            // 
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Location = new System.Drawing.Point(0, 435);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1044, 22);
            this.statusStrip2.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(462, 400);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 30);
            this.button3.TabIndex = 6;
            this.button3.Text = "停止";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(282, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "循环写入";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(102, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "单次写入";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWrite
            // 
            this.dataGridViewWrite.AllowUserToAddRows = false;
            this.dataGridViewWrite.AllowUserToDeleteRows = false;
            this.dataGridViewWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWrite.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dataGridViewWrite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWrite.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewWrite.Name = "dataGridViewWrite";
            this.dataGridViewWrite.RowHeadersWidth = 51;
            this.dataGridViewWrite.RowTemplate.Height = 25;
            this.dataGridViewWrite.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWrite.Size = new System.Drawing.Size(1034, 378);
            this.dataGridViewWrite.TabIndex = 3;
            this.dataGridViewWrite.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWrite_CellDoubleClick);
            // 
            // tabPageV9203
            // 
            this.tabPageV9203.Controls.Add(this.richTextBoxAdjMeterStatus);
            this.tabPageV9203.Controls.Add(this.label2);
            this.tabPageV9203.Controls.Add(this.button4);
            this.tabPageV9203.Controls.Add(this.buttonStartAdjMeter);
            this.tabPageV9203.Location = new System.Drawing.Point(4, 26);
            this.tabPageV9203.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageV9203.Name = "tabPageV9203";
            this.tabPageV9203.Size = new System.Drawing.Size(1044, 457);
            this.tabPageV9203.TabIndex = 2;
            this.tabPageV9203.Text = "V9203";
            this.tabPageV9203.UseVisualStyleBackColor = true;
            // 
            // richTextBoxAdjMeterStatus
            // 
            this.richTextBoxAdjMeterStatus.Location = new System.Drawing.Point(46, 119);
            this.richTextBoxAdjMeterStatus.Name = "richTextBoxAdjMeterStatus";
            this.richTextBoxAdjMeterStatus.Size = new System.Drawing.Size(379, 304);
            this.richTextBoxAdjMeterStatus.TabIndex = 2;
            this.richTextBoxAdjMeterStatus.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "校表状态";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(309, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 26);
            this.button4.TabIndex = 0;
            this.button4.Text = "开始测试";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonStartAdjMeter
            // 
            this.buttonStartAdjMeter.Location = new System.Drawing.Point(46, 39);
            this.buttonStartAdjMeter.Name = "buttonStartAdjMeter";
            this.buttonStartAdjMeter.Size = new System.Drawing.Size(82, 26);
            this.buttonStartAdjMeter.TabIndex = 0;
            this.buttonStartAdjMeter.Text = "开始校表";
            this.buttonStartAdjMeter.UseVisualStyleBackColor = true;
            this.buttonStartAdjMeter.Click += new System.EventHandler(this.buttonStartAdjMeter_Click);
            // 
            // tabPageChangeCommAddr
            // 
            this.tabPageChangeCommAddr.Location = new System.Drawing.Point(4, 26);
            this.tabPageChangeCommAddr.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageChangeCommAddr.Name = "tabPageChangeCommAddr";
            this.tabPageChangeCommAddr.Size = new System.Drawing.Size(1044, 457);
            this.tabPageChangeCommAddr.TabIndex = 3;
            this.tabPageChangeCommAddr.Text = "通讯地址";
            this.tabPageChangeCommAddr.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.plotViewFreeze);
            this.tabPage1.Controls.Add(this.buttonFreezeRead);
            this.tabPage1.Controls.Add(this.statusStrip4);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.dateTimePicker2);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.statusStrip3);
            this.tabPage1.Controls.Add(this.buttonReadFreezeData);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1044, 457);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "冻结";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // plotViewFreeze
            // 
            this.plotViewFreeze.Location = new System.Drawing.Point(13, 24);
            this.plotViewFreeze.Name = "plotViewFreeze";
            this.plotViewFreeze.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewFreeze.Size = new System.Drawing.Size(745, 320);
            this.plotViewFreeze.TabIndex = 9;
            this.plotViewFreeze.Text = "plotViewFreeze";
            this.plotViewFreeze.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewFreeze.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewFreeze.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // buttonFreezeRead
            // 
            this.buttonFreezeRead.Location = new System.Drawing.Point(442, 375);
            this.buttonFreezeRead.Name = "buttonFreezeRead";
            this.buttonFreezeRead.Size = new System.Drawing.Size(94, 32);
            this.buttonFreezeRead.TabIndex = 8;
            this.buttonFreezeRead.Text = "读取";
            this.buttonFreezeRead.UseVisualStyleBackColor = true;
            this.buttonFreezeRead.Click += new System.EventHandler(this.buttonFreezeRead_Click);
            // 
            // statusStrip4
            // 
            this.statusStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            this.statusStrip4.Location = new System.Drawing.Point(0, 413);
            this.statusStrip4.Name = "statusStrip4";
            this.statusStrip4.Size = new System.Drawing.Size(1044, 22);
            this.statusStrip4.TabIndex = 7;
            this.statusStrip4.Text = "statusStrip4";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel2.Text = "冻结状态";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "结束时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "开始时间";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(299, 380);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(113, 23);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 380);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(110, 23);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(777, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "进度";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(832, 185);
            this.progressBar1.Maximum = 672;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(158, 16);
            this.progressBar1.TabIndex = 2;
            // 
            // statusStrip3
            // 
            this.statusStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip3.Location = new System.Drawing.Point(0, 435);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(1044, 22);
            this.statusStrip3.TabIndex = 1;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // buttonReadFreezeData
            // 
            this.buttonReadFreezeData.Location = new System.Drawing.Point(887, 133);
            this.buttonReadFreezeData.Name = "buttonReadFreezeData";
            this.buttonReadFreezeData.Size = new System.Drawing.Size(103, 31);
            this.buttonReadFreezeData.TabIndex = 0;
            this.buttonReadFreezeData.Text = "读取冻结数据";
            this.buttonReadFreezeData.UseVisualStyleBackColor = true;
            this.buttonReadFreezeData.Click += new System.EventHandler(this.buttonReadFreezeData_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "写数据状态";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1062, 515);
            this.Controls.Add(this.tabControlMainForm);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormMain";
            this.Text = "MeterTest";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControlMainForm.ResumeLayout(false);
            this.tabPageRead.ResumeLayout(false);
            this.tabPageRead.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReadList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPageWrite.ResumeLayout(false);
            this.tabPageWrite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWrite)).EndInit();
            this.tabPageV9203.ResumeLayout(false);
            this.tabPageV9203.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip4.ResumeLayout(false);
            this.statusStrip4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于MeterTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMainForm;
        private System.Windows.Forms.TabPage tabPageRead;
        private System.Windows.Forms.ToolStripMenuItem 日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 管理数据标识表ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择所有ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消所有选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除所有数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 激活ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage tabPageWrite;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewWrite;
        private System.Windows.Forms.TabPage tabPageV9203;
        private System.Windows.Forms.TabPage tabPageChangeCommAddr;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonReadFreezeData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.RichTextBox richTextBoxAdjMeterStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonStartAdjMeter;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonReadClyce;
        private System.Windows.Forms.Button buttonReadOne;
        private System.Windows.Forms.DataGridView dataGridViewReadList;
        private System.Windows.Forms.ToolStripMenuItem 校表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hT7036校表ToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Button buttonFreezeRead;
        private OxyPlot.WindowsForms.PlotView plotViewFreeze;
    }
}