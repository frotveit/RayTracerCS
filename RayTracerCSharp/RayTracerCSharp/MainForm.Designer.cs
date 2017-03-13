namespace RayTracerCSharp
{
    partial class MainForm
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
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip_RT = new System.Windows.Forms.MenuStrip();
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTest = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.runRayTracerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.menuStrip_RT.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(2, 97);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(626, 408);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // menuStrip_RT
            // 
            this.menuStrip_RT.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile,
            this.MenuItemEdit});
            this.menuStrip_RT.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_RT.Name = "menuStrip_RT";
            this.menuStrip_RT.Size = new System.Drawing.Size(628, 24);
            this.menuStrip_RT.TabIndex = 1;
            this.menuStrip_RT.Text = "menuStrip1";
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runRayTracerToolStripMenuItem,
            this.MenuItemTest,
            this.ToolStripMenuItemQuit});
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.MenuItemFile.Text = "File";
            // 
            // MenuItemTest
            // 
            this.MenuItemTest.Name = "MenuItemTest";
            this.MenuItemTest.Size = new System.Drawing.Size(152, 22);
            this.MenuItemTest.Text = "TestImage";
            this.MenuItemTest.Click += new System.EventHandler(this.ClickTest);
            // 
            // ToolStripMenuItemQuit
            // 
            this.ToolStripMenuItemQuit.Name = "ToolStripMenuItemQuit";
            this.ToolStripMenuItemQuit.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemQuit.Text = "Quit";
            this.ToolStripMenuItemQuit.Click += new System.EventHandler(this.ClickQuit);
            // 
            // MenuItemEdit
            // 
            this.MenuItemEdit.Name = "MenuItemEdit";
            this.MenuItemEdit.Size = new System.Drawing.Size(39, 20);
            this.MenuItemEdit.Text = "Edit";
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
            // runRayTracerToolStripMenuItem
            // 
            this.runRayTracerToolStripMenuItem.Name = "runRayTracerToolStripMenuItem";
            this.runRayTracerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.runRayTracerToolStripMenuItem.Text = "RunRayTracer";
            this.runRayTracerToolStripMenuItem.Click += new System.EventHandler(this.ClickRunRayTracer);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 517);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.menuStrip_RT);
            this.MainMenuStrip = this.menuStrip_RT;
            this.Name = "MainForm";
            this.Text = "RayTracer Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.menuStrip_RT.ResumeLayout(false);
            this.menuStrip_RT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.MenuStrip menuStrip_RT;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQuit;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTest;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem runRayTracerToolStripMenuItem;
    }
}

