﻿
namespace MeterTest.Source.WinForm
{
    partial class FormLogger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            Hide();
            // if (disposing && (components != null))
            // {
            //     components.Dispose();
            // }
            // base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RichTextBoxLogger = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RichTextBoxLogger
            // 
            this.RichTextBoxLogger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBoxLogger.Location = new System.Drawing.Point(9, 10);
            this.RichTextBoxLogger.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.RichTextBoxLogger.MaxLength = 104857600;
            this.RichTextBoxLogger.Name = "RichTextBoxLogger";
            this.RichTextBoxLogger.Size = new System.Drawing.Size(795, 408);
            this.RichTextBoxLogger.TabIndex = 0;
            this.RichTextBoxLogger.Text = "";
            // 
            // FormLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 428);
            this.Controls.Add(this.RichTextBoxLogger);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormLogger";
            this.Text = "日志";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogger_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RichTextBoxLogger;
    }
}