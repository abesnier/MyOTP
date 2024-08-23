namespace MyOTP
{
    partial class FormMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            quitToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            button1 = new Button();
            panelTotpComp = new Panel();
            lblNoApp = new Label();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panelTotpComp.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseClick += NotifyIcon1_MouseClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { quitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(98, 26);
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(97, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += QuitToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(333, 27);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.Dock = DockStyle.Right;
            button1.Location = new Point(287, 0);
            button1.Name = "button1";
            button1.Size = new Size(46, 27);
            button1.TabIndex = 99;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // panelTotpComp
            // 
            panelTotpComp.BackColor = SystemColors.Control;
            panelTotpComp.Controls.Add(lblNoApp);
            panelTotpComp.Dock = DockStyle.Fill;
            panelTotpComp.Location = new Point(0, 27);
            panelTotpComp.Name = "panelTotpComp";
            panelTotpComp.Size = new Size(333, 73);
            panelTotpComp.TabIndex = 1;
            // 
            // lblNoApp
            // 
            lblNoApp.Anchor = AnchorStyles.Top;
            lblNoApp.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblNoApp.Location = new Point(12, 6);
            lblNoApp.Name = "lblNoApp";
            lblNoApp.Size = new Size(309, 61);
            lblNoApp.TabIndex = 2;
            lblNoApp.Text = "Click the 'Add' button\r\nto add a new application";
            lblNoApp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 100);
            Controls.Add(panelTotpComp);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            StartPosition = FormStartPosition.Manual;
            Text = "MyOTP";
            FormClosing += Form1_FormClosing;
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelTotpComp.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private NotifyIcon notifyIcon1;
        private Panel panel1;
        private Button button1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem quitToolStripMenuItem;
        private Panel panelTotpComp;
        private Label lblNoApp;
    }
}