namespace Library_Auto
{
    partial class HolidaySetup_06c
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HolidaySetup_06c));
            this.dgHoliday = new System.Windows.Forms.DataGridView();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.grpSetYear = new System.Windows.Forms.GroupBox();
            this.btnGotoYear = new System.Windows.Forms.Button();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnSetHoliday = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.calHoliday = new System.Windows.Forms.MonthCalendar();
            this.lblHoliday = new System.Windows.Forms.Label();
            this.btnInsertSundays = new System.Windows.Forms.Button();
            this.btnDelPrev = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgHoliday)).BeginInit();
            this.grpSetYear.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgHoliday
            // 
            this.dgHoliday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHoliday.Location = new System.Drawing.Point(271, 46);
            this.dgHoliday.Name = "dgHoliday";
            this.dgHoliday.ReadOnly = true;
            this.dgHoliday.Size = new System.Drawing.Size(260, 187);
            this.dgHoliday.TabIndex = 2;
            this.dgHoliday.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridToCal_Click);
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(6, 15);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(55, 20);
            this.txtYear.TabIndex = 3;
            // 
            // grpSetYear
            // 
            this.grpSetYear.Controls.Add(this.btnGotoYear);
            this.grpSetYear.Controls.Add(this.txtYear);
            this.grpSetYear.Location = new System.Drawing.Point(18, 246);
            this.grpSetYear.Name = "grpSetYear";
            this.grpSetYear.Size = new System.Drawing.Size(106, 43);
            this.grpSetYear.TabIndex = 4;
            this.grpSetYear.TabStop = false;
            this.grpSetYear.Text = "Goto Year";
            // 
            // btnGotoYear
            // 
            this.btnGotoYear.Location = new System.Drawing.Point(67, 15);
            this.btnGotoYear.Name = "btnGotoYear";
            this.btnGotoYear.Size = new System.Drawing.Size(29, 20);
            this.btnGotoYear.TabIndex = 4;
            this.btnGotoYear.Text = "Go";
            this.btnGotoYear.UseVisualStyleBackColor = true;
            this.btnGotoYear.Click += new System.EventHandler(this.btnGotoYear_Click);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(71, 213);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(125, 20);
            this.txtReason.TabIndex = 5;
            // 
            // btnSetHoliday
            // 
            this.btnSetHoliday.Location = new System.Drawing.Point(271, 239);
            this.btnSetHoliday.Name = "btnSetHoliday";
            this.btnSetHoliday.Size = new System.Drawing.Size(71, 23);
            this.btnSetHoliday.TabIndex = 6;
            this.btnSetHoliday.Text = "Insert";
            this.btnSetHoliday.UseVisualStyleBackColor = true;
            this.btnSetHoliday.Click += new System.EventHandler(this.btnSetHoliday_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Reason :";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(348, 239);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(71, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // calHoliday
            // 
            this.calHoliday.Location = new System.Drawing.Point(18, 46);
            this.calHoliday.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.calHoliday.MaxSelectionCount = 1;
            this.calHoliday.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.calHoliday.Name = "calHoliday";
            this.calHoliday.TabIndex = 9;
            // 
            // lblHoliday
            // 
            this.lblHoliday.AutoSize = true;
            this.lblHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoliday.ForeColor = System.Drawing.Color.Black;
            this.lblHoliday.Location = new System.Drawing.Point(19, 8);
            this.lblHoliday.Name = "lblHoliday";
            this.lblHoliday.Size = new System.Drawing.Size(163, 29);
            this.lblHoliday.TabIndex = 10;
            this.lblHoliday.Text = "Holiday Setup";
            // 
            // btnInsertSundays
            // 
            this.btnInsertSundays.Location = new System.Drawing.Point(271, 268);
            this.btnInsertSundays.Name = "btnInsertSundays";
            this.btnInsertSundays.Size = new System.Drawing.Size(148, 23);
            this.btnInsertSundays.TabIndex = 11;
            this.btnInsertSundays.Text = "Insert Sundays";
            this.btnInsertSundays.UseVisualStyleBackColor = true;
            this.btnInsertSundays.Click += new System.EventHandler(this.btnInsertSundays_Click);
            // 
            // btnDelPrev
            // 
            this.btnDelPrev.Location = new System.Drawing.Point(425, 268);
            this.btnDelPrev.Name = "btnDelPrev";
            this.btnDelPrev.Size = new System.Drawing.Size(106, 23);
            this.btnDelPrev.TabIndex = 12;
            this.btnDelPrev.Text = "Delete Previous";
            this.btnDelPrev.UseVisualStyleBackColor = true;
            this.btnDelPrev.Click += new System.EventHandler(this.btnDelPrev_Click);
            // 
            // HolidaySetup_06c
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(543, 301);
            this.Controls.Add(this.btnDelPrev);
            this.Controls.Add(this.btnInsertSundays);
            this.Controls.Add(this.lblHoliday);
            this.Controls.Add(this.calHoliday);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSetHoliday);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.grpSetYear);
            this.Controls.Add(this.dgHoliday);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HolidaySetup_06c";
            this.Text = "Holiday Setup";
            this.Load += new System.EventHandler(this.HolidaySetup_06c_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgHoliday)).EndInit();
            this.grpSetYear.ResumeLayout(false);
            this.grpSetYear.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgHoliday;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.GroupBox grpSetYear;
        private System.Windows.Forms.Button btnGotoYear;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnSetHoliday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.MonthCalendar calHoliday;
        private System.Windows.Forms.Label lblHoliday;
        private System.Windows.Forms.Button btnInsertSundays;
        private System.Windows.Forms.Button btnDelPrev;
    }
}