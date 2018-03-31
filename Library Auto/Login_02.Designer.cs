namespace Library_Auto
{
    partial class Login_02
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_02));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkForgotPW = new System.Windows.Forms.LinkLabel();
            this.cbShowPw = new System.Windows.Forms.CheckBox();
            this.label40 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtpword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkForgotPW);
            this.panel1.Controls.Add(this.cbShowPw);
            this.panel1.Controls.Add(this.label40);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.txtpword);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 258);
            this.panel1.TabIndex = 0;
            // 
            // linkForgotPW
            // 
            this.linkForgotPW.AutoSize = true;
            this.linkForgotPW.Location = new System.Drawing.Point(15, 232);
            this.linkForgotPW.Name = "linkForgotPW";
            this.linkForgotPW.Size = new System.Drawing.Size(95, 13);
            this.linkForgotPW.TabIndex = 8;
            this.linkForgotPW.TabStop = true;
            this.linkForgotPW.Text = "Forgot Password ?";
            this.linkForgotPW.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForgotPW_LinkClicked);
            // 
            // cbShowPw
            // 
            this.cbShowPw.AutoSize = true;
            this.cbShowPw.Location = new System.Drawing.Point(98, 167);
            this.cbShowPw.Name = "cbShowPw";
            this.cbShowPw.Size = new System.Drawing.Size(102, 17);
            this.cbShowPw.TabIndex = 7;
            this.cbShowPw.Text = "Show Password";
            this.cbShowPw.UseVisualStyleBackColor = true;
            this.cbShowPw.CheckedChanged += new System.EventHandler(this.cbShowPw_CheckedChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(13, 21);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(140, 29);
            this.label40.TabIndex = 6;
            this.label40.Text = "Library Auto";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Library_Auto.Properties.Resources.libauto_Logo_256;
            this.pictureBox1.Location = new System.Drawing.Point(172, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(172, 222);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtpword
            // 
            this.txtpword.Location = new System.Drawing.Point(98, 140);
            this.txtpword.MaxLength = 30;
            this.txtpword.Name = "txtpword";
            this.txtpword.ShortcutsEnabled = false;
            this.txtpword.Size = new System.Drawing.Size(149, 20);
            this.txtpword.TabIndex = 3;
            this.txtpword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(98, 114);
            this.txtUsername.MaxLength = 30;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ShortcutsEnabled = false;
            this.txtUsername.Size = new System.Drawing.Size(149, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblError});
            this.statusStrip1.Location = new System.Drawing.Point(0, 283);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(286, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            // 
            // Login_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(286, 305);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login_02";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Login_02_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtpword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cbShowPw;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.LinkLabel linkForgotPW;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblError;
    }
}