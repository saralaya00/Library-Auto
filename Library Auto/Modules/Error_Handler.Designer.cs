namespace Library_Auto.Modules
{
    partial class Error_Handler
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
            this.tabController = new System.Windows.Forms.TabControl();
            this.tabBtnClick = new System.Windows.Forms.TabPage();
            this.txtBtnClicks = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.tabStates = new System.Windows.Forms.TabPage();
            this.txtStateChange = new System.Windows.Forms.TextBox();
            this.tabExceptions = new System.Windows.Forms.TabPage();
            this.txtException = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabController.SuspendLayout();
            this.tabBtnClick.SuspendLayout();
            this.tabStates.SuspendLayout();
            this.tabExceptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Controls.Add(this.tabBtnClick);
            this.tabController.Controls.Add(this.tabStates);
            this.tabController.Controls.Add(this.tabExceptions);
            this.tabController.Location = new System.Drawing.Point(12, 12);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.Size = new System.Drawing.Size(414, 427);
            this.tabController.TabIndex = 0;
            // 
            // tabBtnClick
            // 
            this.tabBtnClick.Controls.Add(this.txtBtnClicks);
            this.tabBtnClick.Controls.Add(this.txtTitle);
            this.tabBtnClick.Location = new System.Drawing.Point(4, 22);
            this.tabBtnClick.Name = "tabBtnClick";
            this.tabBtnClick.Padding = new System.Windows.Forms.Padding(3);
            this.tabBtnClick.Size = new System.Drawing.Size(406, 401);
            this.tabBtnClick.TabIndex = 0;
            this.tabBtnClick.Text = "Functions";
            this.tabBtnClick.UseVisualStyleBackColor = true;
            // 
            // txtBtnClicks
            // 
            this.txtBtnClicks.AcceptsReturn = true;
            this.txtBtnClicks.AcceptsTab = true;
            this.txtBtnClicks.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtBtnClicks.ForeColor = System.Drawing.Color.Black;
            this.txtBtnClicks.Location = new System.Drawing.Point(6, 77);
            this.txtBtnClicks.Multiline = true;
            this.txtBtnClicks.Name = "txtBtnClicks";
            this.txtBtnClicks.ReadOnly = true;
            this.txtBtnClicks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBtnClicks.Size = new System.Drawing.Size(394, 318);
            this.txtBtnClicks.TabIndex = 4;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTitle.ForeColor = System.Drawing.Color.Red;
            this.txtTitle.Location = new System.Drawing.Point(7, 7);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(393, 64);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabStates
            // 
            this.tabStates.Controls.Add(this.txtStateChange);
            this.tabStates.Location = new System.Drawing.Point(4, 22);
            this.tabStates.Name = "tabStates";
            this.tabStates.Padding = new System.Windows.Forms.Padding(3);
            this.tabStates.Size = new System.Drawing.Size(406, 401);
            this.tabStates.TabIndex = 1;
            this.tabStates.Text = "State Changes";
            this.tabStates.UseVisualStyleBackColor = true;
            // 
            // txtStateChange
            // 
            this.txtStateChange.AcceptsReturn = true;
            this.txtStateChange.AcceptsTab = true;
            this.txtStateChange.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtStateChange.ForeColor = System.Drawing.Color.Black;
            this.txtStateChange.Location = new System.Drawing.Point(6, 6);
            this.txtStateChange.Multiline = true;
            this.txtStateChange.Name = "txtStateChange";
            this.txtStateChange.ReadOnly = true;
            this.txtStateChange.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStateChange.Size = new System.Drawing.Size(394, 389);
            this.txtStateChange.TabIndex = 2;
            // 
            // tabExceptions
            // 
            this.tabExceptions.Controls.Add(this.txtException);
            this.tabExceptions.Location = new System.Drawing.Point(4, 22);
            this.tabExceptions.Name = "tabExceptions";
            this.tabExceptions.Size = new System.Drawing.Size(406, 401);
            this.tabExceptions.TabIndex = 2;
            this.tabExceptions.Text = "Exceptions";
            this.tabExceptions.UseVisualStyleBackColor = true;
            // 
            // txtException
            // 
            this.txtException.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtException.ForeColor = System.Drawing.Color.Black;
            this.txtException.Location = new System.Drawing.Point(3, 3);
            this.txtException.Multiline = true;
            this.txtException.Name = "txtException";
            this.txtException.ReadOnly = true;
            this.txtException.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtException.Size = new System.Drawing.Size(400, 395);
            this.txtException.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(351, 450);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Error_Handler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(438, 485);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.tabController);
            this.Name = "Error_Handler";
            this.Text = "Error Handler";
            this.Load += new System.EventHandler(this.Error_Handler_Load);
            this.tabController.ResumeLayout(false);
            this.tabBtnClick.ResumeLayout(false);
            this.tabBtnClick.PerformLayout();
            this.tabStates.ResumeLayout(false);
            this.tabStates.PerformLayout();
            this.tabExceptions.ResumeLayout(false);
            this.tabExceptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabController;
        private System.Windows.Forms.TabPage tabBtnClick;
        private System.Windows.Forms.TabPage tabStates;
        private System.Windows.Forms.Button btnExport;
        public System.Windows.Forms.TextBox txtTitle;
        public System.Windows.Forms.TextBox txtStateChange;
        private System.Windows.Forms.TabPage tabExceptions;
        public System.Windows.Forms.TextBox txtBtnClicks;
        public System.Windows.Forms.TextBox txtException;
    }
}