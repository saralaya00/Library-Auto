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
    public partial class HolidaySetup_06c : Form
    {
        public Administration_03 adminInstance;

        Connect c = new Connect();

        SqlDataAdapter adp = new SqlDataAdapter();
        DataTable dt = new DataTable();

        public HolidaySetup_06c()
        {
            InitializeComponent();

            RefreshGrid();
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

        private void btnGotoYear_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtYear.Text != "")
                {
                    int year = Convert.ToInt16(txtYear.Text);

                    if (year > calHoliday.MaxDate.Year) year = calHoliday.MaxDate.Year;
                    if (year < calHoliday.MinDate.Year) year = calHoliday.MinDate.Year;
                    
                    DateTime dtYear = new DateTime(year, 01, 01);
                    calHoliday.SetDate(dtYear);
                }
            }

            catch (FormatException)
            {
                txtYear.Focus();
            }


        }

        private void btnSetHoliday_Click(object sender, EventArgs e)
        {
            if (c.cnn.State != ConnectionState.Open)
            {
                c.cnn.Close();
                c.cnn.Open();
            }

            DateTime selectedDate = calHoliday.SelectionStart;
            c.cmd.CommandText = "select count(*) from HolidayTable where date='" + selectedDate.ToShortDateString() + "'";

            if ((int)c.cmd.ExecuteScalar() == 0)
            {
                c.cmd.CommandText = "insert into HolidayTable values(@date, @reason)";
                c.cmd.Parameters.Clear();
                c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = selectedDate.ToShortDateString();
                c.cmd.Parameters.Add("@reason", SqlDbType.VarChar).Value = txtReason.Text;

                c.cmd.ExecuteNonQuery();

                RefreshGrid();
                Interaction.Beep();
            }
        }

        void RefreshGrid()
        {
            c.cmd.CommandText = "select * from HolidayTable";
            adp.SelectCommand = c.cmd;

            dt.Clear();
            adp.Fill(dt);

            DataView dView = new DataView(dt);
            dView.Sort = "date ASC";
            
            dgHoliday.DataSource = dView;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            c.cmd.CommandText = "delete from HolidayTable where date=@date";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = calHoliday.SelectionStart.ToShortDateString();
            c.cmd.ExecuteNonQuery();

            RefreshGrid();
        }

        private void GridToCal_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgHoliday.SelectedCells[0].Value == DBNull.Value) 
                {
                    return;
                }

                DateTime dtGrid = Convert.ToDateTime(dgHoliday.SelectedCells[0].Value);

                if (dtGrid != null)
                {
                    calHoliday.SetDate(dtGrid);
                }
            }

            catch (FormatException)
            {
                txtReason.Text = dgHoliday.SelectedCells[0].Value.ToString();
            }

        }

        private void HolidaySetup_06c_Load(object sender, EventArgs e)
        {

        }

        private void btnInsertSundays_Click(object sender, EventArgs e)
        {
            try
            {
                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                DateTime thisYear = new DateTime(DateTime.Now.Year, 01, 01);
                DateTime nextYearPlusTwo = thisYear.AddYears(1);

                while (thisYear < nextYearPlusTwo)
                {
                    if (thisYear.DayOfWeek == DayOfWeek.Sunday)
                    {
                        c.cmd.CommandText = "select count(*) from HolidayTable where date='" + thisYear + "'";
                        
                        if ((int)c.cmd.ExecuteScalar() <= 0)
                        {
                            c.cmd.CommandText = "insert into HolidayTable values (@date, @reason)";
                            c.cmd.Parameters.Clear();

                            c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = thisYear;
                            c.cmd.Parameters.Add("@reason", SqlDbType.VarChar).Value = "Sunday";
                            c.cmd.ExecuteNonQuery();
                        }
                    }
                    thisYear = thisYear.AddDays(1);
                }

                RefreshGrid();
            }
           
            
            catch (Exception ex)
            {
                adminInstance.errObj.txtException.Text = ex.ToString();
                adminInstance.errObj.Show();

                this.Close();
            }
        }

        private void btnDelPrev_Click(object sender, EventArgs e)
        {
            DateTime prevYear = new DateTime(DateTime.Now.Year - 1, 06, 01);

            DialogResult diaRes = MessageBox.Show("Current Year :" + DateTime.Now.Year
                + "\nThis will delete all the previous years results."
                + "\nThe Year " + (DateTime.Now.Year - 1) + " will have upto 6 months of details.",
                "Delete Previous Years", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (diaRes == DialogResult.Cancel)
            {
                return;
            }

            c.cmd.CommandText = "delete from HolidayTable where date <= @date";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = prevYear;
            c.cmd.ExecuteNonQuery();

            RefreshGrid();
        }
    }
}