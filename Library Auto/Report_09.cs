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
    public partial class Report_09 : Form
    {
        public Administration_03 adminInstance;
        public string action;

        string commandTextShowAll;
        string commandTextShow;

        Connect c = new Connect();
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter();
       

        public Report_09()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dt.Clear();
        }

        private void StockLookup_04b_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            FillGrid(commandTextShowAll);
        }

        private void btnDelCopy_Click(object sender, EventArgs e)
        {
            c.cmd.CommandText = "select count(*) from StockTable where accno ='" + txtBox.Text + "'";
            int count = (int) c.cmd.ExecuteScalar();

            if (count > 0)
            {
                string copyno = Interaction.InputBox("Enter the CopyNo:", "Delete Copy", "", -1, -1);
                string commandText = "select * from StockTable where accno ='" + txtBox.Text + "' and copyno ='" + copyno + "'";

                FillGrid(commandText);

                if (dt.Rows.Count > 0)
                {
                    c.cmd.CommandText = "delete from StockTable where accno ='" + txtBox.Text + "' and copyno ='" + copyno + "'";
                    c.cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted!");
                }

                else MessageBox.Show("\nAccno :" + txtBox.Text + "\nCopy Number :" + copyno + "\n\nNot found!", "Delete Copy");
            } 

            else
            {
                MessageBox.Show("Not Found!");
                Interaction.Beep();
                txtBox.Focus();
                return;
            }
        }

        void FillGrid(string _commandText)
        {
            c.cmd.CommandText = _commandText;

            adp.SelectCommand = c.cmd;
            dt.Clear();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;

            //lblCurrentStock.Text = "Current Stock (Count): " + dView.Count;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            switch (e.CloseReason)
            {
                case CloseReason.WindowsShutDown:
                case CloseReason.TaskManagerClosing:
                    return;
                default: break;

            }

            if (adminInstance != null) adminInstance.Show();
        }

        private void AlphaNumValidations(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar)
                && !char.Equals(e.KeyChar, '-'))
            {
                stripError.Text = "Enter only Letters or Digits";
                e.Handled = true;

                return;
            }

            stripError.Text = "...";
        }

        public void ShowReport(string reName)
        {
            lblReport.Text += reName;
            switch (reName)
            {
                case "Circulation": CirculationReports(); break;
                case "Stock": StockReport(); break;
                case "Members":

                    action = "Members";
                    commandTextShowAll = "select * from MembersTable"; 
                    break;
                case "Purchase": PurchaseReport(); break;
                case "Defaulters": DefaultersReport(); break;
                case "Date based": DatebasedReport(); break;

                default: MessageBox.Show("Empty"); break;
            }
        }

        void CirculationReports()
        {
            action = "Circulation";
        }

        void StockReport()
        {
        
        }

        void MembersReport()
        { 

        }

        void PurchaseReport()
        { 
        
        }

        void DefaultersReport()
        { 
        
        }

        void DatebasedReport()
        { 
        
        }
    }
}