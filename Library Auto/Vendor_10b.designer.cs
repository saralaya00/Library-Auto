namespace Library_Auto
{
    partial class Vendor_10b
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vendor_10b));
            this.grpVendorDetail = new System.Windows.Forms.GroupBox();
            this.lblValidation = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVenName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVenId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpVendorDetail.SuspendLayout();
            this.panelNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpVendorDetail
            // 
            this.grpVendorDetail.Controls.Add(this.lblValidation);
            this.grpVendorDetail.Controls.Add(this.btnSubmit);
            this.grpVendorDetail.Controls.Add(this.txtEmail);
            this.grpVendorDetail.Controls.Add(this.label6);
            this.grpVendorDetail.Controls.Add(this.txtPhno);
            this.grpVendorDetail.Controls.Add(this.label5);
            this.grpVendorDetail.Controls.Add(this.txtAddress);
            this.grpVendorDetail.Controls.Add(this.label4);
            this.grpVendorDetail.Controls.Add(this.txtVenName);
            this.grpVendorDetail.Controls.Add(this.label3);
            this.grpVendorDetail.Controls.Add(this.txtVenId);
            this.grpVendorDetail.Controls.Add(this.label2);
            this.grpVendorDetail.Location = new System.Drawing.Point(12, 123);
            this.grpVendorDetail.Name = "grpVendorDetail";
            this.grpVendorDetail.Size = new System.Drawing.Size(321, 184);
            this.grpVendorDetail.TabIndex = 0;
            this.grpVendorDetail.TabStop = false;
            this.grpVendorDetail.Text = "Vendor Details";
            // 
            // lblValidation
            // 
            this.lblValidation.AutoSize = true;
            this.lblValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidation.ForeColor = System.Drawing.Color.Red;
            this.lblValidation.Location = new System.Drawing.Point(6, 165);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(19, 13);
            this.lblValidation.TabIndex = 56;
            this.lblValidation.Text = "...";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(240, 155);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 45;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(89, 129);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ShortcutsEnabled = false;
            this.txtEmail.Size = new System.Drawing.Size(226, 20);
            this.txtEmail.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Email";
            // 
            // txtPhno
            // 
            this.txtPhno.Location = new System.Drawing.Point(89, 103);
            this.txtPhno.MaxLength = 10;
            this.txtPhno.Name = "txtPhno";
            this.txtPhno.ShortcutsEnabled = false;
            this.txtPhno.Size = new System.Drawing.Size(226, 20);
            this.txtPhno.TabIndex = 7;
            this.txtPhno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumValidations);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ph No";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(89, 77);
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ShortcutsEnabled = false;
            this.txtAddress.Size = new System.Drawing.Size(226, 20);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AlphaNumValidations);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Address";
            // 
            // txtVenName
            // 
            this.txtVenName.Location = new System.Drawing.Point(89, 51);
            this.txtVenName.MaxLength = 20;
            this.txtVenName.Name = "txtVenName";
            this.txtVenName.ShortcutsEnabled = false;
            this.txtVenName.Size = new System.Drawing.Size(226, 20);
            this.txtVenName.TabIndex = 3;
            this.txtVenName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AlphaValidations);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vendor Name";
            // 
            // txtVenId
            // 
            this.txtVenId.Location = new System.Drawing.Point(89, 25);
            this.txtVenId.MaxLength = 10;
            this.txtVenId.Name = "txtVenId";
            this.txtVenId.ShortcutsEnabled = false;
            this.txtVenId.Size = new System.Drawing.Size(226, 20);
            this.txtVenId.TabIndex = 1;
            this.txtVenId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumValidations);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vendor id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 29);
            this.label1.TabIndex = 34;
            this.label1.Text = "Vendor Management";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 51);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 47;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(93, 51);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 45;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(12, 51);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 44;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // panelNavigation
            // 
            this.panelNavigation.Controls.Add(this.btnLast);
            this.panelNavigation.Controls.Add(this.btnFirst);
            this.panelNavigation.Controls.Add(this.btnPrev);
            this.panelNavigation.Controls.Add(this.btnNext);
            this.panelNavigation.Location = new System.Drawing.Point(7, 80);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(326, 36);
            this.panelNavigation.TabIndex = 48;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(248, 7);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 23);
            this.btnLast.TabIndex = 41;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(5, 7);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 23);
            this.btnFirst.TabIndex = 38;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(86, 7);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 39;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(167, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 40;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(255, 51);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 43;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Vendor_10b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(346, 319);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpVendorDetail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Vendor_10b";
            this.Text = "Vendor";
            this.Load += new System.EventHandler(this.Vendor_10b_Load);
            this.grpVendorDetail.ResumeLayout(false);
            this.grpVendorDetail.PerformLayout();
            this.panelNavigation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpVendorDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtVenId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVenName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblValidation;
        private System.Windows.Forms.Button btnAdd;
    }
}