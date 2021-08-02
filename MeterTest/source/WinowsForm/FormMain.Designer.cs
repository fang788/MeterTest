
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于MeterTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRead = new System.Windows.Forms.TabPage();
            this.tabPageWrite = new System.Windows.Forms.TabPage();
            this.tabPageV9203 = new System.Windows.Forms.TabPage();
            this.tabPageChangeCommAddr = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(879, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选项ToolStripMenuItem,
            this.日志ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.选项ToolStripMenuItem.Text = "选项";
            this.选项ToolStripMenuItem.Click += new System.EventHandler(this.选项ToolStripMenuItem_Click);
            // 
            // 日志ToolStripMenuItem
            // 
            this.日志ToolStripMenuItem.Name = "日志ToolStripMenuItem";
            this.日志ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.日志ToolStripMenuItem.Text = "日志";
            this.日志ToolStripMenuItem.Click += new System.EventHandler(this.日志ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于MeterTestToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于MeterTestToolStripMenuItem
            // 
            this.关于MeterTestToolStripMenuItem.Name = "关于MeterTestToolStripMenuItem";
            this.关于MeterTestToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
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
            this.tabControl1.Location = new System.Drawing.Point(12, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(867, 436);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageRead
            // 
            this.tabPageRead.Location = new System.Drawing.Point(4, 29);
            this.tabPageRead.Name = "tabPageRead";
            this.tabPageRead.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRead.Size = new System.Drawing.Size(859, 403);
            this.tabPageRead.TabIndex = 0;
            this.tabPageRead.Text = "读取";
            this.tabPageRead.UseVisualStyleBackColor = true;
            // 
            // tabPageWrite
            // 
            this.tabPageWrite.Location = new System.Drawing.Point(4, 29);
            this.tabPageWrite.Name = "tabPageWrite";
            this.tabPageWrite.Size = new System.Drawing.Size(859, 403);
            this.tabPageWrite.TabIndex = 1;
            this.tabPageWrite.Text = "写入";
            this.tabPageWrite.UseVisualStyleBackColor = true;
            // 
            // tabPageV9203
            // 
            this.tabPageV9203.Location = new System.Drawing.Point(4, 29);
            this.tabPageV9203.Name = "tabPageV9203";
            this.tabPageV9203.Size = new System.Drawing.Size(859, 403);
            this.tabPageV9203.TabIndex = 2;
            this.tabPageV9203.Text = "V9203";
            this.tabPageV9203.UseVisualStyleBackColor = true;
            // 
            // tabPageChangeCommAddr
            // 
            this.tabPageChangeCommAddr.Location = new System.Drawing.Point(4, 29);
            this.tabPageChangeCommAddr.Name = "tabPageChangeCommAddr";
            this.tabPageChangeCommAddr.Size = new System.Drawing.Size(859, 403);
            this.tabPageChangeCommAddr.TabIndex = 3;
            this.tabPageChangeCommAddr.Text = "通讯地址";
            this.tabPageChangeCommAddr.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 470);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormMain";
            this.Text = "MeterTest";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
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
    }
}