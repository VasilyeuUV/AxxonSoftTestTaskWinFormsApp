﻿namespace AxxonSoftTestTaskWinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            pnlPaint = new Panel();
            pbMain = new PictureBox();
            stsStrip = new StatusStrip();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            menuStrip1.SuspendLayout();
            pnlPaint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(69, 29);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // pnlPaint
            // 
            pnlPaint.AutoScroll = true;
            pnlPaint.Controls.Add(pbMain);
            pnlPaint.Location = new Point(12, 33);
            pnlPaint.Name = "pnlPaint";
            pnlPaint.Size = new Size(482, 202);
            pnlPaint.TabIndex = 2;
            // 
            // pbMain
            // 
            pbMain.Dock = DockStyle.Left;
            pbMain.Location = new Point(0, 0);
            pbMain.Name = "pbMain";
            pbMain.Size = new Size(796, 176);
            pbMain.SizeMode = PictureBoxSizeMode.AutoSize;
            pbMain.TabIndex = 3;
            pbMain.TabStop = false;
            // 
            // stsStrip
            // 
            stsStrip.ImageScalingSize = new Size(24, 24);
            stsStrip.Location = new Point(0, 428);
            stsStrip.Name = "stsStrip";
            stsStrip.Size = new Size(800, 22);
            stsStrip.TabIndex = 3;
            stsStrip.Text = "statusStrip1";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(500, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 395);
            panel1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 241);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(482, 184);
            dataGridView1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(stsStrip);
            Controls.Add(pnlPaint);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "AxxsonSoftTestTask";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlPaint.ResumeLayout(false);
            pnlPaint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private Panel pnlPaint;
        private PictureBox pbMain;
        private StatusStrip stsStrip;
        private Panel panel1;
        private DataGridView dataGridView1;
    }
}