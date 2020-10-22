using System;
using System.Windows.Forms;

namespace Stage_Scrapbooker
{
    partial class Form1
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
            this.lstListOfScanner = new System.Windows.Forms.ListBox();
            this.lblListOfScanner = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnScan);
            this.panel1.Controls.Add(this.lstListOfScanner);
            this.panel1.Controls.Add(this.lblListOfScanner);
            this.panel1.Location = new System.Drawing.Point(89, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 462);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lstListOfScanner
            // 
            this.lstListOfScanner.FormattingEnabled = true;
            this.lstListOfScanner.ItemHeight = 25;
            this.lstListOfScanner.Location = new System.Drawing.Point(21, 76);
            this.lstListOfScanner.Name = "lstListOfScanner";
            this.lstListOfScanner.Size = new System.Drawing.Size(208, 229);
            this.lstListOfScanner.TabIndex = 1;
            // 
            // lblListOfScanner
            // 
            this.lblListOfScanner.AutoSize = true;
            this.lblListOfScanner.Location = new System.Drawing.Point(16, 24);
            this.lblListOfScanner.Name = "lblListOfScanner";
            this.lblListOfScanner.Size = new System.Drawing.Size(156, 25);
            this.lblListOfScanner.TabIndex = 0;
            this.lblListOfScanner.Text = "List of Scanner";
            this.lblListOfScanner.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(42, 344);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(147, 31);
            this.btnScan.TabIndex = 2;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(531, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(562, 462);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 764);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblListOfScanner;
        private System.Windows.Forms.ListBox lstListOfScanner;
        private Button btnScan;
        private PictureBox pictureBox1;
    }
}