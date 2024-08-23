namespace MyOTP
{
    partial class FormAddNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddNew));
            groupBox1 = new GroupBox();
            tbSecretKey = new TextBox();
            tbAppName = new TextBox();
            tbStep = new TextBox();
            cbHash = new ComboBox();
            tbSize = new TextBox();
            tbUserName = new TextBox();
            tbUrl = new TextBox();
            label10 = new Label();            
            label8 = new Label();
            groupBox2 = new GroupBox();           
            label1 = new Label();           
            label2 = new Label();           
            label3 = new Label();            
            label4 = new Label();           
            label5 = new Label();
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbUrl);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(tbUserName);
            groupBox1.Controls.Add(label8);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Location = new Point(0, 110);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(486, 90);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Optional Fields";
            // 
            // tbUrl
            // 
            tbUrl.Location = new Point(120, 48);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(246, 23);
            tbUrl.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 51);
            label10.Name = "label10";
            label10.Size = new Size(22, 15);
            label10.TabIndex = 99;
            label10.Text = "Url";
            // 
            // tbUserName
            // 
            tbUserName.Location = new Point(120, 19);
            tbUserName.Name = "tbUserName";
            tbUserName.Size = new Size(246, 23);
            tbUserName.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 22);
            label8.Name = "label8";
            label8.Size = new Size(65, 15);
            label8.TabIndex = 99;
            label8.Text = "User Name";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbHash);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(tbSize);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(tbStep);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(tbSecretKey);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(tbAppName);
            groupBox2.Controls.Add(label5);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(486, 108);
            groupBox2.TabIndex = 99;
            groupBox2.TabStop = false;
            groupBox2.Text = "Mandatory Fields";
            // 
            // cbHash
            // 
            cbHash.FormattingEnabled = true;
            cbHash.Items.AddRange(new object[] { "sha1", "sha256", "sha512" });
            cbHash.Location = new Point(120, 74);
            cbHash.Name = "cbHash";
            cbHash.Size = new Size(121, 23);
            cbHash.TabIndex = 3;
            cbHash.Text = "sha1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 77);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 99;
            label1.Text = "Encryption";
            // 
            // tbSize
            // 
            tbSize.Location = new Point(372, 74);
            tbSize.Name = "tbSize";
            tbSize.Size = new Size(100, 23);
            tbSize.TabIndex = 4;
            tbSize.Text = "6";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(275, 77);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 99;
            label2.Text = "Size";
            // 
            // tbStep
            // 
            tbStep.Location = new Point(372, 45);
            tbStep.Name = "tbStep";
            tbStep.Size = new Size(100, 23);
            tbStep.TabIndex = 2;
            tbStep.Text = "30";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(275, 48);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 99;
            label3.Text = "Steps (duration)";
            // 
            // tbSecretKey
            // 
            tbSecretKey.Location = new Point(120, 16);
            tbSecretKey.Name = "tbSecretKey";
            tbSecretKey.Size = new Size(352, 23);
            tbSecretKey.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 19);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 99;
            label4.Text = "Secret Key";
            // 
            // tbAppName
            // 
            tbAppName.Location = new Point(120, 45);
            tbAppName.Name = "tbAppName";
            tbAppName.Size = new Size(100, 23);
            tbAppName.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 48);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 99;
            label5.Text = "App Name";
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 200);
            panel1.Name = "panel1";
            panel1.Size = new Size(486, 30);
            panel1.TabIndex = 16;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(327, 4);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(408, 4);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormAddNew
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 230);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(groupBox2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAddNew";
            Text = "Add a new app";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private TextBox tbUrl;
        private Label label10;
        private TextBox tbUserName;
        private Label label8;
        private GroupBox groupBox2;
        private ComboBox cbHash;
        private Label label1;
        private TextBox tbSize;
        private Label label2;
        private TextBox tbStep;
        private Label label3;
        private TextBox tbSecretKey;
        private Label label4;
        private TextBox tbAppName;
        private Label label5;
        private Panel panel1;
        private Button button2;
        private Button button1;
    }
}