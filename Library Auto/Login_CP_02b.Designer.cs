namespace Library_Auto
{
    partial class Login_CP_02b
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_CP_02b));
            this.label1 = new System.Windows.Forms.Label();
            this.txtpword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmPW = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSecQuestion = new System.Windows.Forms.Label();
            this.txtSQuestion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSAnswer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 29);
            this.label1.TabIndex = 34;
            this.label1.Text = "Change password";
            // 
            // txtpword
            // 
            this.txtpword.Location = new System.Drawing.Point(127, 93);
            this.txtpword.MaxLength = 30;
            this.txtpword.Name = "txtpword";
            this.txtpword.ShortcutsEnabled = false;
            this.txtpword.Size = new System.Drawing.Size(149, 20);
            this.txtpword.TabIndex = 38;
            this.txtpword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(127, 67);
            this.txtUsername.MaxLength = 30;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.ShortcutsEnabled = false;
            this.txtUsername.Size = new System.Drawing.Size(149, 20);
            this.txtUsername.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "StaffID (User Name)";
            // 
            // txtConfirmPW
            // 
            this.txtConfirmPW.Location = new System.Drawing.Point(127, 119);
            this.txtConfirmPW.MaxLength = 30;
            this.txtConfirmPW.Name = "txtConfirmPW";
            this.txtConfirmPW.ShortcutsEnabled = false;
            this.txtConfirmPW.Size = new System.Drawing.Size(149, 20);
            this.txtConfirmPW.TabIndex = 39;
            this.txtConfirmPW.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Confirm Password";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(207, 260);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSecQuestion
            // 
            this.lblSecQuestion.AutoSize = true;
            this.lblSecQuestion.Location = new System.Drawing.Point(55, 25);
            this.lblSecQuestion.Name = "lblSecQuestion";
            this.lblSecQuestion.Size = new System.Drawing.Size(164, 13);
            this.lblSecQuestion.TabIndex = 42;
            this.lblSecQuestion.Text = "Enter a Unique Security Question";
            // 
            // txtSQuestion
            // 
            this.txtSQuestion.Location = new System.Drawing.Point(6, 48);
            this.txtSQuestion.MaxLength = 100;
            this.txtSQuestion.Name = "txtSQuestion";
            this.txtSQuestion.ShortcutsEnabled = false;
            this.txtSQuestion.Size = new System.Drawing.Size(258, 20);
            this.txtSQuestion.TabIndex = 43;
            this.txtSQuestion.Text = "Default Question : What is your favorite Color?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Enter the Answer";
            // 
            // txtSAnswer
            // 
            this.txtSAnswer.Location = new System.Drawing.Point(115, 74);
            this.txtSAnswer.MaxLength = 30;
            this.txtSAnswer.Name = "txtSAnswer";
            this.txtSAnswer.ShortcutsEnabled = false;
            this.txtSAnswer.Size = new System.Drawing.Size(149, 20);
            this.txtSAnswer.TabIndex = 45;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSQuestion);
            this.groupBox1.Controls.Add(this.txtSAnswer);
            this.groupBox1.Controls.Add(this.lblSecQuestion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 109);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Security Question";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblError});
            this.statusStrip1.Location = new System.Drawing.Point(0, 290);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(288, 22);
            this.statusStrip1.TabIndex = 47;
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
            // Login_CP_02b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 312);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConfirmPW);
            this.Controls.Add(this.txtpword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login_CP_02b";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Auto";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Login_CP_02b_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConfirmPW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSecQuestion;
        private System.Windows.Forms.TextBox txtSQuestion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSAnswer;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblError;
    }
}