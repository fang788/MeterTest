
namespace MeterTest.Source.WinForm
{
    partial class FormDataIdAddAndChg
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFormat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUnit = new System.Windows.Forms.TextBox();
            this.checkBoxReadable = new System.Windows.Forms.CheckBox();
            this.checkBoxWriteable = new System.Windows.Forms.CheckBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxGroup = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据标识";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据项名称";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(133, 22);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(156, 23);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(133, 66);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(156, 23);
            this.textBoxId.TabIndex = 1;
            this.textBoxId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxId_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "数据格式";
            // 
            // textBoxFormat
            // 
            this.textBoxFormat.Location = new System.Drawing.Point(133, 110);
            this.textBoxFormat.Name = "textBoxFormat";
            this.textBoxFormat.Size = new System.Drawing.Size(156, 23);
            this.textBoxFormat.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "数据长度";
            // 
            // textBoxLen
            // 
            this.textBoxLen.Location = new System.Drawing.Point(416, 106);
            this.textBoxLen.Name = "textBoxLen";
            this.textBoxLen.Size = new System.Drawing.Size(85, 23);
            this.textBoxLen.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "单位";
            // 
            // textBoxUnit
            // 
            this.textBoxUnit.Location = new System.Drawing.Point(416, 22);
            this.textBoxUnit.Name = "textBoxUnit";
            this.textBoxUnit.Size = new System.Drawing.Size(85, 23);
            this.textBoxUnit.TabIndex = 1;
            // 
            // checkBoxReadable
            // 
            this.checkBoxReadable.AutoSize = true;
            this.checkBoxReadable.Location = new System.Drawing.Point(345, 155);
            this.checkBoxReadable.Name = "checkBoxReadable";
            this.checkBoxReadable.Size = new System.Drawing.Size(39, 21);
            this.checkBoxReadable.TabIndex = 2;
            this.checkBoxReadable.Text = "读";
            this.checkBoxReadable.UseVisualStyleBackColor = true;
            // 
            // checkBoxWriteable
            // 
            this.checkBoxWriteable.AutoSize = true;
            this.checkBoxWriteable.Location = new System.Drawing.Point(416, 155);
            this.checkBoxWriteable.Name = "checkBoxWriteable";
            this.checkBoxWriteable.Size = new System.Drawing.Size(39, 21);
            this.checkBoxWriteable.TabIndex = 2;
            this.checkBoxWriteable.Text = "写";
            this.checkBoxWriteable.UseVisualStyleBackColor = true;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(185, 178);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(104, 33);
            this.buttonConfirm.TabIndex = 3;
            this.buttonConfirm.Text = "确认";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(345, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "分组";
            // 
            // textBoxGroup
            // 
            this.textBoxGroup.Location = new System.Drawing.Point(416, 64);
            this.textBoxGroup.Name = "textBoxGroup";
            this.textBoxGroup.Size = new System.Drawing.Size(85, 23);
            this.textBoxGroup.TabIndex = 1;
            // 
            // FormDataIdAddAndChg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 236);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.checkBoxWriteable);
            this.Controls.Add(this.checkBoxReadable);
            this.Controls.Add(this.textBoxUnit);
            this.Controls.Add(this.textBoxLen);
            this.Controls.Add(this.textBoxGroup);
            this.Controls.Add(this.textBoxFormat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDataIdAddAndChg";
            this.Text = "FormDataIdAddAndChg";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxUnit;
        private System.Windows.Forms.CheckBox checkBoxReadable;
        private System.Windows.Forms.CheckBox checkBoxWriteable;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxGroup;
    }
}