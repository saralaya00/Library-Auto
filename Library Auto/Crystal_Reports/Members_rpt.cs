using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace Library_Auto.Crystal_Reports
{
    public partial class Members_rpt : Form
    {
        public Administration_03 adminInstance;

        Connect c = new Connect();
        SqlDataAdapter adp = new SqlDataAdapter();

        string selectionType;

        public Members_rpt()
        {
            InitializeComponent();
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

        private void Reports_Base_Load(object sender, EventArgs e)
        {
            ddlDateType.SelectedIndex = 0;
        }

        private void btnDisplayDate_Click(object sender, EventArgs e)
        {
            if (dtStart.Value > dtEnd.Value)
            {
                MessageBox.Show("'From Date' should be smaller than 'To Date'!");
                return;
            }

            string dtStartYear, dtStartMonth, dtStartDay;
            dtStartYear = dtStart.Value.Year.ToString();
            dtStartMonth = dtStart.Value.Month.ToString();
            dtStartDay = dtStart.Value.Day.ToString();

            string dtEndYear, dtEndMonth, dtEndDay;
            dtEndYear = dtEnd.Value.Year.ToString();
            dtEndMonth = dtEnd.Value.Month.ToString();
            dtEndDay = dtEnd.Value.Day.ToString();

            string selectionType;

            switch (ddlDateType.SelectedItem.ToString())
            {
                case "Subscription Date": selectionType = "{MembersTable.subsdate}"; break;
                case "Expiry Date": selectionType = "{MembersTable.expdate}"; break;

                default: Interaction.Beep(); return;
            }

            cryRptViewer.SelectionFormula =
                 selectionType + " >= DateTime (" + dtStartYear + "," + dtStartMonth + "," + dtStartDay + ") and "
                + selectionType + " <= DateTime (" + dtEndYear + "," + dtEndMonth + "," + dtEndDay + ")";
            cryRptViewer.RefreshReport();
        }

        private void DdlUpdate(string cmdText, ComboBox ddlToFill)
        {
            DataTable dtDummy = new DataTable();
            string itemToAdd = "";

            try
            {
                ddlToFill.Items.Clear();

                c.cmd.CommandText = cmdText;
                adp.SelectCommand = c.cmd;
                adp.Fill(dtDummy);

                for (int i = 0; i < dtDummy.Rows.Count; i++)
                {
                    itemToAdd = "";

                    itemToAdd += dtDummy.Rows[i].ItemArray[0];

                    if (!ddlToFill.Items.Contains(itemToAdd))
                    {
                        ddlToFill.Items.Add(itemToAdd);

                    }
                }
            }

            catch (Exception ex)
            {

                adminInstance.errObj.txtException.Text = ex.ToString();
                adminInstance.errObj.Show();
            }
        }

        private void cbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (ddlType.SelectedItem.ToString())
            {
                case "Member Type":
                    DdlUpdate("select distinct memtype from MemberParameters", ddlRpt);
                    selectionType = "{MembersTable.membertype}";
                    break;

                case "Course":
                    DdlUpdate("select distinct course from MembersTable", ddlRpt);
                    selectionType = "{MembersTable.course}";
                    break;

                case "Status":
                    DdlUpdate("select distinct status from MembersTable", ddlRpt);
                    selectionType = "{MembersTable.status}";
                    break;

                default: MessageBox.Show(""); break;
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            cryRptViewer.SelectionFormula = "1=1";
            cryRptViewer.RefreshReport();
        }

        private void btnDisplayType_Click(object sender, EventArgs e)
        {
            try
            {
                cryRptViewer.SelectionFormula = selectionType + "='" + ddlRpt.SelectedItem.ToString() + "'";
                cryRptViewer.RefreshReport();
            }

            catch (Exception)
            {
                MessageBox.Show("Select an Item!");
            }

        }

        private bool CatchFormatExceptions()
        {
            try
            {
                switch (ddlTextType.SelectedItem.ToString())
                {
                    case "Fine > [Number]":
                        Convert.ToInt16(txtSearch.Text);
                        break;

                    case "Fine < [Number]":
                        Convert.ToInt16(txtSearch.Text);
                        break;

                    default: break;
                }
            }

            catch (FormatException)
            {
                MessageBox.Show("Enter only Numeric Value!");
                return true;
            }

            return false;
        }

        private void btnDisplayTextbased_Click(object sender, EventArgs e)
        {
            string selectionType;

            if (ddlTextType.SelectedItem == null)
            {
                MessageBox.Show("Select an Item!");
                return;
            }

            bool caughtFormatException = CatchFormatExceptions();
            if (caughtFormatException) return;

            switch (ddlTextType.SelectedItem.ToString())
            {
                case "Fine > [Number]":
                    selectionType = "{MembersTable.fine}";

                    cryRptViewer.SelectionFormula = selectionType + ">" + txtSearch.Text + " and " + selectionType + "<> 0";
                    cryRptViewer.RefreshReport();
                    return;

                case "Fine < [Number]":
                    selectionType = "{MembersTable.fine}";

                    cryRptViewer.SelectionFormula = selectionType + "<" + txtSearch.Text + " and " + selectionType + "<> 0";
                    cryRptViewer.RefreshReport();
                    return;

                case "Member ID": selectionType = "{MembersTable.memberid}"; break;
                case "Firstname": selectionType = "{MembersTable.firstname}"; break;
                case "Lastname": selectionType = "{MembersTable.lastname}"; break;
                case "Email": selectionType = "{MembersTable.email}"; break;

                default: Interaction.Beep(); return;
            }

            cryRptViewer.SelectionFormula
                = selectionType + " ='" + txtSearch.Text + "'";
            cryRptViewer.RefreshReport();

        }
    }
}