namespace Library_Auto.Crystal_Reports
{
    partial class Reports_Base
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
            this.splitter = new System.Windows.Forms.Splitter();
            this.panelControls = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // cryRptViewer
            // 
            this.cryRptViewer.ActiveViewIndex = -1;
            this.cryRptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cryRptViewer.Dock = System.Windows.Forms.DockStyle.Left;
            this.cryRptViewer.Location = new System.Drawing.Point(0, 0);
            this.cryRptViewer.Name = "cryRptViewer";
            this.cryRptViewer.SelectionFormula = "";
            this.cryRptViewer.Size = new System.Drawing.Size(840, 353);
            this.cryRptViewer.TabIndex = 0;
            this.cryRptViewer.ViewTimeSelectionFormula = "";
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
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControls.Location = new System.Drawing.Point(845, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(168, 353);
            this.panelControls.TabIndex = 2;
            // 
            // Reports_Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1013, 353);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.cryRptViewer);
            this.Name = "Reports_Base";
            this.Text = "Reports Base";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Reports_Base_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter;
        protected CrystalDecisions.Windows.Forms.CrystalReportViewer cryRptViewer;
        protected System.Windows.Forms.Panel panelControls;
    }
}