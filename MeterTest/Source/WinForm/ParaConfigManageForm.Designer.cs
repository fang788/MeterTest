namespace MeterTest.Source.WinForm
{
    partial class ParaConfigManageForm
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
            this.treeViewProject = new System.Windows.Forms.TreeView();
            this.contextMenuStripProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_para_config_table_name = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewParaConfigTable = new System.Windows.Forms.DataGridView();
            this.contextMenuStripProject.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParaConfigTable)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewProject
            // 
            this.treeViewProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewProject.ContextMenuStrip = this.contextMenuStripProject;
            this.treeViewProject.Location = new System.Drawing.Point(12, 12);
            this.treeViewProject.Name = "treeViewProject";
            treeNode1.Name = "节点0";
            treeNode1.Text = "项目";
            this.treeViewProject.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewProject.Size = new System.Drawing.Size(171, 504);
            this.treeViewProject.TabIndex = 0;
            this.treeViewProject.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewProject_NodeMouseClick);
            // 
            // contextMenuStripProject
            // 
            this.contextMenuStripProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.contextMenuStripProject.Name = "contextMenuStripProject";
            this.contextMenuStripProject.Size = new System.Drawing.Size(101, 48);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.添加ToolStripMenuItem.Text = "添加";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // label_para_config_table_name
            // 
            this.label_para_config_table_name.AutoSize = true;
            this.label_para_config_table_name.Location = new System.Drawing.Point(191, 17);
            this.label_para_config_table_name.Name = "label_para_config_table_name";
            this.label_para_config_table_name.Size = new System.Drawing.Size(56, 17);
            this.label_para_config_table_name.TabIndex = 2;
            this.label_para_config_table_name.Text = "项目名称";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(865, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "状态栏";
            // 
            // dataGridViewParaConfigTable
            // 
            this.dataGridViewParaConfigTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewParaConfigTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParaConfigTable.Location = new System.Drawing.Point(191, 37);
            this.dataGridViewParaConfigTable.Name = "dataGridViewParaConfigTable";
            this.dataGridViewParaConfigTable.RowTemplate.Height = 25;
            this.dataGridViewParaConfigTable.Size = new System.Drawing.Size(662, 479);
            this.dataGridViewParaConfigTable.TabIndex = 4;
            // 
            // ParaConfigManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 541);
            this.Controls.Add(this.dataGridViewParaConfigTable);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label_para_config_table_name);
            this.Controls.Add(this.treeViewProject);
            this.Name = "ParaConfigManageForm";
            this.Text = "参数配置表";
            this.Load += new System.EventHandler(this.ParaConfigManageForm_Load);
            this.contextMenuStripProject.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParaConfigTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewProject;
        private System.Windows.Forms.Label label_para_config_table_name;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView dataGridViewParaConfigTable;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProject;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}