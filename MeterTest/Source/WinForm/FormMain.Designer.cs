
namespace MeterTest.Source.WinForm
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
            System.Windows.Forms.ContextMenuStrip contextMenuStripWrite;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.选择ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.取消选择ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.选择所有ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.清除所有选择 = new System.Windows.Forms.ToolStripMenuItem();
            this.写入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于MeterTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripRead = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择所有ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消所有选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除所有数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单次读取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.循环读取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.选择读取表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripParaConfig = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.编程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.比对ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择参数配置方案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通讯地址自适应ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelParaConfig = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelParaConfigTable = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewPara = new System.Windows.Forms.DataGridView();
            this.tabPageWrite = new System.Windows.Forms.TabPage();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelWrite = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelWriteTabName = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewWrite = new System.Windows.Forms.DataGridView();
            this.tabPageRead = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelRead = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRwTab = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewRead = new System.Windows.Forms.DataGridView();
            this.tabControlMainForm = new System.Windows.Forms.TabControl();
            contextMenuStripWrite = new System.Windows.Forms.ContextMenuStrip(this.components);
            contextMenuStripWrite.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripRead.SuspendLayout();
            this.contextMenuStripParaConfig.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.statusStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPara)).BeginInit();
            this.tabPageWrite.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWrite)).BeginInit();
            this.tabPageRead.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRead)).BeginInit();
            this.tabControlMainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripWrite
            // 
            contextMenuStripWrite.ImageScalingSize = new System.Drawing.Size(24, 24);
            contextMenuStripWrite.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择ToolStripMenuItem1,
            this.取消选择ToolStripMenuItem1,
            this.选择所有ToolStripMenuItem1,
            this.清除所有选择,
            this.写入ToolStripMenuItem});
            contextMenuStripWrite.Name = "contextMenuStripFreeze";
            contextMenuStripWrite.Size = new System.Drawing.Size(149, 114);
            // 
            // 选择ToolStripMenuItem1
            // 
            this.选择ToolStripMenuItem1.Name = "选择ToolStripMenuItem1";
            this.选择ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.选择ToolStripMenuItem1.Text = "选择";
            this.选择ToolStripMenuItem1.Click += new System.EventHandler(this.选择ToolStripMenuItem_Click);
            // 
            // 取消选择ToolStripMenuItem1
            // 
            this.取消选择ToolStripMenuItem1.Name = "取消选择ToolStripMenuItem1";
            this.取消选择ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.取消选择ToolStripMenuItem1.Text = "取消选择";
            this.取消选择ToolStripMenuItem1.Click += new System.EventHandler(this.取消选择ToolStripMenuItem_Click);
            // 
            // 选择所有ToolStripMenuItem1
            // 
            this.选择所有ToolStripMenuItem1.Name = "选择所有ToolStripMenuItem1";
            this.选择所有ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.选择所有ToolStripMenuItem1.Text = "选择所有";
            this.选择所有ToolStripMenuItem1.Click += new System.EventHandler(this.选择所有ToolStripMenuItem_Click);
            // 
            // 清除所有选择
            // 
            this.清除所有选择.Name = "清除所有选择";
            this.清除所有选择.Size = new System.Drawing.Size(148, 22);
            this.清除所有选择.Text = "清除所有选择";
            this.清除所有选择.Click += new System.EventHandler(this.取消所有选择ToolStripMenuItem_Click);
            // 
            // 写入ToolStripMenuItem
            // 
            this.写入ToolStripMenuItem.Name = "写入ToolStripMenuItem";
            this.写入ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.写入ToolStripMenuItem.Text = "写入";
            this.写入ToolStripMenuItem.Click += new System.EventHandler(this.写入ToolStripMenuItem_Click);
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
            this.日志ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.选项ToolStripMenuItem.Text = "选项";
            this.选项ToolStripMenuItem.Click += new System.EventHandler(this.选项ToolStripMenuItem_Click);
            // 
            // 日志ToolStripMenuItem
            // 
            this.日志ToolStripMenuItem.Name = "日志ToolStripMenuItem";
            this.日志ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.日志ToolStripMenuItem.Text = "日志";
            this.日志ToolStripMenuItem.Click += new System.EventHandler(this.日志ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于MeterTestToolStripMenuItem});
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
            // contextMenuStripRead
            // 
            this.contextMenuStripRead.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripRead.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择ToolStripMenuItem,
            this.取消选择ToolStripMenuItem,
            this.选择所有ToolStripMenuItem,
            this.取消所有选择ToolStripMenuItem,
            this.清除所有数据ToolStripMenuItem,
            this.单次读取ToolStripMenuItem,
            this.循环读取ToolStripMenuItem,
            this.停止ToolStripMenuItem1,
            this.选择读取表ToolStripMenuItem});
            this.contextMenuStripRead.Name = "contextMenuStrip1";
            this.contextMenuStripRead.Size = new System.Drawing.Size(149, 202);
            this.contextMenuStripRead.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripRead_Opening);
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
            // 单次读取ToolStripMenuItem
            // 
            this.单次读取ToolStripMenuItem.Name = "单次读取ToolStripMenuItem";
            this.单次读取ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.单次读取ToolStripMenuItem.Text = "读取";
            this.单次读取ToolStripMenuItem.Click += new System.EventHandler(this.单次读取ToolStripMenuItem_Click);
            // 
            // 循环读取ToolStripMenuItem
            // 
            this.循环读取ToolStripMenuItem.Name = "循环读取ToolStripMenuItem";
            this.循环读取ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.循环读取ToolStripMenuItem.Text = "循环读取";
            this.循环读取ToolStripMenuItem.Click += new System.EventHandler(this.循环读取ToolStripMenuItem_Click);
            // 
            // 停止ToolStripMenuItem1
            // 
            this.停止ToolStripMenuItem1.Name = "停止ToolStripMenuItem1";
            this.停止ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.停止ToolStripMenuItem1.Text = "停止";
            this.停止ToolStripMenuItem1.Click += new System.EventHandler(this.停止ToolStripMenuItem1_Click);
            // 
            // 选择读取表ToolStripMenuItem
            // 
            this.选择读取表ToolStripMenuItem.Name = "选择读取表ToolStripMenuItem";
            this.选择读取表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.选择读取表ToolStripMenuItem.Text = "选择读取表";
            // 
            // contextMenuStripParaConfig
            // 
            this.contextMenuStripParaConfig.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripParaConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编程ToolStripMenuItem,
            this.比对ToolStripMenuItem,
            this.停止ToolStripMenuItem,
            this.选择参数配置方案ToolStripMenuItem,
            this.通讯地址自适应ToolStripMenuItem});
            this.contextMenuStripParaConfig.Name = "contextMenuStripParaConfig";
            this.contextMenuStripParaConfig.Size = new System.Drawing.Size(173, 114);
            this.contextMenuStripParaConfig.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripParaConfig_Opening);
            // 
            // 编程ToolStripMenuItem
            // 
            this.编程ToolStripMenuItem.Name = "编程ToolStripMenuItem";
            this.编程ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.编程ToolStripMenuItem.Text = "编程";
            this.编程ToolStripMenuItem.Click += new System.EventHandler(this.编程ToolStripMenuItem_Click);
            // 
            // 比对ToolStripMenuItem
            // 
            this.比对ToolStripMenuItem.Name = "比对ToolStripMenuItem";
            this.比对ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.比对ToolStripMenuItem.Text = "比对";
            this.比对ToolStripMenuItem.Click += new System.EventHandler(this.比对ToolStripMenuItem_Click);
            // 
            // 停止ToolStripMenuItem
            // 
            this.停止ToolStripMenuItem.Name = "停止ToolStripMenuItem";
            this.停止ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.停止ToolStripMenuItem.Text = "停止";
            this.停止ToolStripMenuItem.Click += new System.EventHandler(this.停止ToolStripMenuItem_Click);
            // 
            // 选择参数配置方案ToolStripMenuItem
            // 
            this.选择参数配置方案ToolStripMenuItem.Name = "选择参数配置方案ToolStripMenuItem";
            this.选择参数配置方案ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.选择参数配置方案ToolStripMenuItem.Text = "选择参数配置方案";
            // 
            // 通讯地址自适应ToolStripMenuItem
            // 
            this.通讯地址自适应ToolStripMenuItem.Name = "通讯地址自适应ToolStripMenuItem";
            this.通讯地址自适应ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.通讯地址自适应ToolStripMenuItem.Text = "通讯地址自适应";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "写数据状态";
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.statusStrip3);
            this.tabPageConfig.Controls.Add(this.dataGridViewPara);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 26);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Size = new System.Drawing.Size(1044, 457);
            this.tabPageConfig.TabIndex = 6;
            this.tabPageConfig.Text = "参数配置";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // statusStrip3
            // 
            this.statusStrip3.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelParaConfig,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelParaConfigTable});
            this.statusStrip3.Location = new System.Drawing.Point(0, 435);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(1044, 22);
            this.statusStrip3.TabIndex = 1;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // toolStripStatusLabelParaConfig
            // 
            this.toolStripStatusLabelParaConfig.Name = "toolStripStatusLabelParaConfig";
            this.toolStripStatusLabelParaConfig.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabelParaConfig.Text = "参数配置状态";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(881, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabelParaConfigTable
            // 
            this.toolStripStatusLabelParaConfigTable.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabelParaConfigTable.Name = "toolStripStatusLabelParaConfigTable";
            this.toolStripStatusLabelParaConfigTable.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabelParaConfigTable.Text = "当前方案：";
            // 
            // dataGridViewPara
            // 
            this.dataGridViewPara.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPara.ContextMenuStrip = this.contextMenuStripParaConfig;
            this.dataGridViewPara.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewPara.Name = "dataGridViewPara";
            this.dataGridViewPara.RowHeadersWidth = 62;
            this.dataGridViewPara.RowTemplate.Height = 25;
            this.dataGridViewPara.Size = new System.Drawing.Size(1033, 429);
            this.dataGridViewPara.TabIndex = 0;
            // 
            // tabPageWrite
            // 
            this.tabPageWrite.Controls.Add(this.statusStrip2);
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
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelWrite,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelWriteTabName});
            this.statusStrip2.Location = new System.Drawing.Point(0, 435);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1044, 22);
            this.statusStrip2.TabIndex = 7;
            // 
            // toolStripStatusLabelWrite
            // 
            this.toolStripStatusLabelWrite.Name = "toolStripStatusLabelWrite";
            this.toolStripStatusLabelWrite.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabelWrite.Text = "状态";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(867, 17);
            this.toolStripStatusLabel3.Spring = true;
            this.toolStripStatusLabel3.Text = " ";
            // 
            // toolStripStatusLabelWriteTabName
            // 
            this.toolStripStatusLabelWriteTabName.Name = "toolStripStatusLabelWriteTabName";
            this.toolStripStatusLabelWriteTabName.Size = new System.Drawing.Size(130, 17);
            this.toolStripStatusLabelWriteTabName.Text = "当前项目：- 读写表：-";
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
            this.dataGridViewWrite.ContextMenuStrip = contextMenuStripWrite;
            this.dataGridViewWrite.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewWrite.Name = "dataGridViewWrite";
            this.dataGridViewWrite.RowHeadersWidth = 51;
            this.dataGridViewWrite.RowTemplate.Height = 25;
            this.dataGridViewWrite.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWrite.Size = new System.Drawing.Size(1034, 429);
            this.dataGridViewWrite.TabIndex = 3;
            this.dataGridViewWrite.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWrite_CellDoubleClick);
            // 
            // tabPageRead
            // 
            this.tabPageRead.Controls.Add(this.statusStrip1);
            this.tabPageRead.Controls.Add(this.dataGridViewRead);
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
            this.toolStripStatusLabelRead,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabelRwTab});
            this.statusStrip1.Location = new System.Drawing.Point(2, 432);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1040, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelRead
            // 
            this.toolStripStatusLabelRead.Name = "toolStripStatusLabelRead";
            this.toolStripStatusLabelRead.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabelRead.Text = "状态栏";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(851, 17);
            this.toolStripStatusLabel4.Spring = true;
            // 
            // toolStripStatusLabelRwTab
            // 
            this.toolStripStatusLabelRwTab.Name = "toolStripStatusLabelRwTab";
            this.toolStripStatusLabelRwTab.Size = new System.Drawing.Size(130, 17);
            this.toolStripStatusLabelRwTab.Text = "当前项目：- 读写表：-";
            // 
            // dataGridViewRead
            // 
            this.dataGridViewRead.AllowUserToAddRows = false;
            this.dataGridViewRead.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRead.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dataGridViewRead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRead.ContextMenuStrip = this.contextMenuStripRead;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRead.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewRead.Location = new System.Drawing.Point(5, 6);
            this.dataGridViewRead.Name = "dataGridViewRead";
            this.dataGridViewRead.RowHeadersWidth = 51;
            this.dataGridViewRead.RowTemplate.Height = 25;
            this.dataGridViewRead.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRead.Size = new System.Drawing.Size(1026, 430);
            this.dataGridViewRead.TabIndex = 7;
            // 
            // tabControlMainForm
            // 
            this.tabControlMainForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMainForm.Controls.Add(this.tabPageRead);
            this.tabControlMainForm.Controls.Add(this.tabPageWrite);
            this.tabControlMainForm.Controls.Add(this.tabPageConfig);
            this.tabControlMainForm.Location = new System.Drawing.Point(10, 25);
            this.tabControlMainForm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControlMainForm.Name = "tabControlMainForm";
            this.tabControlMainForm.SelectedIndex = 0;
            this.tabControlMainForm.Size = new System.Drawing.Size(1052, 487);
            this.tabControlMainForm.TabIndex = 1;
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
            contextMenuStripWrite.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripRead.ResumeLayout(false);
            this.contextMenuStripParaConfig.ResumeLayout(false);
            this.tabPageConfig.ResumeLayout(false);
            this.tabPageConfig.PerformLayout();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPara)).EndInit();
            this.tabPageWrite.ResumeLayout(false);
            this.tabPageWrite.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWrite)).EndInit();
            this.tabPageRead.ResumeLayout(false);
            this.tabPageRead.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRead)).EndInit();
            this.tabControlMainForm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于MeterTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日志ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRead;
        private System.Windows.Forms.ToolStripMenuItem 选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择所有ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消所有选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除所有数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripParaConfig;
        private System.Windows.Forms.ToolStripMenuItem 编程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 比对ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择参数配置方案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 通讯地址自适应ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单次读取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 循环读取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 选择读取表ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelParaConfig;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelParaConfigTable;
        private System.Windows.Forms.DataGridView dataGridViewPara;
        private System.Windows.Forms.TabPage tabPageWrite;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.DataGridView dataGridViewWrite;
        private System.Windows.Forms.TabPage tabPageRead;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRead;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRwTab;
        private System.Windows.Forms.DataGridView dataGridViewRead;
        private System.Windows.Forms.TabControl tabControlMainForm;
        private System.Windows.Forms.ToolStripMenuItem 选择ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 取消选择ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 选择所有ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 清除所有选择;
        private System.Windows.Forms.ToolStripMenuItem 写入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelWrite;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelWriteTabName;
    }
}