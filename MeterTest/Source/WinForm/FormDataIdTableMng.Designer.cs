
namespace MeterTest.Source.WinForm
{
    partial class FormDataIdTableMng
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewDataIdTable = new System.Windows.Forms.TreeView();
            this.dataGridViewDataIdTable = new System.Windows.Forms.DataGridView();
            this.textBoxDataId = new System.Windows.Forms.TextBox();
            this.labelDataId = new System.Windows.Forms.Label();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonChg = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.contextMenuStripDataIdTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataIdTable)).BeginInit();
            this.contextMenuStripDataIdTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewDataIdTable);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewDataIdTable);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxDataId);
            this.splitContainer1.Panel2.Controls.Add(this.labelDataId);
            this.splitContainer1.Panel2.Controls.Add(this.buttonDel);
            this.splitContainer1.Panel2.Controls.Add(this.buttonAdd);
            this.splitContainer1.Panel2.Controls.Add(this.buttonChg);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSearch);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.Size = new System.Drawing.Size(789, 387);
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewDataIdTable
            // 
            this.treeViewDataIdTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewDataIdTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeViewDataIdTable.LabelEdit = true;
            this.treeViewDataIdTable.Location = new System.Drawing.Point(2, 2);
            this.treeViewDataIdTable.Margin = new System.Windows.Forms.Padding(2);
            this.treeViewDataIdTable.Name = "treeViewDataIdTable";
            this.treeViewDataIdTable.Size = new System.Drawing.Size(122, 377);
            this.treeViewDataIdTable.TabIndex = 21;
            this.treeViewDataIdTable.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewDataIdTable_AfterLabelEdit);
            this.treeViewDataIdTable.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDataIdTable_NodeMouseClick);
            this.treeViewDataIdTable.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDataIdTable_NodeMouseDoubleClick);
            // 
            // dataGridViewDataIdTable
            // 
            this.dataGridViewDataIdTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDataIdTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewDataIdTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataIdTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridViewDataIdTable.Location = new System.Drawing.Point(3, 47);
            this.dataGridViewDataIdTable.Name = "dataGridViewDataIdTable";
            this.dataGridViewDataIdTable.RowHeadersWidth = 62;
            this.dataGridViewDataIdTable.RowTemplate.Height = 25;
            this.dataGridViewDataIdTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDataIdTable.Size = new System.Drawing.Size(660, 332);
            this.dataGridViewDataIdTable.TabIndex = 21;
            // 
            // textBoxDataId
            // 
            this.textBoxDataId.Location = new System.Drawing.Point(66, 11);
            this.textBoxDataId.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDataId.MaxLength = 8;
            this.textBoxDataId.Name = "textBoxDataId";
            this.textBoxDataId.Size = new System.Drawing.Size(97, 23);
            this.textBoxDataId.TabIndex = 19;
            this.textBoxDataId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDataId_KeyPress);
            // 
            // labelDataId
            // 
            this.labelDataId.AutoSize = true;
            this.labelDataId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDataId.Location = new System.Drawing.Point(9, 16);
            this.labelDataId.Name = "labelDataId";
            this.labelDataId.Size = new System.Drawing.Size(65, 12);
            this.labelDataId.TabIndex = 18;
            this.labelDataId.Text = "数据标识：";
            // 
            // buttonDel
            // 
            this.buttonDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDel.Location = new System.Drawing.Point(356, 11);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(53, 23);
            this.buttonDel.TabIndex = 14;
            this.buttonDel.Text = "删除";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd.Location = new System.Drawing.Point(437, 11);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(53, 23);
            this.buttonAdd.TabIndex = 15;
            this.buttonAdd.Text = "添加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonChg
            // 
            this.buttonChg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonChg.Location = new System.Drawing.Point(276, 11);
            this.buttonChg.Name = "buttonChg";
            this.buttonChg.Size = new System.Drawing.Size(53, 23);
            this.buttonChg.TabIndex = 16;
            this.buttonChg.Text = "修改";
            this.buttonChg.UseVisualStyleBackColor = true;
            this.buttonChg.Click += new System.EventHandler(this.buttonChg_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSearch.Location = new System.Drawing.Point(195, 11);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(53, 23);
            this.buttonSearch.TabIndex = 17;
            this.buttonSearch.Text = "查询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // contextMenuStripDataIdTable
            // 
            this.contextMenuStripDataIdTable.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripDataIdTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.重命名ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.导入ToolStripMenuItem,
            this.导出ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.contextMenuStripDataIdTable.Name = "contextMenuStripDataIdTableDel";
            this.contextMenuStripDataIdTable.Size = new System.Drawing.Size(113, 136);
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.重命名ToolStripMenuItem.Text = "重命名";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.重命名ToolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.导入ToolStripMenuItem.Text = "导入";
            this.导入ToolStripMenuItem.Click += new System.EventHandler(this.导入ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // FormDataIdTableMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 387);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDataIdTableMng";
            this.Text = "FormDataIdTableMng";
            this.Load += new System.EventHandler(this.FormDataIdTableMng_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataIdTable)).EndInit();
            this.contextMenuStripDataIdTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonChg;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxDataId;
        private System.Windows.Forms.Label labelDataId;
        private System.Windows.Forms.TreeView treeViewDataIdTable;
        private System.Windows.Forms.DataGridView dataGridViewDataIdTable;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDataIdTable;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}