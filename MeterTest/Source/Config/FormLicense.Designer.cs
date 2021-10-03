
namespace MeterTest.Source.Config
{
    partial class FormLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.textBoxAuthorization = new System.Windows.Forms.TextBox();
            this.buttonActivate = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelRegistration = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "注册码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "授权码：";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(124, 50);
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(252, 23);
            this.textBoxLog.TabIndex = 2;
            // 
            // textBoxAuthorization
            // 
            this.textBoxAuthorization.Location = new System.Drawing.Point(124, 95);
            this.textBoxAuthorization.Name = "textBoxAuthorization";
            this.textBoxAuthorization.Size = new System.Drawing.Size(252, 23);
            this.textBoxAuthorization.TabIndex = 2;
            // 
            // buttonActivate
            // 
            this.buttonActivate.Location = new System.Drawing.Point(124, 139);
            this.buttonActivate.Name = "buttonActivate";
            this.buttonActivate.Size = new System.Drawing.Size(99, 31);
            this.buttonActivate.TabIndex = 3;
            this.buttonActivate.Text = "激活";
            this.buttonActivate.UseVisualStyleBackColor = true;
            this.buttonActivate.Click += new System.EventHandler(this.buttonActivate_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelRegistration});
            this.statusStrip1.Location = new System.Drawing.Point(0, 188);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(468, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelRegistration
            // 
            this.toolStripStatusLabelRegistration.Name = "toolStripStatusLabelRegistration";
            this.toolStripStatusLabelRegistration.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabelRegistration.Text = "激活状态";
            // 
            // FormLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 210);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonActivate);
            this.Controls.Add(this.textBoxAuthorization);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLicense";
            this.Text = "激活";
            this.Load += new System.EventHandler(this.FormLicense_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TextBox textBoxAuthorization;
        private System.Windows.Forms.Button buttonActivate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRegistration;
    }
}