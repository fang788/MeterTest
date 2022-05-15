
namespace MeterTest.Source.WindowsForm
{
    partial class FormAddName
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
            this.labelTip = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.Location = new System.Drawing.Point(79, 78);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(64, 24);
            this.labelTip.TabIndex = 0;
            this.labelTip.Text = "名称：";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(222, 75);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(189, 30);
            this.textBoxName.TabIndex = 1;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(171, 161);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(112, 34);
            this.buttonConfirm.TabIndex = 2;
            this.buttonConfirm.Text = "确定";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // FormAddName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 229);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelTip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddName";
            this.Text = "FormAddName";
            this.Load += new System.EventHandler(this.FormAddName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonConfirm;
    }
}