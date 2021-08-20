
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRead = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonReadClyce = new System.Windows.Forms.Button();
            this.buttonReadOne = new System.Windows.Forms.Button();
            this.dataGridViewDataIdList = new System.Windows.Forms.DataGridView();
            this.tabPageWrite = new System.Windows.Forms.TabPage();
            this.tabPageV9203 = new System.Windows.Forms.TabPage();
            this.tabPageChangeCommAddr = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择所有ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消所有选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageRead.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataIdList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageRead);
            this.tabControl1.Controls.Add(this.tabPageWrite);
            this.tabControl1.Controls.Add(this.tabPageV9203);
            this.tabControl1.Controls.Add(this.tabPageChangeCommAddr);
            this.tabControl1.Location = new System.Drawing.Point(9, 26);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1023, 518);
            this.tabControl1.TabIndex = 1;
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
            this.tabPageRead.Text = "读写";
            this.tabPageRead.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Controls.Add(this.buttonReadClyce);
            this.panel1.Controls.Add(this.buttonReadOne);
            this.panel1.Controls.Add(this.dataGridViewDataIdList);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 476);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 454);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1003, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "状态栏";
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStop.Location = new System.Drawing.Point(568, 410);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(88, 32);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "停止";
            this.buttonStop.UseVisualStyleBackColor = true;
            // 
            // buttonReadClyce
            // 
            this.buttonReadClyce.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonReadClyce.Location = new System.Drawing.Point(306, 410);
            this.buttonReadClyce.Name = "buttonReadClyce";
            this.buttonReadClyce.Size = new System.Drawing.Size(88, 32);
            this.buttonReadClyce.TabIndex = 5;
            this.buttonReadClyce.Text = "循环读取";
            this.buttonReadClyce.UseVisualStyleBackColor = true;
            // 
            // buttonReadOne
            // 
            this.buttonReadOne.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonReadOne.Location = new System.Drawing.Point(21, 410);
            this.buttonReadOne.Name = "buttonReadOne";
            this.buttonReadOne.Size = new System.Drawing.Size(88, 32);
            this.buttonReadOne.TabIndex = 6;
            this.buttonReadOne.Text = "单次读取";
            this.buttonReadOne.UseVisualStyleBackColor = true;
            this.buttonReadOne.Click += new System.EventHandler(this.buttonReadOne_Click);
            // 
            // dataGridViewDataIdList
            // 
            this.dataGridViewDataIdList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewDataIdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataIdList.Location = new System.Drawing.Point(3, 9);
            this.dataGridViewDataIdList.Name = "dataGridViewDataIdList";
            this.dataGridViewDataIdList.RowTemplate.Height = 25;
            this.dataGridViewDataIdList.Size = new System.Drawing.Size(997, 395);
            this.dataGridViewDataIdList.TabIndex = 2;
            this.dataGridViewDataIdList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewDataIdList_CellMouseDown);
            // 
            // tabPageWrite
            // 
            this.tabPageWrite.Location = new System.Drawing.Point(4, 26);
            this.tabPageWrite.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageWrite.Name = "tabPageWrite";
            this.tabPageWrite.Size = new System.Drawing.Size(1015, 488);
            this.tabPageWrite.TabIndex = 1;
            this.tabPageWrite.Text = "写入";
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择ToolStripMenuItem,
            this.取消选择ToolStripMenuItem,
            this.选择所有ToolStripMenuItem,
            this.取消所有选择ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 92);
            // 
            // 选择ToolStripMenuItem
            // 
            this.选择ToolStripMenuItem.Name = "选择ToolStripMenuItem";
            this.选择ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.选择ToolStripMenuItem.Text = "选择";
            // 
            // 取消选择ToolStripMenuItem
            // 
            this.取消选择ToolStripMenuItem.Name = "取消选择ToolStripMenuItem";
            this.取消选择ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.取消选择ToolStripMenuItem.Text = "取消选择";
            // 
            // 选择所有ToolStripMenuItem
            // 
            this.选择所有ToolStripMenuItem.Name = "选择所有ToolStripMenuItem";
            this.选择所有ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.选择所有ToolStripMenuItem.Text = "选择所有";
            // 
            // 取消所有选择ToolStripMenuItem
            // 
            this.取消所有选择ToolStripMenuItem.Name = "取消所有选择ToolStripMenuItem";
            this.取消所有选择ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.取消所有选择ToolStripMenuItem.Text = "取消所有选择";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 547);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "MeterTest";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageRead.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataIdList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于MeterTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRead;
        private System.Windows.Forms.ToolStripMenuItem 日志ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageWrite;
        private System.Windows.Forms.TabPage tabPageV9203;
        private System.Windows.Forms.TabPage tabPageChangeCommAddr;
        private System.Windows.Forms.ToolStripMenuItem 管理数据标识表ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonReadClyce;
        private System.Windows.Forms.Button buttonReadOne;
        private System.Windows.Forms.DataGridView dataGridViewDataIdList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择所有ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消所有选择ToolStripMenuItem;
    }
}