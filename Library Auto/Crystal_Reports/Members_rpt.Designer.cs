namespace Library_Auto.Crystal_Reports
{
    partial class Members_rpt
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
            this.cryRptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this._Members1 = new Library_Auto.Crystal_Reports._Members();
            this.splitter = new System.Windows.Forms.Splitter();
            this.panelControls = new System.Windows.Forms.Panel();
            this.grpType = new System.Windows.Forms.GroupBox();
            this.btnDisplayType = new System.Windows.Forms.Button();
            this.ddlRpt = new System.Windows.Forms.ComboBox();
            this.ddlType = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.grpDatebased = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.ddlDateType = new System.Windows.Forms.DomainUpDown();
            this.btnDisplayDate = new System.Windows.Forms.Button();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddlTextType = new System.Windows.Forms.ComboBox();
            this.btnDisplayTextbased = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panelControls.SuspendLayout();
            this.grpType.SuspendLayout();
            this.grpDatebased.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cryRptViewer
            // 
            this.cryRptViewer.ActiveViewIndex = 0;
            this.cryRptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cryRptViewer.Dock = System.Windows.Forms.DockStyle.Left;
            this.cryRptViewer.Location = new System.Drawing.Point(0, 0);
            this.cryRptViewer.Name = "cryRptViewer";
            this.cryRptViewer.ReportSource = this._Members1;
            this.cryRptViewer.Size = new System.Drawing.Size(840, 418);
            this.cryRptViewer.TabIndex = 0;
            // 
            // splitter
            // 
            this.splitter.Location = new System.Drawing.Point(840, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(5, 418);
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.grpType);
            this.panelControls.Controls.Add(this.btnReset);
            this.panelControls.Controls.Add(this.grpDatebased);
            this.panelControls.Controls.Add(this.groupBox1);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControls.Location = new System.Drawing.Point(845, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(168, 418);
            this.panelControls.TabIndex = 2;
            // 
            // grpType
            // 
            this.grpType.Controls.Add(this.btnDisplayType);
            this.grpType.Controls.Add(this.ddlRpt);
            this.grpType.Controls.Add(this.ddlType);
            this.grpType.Location = new System.Drawing.Point(6, 148);
            this.grpType.Name = "grpType";
            this.grpType.Size = new System.Drawing.Size(150, 105);
            this.grpType.TabIndex = 10;
            this.grpType.TabStop = false;
            this.grpType.Text = "Type based Search";
            // 
            // btnDisplayType
            // 
            this.btnDisplayType.Location = new System.Drawing.Point(8, 74);
            this.btnDisplayType.Name = "btnDisplayType";
            this.btnDisplayType.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayType.TabIndex = 4;
            this.btnDisplayType.Text = "Display";
            this.btnDisplayType.UseVisualStyleBackColor = true;
            this.btnDisplayType.Click += new System.EventHandler(this.btnDisplayType_Click);
            // 
            // ddlRpt
            // 
            this.ddlRpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRpt.FormattingEnabled = true;
            this.ddlRpt.Location = new System.Drawing.Point(8, 47);
            this.ddlRpt.Name = "ddlRpt";
            this.ddlRpt.Size = new System.Drawing.Size(135, 21);
            this.ddlRpt.TabIndex = 1;
            // 
            // ddlType
            // 
            this.ddlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType.FormattingEnabled = true;
            this.ddlType.Items.AddRange(new object[] {
            "Member Type",
            "Course",
            "Status"});
            this.ddlType.Location = new System.Drawing.Point(8, 20);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(135, 21);
            this.ddlType.TabIndex = 0;
            this.ddlType.SelectionChangeCommitted += new System.EventHandler(this.cbType_SelectionChangeCommitted);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 367);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset All";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grpDatebased
            // 
            this.grpDatebased.Controls.Add(this.label2);
            this.grpDatebased.Controls.Add(this.label1);
            this.grpDatebased.Controls.Add(this.dtStart);
            this.grpDatebased.Controls.Add(this.ddlDateType);
            this.grpDatebased.Controls.Add(this.btnDisplayDate);
            this.grpDatebased.Controls.Add(this.dtEnd);
            this.grpDatebased.Location = new System.Drawing.Point(6, 12);
            this.grpDatebased.Name = "grpDatebased";
            this.grpDatebased.Size = new System.Drawing.Size(150, 129);
            this.grpDatebased.TabIndex = 7;
            this.grpDatebased.TabStop = false;
            this.grpDatebased.Text = "Date based Sort";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "From";
            // 
            // dtStart
            // 
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStart.Location = new System.Drawing.Point(42, 45);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(102, 20);
            this.dtStart.TabIndex = 0;
            // 
            // ddlDateType
            // 
            this.ddlDateType.Items.Add("Subscription Date");
            this.ddlDateType.Items.Add("Expiry Date");
            this.ddlDateType.Location = new System.Drawing.Point(6, 19);
            this.ddlDateType.Name = "ddlDateType";
            this.ddlDateType.ReadOnly = true;
            this.ddlDateType.Size = new System.Drawing.Size(138, 20);
            this.ddlDateType.TabIndex = 2;
            // 
            // btnDisplayDate
            // 
            this.btnDisplayDate.Location = new System.Drawing.Point(6, 97);
            this.btnDisplayDate.Name = "btnDisplayDate";
            this.btnDisplayDate.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayDate.TabIndex = 3;
            this.btnDisplayDate.Text = "Display";
            this.btnDisplayDate.UseVisualStyleBackColor = true;
            this.btnDisplayDate.Click += new System.EventHandler(this.btnDisplayDate_Click);
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(42, 71);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(102, 20);
            this.dtEnd.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddlTextType);
            this.groupBox1.Controls.Add(this.btnDisplayTextbased);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Location = new System.Drawing.Point(6, 259);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 102);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text based Search";
            // 
            // ddlTextType
            // 
            this.ddlTextType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTextType.FormattingEnabled = true;
            this.ddlTextType.Items.AddRange(new object[] {
            "Fine > [Number]",
            "Fine < [Number]",
            "Member ID",
            "Firstname",
            "Lastname",
            "Email"});
            this.ddlTextType.Location = new System.Drawing.Point(6, 45);
            this.ddlTextType.Name = "ddlTextType";
            this.ddlTextType.Size = new System.Drawing.Size(138, 21);
            this.ddlTextType.TabIndex = 3;
            // 
            // btnDisplayTextbased
            // 
            this.btnDisplayTextbased.Location = new System.Drawing.Point(6, 71);
            this.btnDisplayTextbased.Name = "btnDisplayTextbased";
            this.btnDisplayTextbased.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayTextbased.TabIndex = 2;
            this.btnDisplayTextbased.Text = "Display";
            this.btnDisplayTextbased.UseVisualStyleBackColor = true;
            this.btnDisplayTextbased.Click += new System.EventHandler(this.btnDisplayTextbased_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(6, 19);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(138, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // Members_rpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1013, 418);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.cryRptViewer);
            this.Name = "Members_rpt";
            this.Text = "Members Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Reports_Base_Load);
            this.panelControls.ResumeLayout(false);
            this.grpType.ResumeLayout(false);
            this.grpDatebased.ResumeLayout(false);
            this.grpDatebased.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter;
        protected CrystalDecisions.Windows.Forms.CrystalReportViewer cryRptViewer;
        protected System.Windows.Forms.Panel panelControls;
        private _Members _Members1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpDatebased;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DomainUpDown ddlDateType;
        private System.Windows.Forms.Button btnDisplayDate;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ddlTextType;
        private System.Windows.Forms.Button btnDisplayTextbased;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox grpType;
        private System.Windows.Forms.Button btnDisplayType;
        private System.Windows.Forms.ComboBox ddlRpt;
        private System.Windows.Forms.ComboBox ddlType;
    }
}