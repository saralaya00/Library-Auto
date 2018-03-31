namespace Library_Auto
{
    partial class Stock_08
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stock_08));
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccno = new System.Windows.Forms.TextBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnDelCopy = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCurrentStock = new System.Windows.Forms.ToolStripStatusLabel();
            this.bar = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripError = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the Accno";
            // 
            // txtAccno
            // 
            this.txtAccno.Location = new System.Drawing.Point(112, 58);
            this.txtAccno.MaxLength = 15;
            this.txtAccno.Name = "txtAccno";
            this.txtAccno.ShortcutsEnabled = false;
            this.txtAccno.Size = new System.Drawing.Size(192, 20);
            this.txtAccno.TabIndex = 1;
            this.txtAccno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AlphaNumValidations);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(326, 55);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label40.Location = new System.Drawing.Point(12, 9);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(159, 29);
            this.label40.TabIndex = 4;
            this.label40.Text = "Stock Lookup";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(628, 362);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(488, 55);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(407, 55);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(75, 23);
            this.btnShowAll.TabIndex = 7;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnDelCopy
            // 
            this.btnDelCopy.Location = new System.Drawing.Point(570, 55);
            this.btnDelCopy.Name = "btnDelCopy";
            this.btnDelCopy.Size = new System.Drawing.Size(75, 23);
            this.btnDelCopy.TabIndex = 8;
            this.btnDelCopy.Text = "Delete Copy";
            this.btnDelCopy.UseVisualStyleBackColor = true;
            this.btnDelCopy.Click += new System.EventHandler(this.btnDelCopy_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCurrentStock,
            this.bar,
            this.stripError});
            this.statusStrip1.Location = new System.Drawing.Point(0, 471);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(666, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCurrentStock
            // 
            this.lblCurrentStock.Name = "lblCurrentStock";
            this.lblCurrentStock.Size = new System.Drawing.Size(126, 17);
            this.lblCurrentStock.Text = "Current Stock (Count):";
            // 
            // bar
            // 
            this.bar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(14, 17);
            this.bar.Text = "|";
            // 
            // stripError
            // 
            this.stripError.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.stripError.ForeColor = System.Drawing.Color.Red;
            this.stripError.Name = "stripError";
            this.stripError.Size = new System.Drawing.Size(16, 17);
            this.stripError.Text = "...";
            // 
            // Stock_08
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(666, 493);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnDelCopy);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.txtAccno);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(682, 532);
            this.Name = "Stock_08";
            this.Text = "Library Auto";
            this.Load += new System.EventHandler(this.StockLookup_04b_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccno;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnDelCopy;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentStock;
        private System.Windows.Forms.ToolStripStatusLabel bar;
        private System.Windows.Forms.ToolStripStatusLabel stripError;
    }
}