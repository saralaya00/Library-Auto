using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Library_Auto
{
    public partial class ViewIssued_11 : Form
    {
        Connect c = new Connect();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataTable dt = new DataTable();

        public string state = "";

        public ViewIssued_11()
        {
            InitializeComponent();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            c.cmd.CommandText = "select * from IssueTable";
            adp.SelectCommand = c.cmd;
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnLost_Click(object sender, EventArgs e)
        {

            int issueIDMax;
            string status;

            if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

            c.cmd.CommandText = "select max(issueid) from issueTable where memberid ='" + txtMemID.Text + "'";
            issueIDMax = (int) c.cmd.ExecuteScalar();

            c.cmd.CommandText = "select status from issueTable where issueID='" + issueIDMax + "'";
            status = (string) c.cmd.ExecuteScalar();

            if (status != "Issued")
            {
                MessageBox.Show("The issue status is " + status
                    + "\n\n To set Book Status to Lost the Issue Status must be \"Issued\"",
                    "Book Lost", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }



        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            dt.Clear();

            c.cmd.CommandText = "select count(*) from IssueTable where memberid = '" + txtMemID.Text + "'";

            if ((int)c.cmd.ExecuteScalar() > 0)
            {
                btnLost.Enabled = true;
            }

            else btnLost.Enabled = false;

            c.cmd.CommandText = "select * from IssueTable where memberid = '" + txtMemID.Text + "'";
            adp.SelectCommand = c.cmd;
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void BookLost_11_Load(object sender, EventArgs e)
        {
            if (state == "View Issued")
            {
                lblLostBook.Text = "View Issued";
                this.Text = "View Issued";

                this.Controls.Remove(btnLost);
                this.Controls.Remove(txtMemID);
                this.Controls.Remove(btnFind);
                this.Controls.Remove(lblIssueId);
          
            }

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            Size reSize = new Size(this.Size.Width - 60, this.Size.Height - 120);
            dataGridView1.Size = reSize;
        }

    }
}