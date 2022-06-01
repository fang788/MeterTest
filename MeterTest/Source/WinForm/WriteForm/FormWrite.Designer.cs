
namespace MeterTest.Source.WinForm
{
    partial class FormWrite
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
            this.labelDataIdName = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxDataIdData = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelDataIdName
            // 
            this.labelDataIdName.AutoSize = true;
            this.labelDataIdName.Location = new System.Drawing.Point(87, 43);
            this.labelDataIdName.Name = "labelDataIdName";
            this.labelDataIdName.Size = new System.Drawing.Size(80, 17);
            this.labelDataIdName.TabIndex = 1;
            this.labelDataIdName.Text = "数据标识名称";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(87, 157);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 2;
            this.buttonConfirm.Text = "确认";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(243, 156);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxDataIdData
            // 
            this.textBoxDataIdData.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDataIdData.Location = new System.Drawing.Point(87, 89);
            this.textBoxDataIdData.Name = "textBoxDataIdData";
            this.textBoxDataIdData.Size = new System.Drawing.Size(231, 23);
            this.textBoxDataIdData.TabIndex = 4;
            this.textBoxDataIdData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDataIdData_KeyPress);
            // 
            // FormWrite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 250);
            this.Controls.Add(this.textBoxDataIdData);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.labelDataIdName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWrite";
            this.Text = "FormWrite";
            this.Load += new System.EventHandler(this.FormWrite_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelDataIdName;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxDataIdData;
    }
}