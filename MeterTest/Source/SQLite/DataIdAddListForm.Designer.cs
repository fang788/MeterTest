
namespace MeterTest.Source.SQLite
{
    partial class DataIdAddListForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxAddLot = new System.Windows.Forms.TextBox();
            this.buttonAddOne = new System.Windows.Forms.Button();
            this.buttonAddLotMould = new System.Windows.Forms.Button();
            this.buttonAddLot = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewDataIdList = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataIdList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxAddLot);
            this.panel1.Controls.Add(this.buttonAddOne);
            this.panel1.Controls.Add(this.buttonAddLotMould);
            this.panel1.Controls.Add(this.buttonAddLot);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridViewDataIdList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 438);
            this.panel1.TabIndex = 0;
            // 
            // textBoxAddLot
            // 
            this.textBoxAddLot.Location = new System.Drawing.Point(76, 388);
            this.textBoxAddLot.Name = "textBoxAddLot";
            this.textBoxAddLot.ReadOnly = true;
            this.textBoxAddLot.Size = new System.Drawing.Size(318, 23);
            this.textBoxAddLot.TabIndex = 3;
            // 
            // buttonAddOne
            // 
            this.buttonAddOne.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddOne.Location = new System.Drawing.Point(671, 388);
            this.buttonAddOne.Name = "buttonAddOne";
            this.buttonAddOne.Size = new System.Drawing.Size(75, 23);
            this.buttonAddOne.TabIndex = 2;
            this.buttonAddOne.Text = "单个添加";
            this.buttonAddOne.UseVisualStyleBackColor = true;
            this.buttonAddOne.Click += new System.EventHandler(this.buttonAddOne_Click);
            // 
            // buttonAddLotMould
            // 
            this.buttonAddLotMould.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddLotMould.Location = new System.Drawing.Point(541, 388);
            this.buttonAddLotMould.Name = "buttonAddLotMould";
            this.buttonAddLotMould.Size = new System.Drawing.Size(75, 23);
            this.buttonAddLotMould.TabIndex = 2;
            this.buttonAddLotMould.Text = "批量模板";
            this.buttonAddLotMould.UseVisualStyleBackColor = true;
            // 
            // buttonAddLot
            // 
            this.buttonAddLot.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddLot.Location = new System.Drawing.Point(411, 388);
            this.buttonAddLot.Name = "buttonAddLot";
            this.buttonAddLot.Size = new System.Drawing.Size(75, 23);
            this.buttonAddLot.TabIndex = 2;
            this.buttonAddLot.Text = "批量添加";
            this.buttonAddLot.UseVisualStyleBackColor = true;
            this.buttonAddLot.Click += new System.EventHandler(this.buttonAddLot_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "文件路径";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "已添加数据标识";
            // 
            // dataGridViewDataIdList
            // 
            this.dataGridViewDataIdList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewDataIdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataIdList.Location = new System.Drawing.Point(14, 39);
            this.dataGridViewDataIdList.Name = "dataGridViewDataIdList";
            this.dataGridViewDataIdList.RowTemplate.Height = 25;
            this.dataGridViewDataIdList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDataIdList.Size = new System.Drawing.Size(809, 326);
            this.dataGridViewDataIdList.TabIndex = 0;
            // 
            // DataIdAddListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 438);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataIdAddListForm";
            this.Text = "添加数据标识";
            this.Load += new System.EventHandler(this.DataIdAddListForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataIdList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxAddLot;
        private System.Windows.Forms.Button buttonAddOne;
        private System.Windows.Forms.Button buttonAddLotMould;
        private System.Windows.Forms.Button buttonAddLot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewDataIdList;
    }
}