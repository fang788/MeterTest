
namespace MeterTest.Source.Emu
{
    partial class Ht7036Convert
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
            this.richTextBoxHt7036Reg = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRegisterType = new System.Windows.Forms.ComboBox();
            this.buttonSelectFilePath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxConvertType = new System.Windows.Forms.ComboBox();
            this.buttonStartConvert = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxEeprom = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // richTextBoxHt7036Reg
            // 
            this.richTextBoxHt7036Reg.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxHt7036Reg.Name = "richTextBoxHt7036Reg";
            this.richTextBoxHt7036Reg.Size = new System.Drawing.Size(1121, 292);
            this.richTextBoxHt7036Reg.TabIndex = 0;
            this.richTextBoxHt7036Reg.Text = "";
            this.richTextBoxHt7036Reg.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件路径：";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(143, 350);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(490, 27);
            this.textBoxFilePath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "寄存器类型：";
            // 
            // comboBoxRegisterType
            // 
            this.comboBoxRegisterType.FormattingEnabled = true;
            this.comboBoxRegisterType.Items.AddRange(new object[] {
            "计量参数寄存器",
            "校表参数寄存器"});
            this.comboBoxRegisterType.Location = new System.Drawing.Point(143, 399);
            this.comboBoxRegisterType.Name = "comboBoxRegisterType";
            this.comboBoxRegisterType.Size = new System.Drawing.Size(317, 28);
            this.comboBoxRegisterType.TabIndex = 4;
            // 
            // buttonSelectFilePath
            // 
            this.buttonSelectFilePath.Location = new System.Drawing.Point(686, 347);
            this.buttonSelectFilePath.Name = "buttonSelectFilePath";
            this.buttonSelectFilePath.Size = new System.Drawing.Size(96, 33);
            this.buttonSelectFilePath.TabIndex = 5;
            this.buttonSelectFilePath.Text = "选择";
            this.buttonSelectFilePath.UseVisualStyleBackColor = true;
            this.buttonSelectFilePath.Click += new System.EventHandler(this.buttonSelectFilePath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 451);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "转换类型：";
            // 
            // comboBoxConvertType
            // 
            this.comboBoxConvertType.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBoxConvertType.FormattingEnabled = true;
            this.comboBoxConvertType.Items.AddRange(new object[] {
            "地址枚举",
            "数值列表"});
            this.comboBoxConvertType.Location = new System.Drawing.Point(143, 448);
            this.comboBoxConvertType.Name = "comboBoxConvertType";
            this.comboBoxConvertType.Size = new System.Drawing.Size(317, 28);
            this.comboBoxConvertType.TabIndex = 4;
            // 
            // buttonStartConvert
            // 
            this.buttonStartConvert.Location = new System.Drawing.Point(143, 513);
            this.buttonStartConvert.Name = "buttonStartConvert";
            this.buttonStartConvert.Size = new System.Drawing.Size(149, 46);
            this.buttonStartConvert.TabIndex = 7;
            this.buttonStartConvert.Text = "开始转换";
            this.buttonStartConvert.UseVisualStyleBackColor = true;
            this.buttonStartConvert.Click += new System.EventHandler(this.buttonStartConvert_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 503);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 6;
            // 
            // checkBoxEeprom
            // 
            this.checkBoxEeprom.AutoSize = true;
            this.checkBoxEeprom.Location = new System.Drawing.Point(686, 403);
            this.checkBoxEeprom.Name = "checkBoxEeprom";
            this.checkBoxEeprom.Size = new System.Drawing.Size(93, 24);
            this.checkBoxEeprom.TabIndex = 8;
            this.checkBoxEeprom.Text = "EEPROM";
            this.checkBoxEeprom.UseVisualStyleBackColor = true;
            // 
            // Ht7036Convert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 599);
            this.Controls.Add(this.checkBoxEeprom);
            this.Controls.Add(this.buttonStartConvert);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSelectFilePath);
            this.Controls.Add(this.comboBoxConvertType);
            this.Controls.Add(this.comboBoxRegisterType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxHt7036Reg);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ht7036Convert";
            this.Text = "Ht7036转换";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxHt7036Reg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxRegisterType;
        private System.Windows.Forms.Button buttonSelectFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxConvertType;
        private System.Windows.Forms.Button buttonStartConvert;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxEeprom;
    }
}