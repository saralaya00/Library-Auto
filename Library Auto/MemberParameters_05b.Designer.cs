namespace Library_Auto
{
    partial class MemberParameters_05b
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberParameters_05b));
            this.label40 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMtypeID = new System.Windows.Forms.TextBox();
            this.txtMaxIssuedays = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFinePD = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtMemtype = new System.Windows.Forms.TextBox();
            this.checkUnlock = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblValidation = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(12, 9);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(231, 29);
            this.label40.TabIndex = 5;
            this.label40.Text = "Member parameters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Member Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Member Type Identifier";
            // 
            // txtMtypeID
            // 
            this.txtMtypeID.Location = new System.Drawing.Point(144, 78);
            this.txtMtypeID.MaxLength = 2;
            this.txtMtypeID.Name = "txtMtypeID";
            this.txtMtypeID.ShortcutsEnabled = false;
            this.txtMtypeID.Size = new System.Drawing.Size(120, 20);
            this.txtMtypeID.TabIndex = 9;
            this.txtMtypeID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AlphaValidations);
            // 
            // txtMaxIssuedays
            // 
            this.txtMaxIssuedays.Location = new System.Drawing.Point(144, 104);
            this.txtMaxIssuedays.MaxLength = 1;
            this.txtMaxIssuedays.Name = "txtMaxIssuedays";
            this.txtMaxIssuedays.ShortcutsEnabled = false;
            this.txtMaxIssuedays.Size = new System.Drawing.Size(120, 20);
            this.txtMaxIssuedays.TabIndex = 10;
            this.txtMaxIssuedays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumValidations);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Max Issue Period : In Days";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fine per Day";
            // 
            // txtFinePD
            // 
            this.txtFinePD.Location = new System.Drawing.Point(144, 130);
            this.txtFinePD.MaxLength = 2;
            this.txtFinePD.Name = "txtFinePD";
            this.txtFinePD.ShortcutsEnabled = false;
            this.txtFinePD.Size = new System.Drawing.Size(120, 20);
            this.txtFinePD.TabIndex = 13;
            this.txtFinePD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumValidations);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(189, 156);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnMaster_Click);
            // 
            // txtMemtype
            // 
            this.txtMemtype.Location = new System.Drawing.Point(144, 52);
            this.txtMemtype.MaxLength = 10;
            this.txtMemtype.Name = "txtMemtype";
            this.txtMemtype.ShortcutsEnabled = false;
            this.txtMemtype.Size = new System.Drawing.Size(120, 20);
            this.txtMemtype.TabIndex = 15;
            this.txtMemtype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AlphaValidations);
            // 
            // checkUnlock
            // 
            this.checkUnlock.AutoSize = true;
            this.checkUnlock.Location = new System.Drawing.Point(168, 161);
            this.checkUnlock.Name = "checkUnlock";
            this.checkUnlock.Size = new System.Drawing.Size(15, 14);
            this.checkUnlock.TabIndex = 16;
            this.checkUnlock.UseVisualStyleBackColor = true;
            this.checkUnlock.CheckedChanged += new System.EventHandler(this.checkUnlock_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblValidation});
            this.statusStrip1.Location = new System.Drawing.Point(0, 192);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(283, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblValidation
            // 
            this.lblValidation.BackColor = System.Drawing.Color.Transparent;
            this.lblValidation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblValidation.ForeColor = System.Drawing.Color.Red;
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(16, 17);
            this.lblValidation.Text = "...";
            // 
            // MemberParameters_05b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(283, 214);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.checkUnlock);
            this.Controls.Add(this.txtMemtype);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtFinePD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaxIssuedays);
            this.Controls.Add(this.txtMtypeID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label40);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MemberParameters_05b";
            this.Text = "Member Parameters";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMtypeID;
        private System.Windows.Forms.TextBox txtMaxIssuedays;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFinePD;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtMemtype;
        private System.Windows.Forms.CheckBox checkUnlock;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblValidation;
    }
}