namespace Library_Auto
{
    partial class Search_01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search_01));
            this.grpTxtFormat = new System.Windows.Forms.GroupBox();
            this.radoLetter = new System.Windows.Forms.RadioButton();
            this.radoFull = new System.Windows.Forms.RadioButton();
            this.radoWordBeg = new System.Windows.Forms.RadioButton();
            this.ddlLogical = new System.Windows.Forms.ComboBox();
            this.txtAuthor1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radoAll = new System.Windows.Forms.RadioButton();
            this.radoJournal = new System.Windows.Forms.RadioButton();
            this.radoMagazine = new System.Windows.Forms.RadioButton();
            this.radoBook = new System.Windows.Forms.RadioButton();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblOPAC = new System.Windows.Forms.Label();
            this.cbAdvSearch = new System.Windows.Forms.CheckBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.txtAccno = new System.Windows.Forms.TextBox();
            this.grpSimple = new System.Windows.Forms.GroupBox();
            this.grpAdv = new System.Windows.Forms.GroupBox();
            this.cbYear = new System.Windows.Forms.RadioButton();
            this.cbKeyword = new System.Windows.Forms.RadioButton();
            this.cbSubject = new System.Windows.Forms.RadioButton();
            this.cbLanguage = new System.Windows.Forms.RadioButton();
            this.cbAccno = new System.Windows.Forms.RadioButton();
            this.cbSection = new System.Windows.Forms.RadioButton();
            this.ddlSubject = new System.Windows.Forms.ComboBox();
            this.ddlLanguage = new System.Windows.Forms.ComboBox();
            this.ddlSection = new System.Windows.Forms.ComboBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpTxtFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpSimple.SuspendLayout();
            this.grpAdv.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTxtFormat
            // 
            this.grpTxtFormat.Controls.Add(this.radoLetter);
            this.grpTxtFormat.Controls.Add(this.radoFull);
            this.grpTxtFormat.Controls.Add(this.radoWordBeg);
            this.grpTxtFormat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grpTxtFormat.Location = new System.Drawing.Point(12, 219);
            this.grpTxtFormat.Name = "grpTxtFormat";
            this.grpTxtFormat.Size = new System.Drawing.Size(275, 47);
            this.grpTxtFormat.TabIndex = 0;
            this.grpTxtFormat.TabStop = false;
            this.grpTxtFormat.Text = "Text Format";
            // 
            // radoLetter
            // 
            this.radoLetter.AutoSize = true;
            this.radoLetter.Location = new System.Drawing.Point(99, 19);
            this.radoLetter.Name = "radoLetter";
            this.radoLetter.Size = new System.Drawing.Size(74, 17);
            this.radoLetter.TabIndex = 2;
            this.radoLetter.Text = "First Letter";
            this.radoLetter.UseVisualStyleBackColor = true;
            // 
            // radoFull
            // 
            this.radoFull.AutoSize = true;
            this.radoFull.Checked = true;
            this.radoFull.Location = new System.Drawing.Point(179, 19);
            this.radoFull.Name = "radoFull";
            this.radoFull.Size = new System.Drawing.Size(65, 17);
            this.radoFull.TabIndex = 1;
            this.radoFull.TabStop = true;
            this.radoFull.Text = "Full Text";
            this.radoFull.UseVisualStyleBackColor = true;
            // 
            // radoWordBeg
            // 
            this.radoWordBeg.AutoSize = true;
            this.radoWordBeg.Location = new System.Drawing.Point(20, 19);
            this.radoWordBeg.Name = "radoWordBeg";
            this.radoWordBeg.Size = new System.Drawing.Size(73, 17);
            this.radoWordBeg.TabIndex = 0;
            this.radoWordBeg.Text = "First Word";
            this.radoWordBeg.UseVisualStyleBackColor = true;
            // 
            // ddlLogical
            // 
            this.ddlLogical.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLogical.FormattingEnabled = true;
            this.ddlLogical.Items.AddRange(new object[] {
            "OR",
            "AND"});
            this.ddlLogical.Location = new System.Drawing.Point(297, 18);
            this.ddlLogical.Name = "ddlLogical";
            this.ddlLogical.Size = new System.Drawing.Size(54, 21);
            this.ddlLogical.TabIndex = 8;
            // 
            // txtAuthor1
            // 
            this.txtAuthor1.Location = new System.Drawing.Point(415, 18);
            this.txtAuthor1.MaxLength = 50;
            this.txtAuthor1.Name = "txtAuthor1";
            this.txtAuthor1.ShortcutsEnabled = false;
            this.txtAuthor1.Size = new System.Drawing.Size(148, 20);
            this.txtAuthor1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(371, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Author";
            // 
            // txtTitle1
            // 
            this.txtTitle1.Location = new System.Drawing.Point(127, 19);
            this.txtTitle1.MaxLength = 50;
            this.txtTitle1.Name = "txtTitle1";
            this.txtTitle1.ShortcutsEnabled = false;
            this.txtTitle1.Size = new System.Drawing.Size(148, 20);
            this.txtTitle1.TabIndex = 1;
            this.txtTitle1.TextChanged += new System.EventHandler(this.txtTitle1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(66, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book Title";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 272);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(675, 291);
            this.dataGridView1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radoAll);
            this.groupBox2.Controls.Add(this.radoJournal);
            this.groupBox2.Controls.Add(this.radoMagazine);
            this.groupBox2.Controls.Add(this.radoBook);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Location = new System.Drawing.Point(293, 219);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 47);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search For";
            // 
            // radoAll
            // 
            this.radoAll.AutoSize = true;
            this.radoAll.Checked = true;
            this.radoAll.Location = new System.Drawing.Point(218, 19);
            this.radoAll.Name = "radoAll";
            this.radoAll.Size = new System.Drawing.Size(36, 17);
            this.radoAll.TabIndex = 3;
            this.radoAll.TabStop = true;
            this.radoAll.Text = "All";
            this.radoAll.UseVisualStyleBackColor = true;
            // 
            // radoJournal
            // 
            this.radoJournal.AutoSize = true;
            this.radoJournal.Location = new System.Drawing.Point(153, 19);
            this.radoJournal.Name = "radoJournal";
            this.radoJournal.Size = new System.Drawing.Size(59, 17);
            this.radoJournal.TabIndex = 2;
            this.radoJournal.TabStop = true;
            this.radoJournal.Text = "Journal";
            this.radoJournal.UseVisualStyleBackColor = true;
            // 
            // radoMagazine
            // 
            this.radoMagazine.AutoSize = true;
            this.radoMagazine.Location = new System.Drawing.Point(76, 19);
            this.radoMagazine.Name = "radoMagazine";
            this.radoMagazine.Size = new System.Drawing.Size(71, 17);
            this.radoMagazine.TabIndex = 1;
            this.radoMagazine.TabStop = true;
            this.radoMagazine.Text = "Magazine";
            this.radoMagazine.UseVisualStyleBackColor = true;
            // 
            // radoBook
            // 
            this.radoBook.AutoSize = true;
            this.radoBook.Location = new System.Drawing.Point(20, 19);
            this.radoBook.Name = "radoBook";
            this.radoBook.Size = new System.Drawing.Size(50, 17);
            this.radoBook.TabIndex = 0;
            this.radoBook.TabStop = true;
            this.radoBook.Text = "Book";
            this.radoBook.UseVisualStyleBackColor = true;
            // 
            // btnAll
            // 
            this.btnAll.ForeColor = System.Drawing.Color.Black;
            this.btnAll.Location = new System.Drawing.Point(6, 48);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 4;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(6, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(6, 76);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblOPAC
            // 
            this.lblOPAC.AutoSize = true;
            this.lblOPAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOPAC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblOPAC.Location = new System.Drawing.Point(12, 9);
            this.lblOPAC.Name = "lblOPAC";
            this.lblOPAC.Size = new System.Drawing.Size(418, 29);
            this.lblOPAC.TabIndex = 6;
            this.lblOPAC.Text = "Online Public Access Catalog (OPAC)";
            // 
            // cbAdvSearch
            // 
            this.cbAdvSearch.AutoSize = true;
            this.cbAdvSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbAdvSearch.Location = new System.Drawing.Point(604, 232);
            this.cbAdvSearch.Name = "cbAdvSearch";
            this.cbAdvSearch.Size = new System.Drawing.Size(75, 30);
            this.cbAdvSearch.TabIndex = 14;
            this.cbAdvSearch.Text = "Advanced\r\nSearch";
            this.cbAdvSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbAdvSearch.UseVisualStyleBackColor = true;
            this.cbAdvSearch.CheckedChanged += new System.EventHandler(this.cbAdvSearch_CheckedChanged);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Enabled = false;
            this.txtKeyword.Location = new System.Drawing.Point(127, 45);
            this.txtKeyword.MaxLength = 20;
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.ShortcutsEnabled = false;
            this.txtKeyword.Size = new System.Drawing.Size(148, 20);
            this.txtKeyword.TabIndex = 20;
            // 
            // txtAccno
            // 
            this.txtAccno.Enabled = false;
            this.txtAccno.Location = new System.Drawing.Point(127, 19);
            this.txtAccno.MaxLength = 15;
            this.txtAccno.Name = "txtAccno";
            this.txtAccno.ShortcutsEnabled = false;
            this.txtAccno.Size = new System.Drawing.Size(148, 20);
            this.txtAccno.TabIndex = 17;
            // 
            // grpSimple
            // 
            this.grpSimple.Controls.Add(this.txtTitle1);
            this.grpSimple.Controls.Add(this.ddlLogical);
            this.grpSimple.Controls.Add(this.label1);
            this.grpSimple.Controls.Add(this.txtAuthor1);
            this.grpSimple.Controls.Add(this.label2);
            this.grpSimple.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grpSimple.Location = new System.Drawing.Point(12, 49);
            this.grpSimple.Name = "grpSimple";
            this.grpSimple.Size = new System.Drawing.Size(575, 53);
            this.grpSimple.TabIndex = 16;
            this.grpSimple.TabStop = false;
            this.grpSimple.Text = "Search : Simple";
            // 
            // grpAdv
            // 
            this.grpAdv.Controls.Add(this.cbYear);
            this.grpAdv.Controls.Add(this.cbKeyword);
            this.grpAdv.Controls.Add(this.cbSubject);
            this.grpAdv.Controls.Add(this.cbLanguage);
            this.grpAdv.Controls.Add(this.cbAccno);
            this.grpAdv.Controls.Add(this.cbSection);
            this.grpAdv.Controls.Add(this.ddlSubject);
            this.grpAdv.Controls.Add(this.ddlLanguage);
            this.grpAdv.Controls.Add(this.ddlSection);
            this.grpAdv.Controls.Add(this.txtYear);
            this.grpAdv.Controls.Add(this.txtAccno);
            this.grpAdv.Controls.Add(this.txtKeyword);
            this.grpAdv.Enabled = false;
            this.grpAdv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grpAdv.Location = new System.Drawing.Point(12, 108);
            this.grpAdv.Name = "grpAdv";
            this.grpAdv.Size = new System.Drawing.Size(575, 105);
            this.grpAdv.TabIndex = 17;
            this.grpAdv.TabStop = false;
            this.grpAdv.Text = "Search : Advanced";
            // 
            // cbYear
            // 
            this.cbYear.AutoSize = true;
            this.cbYear.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbYear.Location = new System.Drawing.Point(362, 21);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(47, 17);
            this.cbYear.TabIndex = 34;
            this.cbYear.TabStop = true;
            this.cbYear.Text = "Year";
            this.cbYear.UseVisualStyleBackColor = true;
            this.cbYear.CheckedChanged += new System.EventHandler(this.cbYear_CheckedChanged);
            // 
            // cbKeyword
            // 
            this.cbKeyword.AutoSize = true;
            this.cbKeyword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbKeyword.Location = new System.Drawing.Point(55, 46);
            this.cbKeyword.Name = "cbKeyword";
            this.cbKeyword.Size = new System.Drawing.Size(66, 17);
            this.cbKeyword.TabIndex = 33;
            this.cbKeyword.TabStop = true;
            this.cbKeyword.Text = "Keyword";
            this.cbKeyword.UseVisualStyleBackColor = true;
            this.cbKeyword.CheckedChanged += new System.EventHandler(this.cbKeyword_CheckedChanged);
            // 
            // cbSubject
            // 
            this.cbSubject.AutoSize = true;
            this.cbSubject.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbSubject.Location = new System.Drawing.Point(348, 73);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(61, 17);
            this.cbSubject.TabIndex = 32;
            this.cbSubject.TabStop = true;
            this.cbSubject.Text = "Subject";
            this.cbSubject.UseVisualStyleBackColor = true;
            this.cbSubject.CheckedChanged += new System.EventHandler(this.cbSubject_CheckedChanged);
            // 
            // cbLanguage
            // 
            this.cbLanguage.AutoSize = true;
            this.cbLanguage.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbLanguage.Location = new System.Drawing.Point(336, 46);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(73, 17);
            this.cbLanguage.TabIndex = 31;
            this.cbLanguage.TabStop = true;
            this.cbLanguage.Text = "Language";
            this.cbLanguage.UseVisualStyleBackColor = true;
            this.cbLanguage.CheckedChanged += new System.EventHandler(this.cbLanguage_CheckedChanged);
            // 
            // cbAccno
            // 
            this.cbAccno.AutoSize = true;
            this.cbAccno.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAccno.Location = new System.Drawing.Point(7, 20);
            this.cbAccno.Name = "cbAccno";
            this.cbAccno.Size = new System.Drawing.Size(114, 17);
            this.cbAccno.TabIndex = 30;
            this.cbAccno.TabStop = true;
            this.cbAccno.Text = "Accession Number";
            this.cbAccno.UseVisualStyleBackColor = true;
            this.cbAccno.CheckedChanged += new System.EventHandler(this.cbAccno_CheckedChanged);
            // 
            // cbSection
            // 
            this.cbSection.AutoSize = true;
            this.cbSection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbSection.Location = new System.Drawing.Point(60, 73);
            this.cbSection.Name = "cbSection";
            this.cbSection.Size = new System.Drawing.Size(61, 17);
            this.cbSection.TabIndex = 29;
            this.cbSection.TabStop = true;
            this.cbSection.Text = "Section";
            this.cbSection.UseVisualStyleBackColor = true;
            this.cbSection.CheckedChanged += new System.EventHandler(this.chSection_CheckedChanged);
            // 
            // ddlSubject
            // 
            this.ddlSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSubject.Enabled = false;
            this.ddlSubject.FormattingEnabled = true;
            this.ddlSubject.Location = new System.Drawing.Point(415, 72);
            this.ddlSubject.Name = "ddlSubject";
            this.ddlSubject.Size = new System.Drawing.Size(148, 21);
            this.ddlSubject.TabIndex = 27;
            this.ddlSubject.SelectionChangeCommitted += new System.EventHandler(this.ddlSubject_SelectionChangeCommitted);
            // 
            // ddlLanguage
            // 
            this.ddlLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLanguage.Enabled = false;
            this.ddlLanguage.FormattingEnabled = true;
            this.ddlLanguage.Location = new System.Drawing.Point(415, 45);
            this.ddlLanguage.Name = "ddlLanguage";
            this.ddlLanguage.Size = new System.Drawing.Size(148, 21);
            this.ddlLanguage.TabIndex = 25;
            this.ddlLanguage.SelectionChangeCommitted += new System.EventHandler(this.ddlLanguage_SelectionChangeCommitted);
            // 
            // ddlSection
            // 
            this.ddlSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSection.Enabled = false;
            this.ddlSection.FormattingEnabled = true;
            this.ddlSection.Items.AddRange(new object[] {
            "UG Library",
            "PG Library",
            "General"});
            this.ddlSection.Location = new System.Drawing.Point(127, 72);
            this.ddlSection.Name = "ddlSection";
            this.ddlSection.Size = new System.Drawing.Size(148, 21);
            this.ddlSection.TabIndex = 23;
            this.ddlSection.SelectionChangeCommitted += new System.EventHandler(this.ddlSection_SelectionChangeCommitted);
            // 
            // txtYear
            // 
            this.txtYear.Enabled = false;
            this.txtYear.Location = new System.Drawing.Point(415, 19);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.ShortcutsEnabled = false;
            this.txtYear.Size = new System.Drawing.Size(148, 20);
            this.txtYear.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAll);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Location = new System.Drawing.Point(598, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 105);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Functions";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Library_Auto.Properties.Resources.libauto_Logo_256;
            this.pictureBox1.Location = new System.Drawing.Point(606, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // Search_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(694, 575);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpAdv);
            this.Controls.Add(this.grpSimple);
            this.Controls.Add(this.cbAdvSearch);
            this.Controls.Add(this.lblOPAC);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grpTxtFormat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Search_01";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_01_Load);
            this.grpTxtFormat.ResumeLayout(false);
            this.grpTxtFormat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpSimple.ResumeLayout(false);
            this.grpSimple.PerformLayout();
            this.grpAdv.ResumeLayout(false);
            this.grpAdv.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTxtFormat;
        private System.Windows.Forms.RadioButton radoFull;
        private System.Windows.Forms.RadioButton radoWordBeg;
        private System.Windows.Forms.TextBox txtTitle1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuthor1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlLogical;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton radoLetter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radoAll;
        private System.Windows.Forms.RadioButton radoJournal;
        private System.Windows.Forms.RadioButton radoMagazine;
        private System.Windows.Forms.RadioButton radoBook;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblOPAC;
        private System.Windows.Forms.CheckBox cbAdvSearch;
        private System.Windows.Forms.TextBox txtAccno;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.GroupBox grpSimple;
        private System.Windows.Forms.GroupBox grpAdv;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ddlSection;
        private System.Windows.Forms.ComboBox ddlLanguage;
        private System.Windows.Forms.RadioButton cbSection;
        private System.Windows.Forms.ComboBox ddlSubject;
        private System.Windows.Forms.RadioButton cbAccno;
        private System.Windows.Forms.RadioButton cbSubject;
        private System.Windows.Forms.RadioButton cbLanguage;
        private System.Windows.Forms.RadioButton cbKeyword;
        private System.Windows.Forms.RadioButton cbYear;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

