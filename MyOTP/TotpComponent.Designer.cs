namespace MyOTP
{
    partial class TotpComponent
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            panel2 = new Panel();
            lbRemaining = new Label();
            lbUserName = new Label();
            lbTotpCode = new Label();
            lbAppName = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            panel2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(248, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(84, 92);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(lbRemaining);
            panel2.Controls.Add(lbUserName);
            panel2.Controls.Add(lbTotpCode);
            panel2.Controls.Add(lbAppName);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(248, 92);
            panel2.TabIndex = 1;
            // 
            // lbRemaining
            // 
            lbRemaining.Anchor = AnchorStyles.Left;
            lbRemaining.AutoSize = true;
            lbRemaining.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbRemaining.Location = new Point(133, 62);
            lbRemaining.Name = "lbRemaining";
            lbRemaining.Size = new Size(84, 21);
            lbRemaining.TabIndex = 3;
            lbRemaining.Text = "{totpCode}";
            // 
            // lbUserName
            // 
            lbUserName.AutoSize = true;
            lbUserName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lbUserName.Location = new Point(0, 30);
            lbUserName.Name = "lbUserName";
            lbUserName.Size = new Size(110, 25);
            lbUserName.TabIndex = 2;
            lbUserName.Text = "{userName}";
            // 
            // lbTotpCode
            // 
            lbTotpCode.AutoSize = true;
            lbTotpCode.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lbTotpCode.Location = new Point(0, 55);
            lbTotpCode.Name = "lbTotpCode";
            lbTotpCode.Size = new Size(127, 30);
            lbTotpCode.TabIndex = 1;
            lbTotpCode.Text = "{totpCode}";
            lbTotpCode.Click += LbTotpCode_Click;
            // 
            // lbAppName
            // 
            lbAppName.AutoSize = true;
            lbAppName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lbAppName.ForeColor = SystemColors.ControlText;
            lbAppName.Location = new Point(0, 0);
            lbAppName.Name = "lbAppName";
            lbAppName.Size = new Size(130, 30);
            lbAppName.TabIndex = 0;
            lbAppName.Text = "{appName}";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // timer1
            // 
            timer1.Interval = 500;
            timer1.Tick += Timer1_Tick;
            // 
            // TotpComponent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "TotpComponent";
            Size = new Size(332, 92);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label lbTotpCode;
        private Label lbAppName;
        private Label lbUserName;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Label lbRemaining;
        private System.Windows.Forms.Timer timer1;
    }
}
