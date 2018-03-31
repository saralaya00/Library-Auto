namespace Library_Auto
{
    partial class CreateOrder_10c
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateOrder_10c));
            this.grpVendorInfo = new System.Windows.Forms.GroupBox();
            this.ddlVenId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhno = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OrderDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.grpBookInfo = new System.Windows.Forms.GroupBox();
            this.ddlAccno = new System.Windows.Forms.ComboBox();
            this.txtNoCopy = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgCreateOrder = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpVendorInfo.SuspendLayout();
            this.grpBookInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCreateOrder)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpVendorInfo
            // 
            this.grpVendorInfo.Controls.Add(this.ddlVenId);
            this.grpVendorInfo.Controls.Add(this.label2);
            this.grpVendorInfo.Controls.Add(this.label3);
            this.grpVendorInfo.Controls.Add(this.label4);
            this.grpVendorInfo.Controls.Add(this.txtName);
            this.grpVendorInfo.Controls.Add(this.txtEmail);
            this.grpVendorInfo.Controls.Add(this.txtPhno);
            this.grpVendorInfo.Controls.Add(this.txtAddress);
            this.grpVendorInfo.Controls.Add(this.label5);
            this.grpVendorInfo.Controls.Add(this.label6);
            this.grpVendorInfo.Location = new System.Drawing.Point(12, 96);
            this.grpVendorInfo.Name = "grpVendorInfo";
            this.grpVendorInfo.Size = new System.Drawing.Size(200, 160);
            this.grpVendorInfo.TabIndex = 0;
            this.grpVendorInfo.TabStop = false;
            this.grpVendorInfo.Text = "Vendors info";
            // 
            // ddlVenId
            // 
            this.ddlVenId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlVenId.FormattingEnabled = true;
            this.ddlVenId.Location = new System.Drawing.Point(83, 19);
            this.ddlVenId.Name = "ddlVenId";
            this.ddlVenId.Size = new System.Drawing.Size(100, 21);
            this.ddlVenId.TabIndex = 41;
            this.ddlVenId.SelectionChangeCommitted += new System.EventHandler(this.UpdateVendorInfo_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Vendor Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Vendor Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Email Id";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 46);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.ShortcutsEnabled = false;
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 52;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(83, 72);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ShortcutsEnabled = false;
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 53;
            // 
            // txtPhno
            // 
            this.txtPhno.Location = new System.Drawing.Point(83, 98);
            this.txtPhno.MaxLength = 10;
            this.txtPhno.Name = "txtPhno";
            this.txtPhno.ShortcutsEnabled = false;
            this.txtPhno.Size = new System.Drawing.Size(100, 20);
            this.txtPhno.TabIndex = 54;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(83, 124);
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ShortcutsEnabled = false;
            this.txtAddress.Size = new System.Drawing.Size(100, 20);
            this.txtAddress.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Phone No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Address";
            // 
            // OrderDatePicker
            // 
            this.OrderDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.OrderDatePicker.Location = new System.Drawing.Point(83, 19);
            this.OrderDatePicker.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.OrderDatePicker.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.OrderDatePicker.Name = "OrderDatePicker";
            this.OrderDatePicker.Size = new System.Drawing.Size(100, 20);
            this.OrderDatePicker.TabIndex = 56;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Order Date";
            // 
            // grpBookInfo
            // 
            this.grpBookInfo.Controls.Add(this.ddlAccno);
            this.grpBookInfo.Controls.Add(this.txtNoCopy);
            this.grpBookInfo.Controls.Add(this.txtPublisher);
            this.grpBookInfo.Controls.Add(this.txtAuthor);
            this.grpBookInfo.Controls.Add(this.txtTitle);
            this.grpBookInfo.Controls.Add(this.label9);
            this.grpBookInfo.Controls.Add(this.label10);
            this.grpBookInfo.Controls.Add(this.label11);
            this.grpBookInfo.Controls.Add(this.label12);
            this.grpBookInfo.Controls.Add(this.label13);
            this.grpBookInfo.Location = new System.Drawing.Point(218, 96);
            this.grpBookInfo.Name = "grpBookInfo";
            this.grpBookInfo.Size = new System.Drawing.Size(198, 160);
            this.grpBookInfo.TabIndex = 0;
            this.grpBookInfo.TabStop = false;
            this.grpBookInfo.Text = "Book info";
            // 
            // ddlAccno
            // 
            this.ddlAccno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAccno.FormattingEnabled = true;
            this.ddlAccno.Location = new System.Drawing.Point(82, 19);
            this.ddlAccno.Name = "ddlAccno";
            this.ddlAccno.Size = new System.Drawing.Size(100, 21);
            this.ddlAccno.TabIndex = 42;
            this.ddlAccno.SelectionChangeCommitted += new System.EventHandler(this.UpdateAccRegTableInfo_SelectionChangeCommitted);
            // 
            // txtNoCopy
            // 
            this.txtNoCopy.Location = new System.Drawing.Point(82, 124);
            this.txtNoCopy.MaxLength = 2;
            this.txtNoCopy.Name = "txtNoCopy";
            this.txtNoCopy.ShortcutsEnabled = false;
            this.txtNoCopy.Size = new System.Drawing.Size(100, 20);
            this.txtNoCopy.TabIndex = 60;
            this.txtNoCopy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumValidations);
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(82, 98);
            this.txtPublisher.MaxLength = 50;
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.ShortcutsEnabled = false;
            this.txtPublisher.Size = new System.Drawing.Size(100, 20);
            this.txtPublisher.TabIndex = 59;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(82, 72);
            this.txtAuthor.MaxLength = 50;
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ShortcutsEnabled = false;
            this.txtAuthor.Size = new System.Drawing.Size(100, 20);
            this.txtAuthor.TabIndex = 58;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(82, 46);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ShortcutsEnabled = false;
            this.txtTitle.Size = new System.Drawing.Size(100, 20);
            this.txtTitle.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "AccNo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "Title";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "Author";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = "Publisher";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 127);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 51;
            this.label13.Text = "No Of Copies";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Location = new System.Drawing.Point(288, 19);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.ReadOnly = true;
            this.txtOrderNo.ShortcutsEnabled = false;
            this.txtOrderNo.Size = new System.Drawing.Size(100, 20);
            this.txtOrderNo.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(232, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Order No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 29);
            this.label1.TabIndex = 35;
            this.label1.Text = "Purchase Order";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(93, 447);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 37;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(260, 447);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 38;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(12, 447);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 39;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgCreateOrder
            // 
            this.dgCreateOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCreateOrder.Location = new System.Drawing.Point(12, 291);
            this.dgCreateOrder.Name = "dgCreateOrder";
            this.dgCreateOrder.ReadOnly = true;
            this.dgCreateOrder.Size = new System.Drawing.Size(404, 150);
            this.dgCreateOrder.TabIndex = 40;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 262);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 41;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OrderDatePicker);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtOrderNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 46);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Info";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(341, 447);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 43;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblError});
            this.statusStrip1.Location = new System.Drawing.Point(0, 483);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(433, 22);
            this.statusStrip1.TabIndex = 44;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(16, 17);
            this.lblError.Text = "...";
            // 
            // CreateOrder_10c
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(433, 505);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgCreateOrder);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpBookInfo);
            this.Controls.Add(this.grpVendorInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreateOrder_10c";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Order";
            this.Load += new System.EventHandler(this.CreateOrder_10c_Load);
            this.grpVendorInfo.ResumeLayout(false);
            this.grpVendorInfo.PerformLayout();
            this.grpBookInfo.ResumeLayout(false);
            this.grpBookInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCreateOrder)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpVendorInfo;
        private System.Windows.Forms.GroupBox grpBookInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox ddlVenId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhno;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlAccno;
        private System.Windows.Forms.TextBox txtNoCopy;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgCreateOrder;
        private System.Windows.Forms.DateTimePicker OrderDatePicker;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblError;
    }
}