
namespace MeterTest.Source.SQLite
{
    partial class DataIdListForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelOpt = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonChg = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxDataId = new System.Windows.Forms.TextBox();
            this.labelDataId = new System.Windows.Forms.Label();
            this.dataGridViewDataId = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataId)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.buttonDel);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.buttonChg);
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.textBoxDataId);
            this.panel1.Controls.Add(this.labelDataId);
            this.panel1.Controls.Add(this.dataGridViewDataId);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1463, 709);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelOpt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 22, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1463, 31);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelOpt
            // 
            this.toolStripStatusLabelOpt.Name = "toolStripStatusLabelOpt";
            this.toolStripStatusLabelOpt.Size = new System.Drawing.Size(64, 24);
            this.toolStripStatusLabelOpt.Text = "状态栏";
            // 
            // buttonDel
            // 
            this.buttonDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDel.Location = new System.Drawing.Point(776, 24);
            this.buttonDel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(118, 32);
            this.buttonDel.TabIndex = 11;
            this.buttonDel.Text = "删除";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd.Location = new System.Drawing.Point(971, 24);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(118, 32);
            this.buttonAdd.TabIndex = 12;
            this.buttonAdd.Text = "添加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonChg
            // 
            this.buttonChg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonChg.Location = new System.Drawing.Point(581, 24);
            this.buttonChg.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonChg.Name = "buttonChg";
            this.buttonChg.Size = new System.Drawing.Size(118, 32);
            this.buttonChg.TabIndex = 12;
            this.buttonChg.Text = "修改";
            this.buttonChg.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSearch.Location = new System.Drawing.Point(387, 24);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(118, 32);
            this.buttonSearch.TabIndex = 13;
            this.buttonSearch.Text = "查询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxDataId
            // 
            this.textBoxDataId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxDataId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDataId.Location = new System.Drawing.Point(146, 24);
            this.textBoxDataId.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxDataId.MaxLength = 8;
            this.textBoxDataId.Name = "textBoxDataId";
            this.textBoxDataId.Size = new System.Drawing.Size(185, 28);
            this.textBoxDataId.TabIndex = 10;
            this.textBoxDataId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDataId_KeyPress);
            // 
            // labelDataId
            // 
            this.labelDataId.AutoSize = true;
            this.labelDataId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDataId.Location = new System.Drawing.Point(31, 28);
            this.labelDataId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelDataId.Name = "labelDataId";
            this.labelDataId.Size = new System.Drawing.Size(80, 18);
            this.labelDataId.TabIndex = 9;
            this.labelDataId.Text = "数据标识";
            // 
            // dataGridViewDataId
            // 
            this.dataGridViewDataId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDataId.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewDataId.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataId.Location = new System.Drawing.Point(31, 83);
            this.dataGridViewDataId.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewDataId.Name = "dataGridViewDataId";
            this.dataGridViewDataId.RowHeadersWidth = 62;
            this.dataGridViewDataId.RowTemplate.Height = 25;
            this.dataGridViewDataId.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDataId.Size = new System.Drawing.Size(1414, 589);
            this.dataGridViewDataId.TabIndex = 8;
            // 
            // DataIdListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 712);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "DataIdListForm";
            this.Text = "数据标识表";
            this.Load += new System.EventHandler(this.DataIdListForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonChg;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxDataId;
        private System.Windows.Forms.Label labelDataId;
        private System.Windows.Forms.DataGridView dataGridViewDataId;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelOpt;
    }
}