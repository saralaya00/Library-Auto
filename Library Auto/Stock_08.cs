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
    public partial class Stock_08 : Form
    {
        public Administration_03 adminInstance;

        Connect c = new Connect();
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter();
        
        public string accno;
        string star = "accno, copyno, status, vendor, source, currency, dept, edition, billno, billdate,  category, price,  discount, netcost, pages, location, binding, copyyear";

        public Stock_08()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string commandText = "select " + star + " from StockTable where accno='" + txtAccno.Text + "'";
            FillGrid(commandText);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dt.Clear();
        }

        private void StockLookup_04b_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            if (accno != null) txtAccno.Text = accno;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            string commandText = "select " + star + " from StockTable ORDER BY LEN(accno) ASC, accno ASC, copyno ASC";
            FillGrid(commandText);
        }

        private void btnDelCopy_Click(object sender, EventArgs e)
        {
            c.cmd.CommandText = "select count(*) from StockTable where accno ='" + txtAccno.Text + "'";
            int count = (int) c.cmd.ExecuteScalar();

            if (count > 0)
            {
                string copyno = Interaction.InputBox("Enter the CopyNo:", "Delete Copy", "", -1, -1);
                string commandText = "select " + star + " from StockTable where accno ='" + txtAccno.Text + "' and copyno ='" + copyno + "'";

                FillGrid(commandText);

                if (dt.Rows.Count > 0)
                {
                    c.cmd.CommandText = "delete from StockTable where accno ='" + txtAccno.Text + "' and copyno ='" + copyno + "'";
                    c.cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted!");
                }

                else MessageBox.Show("\nAccno :" + txtAccno.Text + "\nCopy Number :" + copyno + "\n\nNot found!", "Delete Copy");
            } 

            else
            {
                MessageBox.Show("Not Found!");
                Interaction.Beep();
                txtAccno.Focus();
                return;
            }
        }

        void FillGrid(string _commandText)
        {
            c.cmd.CommandText = _commandText;

            adp.SelectCommand = c.cmd;
            dt.Clear();
            adp.Fill(dt);

            DataView dView = new DataView(dt);

            dataGridView1.DataSource = dView;

            lblCurrentStock.Text = "Current Stock (Count): " + dView.Count;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells[0].Value == DBNull.Value)
                {
                    return;
                }

                txtAccno.Text = (string)dt.Rows[dataGridView1.SelectedCells[0].RowIndex].ItemArray[0];
            }

            catch (FormatException) { }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            Size reSize = new Size(this.Size.Width - 60, this.Size.Height - 180);
            dataGridView1.Size = reSize;
        }

    }
}