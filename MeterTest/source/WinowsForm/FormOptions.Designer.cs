
namespace MeterTest.Source.WinowsForm
{
    partial class FormOptions
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numericUpDownReadTimeOut = new System.Windows.Forms.NumericUpDown();
            this.ComboBoxCheckBit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboBoxStopBit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboBoxDataBit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonConfirm = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadTimeOut)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(548, 381);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numericUpDownReadTimeOut);
            this.tabPage1.Controls.Add(this.ComboBoxCheckBit);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.ComboBoxStopBit);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.ComboBoxDataBit);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.ComboBoxBaudRate);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.ComboBoxPort);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(540, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "串口";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numericUpDownReadTimeOut
            // 
            this.numericUpDownReadTimeOut.Location = new System.Drawing.Point(202, 284);
            this.numericUpDownReadTimeOut.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownReadTimeOut.Name = "numericUpDownReadTimeOut";
            this.numericUpDownReadTimeOut.Size = new System.Drawing.Size(150, 27);
            this.numericUpDownReadTimeOut.TabIndex = 3;
            // 
            // ComboBoxCheckBit
            // 
            this.ComboBoxCheckBit.FormattingEnabled = true;
            this.ComboBoxCheckBit.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.ComboBoxCheckBit.Location = new System.Drawing.Point(201, 231);
            this.ComboBoxCheckBit.Name = "ComboBoxCheckBit";
            this.ComboBoxCheckBit.Size = new System.Drawing.Size(151, 28);
            this.ComboBoxCheckBit.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "奇偶校验位(A):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "超时时间(T):";
            // 
            // ComboBoxStopBit
            // 
            this.ComboBoxStopBit.FormattingEnabled = true;
            this.ComboBoxStopBit.Items.AddRange(new object[] {
            "None",
            "One",
            "Two",
            "OnePointFive"});
            this.ComboBoxStopBit.Location = new System.Drawing.Point(201, 182);
            this.ComboBoxStopBit.Name = "ComboBoxStopBit";
            this.ComboBoxStopBit.Size = new System.Drawing.Size(151, 28);
            this.ComboBoxStopBit.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "停止位(S):";
            // 
            // ComboBoxDataBit
            // 
            this.ComboBoxDataBit.FormattingEnabled = true;
            this.ComboBoxDataBit.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.ComboBoxDataBit.Location = new System.Drawing.Point(201, 133);
            this.ComboBoxDataBit.Name = "ComboBoxDataBit";
            this.ComboBoxDataBit.Size = new System.Drawing.Size(151, 28);
            this.ComboBoxDataBit.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "数据位(D):";
            // 
            // ComboBoxBaudRate
            // 
            this.ComboBoxBaudRate.FormattingEnabled = true;
            this.ComboBoxBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "115200"});
            this.ComboBoxBaudRate.Location = new System.Drawing.Point(201, 84);
            this.ComboBoxBaudRate.Name = "ComboBoxBaudRate";
            this.ComboBoxBaudRate.Size = new System.Drawing.Size(151, 28);
            this.ComboBoxBaudRate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "波特率(B):";
            // 
            // ComboBoxPort
            // 
            this.ComboBoxPort.FormattingEnabled = true;
            this.ComboBoxPort.Location = new System.Drawing.Point(201, 35);
            this.ComboBoxPort.Name = "ComboBoxPort";
            this.ComboBoxPort.Size = new System.Drawing.Size(151, 28);
            this.ComboBoxPort.TabIndex = 1;
            this.ComboBoxPort.DropDown += new System.EventHandler(this.ComboBoxPort_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号(P):";
            // 
            // ButtonConfirm
            // 
            this.ButtonConfirm.Location = new System.Drawing.Point(338, 435);
            this.ButtonConfirm.Name = "ButtonConfirm";
            this.ButtonConfirm.Size = new System.Drawing.Size(94, 29);
            this.ButtonConfirm.TabIndex = 1;
            this.ButtonConfirm.Text = "确定";
            this.ButtonConfirm.UseVisualStyleBackColor = true;
            this.ButtonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(462, 435);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(94, 29);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 491);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonConfirm);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.Text = "选项";
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadTimeOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox ComboBoxCheckBit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboBoxStopBit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ComboBoxDataBit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboBoxBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBoxPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonConfirm;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDownReadTimeOut;
    }
}