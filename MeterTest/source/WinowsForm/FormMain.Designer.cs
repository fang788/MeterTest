
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
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.tabPageChangeCommAddr = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonReadFreezeData = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControlMainForm.SuspendLayout();
            this.tabPageRead.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReadList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPageWrite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWrite)).BeginInit();
            this.tabPage1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1033, 25);
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
            this.tabControlMainForm.Location = new System.Drawing.Point(9, 26);
            this.tabControlMainForm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControlMainForm.Name = "tabControlMainForm";
            this.tabControlMainForm.SelectedIndex = 0;
            this.tabControlMainForm.Size = new System.Drawing.Size(1023, 518);
            this.tabControlMainForm.TabIndex = 1;
            // 
            // tabPageRead
            // 
            this.tabPageRead.Controls.Add(this.panel1);
            this.tabPageRead.Location = new System.Drawing.Point(4, 26);
            this.tabPageRead.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageRead.Name = "tabPageRead";
            this.tabPageRead.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageRead.Size = new System.Drawing.Size(1015, 488);
            this.tabPageRead.TabIndex = 0;
            this.tabPageRead.Text = "读数据";
            this.tabPageRead.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Controls.Add(this.buttonReadClyce);
            this.panel1.Controls.Add(this.buttonReadOne);
            this.panel1.Controls.Add(this.dataGridViewReadList);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 476);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 454);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1003, 22);
            this.statusStrip1.TabIndex = 7;
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
            this.buttonStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonStop.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStop.Location = new System.Drawing.Point(568, 410);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(88, 32);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "停止";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonReadClyce
            // 
            this.buttonReadClyce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReadClyce.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonReadClyce.Location = new System.Drawing.Point(306, 410);
            this.buttonReadClyce.Name = "buttonReadClyce";
            this.buttonReadClyce.Size = new System.Drawing.Size(88, 32);
            this.buttonReadClyce.TabIndex = 5;
            this.buttonReadClyce.Text = "循环读取";
            this.buttonReadClyce.UseVisualStyleBackColor = true;
            this.buttonReadClyce.Click += new System.EventHandler(this.buttonReadClyce_Click);
            // 
            // buttonReadOne
            // 
            this.buttonReadOne.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonReadOne.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonReadOne.Location = new System.Drawing.Point(21, 410);
            this.buttonReadOne.Name = "buttonReadOne";
            this.buttonReadOne.Size = new System.Drawing.Size(88, 32);
            this.buttonReadOne.TabIndex = 6;
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
            this.dataGridViewReadList.Location = new System.Drawing.Point(3, 9);
            this.dataGridViewReadList.Name = "dataGridViewReadList";
            this.dataGridViewReadList.RowTemplate.Height = 25;
            this.dataGridViewReadList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReadList.Size = new System.Drawing.Size(997, 395);
            this.dataGridViewReadList.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
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
            this.tabPageWrite.Size = new System.Drawing.Size(1015, 488);
            this.tabPageWrite.TabIndex = 1;
            this.tabPageWrite.Text = "写数据";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Location = new System.Drawing.Point(0, 466);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1015, 22);
            this.statusStrip2.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(449, 425);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 32);
            this.button3.TabIndex = 6;
            this.button3.Text = "停止";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(274, 425);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 32);
            this.button2.TabIndex = 6;
            this.button2.Text = "循环写入";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(99, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
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
            this.dataGridViewWrite.RowTemplate.Height = 25;
            this.dataGridViewWrite.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWrite.Size = new System.Drawing.Size(1005, 402);
            this.dataGridViewWrite.TabIndex = 3;
            this.dataGridViewWrite.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWrite_CellDoubleClick);
            // 
            // tabPageV9203
            // 
            this.tabPageV9203.Location = new System.Drawing.Point(4, 26);
            this.tabPageV9203.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageV9203.Name = "tabPageV9203";
            this.tabPageV9203.Size = new System.Drawing.Size(1015, 488);
            this.tabPageV9203.TabIndex = 2;
            this.tabPageV9203.Text = "V9203";
            this.tabPageV9203.UseVisualStyleBackColor = true;
            // 
            // tabPageChangeCommAddr
            // 
            this.tabPageChangeCommAddr.Location = new System.Drawing.Point(4, 26);
            this.tabPageChangeCommAddr.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageChangeCommAddr.Name = "tabPageChangeCommAddr";
            this.tabPageChangeCommAddr.Size = new System.Drawing.Size(1015, 488);
            this.tabPageChangeCommAddr.TabIndex = 3;
            this.tabPageChangeCommAddr.Text = "通讯地址";
            this.tabPageChangeCommAddr.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.statusStrip3);
            this.tabPage1.Controls.Add(this.buttonReadFreezeData);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1015, 488);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "冻结";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonReadFreezeData
            // 
            this.buttonReadFreezeData.Location = new System.Drawing.Point(323, 187);
            this.buttonReadFreezeData.Name = "buttonReadFreezeData";
            this.buttonReadFreezeData.Size = new System.Drawing.Size(100, 33);
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
            // statusStrip3
            // 
            this.statusStrip3.Location = new System.Drawing.Point(0, 466);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(1015, 22);
            this.statusStrip3.TabIndex = 1;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(269, 242);
            this.progressBar1.Maximum = 672;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(154, 17);
            this.progressBar1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "进度";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 547);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReadList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPageWrite.ResumeLayout(false);
            this.tabPageWrite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWrite)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonReadClyce;
        private System.Windows.Forms.Button buttonReadOne;
        private System.Windows.Forms.DataGridView dataGridViewReadList;
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
    }
}