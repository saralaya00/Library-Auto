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
    public partial class Fine_06b : Form
    {
        Connect c = new Connect();
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter();


        public Administration_03 adminInstance;

        public Fine_06b()
        {
            InitializeComponent();
        }

        private void Fine_Load(object sender, EventArgs e)
        {
            label40.Dock = DockStyle.Right;

            Point lblLoc = label40.Location;
            label40.Dock = DockStyle.None;
            label40.Location = new Point(lblLoc.X - 10, lblLoc.Y + 10);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            switch (e.CloseReason)
            {
                case CloseReason.TaskManagerClosing:
                case CloseReason.WindowsShutDown:
                    return;
                default: break;
            }

            if (adminInstance != null)
            {
                adminInstance.Show();
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            btnPay.Enabled = false;

            dt.Clear();

            c.cmd.CommandText = "select membertype, memberid, firstname, lastname, course,  fine, phoneno, email,  status" 
            + " from MembersTable where fine > 0";
            adp.SelectCommand = c.cmd;
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dt.Clear();

            c.cmd.CommandText = "select count(*) from MembersTable where memberid = '" + txtMemID.Text + "' and fine > 0";

            if ((int)c.cmd.ExecuteScalar() > 0)
            {
                btnPay.Enabled = true;
            }

            else btnPay.Enabled = false;

            c.cmd.CommandText = "select membertype, memberid, firstname, lastname, course, fine, phoneno, email,  status"
                + " from MembersTable where memberid = '" + txtMemID.Text + "'";
            adp.SelectCommand = c.cmd;
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                c.cmd.CommandText = "select fine from MembersTable where memberid ='" + txtMemID.Text + "'";
                int fine = (int)c.cmd.ExecuteScalar();

                string inputBoxValue = Interaction.InputBox("Current Fine:" + fine
                    + "\nEnter the Fine Amount to deduct.", "Pay Fine", "", -1, -1);
                int fineToDeduct = Convert.ToInt32(inputBoxValue);


                if (fineToDeduct > fine || fineToDeduct <= 0)
                {
                    DialogResult diaRes = MessageBox.Show("Incorrect Deduction Amount!"
                        + "\nDo you want to Set the Fine to 0 ?", "Pay Fine", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (diaRes == DialogResult.Cancel)
                    {
                        return;
                    }

                    else fineToDeduct = fine;
                }

                c.cmd.CommandText = "update MembersTable set fine=@fine where memberid ='" + txtMemID.Text + "'";
                c.cmd.Parameters.Clear();
                c.cmd.Parameters.Add("@fine", SqlDbType.Int).Value = (fine - fineToDeduct);
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "select membertype, memberid, firstname, lastname, course, fine, phoneno, email,  status"
                    + " from MembersTable where memberid = '" + txtMemID.Text + "'";

                dt.Clear();

                adp.SelectCommand = c.cmd;
                adp.Fill(dt);
                dataGridView1.DataSource = dt;

                dataGridView1.Refresh();

            }

            catch (FormatException)
            {
                MessageBox.Show("Incorrect Deduction Amount!");
                return;
            }

            catch (Exception ex)
            {
                if (adminInstance != null)
                {
                    adminInstance.errObj.txtException.Text = ex.ToString();
                    adminInstance.errObj.Show();
                }
            }
            

        }

        private void SetMemID_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells[0].Value == DBNull.Value)
                {
                    return;
                }

                txtMemID.Text = (string)dt.Rows[dataGridView1.SelectedCells[0].RowIndex].ItemArray[1];
            }

            catch (FormatException) { }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            Size reSize = new Size(this.Size.Width - 50, this.Size.Height - 100);
            dataGridView1.Size = reSize;
            
            label40.Dock = DockStyle.Right;
            
            Point lblLoc = label40.Location;
            label40.Dock = DockStyle.None;
            label40.Location = new Point(lblLoc.X - 10, lblLoc.Y + 10);
        }
    }
}