
namespace MeterTest.source.SQLite
{
    partial class DataIdShowForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxFormat = new System.Windows.Forms.TextBox();
            this.numericUpDownDataBytes = new System.Windows.Forms.NumericUpDown();
            this.textBoxUnit = new System.Windows.Forms.TextBox();
            this.checkBoxIsReadable = new System.Windows.Forms.CheckBox();
            this.checkBoxIsWritable = new System.Windows.Forms.CheckBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxGroup = new System.Windows.Forms.TextBox();
            this.buttonCertain = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDataBytes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据标识";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据格式";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "数据长度（字节）";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "单位";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "数据项名称";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "分组";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(151, 24);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(120, 23);
            this.textBoxId.TabIndex = 1;
            this.textBoxId.TextChanged += new System.EventHandler(this.textBoxId_TextChanged);
            // 
            // textBoxFormat
            // 
            this.textBoxFormat.Location = new System.Drawing.Point(151, 59);
            this.textBoxFormat.Name = "textBoxFormat";
            this.textBoxFormat.Size = new System.Drawing.Size(120, 23);
            this.textBoxFormat.TabIndex = 1;
            this.textBoxFormat.TextChanged += new System.EventHandler(this.textBoxFormat_TextChanged);
            // 
            // numericUpDownDataBytes
            // 
            this.numericUpDownDataBytes.InterceptArrowKeys = false;
            this.numericUpDownDataBytes.Location = new System.Drawing.Point(151, 94);
            this.numericUpDownDataBytes.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDownDataBytes.Name = "numericUpDownDataBytes";
            this.numericUpDownDataBytes.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownDataBytes.TabIndex = 2;
            this.numericUpDownDataBytes.ValueChanged += new System.EventHandler(this.numericUpDownDataBytes_ValueChanged);
            // 
            // textBoxUnit
            // 
            this.textBoxUnit.Location = new System.Drawing.Point(151, 129);
            this.textBoxUnit.Name = "textBoxUnit";
            this.textBoxUnit.Size = new System.Drawing.Size(120, 23);
            this.textBoxUnit.TabIndex = 1;
            this.textBoxUnit.TextChanged += new System.EventHandler(this.textBoxUnit_TextChanged);
            // 
            // checkBoxIsReadable
            // 
            this.checkBoxIsReadable.AutoSize = true;
            this.checkBoxIsReadable.Location = new System.Drawing.Point(317, 26);
            this.checkBoxIsReadable.Name = "checkBoxIsReadable";
            this.checkBoxIsReadable.Size = new System.Drawing.Size(39, 21);
            this.checkBoxIsReadable.TabIndex = 3;
            this.checkBoxIsReadable.Text = "读";
            this.checkBoxIsReadable.UseVisualStyleBackColor = true;
            this.checkBoxIsReadable.CheckedChanged += new System.EventHandler(this.checkBoxIsReadable_CheckedChanged);
            // 
            // checkBoxIsWritable
            // 
            this.checkBoxIsWritable.AutoSize = true;
            this.checkBoxIsWritable.Location = new System.Drawing.Point(363, 26);
            this.checkBoxIsWritable.Name = "checkBoxIsWritable";
            this.checkBoxIsWritable.Size = new System.Drawing.Size(39, 21);
            this.checkBoxIsWritable.TabIndex = 4;
            this.checkBoxIsWritable.Text = "写";
            this.checkBoxIsWritable.UseVisualStyleBackColor = true;
            this.checkBoxIsWritable.CheckedChanged += new System.EventHandler(this.checkBoxIsWritable_CheckedChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(151, 164);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(120, 23);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxGroup
            // 
            this.textBoxGroup.Location = new System.Drawing.Point(151, 199);
            this.textBoxGroup.Name = "textBoxGroup";
            this.textBoxGroup.Size = new System.Drawing.Size(120, 23);
            this.textBoxGroup.TabIndex = 1;
            this.textBoxGroup.TextChanged += new System.EventHandler(this.textBoxGroup_TextChanged);
            // 
            // buttonCertain
            // 
            this.buttonCertain.Location = new System.Drawing.Point(69, 272);
            this.buttonCertain.Name = "buttonCertain";
            this.buttonCertain.Size = new System.Drawing.Size(75, 23);
            this.buttonCertain.TabIndex = 5;
            this.buttonCertain.Text = "确定";
            this.buttonCertain.UseVisualStyleBackColor = true;
            this.buttonCertain.Click += new System.EventHandler(this.buttonCertain_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(283, 272);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // DataIdShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 321);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCertain);
            this.Controls.Add(this.checkBoxIsWritable);
            this.Controls.Add(this.checkBoxIsReadable);
            this.Controls.Add(this.numericUpDownDataBytes);
            this.Controls.Add(this.textBoxGroup);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxUnit);
            this.Controls.Add(this.textBoxFormat);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataIdShowForm";
            this.Text = "修改数据标识";
            this.Load += new System.EventHandler(this.DataIdShowForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDataBytes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxFormat;
        private System.Windows.Forms.NumericUpDown numericUpDownDataBytes;
        private System.Windows.Forms.TextBox textBoxUnit;
        private System.Windows.Forms.CheckBox checkBoxIsReadable;
        private System.Windows.Forms.CheckBox checkBoxIsWritable;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxGroup;
        private System.Windows.Forms.Button buttonCertain;
        private System.Windows.Forms.Button buttonCancel;
    }
}