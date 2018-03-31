namespace Library_Auto
{
    partial class Fine_06b
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fine_06b));
            this.label2 = new System.Windows.Forms.Label();
            this.txtMemID = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Member ID";
            // 
            // txtMemID
            // 
            this.txtMemID.Location = new System.Drawing.Point(84, 18);
            this.txtMemID.Name = "txtMemID";
            this.txtMemID.Size = new System.Drawing.Size(138, 20);
            this.txtMemID.TabIndex = 3;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(228, 17);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(596, 9);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(61, 29);
            this.label40.TabIndex = 9;
            this.label40.Text = "Fine";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(640, 329);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SetMemID_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(309, 17);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 11;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnPay
            // 
            this.btnPay.Enabled = false;
            this.btnPay.Location = new System.Drawing.Point(391, 17);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 23);
            this.btnPay.TabIndex = 12;
            this.btnPay.Text = "Pay Fine";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // Fine_06b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(669, 389);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtMemID);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(685, 428);
            this.Name = "Fine_06b";
            this.Text = "Fine";
            this.Load += new System.EventHandler(this.Fine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMemID;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnPay;
    }
}