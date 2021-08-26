
namespace MeterTest.source.SQLite
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
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 502);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelOpt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 480);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(931, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelOpt
            // 
            this.toolStripStatusLabelOpt.Name = "toolStripStatusLabelOpt";
            this.toolStripStatusLabelOpt.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabelOpt.Text = "状态栏";
            // 
            // buttonDel
            // 
            this.buttonDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDel.Location = new System.Drawing.Point(494, 17);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 11;
            this.buttonDel.Text = "删除";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd.Location = new System.Drawing.Point(618, 17);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 12;
            this.buttonAdd.Text = "添加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonChg
            // 
            this.buttonChg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonChg.Location = new System.Drawing.Point(370, 17);
            this.buttonChg.Name = "buttonChg";
            this.buttonChg.Size = new System.Drawing.Size(75, 23);
            this.buttonChg.TabIndex = 12;
            this.buttonChg.Text = "修改";
            this.buttonChg.UseVisualStyleBackColor = true;
            this.buttonChg.Click += new System.EventHandler(this.buttonChg_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSearch.Location = new System.Drawing.Point(246, 17);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 13;
            this.buttonSearch.Text = "查询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxDataId
            // 
            this.textBoxDataId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDataId.Location = new System.Drawing.Point(93, 17);
            this.textBoxDataId.MaxLength = 16;
            this.textBoxDataId.Name = "textBoxDataId";
            this.textBoxDataId.Size = new System.Drawing.Size(119, 21);
            this.textBoxDataId.TabIndex = 10;
            this.textBoxDataId.TextChanged += new System.EventHandler(this.textBoxDataId_TextChanged);
            // 
            // labelDataId
            // 
            this.labelDataId.AutoSize = true;
            this.labelDataId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDataId.Location = new System.Drawing.Point(20, 20);
            this.labelDataId.Name = "labelDataId";
            this.labelDataId.Size = new System.Drawing.Size(53, 12);
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
            this.dataGridViewDataId.Location = new System.Drawing.Point(20, 59);
            this.dataGridViewDataId.Name = "dataGridViewDataId";
            this.dataGridViewDataId.RowTemplate.Height = 25;
            this.dataGridViewDataId.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDataId.Size = new System.Drawing.Size(900, 417);
            this.dataGridViewDataId.TabIndex = 8;
            // 
            // DataIdListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 504);
            this.Controls.Add(this.panel1);
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