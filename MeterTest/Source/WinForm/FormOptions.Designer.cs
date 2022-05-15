
namespace MeterTest.Source.WinForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("项目");
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxAuthority = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxOperatorCode = new System.Windows.Forms.TextBox();
            this.textBoxServerAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBoxTTPort = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.buttonParaTableMng = new System.Windows.Forms.Button();
            this.buttonRwTableMng = new System.Windows.Forms.Button();
            this.treeViewProject = new System.Windows.Forms.TreeView();
            this.checkBoxIsUse = new System.Windows.Forms.CheckBox();
            this.textBoxParaTableCnt = new System.Windows.Forms.TextBox();
            this.textBoxRwTableCnt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxProjectChgTime = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxProjectName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.contextMenuStripAddProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonConfirm = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.contextMenuStripDelProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadTimeOut)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.contextMenuStripAddProject.SuspendLayout();
            this.contextMenuStripDelProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(9, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(473, 369);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Size = new System.Drawing.Size(465, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "串口";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numericUpDownReadTimeOut
            // 
            this.numericUpDownReadTimeOut.Location = new System.Drawing.Point(157, 241);
            this.numericUpDownReadTimeOut.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.numericUpDownReadTimeOut.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownReadTimeOut.Name = "numericUpDownReadTimeOut";
            this.numericUpDownReadTimeOut.Size = new System.Drawing.Size(117, 23);
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
            this.ComboBoxCheckBit.Location = new System.Drawing.Point(156, 196);
            this.ComboBoxCheckBit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ComboBoxCheckBit.Name = "ComboBoxCheckBit";
            this.ComboBoxCheckBit.Size = new System.Drawing.Size(118, 25);
            this.ComboBoxCheckBit.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 200);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "奇偶校验位(A):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 241);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
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
            this.ComboBoxStopBit.Location = new System.Drawing.Point(156, 155);
            this.ComboBoxStopBit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ComboBoxStopBit.Name = "ComboBoxStopBit";
            this.ComboBoxStopBit.Size = new System.Drawing.Size(118, 25);
            this.ComboBoxStopBit.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
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
            this.ComboBoxDataBit.Location = new System.Drawing.Point(156, 113);
            this.ComboBoxDataBit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ComboBoxDataBit.Name = "ComboBoxDataBit";
            this.ComboBoxDataBit.Size = new System.Drawing.Size(118, 25);
            this.ComboBoxDataBit.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
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
            this.ComboBoxBaudRate.Location = new System.Drawing.Point(156, 71);
            this.ComboBoxBaudRate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ComboBoxBaudRate.Name = "ComboBoxBaudRate";
            this.ComboBoxBaudRate.Size = new System.Drawing.Size(118, 25);
            this.ComboBoxBaudRate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "波特率(B):";
            // 
            // ComboBoxPort
            // 
            this.ComboBoxPort.FormattingEnabled = true;
            this.ComboBoxPort.Location = new System.Drawing.Point(156, 30);
            this.ComboBoxPort.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ComboBoxPort.Name = "ComboBoxPort";
            this.ComboBoxPort.Size = new System.Drawing.Size(118, 25);
            this.ComboBoxPort.TabIndex = 1;
            this.ComboBoxPort.DropDown += new System.EventHandler(this.ComboBoxPort_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号(P):";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBoxAuthority);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.textBoxPassword);
            this.tabPage2.Controls.Add(this.textBoxOperatorCode);
            this.tabPage2.Controls.Add(this.textBoxServerAddress);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(465, 339);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DLT645";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxAuthority
            // 
            this.comboBoxAuthority.FormattingEnabled = true;
            this.comboBoxAuthority.Items.AddRange(new object[] {
            "01",
            "02",
            "04",
            "98"});
            this.comboBoxAuthority.Location = new System.Drawing.Point(108, 63);
            this.comboBoxAuthority.Name = "comboBoxAuthority";
            this.comboBoxAuthority.Size = new System.Drawing.Size(131, 25);
            this.comboBoxAuthority.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "操作者代码：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "密码：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "密码权限：";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxPassword.Location = new System.Drawing.Point(108, 101);
            this.textBoxPassword.MaxLength = 6;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(131, 23);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxServerAddress_KeyPress);
            // 
            // textBoxOperatorCode
            // 
            this.textBoxOperatorCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxOperatorCode.Location = new System.Drawing.Point(108, 137);
            this.textBoxOperatorCode.MaxLength = 8;
            this.textBoxOperatorCode.Name = "textBoxOperatorCode";
            this.textBoxOperatorCode.Size = new System.Drawing.Size(131, 23);
            this.textBoxOperatorCode.TabIndex = 2;
            this.textBoxOperatorCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxServerAddress_KeyPress);
            // 
            // textBoxServerAddress
            // 
            this.textBoxServerAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxServerAddress.Location = new System.Drawing.Point(108, 27);
            this.textBoxServerAddress.MaxLength = 12;
            this.textBoxServerAddress.Name = "textBoxServerAddress";
            this.textBoxServerAddress.Size = new System.Drawing.Size(131, 23);
            this.textBoxServerAddress.TabIndex = 2;
            this.textBoxServerAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxServerAddress_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "服务器地址：";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.comboBoxTTPort);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(465, 339);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "台体";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // comboBoxTTPort
            // 
            this.comboBoxTTPort.FormattingEnabled = true;
            this.comboBoxTTPort.Location = new System.Drawing.Point(96, 21);
            this.comboBoxTTPort.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxTTPort.Name = "comboBoxTTPort";
            this.comboBoxTTPort.Size = new System.Drawing.Size(118, 25);
            this.comboBoxTTPort.TabIndex = 3;
            this.comboBoxTTPort.DropDown += new System.EventHandler(this.comboBoxTTPort_DropDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 24);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "端口号(P):";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.buttonParaTableMng);
            this.tabPage6.Controls.Add(this.buttonRwTableMng);
            this.tabPage6.Controls.Add(this.treeViewProject);
            this.tabPage6.Controls.Add(this.checkBoxIsUse);
            this.tabPage6.Controls.Add(this.textBoxParaTableCnt);
            this.tabPage6.Controls.Add(this.textBoxRwTableCnt);
            this.tabPage6.Controls.Add(this.label15);
            this.tabPage6.Controls.Add(this.textBoxProjectChgTime);
            this.tabPage6.Controls.Add(this.label14);
            this.tabPage6.Controls.Add(this.textBoxProjectName);
            this.tabPage6.Controls.Add(this.label13);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Location = new System.Drawing.Point(4, 26);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(465, 339);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "项目";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // buttonParaTableMng
            // 
            this.buttonParaTableMng.Location = new System.Drawing.Point(298, 260);
            this.buttonParaTableMng.Name = "buttonParaTableMng";
            this.buttonParaTableMng.Size = new System.Drawing.Size(100, 32);
            this.buttonParaTableMng.TabIndex = 8;
            this.buttonParaTableMng.Text = "参数表管理";
            this.buttonParaTableMng.UseVisualStyleBackColor = true;
            this.buttonParaTableMng.Click += new System.EventHandler(this.buttonParaTableMng_Click);
            // 
            // buttonRwTableMng
            // 
            this.buttonRwTableMng.Location = new System.Drawing.Point(298, 211);
            this.buttonRwTableMng.Name = "buttonRwTableMng";
            this.buttonRwTableMng.Size = new System.Drawing.Size(100, 32);
            this.buttonRwTableMng.TabIndex = 8;
            this.buttonRwTableMng.Text = "读写表管理";
            this.buttonRwTableMng.UseVisualStyleBackColor = true;
            this.buttonRwTableMng.Click += new System.EventHandler(this.buttonRwTableMng_Click);
            // 
            // treeViewProject
            // 
            this.treeViewProject.Location = new System.Drawing.Point(3, 3);
            this.treeViewProject.Name = "treeViewProject";
            treeNode1.Name = "Node0";
            treeNode1.Text = "项目";
            this.treeViewProject.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewProject.Size = new System.Drawing.Size(203, 333);
            this.treeViewProject.TabIndex = 4;
            this.treeViewProject.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewProject_NodeMouseDoubleClick);
            // 
            // checkBoxIsUse
            // 
            this.checkBoxIsUse.AutoSize = true;
            this.checkBoxIsUse.Location = new System.Drawing.Point(298, 173);
            this.checkBoxIsUse.Name = "checkBoxIsUse";
            this.checkBoxIsUse.Size = new System.Drawing.Size(75, 21);
            this.checkBoxIsUse.TabIndex = 3;
            this.checkBoxIsUse.Text = "是否使用";
            this.checkBoxIsUse.UseVisualStyleBackColor = true;
            this.checkBoxIsUse.CheckedChanged += new System.EventHandler(this.checkBoxIsUse_CheckedChanged);
            // 
            // textBoxParaTableCnt
            // 
            this.textBoxParaTableCnt.Location = new System.Drawing.Point(298, 133);
            this.textBoxParaTableCnt.Name = "textBoxParaTableCnt";
            this.textBoxParaTableCnt.ReadOnly = true;
            this.textBoxParaTableCnt.Size = new System.Drawing.Size(154, 23);
            this.textBoxParaTableCnt.TabIndex = 2;
            // 
            // textBoxRwTableCnt
            // 
            this.textBoxRwTableCnt.Location = new System.Drawing.Point(298, 93);
            this.textBoxRwTableCnt.Name = "textBoxRwTableCnt";
            this.textBoxRwTableCnt.ReadOnly = true;
            this.textBoxRwTableCnt.Size = new System.Drawing.Size(154, 23);
            this.textBoxRwTableCnt.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(213, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 17);
            this.label15.TabIndex = 1;
            this.label15.Text = "参数表数量：";
            // 
            // textBoxProjectChgTime
            // 
            this.textBoxProjectChgTime.Location = new System.Drawing.Point(298, 53);
            this.textBoxProjectChgTime.Name = "textBoxProjectChgTime";
            this.textBoxProjectChgTime.ReadOnly = true;
            this.textBoxProjectChgTime.Size = new System.Drawing.Size(154, 23);
            this.textBoxProjectChgTime.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(213, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 17);
            this.label14.TabIndex = 1;
            this.label14.Text = "读写表数量：";
            // 
            // textBoxProjectName
            // 
            this.textBoxProjectName.Location = new System.Drawing.Point(298, 13);
            this.textBoxProjectName.Name = "textBoxProjectName";
            this.textBoxProjectName.ReadOnly = true;
            this.textBoxProjectName.Size = new System.Drawing.Size(154, 23);
            this.textBoxProjectName.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(212, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 17);
            this.label13.TabIndex = 1;
            this.label13.Text = "修改时间：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(213, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "项目名：";
            // 
            // contextMenuStripAddProject
            // 
            this.contextMenuStripAddProject.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripAddProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem});
            this.contextMenuStripAddProject.Name = "contextMenuStrip1";
            this.contextMenuStripAddProject.Size = new System.Drawing.Size(101, 26);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.添加ToolStripMenuItem.Text = "添加";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.添加ToolStripMenuItem_Click);
            // 
            // ButtonConfirm
            // 
            this.ButtonConfirm.Location = new System.Drawing.Point(263, 407);
            this.ButtonConfirm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonConfirm.Name = "ButtonConfirm";
            this.ButtonConfirm.Size = new System.Drawing.Size(73, 25);
            this.ButtonConfirm.TabIndex = 1;
            this.ButtonConfirm.Text = "确定";
            this.ButtonConfirm.UseVisualStyleBackColor = true;
            this.ButtonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(359, 407);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(73, 25);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // contextMenuStripDelProject
            // 
            this.contextMenuStripDelProject.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripDelProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStripDelProject.Name = "contextMenuStripDelProject";
            this.contextMenuStripDelProject.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 457);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonConfirm);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.Text = "选项";
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadTimeOut)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.contextMenuStripAddProject.ResumeLayout(false);
            this.contextMenuStripDelProject.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxServerAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxAuthority;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxOperatorCode;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox comboBoxTTPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxProjectChgTime;
        private System.Windows.Forms.TextBox textBoxProjectName;
        private System.Windows.Forms.CheckBox checkBoxIsUse;
        private System.Windows.Forms.TextBox textBoxParaTableCnt;
        private System.Windows.Forms.TextBox textBoxRwTableCnt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TreeView treeViewProject;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAddProject;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.Button buttonRwTableMng;
        private System.Windows.Forms.Button buttonParaTableMng;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDelProject;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}