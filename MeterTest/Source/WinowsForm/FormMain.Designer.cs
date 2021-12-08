
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
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于MeterTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.激活ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMainForm = new System.Windows.Forms.TabControl();
            this.tabPageRead = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonReadCycle = new System.Windows.Forms.Button();
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
            this.tabPageEmuAdj = new System.Windows.Forms.TabPage();
            this.comboBoxTypeSelect = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.richTextBoxAdjMeterStatus = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonStartAdjMeter = new System.Windows.Forms.Button();
            this.tabPageFreeze = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFreezeSelect = new System.Windows.Forms.ComboBox();
            this.plotViewFreeze = new OxyPlot.WindowsForms.PlotView();
            this.buttonFreezeReadStop = new System.Windows.Forms.Button();
            this.buttonFreezeRead = new System.Windows.Forms.Button();
            this.statusStrip4 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelFreeze = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarFreezeRead = new System.Windows.Forms.ToolStripProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerFreezeReadEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerFreezeReadStart = new System.Windows.Forms.DateTimePicker();
            this.tabPageCmd = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonMeterClear = new System.Windows.Forms.Button();
            this.statusStrip5 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMeterClear = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboBoxMeterClearPassword = new System.Windows.Forms.ComboBox();
            this.textBoxMeterClearOptCode = new System.Windows.Forms.TextBox();
            this.textBoxMeterClearAddr = new System.Windows.Forms.TextBox();
            this.textBoxMeterClearPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageParaConfig = new System.Windows.Forms.TabPage();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.管理参数配置表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControlMainForm.SuspendLayout();
            this.tabPageRead.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReadList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPageWrite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWrite)).BeginInit();
            this.tabPageEmuAdj.SuspendLayout();
            this.tabPageFreeze.SuspendLayout();
            this.statusStrip4.SuspendLayout();
            this.tabPageCmd.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具ToolStripMenuItem,
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
            this.管理数据标识表ToolStripMenuItem,
            this.管理参数配置表ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.选项ToolStripMenuItem.Text = "选项";
            this.选项ToolStripMenuItem.Click += new System.EventHandler(this.选项ToolStripMenuItem_Click);
            // 
            // 日志ToolStripMenuItem
            // 
            this.日志ToolStripMenuItem.Name = "日志ToolStripMenuItem";
            this.日志ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.日志ToolStripMenuItem.Text = "日志";
            this.日志ToolStripMenuItem.Click += new System.EventHandler(this.日志ToolStripMenuItem_Click);
            // 
            // 管理数据标识表ToolStripMenuItem
            // 
            this.管理数据标识表ToolStripMenuItem.Name = "管理数据标识表ToolStripMenuItem";
            this.管理数据标识表ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.管理数据标识表ToolStripMenuItem.Text = "管理数据标识表";
            this.管理数据标识表ToolStripMenuItem.Click += new System.EventHandler(this.管理数据标识表ToolStripMenuItem_Click);
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
            this.tabControlMainForm.Controls.Add(this.tabPageEmuAdj);
            this.tabControlMainForm.Controls.Add(this.tabPageFreeze);
            this.tabControlMainForm.Controls.Add(this.tabPageCmd);
            this.tabControlMainForm.Controls.Add(this.tabPageParaConfig);
            this.tabControlMainForm.Location = new System.Drawing.Point(10, 25);
            this.tabControlMainForm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControlMainForm.Name = "tabControlMainForm";
            this.tabControlMainForm.SelectedIndex = 0;
            this.tabControlMainForm.Size = new System.Drawing.Size(1052, 487);
            this.tabControlMainForm.TabIndex = 1;
            this.tabControlMainForm.SelectedIndexChanged += new System.EventHandler(this.tabControlMainForm_SelectedIndexChanged);
            // 
            // tabPageRead
            // 
            this.tabPageRead.Controls.Add(this.statusStrip1);
            this.tabPageRead.Controls.Add(this.buttonStop);
            this.tabPageRead.Controls.Add(this.buttonReadCycle);
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
            // buttonReadCycle
            // 
            this.buttonReadCycle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonReadCycle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonReadCycle.Location = new System.Drawing.Point(305, 386);
            this.buttonReadCycle.Name = "buttonReadCycle";
            this.buttonReadCycle.Size = new System.Drawing.Size(90, 30);
            this.buttonReadCycle.TabIndex = 9;
            this.buttonReadCycle.Text = "循环读取";
            this.buttonReadCycle.UseVisualStyleBackColor = true;
            this.buttonReadCycle.Click += new System.EventHandler(this.buttonReadCycle_Click);
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
            // tabPageEmuAdj
            // 
            this.tabPageEmuAdj.Controls.Add(this.comboBoxTypeSelect);
            this.tabPageEmuAdj.Controls.Add(this.label8);
            this.tabPageEmuAdj.Controls.Add(this.richTextBoxAdjMeterStatus);
            this.tabPageEmuAdj.Controls.Add(this.label2);
            this.tabPageEmuAdj.Controls.Add(this.buttonStartAdjMeter);
            this.tabPageEmuAdj.Location = new System.Drawing.Point(4, 26);
            this.tabPageEmuAdj.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageEmuAdj.Name = "tabPageEmuAdj";
            this.tabPageEmuAdj.Size = new System.Drawing.Size(1044, 457);
            this.tabPageEmuAdj.TabIndex = 2;
            this.tabPageEmuAdj.Text = "校表";
            this.tabPageEmuAdj.UseVisualStyleBackColor = true;
            // 
            // comboBoxTypeSelect
            // 
            this.comboBoxTypeSelect.FormattingEnabled = true;
            this.comboBoxTypeSelect.Items.AddRange(new object[] {
            "II型终端-V9203",
            "相变-HT7036"});
            this.comboBoxTypeSelect.Location = new System.Drawing.Point(75, 34);
            this.comboBoxTypeSelect.Name = "comboBoxTypeSelect";
            this.comboBoxTypeSelect.Size = new System.Drawing.Size(121, 25);
            this.comboBoxTypeSelect.TabIndex = 4;
            this.comboBoxTypeSelect.Text = "II型终端-V9203";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "方案：";
            // 
            // richTextBoxAdjMeterStatus
            // 
            this.richTextBoxAdjMeterStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAdjMeterStatus.Location = new System.Drawing.Point(25, 119);
            this.richTextBoxAdjMeterStatus.Name = "richTextBoxAdjMeterStatus";
            this.richTextBoxAdjMeterStatus.Size = new System.Drawing.Size(1011, 318);
            this.richTextBoxAdjMeterStatus.TabIndex = 2;
            this.richTextBoxAdjMeterStatus.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "校表状态";
            // 
            // buttonStartAdjMeter
            // 
            this.buttonStartAdjMeter.Location = new System.Drawing.Point(266, 33);
            this.buttonStartAdjMeter.Name = "buttonStartAdjMeter";
            this.buttonStartAdjMeter.Size = new System.Drawing.Size(82, 26);
            this.buttonStartAdjMeter.TabIndex = 0;
            this.buttonStartAdjMeter.Text = "开始校表";
            this.buttonStartAdjMeter.UseVisualStyleBackColor = true;
            this.buttonStartAdjMeter.Click += new System.EventHandler(this.buttonStartAdjMeter_Click);
            // 
            // tabPageFreeze
            // 
            this.tabPageFreeze.Controls.Add(this.label1);
            this.tabPageFreeze.Controls.Add(this.comboBoxFreezeSelect);
            this.tabPageFreeze.Controls.Add(this.plotViewFreeze);
            this.tabPageFreeze.Controls.Add(this.buttonFreezeReadStop);
            this.tabPageFreeze.Controls.Add(this.buttonFreezeRead);
            this.tabPageFreeze.Controls.Add(this.statusStrip4);
            this.tabPageFreeze.Controls.Add(this.label4);
            this.tabPageFreeze.Controls.Add(this.dateTimePickerFreezeReadEnd);
            this.tabPageFreeze.Controls.Add(this.label3);
            this.tabPageFreeze.Controls.Add(this.dateTimePickerFreezeReadStart);
            this.tabPageFreeze.Location = new System.Drawing.Point(4, 26);
            this.tabPageFreeze.Name = "tabPageFreeze";
            this.tabPageFreeze.Size = new System.Drawing.Size(1044, 457);
            this.tabPageFreeze.TabIndex = 4;
            this.tabPageFreeze.Text = "冻结";
            this.tabPageFreeze.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "曲线：";
            // 
            // comboBoxFreezeSelect
            // 
            this.comboBoxFreezeSelect.FormattingEnabled = true;
            this.comboBoxFreezeSelect.Items.AddRange(new object[] {
            "电压",
            "电流",
            "有功功率",
            "无功功率",
            "视在功率",
            "功率因数",
            "正向有功电能",
            "反向有功电能",
            "正向无功电能",
            "反向无功电能"});
            this.comboBoxFreezeSelect.Location = new System.Drawing.Point(559, 19);
            this.comboBoxFreezeSelect.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxFreezeSelect.Name = "comboBoxFreezeSelect";
            this.comboBoxFreezeSelect.Size = new System.Drawing.Size(121, 25);
            this.comboBoxFreezeSelect.TabIndex = 10;
            this.comboBoxFreezeSelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxFreezeSelect_SelectedIndexChanged);
            // 
            // plotViewFreeze
            // 
            this.plotViewFreeze.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotViewFreeze.Location = new System.Drawing.Point(15, 62);
            this.plotViewFreeze.Name = "plotViewFreeze";
            this.plotViewFreeze.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewFreeze.Size = new System.Drawing.Size(1010, 352);
            this.plotViewFreeze.TabIndex = 9;
            this.plotViewFreeze.Text = "plotViewFreeze";
            this.plotViewFreeze.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewFreeze.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewFreeze.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // buttonFreezeReadStop
            // 
            this.buttonFreezeReadStop.Location = new System.Drawing.Point(872, 14);
            this.buttonFreezeReadStop.Name = "buttonFreezeReadStop";
            this.buttonFreezeReadStop.Size = new System.Drawing.Size(94, 32);
            this.buttonFreezeReadStop.TabIndex = 8;
            this.buttonFreezeReadStop.Text = "停止";
            this.buttonFreezeReadStop.UseVisualStyleBackColor = true;
            this.buttonFreezeReadStop.Click += new System.EventHandler(this.buttonFreezeReadStop_Click);
            // 
            // buttonFreezeRead
            // 
            this.buttonFreezeRead.Location = new System.Drawing.Point(721, 13);
            this.buttonFreezeRead.Name = "buttonFreezeRead";
            this.buttonFreezeRead.Size = new System.Drawing.Size(94, 32);
            this.buttonFreezeRead.TabIndex = 8;
            this.buttonFreezeRead.Text = "读取";
            this.buttonFreezeRead.UseVisualStyleBackColor = true;
            this.buttonFreezeRead.Click += new System.EventHandler(this.buttonFreezeRead_Click);
            // 
            // statusStrip4
            // 
            this.statusStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelFreeze,
            this.toolStripProgressBarFreezeRead});
            this.statusStrip4.Location = new System.Drawing.Point(0, 433);
            this.statusStrip4.Name = "statusStrip4";
            this.statusStrip4.Size = new System.Drawing.Size(1044, 24);
            this.statusStrip4.TabIndex = 7;
            this.statusStrip4.Text = "statusStrip4";
            // 
            // toolStripStatusLabelFreeze
            // 
            this.toolStripStatusLabelFreeze.Name = "toolStripStatusLabelFreeze";
            this.toolStripStatusLabelFreeze.Size = new System.Drawing.Size(56, 19);
            this.toolStripStatusLabelFreeze.Text = "冻结状态";
            // 
            // toolStripProgressBarFreezeRead
            // 
            this.toolStripProgressBarFreezeRead.Name = "toolStripProgressBarFreezeRead";
            this.toolStripProgressBarFreezeRead.Size = new System.Drawing.Size(100, 18);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "结束时间：";
            // 
            // dateTimePickerFreezeReadEnd
            // 
            this.dateTimePickerFreezeReadEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerFreezeReadEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFreezeReadEnd.Location = new System.Drawing.Point(340, 18);
            this.dateTimePickerFreezeReadEnd.Name = "dateTimePickerFreezeReadEnd";
            this.dateTimePickerFreezeReadEnd.Size = new System.Drawing.Size(145, 23);
            this.dateTimePickerFreezeReadEnd.TabIndex = 4;
            this.dateTimePickerFreezeReadEnd.ValueChanged += new System.EventHandler(this.dateTimePickerFreezeReadEnd_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "开始时间：";
            // 
            // dateTimePickerFreezeReadStart
            // 
            this.dateTimePickerFreezeReadStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerFreezeReadStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFreezeReadStart.Location = new System.Drawing.Point(98, 18);
            this.dateTimePickerFreezeReadStart.Name = "dateTimePickerFreezeReadStart";
            this.dateTimePickerFreezeReadStart.Size = new System.Drawing.Size(145, 23);
            this.dateTimePickerFreezeReadStart.TabIndex = 4;
            this.dateTimePickerFreezeReadStart.ValueChanged += new System.EventHandler(this.dateTimePickerFreezeReadStart_ValueChanged);
            // 
            // tabPageCmd
            // 
            this.tabPageCmd.Controls.Add(this.groupBox1);
            this.tabPageCmd.Location = new System.Drawing.Point(4, 26);
            this.tabPageCmd.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageCmd.Name = "tabPageCmd";
            this.tabPageCmd.Size = new System.Drawing.Size(1044, 457);
            this.tabPageCmd.TabIndex = 5;
            this.tabPageCmd.Text = "特殊命令";
            this.tabPageCmd.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonMeterClear);
            this.groupBox1.Controls.Add(this.statusStrip5);
            this.groupBox1.Controls.Add(this.comboBoxMeterClearPassword);
            this.groupBox1.Controls.Add(this.textBoxMeterClearOptCode);
            this.groupBox1.Controls.Add(this.textBoxMeterClearAddr);
            this.groupBox1.Controls.Add(this.textBoxMeterClearPassword);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(13, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(282, 211);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "清零";
            // 
            // buttonMeterClear
            // 
            this.buttonMeterClear.Location = new System.Drawing.Point(96, 151);
            this.buttonMeterClear.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMeterClear.Name = "buttonMeterClear";
            this.buttonMeterClear.Size = new System.Drawing.Size(80, 34);
            this.buttonMeterClear.TabIndex = 4;
            this.buttonMeterClear.Text = "清零";
            this.buttonMeterClear.UseVisualStyleBackColor = true;
            this.buttonMeterClear.Click += new System.EventHandler(this.buttonMeterClear_Click);
            // 
            // statusStrip5
            // 
            this.statusStrip5.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMeterClear});
            this.statusStrip5.Location = new System.Drawing.Point(2, 187);
            this.statusStrip5.Name = "statusStrip5";
            this.statusStrip5.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            this.statusStrip5.Size = new System.Drawing.Size(278, 22);
            this.statusStrip5.TabIndex = 3;
            this.statusStrip5.Text = "statusStrip5";
            // 
            // toolStripStatusLabelMeterClear
            // 
            this.toolStripStatusLabelMeterClear.Name = "toolStripStatusLabelMeterClear";
            this.toolStripStatusLabelMeterClear.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabelMeterClear.Text = "清零状态栏";
            // 
            // comboBoxMeterClearPassword
            // 
            this.comboBoxMeterClearPassword.FormattingEnabled = true;
            this.comboBoxMeterClearPassword.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09"});
            this.comboBoxMeterClearPassword.Location = new System.Drawing.Point(96, 32);
            this.comboBoxMeterClearPassword.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxMeterClearPassword.Name = "comboBoxMeterClearPassword";
            this.comboBoxMeterClearPassword.Size = new System.Drawing.Size(44, 25);
            this.comboBoxMeterClearPassword.TabIndex = 2;
            this.comboBoxMeterClearPassword.Text = "02";
            // 
            // textBoxMeterClearOptCode
            // 
            this.textBoxMeterClearOptCode.Location = new System.Drawing.Point(96, 107);
            this.textBoxMeterClearOptCode.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMeterClearOptCode.MaxLength = 8;
            this.textBoxMeterClearOptCode.Name = "textBoxMeterClearOptCode";
            this.textBoxMeterClearOptCode.Size = new System.Drawing.Size(149, 23);
            this.textBoxMeterClearOptCode.TabIndex = 1;
            this.textBoxMeterClearOptCode.Text = "12345678";
            // 
            // textBoxMeterClearAddr
            // 
            this.textBoxMeterClearAddr.Location = new System.Drawing.Point(96, 70);
            this.textBoxMeterClearAddr.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMeterClearAddr.MaxLength = 12;
            this.textBoxMeterClearAddr.Name = "textBoxMeterClearAddr";
            this.textBoxMeterClearAddr.Size = new System.Drawing.Size(149, 23);
            this.textBoxMeterClearAddr.TabIndex = 1;
            this.textBoxMeterClearAddr.Text = "111111111111";
            // 
            // textBoxMeterClearPassword
            // 
            this.textBoxMeterClearPassword.Location = new System.Drawing.Point(144, 33);
            this.textBoxMeterClearPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMeterClearPassword.MaxLength = 6;
            this.textBoxMeterClearPassword.Name = "textBoxMeterClearPassword";
            this.textBoxMeterClearPassword.Size = new System.Drawing.Size(101, 23);
            this.textBoxMeterClearPassword.TabIndex = 1;
            this.textBoxMeterClearPassword.Text = "123456";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 110);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "操作者代码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "通讯地址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "密码：";
            // 
            // tabPageParaConfig
            // 
            this.tabPageParaConfig.Location = new System.Drawing.Point(4, 26);
            this.tabPageParaConfig.Name = "tabPageParaConfig";
            this.tabPageParaConfig.Size = new System.Drawing.Size(1044, 457);
            this.tabPageParaConfig.TabIndex = 6;
            this.tabPageParaConfig.Text = "参数配置";
            this.tabPageParaConfig.UseVisualStyleBackColor = true;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "写数据状态";
            // 
            // 管理参数配置表ToolStripMenuItem
            // 
            this.管理参数配置表ToolStripMenuItem.Name = "管理参数配置表ToolStripMenuItem";
            this.管理参数配置表ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.管理参数配置表ToolStripMenuItem.Text = "管理参数配置表";
            this.管理参数配置表ToolStripMenuItem.Click += new System.EventHandler(this.管理参数配置表ToolStripMenuItem_Click);
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
            this.tabPageEmuAdj.ResumeLayout(false);
            this.tabPageEmuAdj.PerformLayout();
            this.tabPageFreeze.ResumeLayout(false);
            this.tabPageFreeze.PerformLayout();
            this.statusStrip4.ResumeLayout(false);
            this.statusStrip4.PerformLayout();
            this.tabPageCmd.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip5.ResumeLayout(false);
            this.statusStrip5.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPageEmuAdj;
        private System.Windows.Forms.TabPage tabPageFreeze;
        private System.Windows.Forms.RichTextBox richTextBoxAdjMeterStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonStartAdjMeter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonReadCycle;
        private System.Windows.Forms.Button buttonReadOne;
        private System.Windows.Forms.DataGridView dataGridViewReadList;
        private System.Windows.Forms.DateTimePicker dateTimePickerFreezeReadStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFreeze;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarFreezeRead;
        private System.Windows.Forms.Button buttonFreezeRead;
        private OxyPlot.WindowsForms.PlotView plotViewFreeze;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerFreezeReadEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFreezeSelect;
        private System.Windows.Forms.Button buttonFreezeReadStop;
        private System.Windows.Forms.TabPage tabPageCmd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonMeterClear;
        private System.Windows.Forms.StatusStrip statusStrip5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMeterClear;
        private System.Windows.Forms.ComboBox comboBoxMeterClearPassword;
        private System.Windows.Forms.TextBox textBoxMeterClearOptCode;
        private System.Windows.Forms.TextBox textBoxMeterClearAddr;
        private System.Windows.Forms.TextBox textBoxMeterClearPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxTypeSelect;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPageParaConfig;
        private System.Windows.Forms.ToolStripMenuItem 管理参数配置表ToolStripMenuItem;
    }
}