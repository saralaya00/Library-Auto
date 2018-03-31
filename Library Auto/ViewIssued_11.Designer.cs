namespace Library_Auto
{
    partial class ViewIssued_11
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewIssued_11));
            this.btnLost = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblLostBook = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtMemID = new System.Windows.Forms.TextBox();
            this.lblIssueId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLost
            // 
            this.btnLost.Enabled = false;
            this.btnLost.Location = new System.Drawing.Point(307, 405);
            this.btnLost.Name = "btnLost";
            this.btnLost.Size = new System.Drawing.Size(75, 23);
            this.btnLost.TabIndex = 19;
            this.btnLost.Text = "Set to Lost";
            this.btnLost.UseVisualStyleBackColor = true;
            this.btnLost.Click += new System.EventHandler(this.btnLost_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(161, 15);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 18;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(640, 344);
            this.dataGridView1.TabIndex = 17;
            // 
            // lblLostBook
            // 
            this.lblLostBook.AutoSize = true;
            this.lblLostBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLostBook.Location = new System.Drawing.Point(12, 9);
            this.lblLostBook.Name = "lblLostBook";
            this.lblLostBook.Size = new System.Drawing.Size(143, 29);
            this.lblLostBook.TabIndex = 16;
            this.lblLostBook.Text = "View Issued";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(226, 404);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 15;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtMemID
            // 
            this.txtMemID.Location = new System.Drawing.Point(82, 405);
            this.txtMemID.Name = "txtMemID";
            this.txtMemID.ShortcutsEnabled = false;
            this.txtMemID.Size = new System.Drawing.Size(138, 20);
            this.txtMemID.TabIndex = 14;
            // 
            // lblIssueId
            // 
            this.lblIssueId.AutoSize = true;
            this.lblIssueId.Location = new System.Drawing.Point(12, 409);
            this.lblIssueId.Name = "lblIssueId";
            this.lblIssueId.Size = new System.Drawing.Size(59, 13);
            this.lblIssueId.TabIndex = 13;
            this.lblIssueId.Text = "Member ID";
            // 
            // ViewIssued_11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(668, 437);
            this.Controls.Add(this.btnLost);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblLostBook);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtMemID);
            this.Controls.Add(this.lblIssueId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(684, 476);
            this.Name = "ViewIssued_11";
            this.Text = "Library Auto";
            this.Load += new System.EventHandler(this.BookLost_11_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLost;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblLostBook;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblIssueId;
        public System.Windows.Forms.TextBox txtMemID;
    }
}