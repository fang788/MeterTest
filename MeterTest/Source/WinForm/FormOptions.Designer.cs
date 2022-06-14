
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
            this.tabPage6.SuspendLayout();
            this.contextMenuStripAddProject.SuspendLayout();
            this.contextMenuStripDelProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(608, 434);
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
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(600, 401);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "串口";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numericUpDownReadTimeOut
            // 
            this.numericUpDownReadTimeOut.Location = new System.Drawing.Point(202, 284);
            this.numericUpDownReadTimeOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.ComboBoxCheckBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.ComboBoxStopBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.ComboBoxDataBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboBoxDataBit.Name = "ComboBoxDataBit";
            this.ComboBoxDataBit.Size = new System.Drawing.Size(151, 28);
            this.ComboBoxDataBit.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 136);
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
            this.ComboBoxBaudRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.ComboBoxPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(600, 401);
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
            this.comboBoxAuthority.Location = new System.Drawing.Point(139, 74);
            this.comboBoxAuthority.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxAuthority.Name = "comboBoxAuthority";
            this.comboBoxAuthority.Size = new System.Drawing.Size(167, 28);
            this.comboBoxAuthority.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 166);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "操作者代码：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 122);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "密码：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 79);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "密码权限：";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxPassword.Location = new System.Drawing.Point(139, 119);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPassword.MaxLength = 6;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(167, 27);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxServerAddress_KeyPress);
            // 
            // textBoxOperatorCode
            // 
            this.textBoxOperatorCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxOperatorCode.Location = new System.Drawing.Point(139, 161);
            this.textBoxOperatorCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxOperatorCode.MaxLength = 8;
            this.textBoxOperatorCode.Name = "textBoxOperatorCode";
            this.textBoxOperatorCode.Size = new System.Drawing.Size(167, 27);
            this.textBoxOperatorCode.TabIndex = 2;
            this.textBoxOperatorCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxServerAddress_KeyPress);
            // 
            // textBoxServerAddress
            // 
            this.textBoxServerAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxServerAddress.Location = new System.Drawing.Point(139, 32);
            this.textBoxServerAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxServerAddress.MaxLength = 12;
            this.textBoxServerAddress.Name = "textBoxServerAddress";
            this.textBoxServerAddress.Size = new System.Drawing.Size(167, 27);
            this.textBoxServerAddress.TabIndex = 2;
            this.textBoxServerAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxServerAddress_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "服务器地址：";
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
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(600, 401);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "项目";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // buttonParaTableMng
            // 
            this.buttonParaTableMng.Location = new System.Drawing.Point(383, 306);
            this.buttonParaTableMng.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonParaTableMng.Name = "buttonParaTableMng";
            this.buttonParaTableMng.Size = new System.Drawing.Size(129, 38);
            this.buttonParaTableMng.TabIndex = 8;
            this.buttonParaTableMng.Text = "参数表管理";
            this.buttonParaTableMng.UseVisualStyleBackColor = true;
            this.buttonParaTableMng.Click += new System.EventHandler(this.buttonParaTableMng_Click);
            // 
            // buttonRwTableMng
            // 
            this.buttonRwTableMng.Location = new System.Drawing.Point(383, 248);
            this.buttonRwTableMng.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRwTableMng.Name = "buttonRwTableMng";
            this.buttonRwTableMng.Size = new System.Drawing.Size(129, 38);
            this.buttonRwTableMng.TabIndex = 8;
            this.buttonRwTableMng.Text = "读写表管理";
            this.buttonRwTableMng.UseVisualStyleBackColor = true;
            this.buttonRwTableMng.Click += new System.EventHandler(this.buttonRwTableMng_Click);
            // 
            // treeViewProject
            // 
            this.treeViewProject.Location = new System.Drawing.Point(4, 4);
            this.treeViewProject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeViewProject.Name = "treeViewProject";
            treeNode1.Name = "Node0";
            treeNode1.Text = "项目";
            this.treeViewProject.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewProject.Size = new System.Drawing.Size(260, 391);
            this.treeViewProject.TabIndex = 4;
            this.treeViewProject.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewProject_NodeMouseDoubleClick);
            // 
            // checkBoxIsUse
            // 
            this.checkBoxIsUse.AutoSize = true;
            this.checkBoxIsUse.Location = new System.Drawing.Point(383, 204);
            this.checkBoxIsUse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxIsUse.Name = "checkBoxIsUse";
            this.checkBoxIsUse.Size = new System.Drawing.Size(91, 24);
            this.checkBoxIsUse.TabIndex = 3;
            this.checkBoxIsUse.Text = "是否使用";
            this.checkBoxIsUse.UseVisualStyleBackColor = true;
            this.checkBoxIsUse.CheckedChanged += new System.EventHandler(this.checkBoxIsUse_CheckedChanged);
            // 
            // textBoxParaTableCnt
            // 
            this.textBoxParaTableCnt.Location = new System.Drawing.Point(383, 156);
            this.textBoxParaTableCnt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxParaTableCnt.Name = "textBoxParaTableCnt";
            this.textBoxParaTableCnt.ReadOnly = true;
            this.textBoxParaTableCnt.Size = new System.Drawing.Size(197, 27);
            this.textBoxParaTableCnt.TabIndex = 2;
            // 
            // textBoxRwTableCnt
            // 
            this.textBoxRwTableCnt.Location = new System.Drawing.Point(383, 109);
            this.textBoxRwTableCnt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRwTableCnt.Name = "textBoxRwTableCnt";
            this.textBoxRwTableCnt.ReadOnly = true;
            this.textBoxRwTableCnt.Size = new System.Drawing.Size(197, 27);
            this.textBoxRwTableCnt.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(274, 160);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 20);
            this.label15.TabIndex = 1;
            this.label15.Text = "参数表数量：";
            // 
            // textBoxProjectChgTime
            // 
            this.textBoxProjectChgTime.Location = new System.Drawing.Point(383, 62);
            this.textBoxProjectChgTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxProjectChgTime.Name = "textBoxProjectChgTime";
            this.textBoxProjectChgTime.ReadOnly = true;
            this.textBoxProjectChgTime.Size = new System.Drawing.Size(197, 27);
            this.textBoxProjectChgTime.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(274, 113);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 20);
            this.label14.TabIndex = 1;
            this.label14.Text = "读写表数量：";
            // 
            // textBoxProjectName
            // 
            this.textBoxProjectName.Location = new System.Drawing.Point(383, 15);
            this.textBoxProjectName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxProjectName.Name = "textBoxProjectName";
            this.textBoxProjectName.ReadOnly = true;
            this.textBoxProjectName.Size = new System.Drawing.Size(197, 27);
            this.textBoxProjectName.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(273, 66);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 20);
            this.label13.TabIndex = 1;
            this.label13.Text = "修改时间：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(274, 19);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "项目名：";
            // 
            // contextMenuStripAddProject
            // 
            this.contextMenuStripAddProject.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripAddProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem});
            this.contextMenuStripAddProject.Name = "contextMenuStrip1";
            this.contextMenuStripAddProject.Size = new System.Drawing.Size(109, 28);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.添加ToolStripMenuItem.Text = "添加";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // ButtonConfirm
            // 
            this.ButtonConfirm.Location = new System.Drawing.Point(338, 479);
            this.ButtonConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonConfirm.Name = "ButtonConfirm";
            this.ButtonConfirm.Size = new System.Drawing.Size(94, 29);
            this.ButtonConfirm.TabIndex = 1;
            this.ButtonConfirm.Text = "确定";
            this.ButtonConfirm.UseVisualStyleBackColor = true;
            this.ButtonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(462, 479);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(94, 29);
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
            this.contextMenuStripDelProject.Size = new System.Drawing.Size(109, 28);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 538);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonConfirm);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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