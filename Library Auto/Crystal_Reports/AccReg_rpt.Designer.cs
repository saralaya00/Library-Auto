namespace Library_Auto.Crystal_Reports
{
    partial class AccReg_rpt
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
            this.splitter = new System.Windows.Forms.Splitter();
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddlTextType = new System.Windows.Forms.ComboBox();
            this.btnDisplayTextbased = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.grpType = new System.Windows.Forms.GroupBox();
            this.btnDisplayType = new System.Windows.Forms.Button();
            this.ddlRpt = new System.Windows.Forms.ComboBox();
            this.ddlType = new System.Windows.Forms.ComboBox();
            this.cryRptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.accReg1 = new Library_Auto.Crystal_Reports._AccReg();
            this.panelControls.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpType.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter
            // 
            this.splitter.Location = new System.Drawing.Point(840, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(5, 353);
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.btnReset);
            this.panelControls.Controls.Add(this.groupBox1);
            this.panelControls.Controls.Add(this.grpType);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControls.Location = new System.Drawing.Point(845, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(168, 353);
            this.panelControls.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(14, 231);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Reset All";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddlTextType);
            this.groupBox1.Controls.Add(this.btnDisplayTextbased);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Location = new System.Drawing.Point(6, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 102);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text based Search";
            // 
            // ddlTextType
            // 
            this.ddlTextType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTextType.FormattingEnabled = true;
            this.ddlTextType.Items.AddRange(new object[] {
            "Accno",
            "Title",
            "Author"});
            this.ddlTextType.Location = new System.Drawing.Point(8, 45);
            this.ddlTextType.Name = "ddlTextType";
            this.ddlTextType.Size = new System.Drawing.Size(136, 21);
            this.ddlTextType.TabIndex = 3;
            // 
            // btnDisplayTextbased
            // 
            this.btnDisplayTextbased.Location = new System.Drawing.Point(8, 71);
            this.btnDisplayTextbased.Name = "btnDisplayTextbased";
            this.btnDisplayTextbased.Size = new System.Drawing.Size(73, 23);
            this.btnDisplayTextbased.TabIndex = 2;
            this.btnDisplayTextbased.Text = "Display";
            this.btnDisplayTextbased.UseVisualStyleBackColor = true;
            this.btnDisplayTextbased.Click += new System.EventHandler(this.btnDisplayTextbased_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(8, 19);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(136, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // grpType
            // 
            this.grpType.Controls.Add(this.btnDisplayType);
            this.grpType.Controls.Add(this.ddlRpt);
            this.grpType.Controls.Add(this.ddlType);
            this.grpType.Location = new System.Drawing.Point(6, 12);
            this.grpType.Name = "grpType";
            this.grpType.Size = new System.Drawing.Size(150, 105);
            this.grpType.TabIndex = 15;
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
            "Section",
            "Type",
            "Language",
            "Subject",
            "Publisher"});
            this.ddlType.Location = new System.Drawing.Point(8, 20);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(135, 21);
            this.ddlType.TabIndex = 0;
            this.ddlType.SelectionChangeCommitted += new System.EventHandler(this.ddlType_SelectionChangeCommitted);
            // 
            // cryRptViewer
            // 
            this.cryRptViewer.ActiveViewIndex = 0;
            this.cryRptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cryRptViewer.Dock = System.Windows.Forms.DockStyle.Left;
            this.cryRptViewer.Location = new System.Drawing.Point(0, 0);
            this.cryRptViewer.Name = "cryRptViewer";
            this.cryRptViewer.ReportSource = this.accReg1;
            this.cryRptViewer.Size = new System.Drawing.Size(840, 353);
            this.cryRptViewer.TabIndex = 0;
            // 
            // AccReg_rpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1013, 353);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.cryRptViewer);
            this.Name = "AccReg_rpt";
            this.Text = "Accession Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Reports_Base_Load);
            this.panelControls.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter;
        protected CrystalDecisions.Windows.Forms.CrystalReportViewer cryRptViewer;
        protected System.Windows.Forms.Panel panelControls;
        private _AccReg accReg1;
        private System.Windows.Forms.GroupBox grpType;
        private System.Windows.Forms.Button btnDisplayType;
        private System.Windows.Forms.ComboBox ddlRpt;
        private System.Windows.Forms.ComboBox ddlType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ddlTextType;
        private System.Windows.Forms.Button btnDisplayTextbased;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnReset;
    }
}