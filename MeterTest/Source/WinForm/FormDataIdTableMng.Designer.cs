﻿
namespace MeterTest.Source.WindowsForm
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
            this.contextMenuStripDataIdTableAdd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDataIdTableDel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataIdTable)).BeginInit();
            this.contextMenuStripDataIdTableAdd.SuspendLayout();
            this.contextMenuStripDataIdTableDel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Size = new System.Drawing.Size(1240, 546);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewDataIdTable
            // 
            this.treeViewDataIdTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewDataIdTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeViewDataIdTable.Location = new System.Drawing.Point(3, 3);
            this.treeViewDataIdTable.Name = "treeViewDataIdTable";
            this.treeViewDataIdTable.Size = new System.Drawing.Size(189, 531);
            this.treeViewDataIdTable.TabIndex = 21;
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
            this.dataGridViewDataIdTable.Location = new System.Drawing.Point(14, 66);
            this.dataGridViewDataIdTable.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewDataIdTable.Name = "dataGridViewDataIdTable";
            this.dataGridViewDataIdTable.RowHeadersWidth = 62;
            this.dataGridViewDataIdTable.RowTemplate.Height = 25;
            this.dataGridViewDataIdTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDataIdTable.Size = new System.Drawing.Size(1013, 469);
            this.dataGridViewDataIdTable.TabIndex = 21;
            // 
            // textBoxDataId
            // 
            this.textBoxDataId.Location = new System.Drawing.Point(104, 16);
            this.textBoxDataId.Name = "textBoxDataId";
            this.textBoxDataId.Size = new System.Drawing.Size(150, 30);
            this.textBoxDataId.TabIndex = 19;
            // 
            // labelDataId
            // 
            this.labelDataId.AutoSize = true;
            this.labelDataId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDataId.Location = new System.Drawing.Point(14, 22);
            this.labelDataId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelDataId.Name = "labelDataId";
            this.labelDataId.Size = new System.Drawing.Size(98, 18);
            this.labelDataId.TabIndex = 18;
            this.labelDataId.Text = "数据标识：";
            // 
            // buttonDel
            // 
            this.buttonDel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDel.Location = new System.Drawing.Point(560, 15);
            this.buttonDel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(83, 32);
            this.buttonDel.TabIndex = 14;
            this.buttonDel.Text = "删除";
            this.buttonDel.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd.Location = new System.Drawing.Point(687, 15);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(83, 32);
            this.buttonAdd.TabIndex = 15;
            this.buttonAdd.Text = "添加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonChg
            // 
            this.buttonChg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonChg.Location = new System.Drawing.Point(433, 15);
            this.buttonChg.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonChg.Name = "buttonChg";
            this.buttonChg.Size = new System.Drawing.Size(83, 32);
            this.buttonChg.TabIndex = 16;
            this.buttonChg.Text = "修改";
            this.buttonChg.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSearch.Location = new System.Drawing.Point(306, 15);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(83, 32);
            this.buttonSearch.TabIndex = 17;
            this.buttonSearch.Text = "查询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // contextMenuStripDataIdTableAdd
            // 
            this.contextMenuStripDataIdTableAdd.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripDataIdTableAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem});
            this.contextMenuStripDataIdTableAdd.Name = "contextMenuStripDataIdTableAdd";
            this.contextMenuStripDataIdTableAdd.Size = new System.Drawing.Size(117, 34);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(116, 30);
            this.添加ToolStripMenuItem.Text = "添加";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.添加ToolStripMenuItem_Click);
            // 
            // contextMenuStripDataIdTableDel
            // 
            this.contextMenuStripDataIdTableDel.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripDataIdTableDel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStripDataIdTableDel.Name = "contextMenuStripDataIdTableDel";
            this.contextMenuStripDataIdTableDel.Size = new System.Drawing.Size(117, 34);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(116, 30);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // FormDataIdTableMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 546);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormDataIdTableMng";
            this.Text = "FormDataIdTableMng";
            this.Load += new System.EventHandler(this.FormDataIdTableMng_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataIdTable)).EndInit();
            this.contextMenuStripDataIdTableAdd.ResumeLayout(false);
            this.contextMenuStripDataIdTableDel.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDataIdTableAdd;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDataIdTableDel;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}