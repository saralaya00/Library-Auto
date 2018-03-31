namespace Library_Auto
{
    partial class AccRegButtons_04a
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccRegButtons_04a));
            this.adderList = new System.Windows.Forms.ListBox();
            this.label40 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblOps = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // adderList
            // 
            this.adderList.FormattingEnabled = true;
            this.adderList.Location = new System.Drawing.Point(143, 41);
            this.adderList.Name = "adderList";
            this.adderList.Size = new System.Drawing.Size(159, 212);
            this.adderList.TabIndex = 0;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(10, 9);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(99, 29);
            this.label40.TabIndex = 4;
            this.label40.Text = "Add List";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblOps});
            this.statusStrip1.Location = new System.Drawing.Point(0, 261);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(314, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblOps
            // 
            this.lblOps.Name = "lblOps";
            this.lblOps.Size = new System.Drawing.Size(112, 17);
            this.lblOps.Text = "Current Operation : ";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 80);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 109);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(12, 54);
            this.txtAdd.MaxLength = 20;
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.ShortcutsEnabled = false;
            this.txtAdd.Size = new System.Drawing.Size(125, 20);
            this.txtAdd.TabIndex = 9;
            // 
            // AccRegButtons_04a
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(314, 283);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.adderList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AccRegButtons_04a";
            this.Text = " ";
            this.Load += new System.EventHandler(this.AccRegButtons_04a_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox adderList;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblOps;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtAdd;
    }
}