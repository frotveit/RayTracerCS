namespace RayTracerCSharp
{
    partial class Form_RT
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip_RT = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemTest = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip_RT.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(2, 97);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 250);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip_RT
            // 
            this.menuStrip_RT.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile});
            this.menuStrip_RT.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_RT.Name = "menuStrip_RT";
            this.menuStrip_RT.Size = new System.Drawing.Size(492, 24);
            this.menuStrip_RT.TabIndex = 1;
            this.menuStrip_RT.Text = "menuStrip1";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemQuit,
            this.ToolStripMenuItemTest});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(35, 20);
            this.toolStripMenuItemFile.Text = "File";
            // 
            // ToolStripMenuItemQuit
            // 
            this.ToolStripMenuItemQuit.Name = "ToolStripMenuItemQuit";
            this.ToolStripMenuItemQuit.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemQuit.Text = "Quit";
            this.ToolStripMenuItemQuit.Click += new System.EventHandler(this.toolStripMenuItem_ClickClose);
            // 
            // ToolStripMenuItemTest
            // 
            this.ToolStripMenuItemTest.Name = "ToolStripMenuItemTest";
            this.ToolStripMenuItemTest.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemTest.Text = "TestImage";
            this.ToolStripMenuItemTest.Click += new System.EventHandler(this.toolStripMenuItem_ClickTest);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(2, 27);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(331, 64);
            this.textBoxLog.TabIndex = 2;
            // 
            // Form_RT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 359);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip_RT);
            this.MainMenuStrip = this.menuStrip_RT;
            this.Name = "Form_RT";
            this.Text = "RayTracer Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip_RT.ResumeLayout(false);
            this.menuStrip_RT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip_RT;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQuit;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTest;
    }
}

