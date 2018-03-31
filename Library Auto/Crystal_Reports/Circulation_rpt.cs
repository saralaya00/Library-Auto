using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using Microsoft.VisualBasic;

namespace Library_Auto.Crystal_Reports
{
    public partial class Circulation_rpt : Form
    {
        public Administration_03 adminInstance;

        public Circulation_rpt()
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
            ddlTextType.SelectedIndex = 0;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
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
                case "Issue-Date": selectionType = "{IssueTable.issuedate}"; break;
                case "Renew-Date": selectionType = "{IssueTable.renewdate}"; break;
                case "Return-Date": selectionType = "{IssueTable.returndate}"; break;
                case "Due-Date": selectionType = "{IssueTable.duedate}"; break;
                default: Interaction.Beep(); return;
            }

            cryRptViewer.SelectionFormula = 
                 selectionType + " >= DateTime (" + dtStartYear + "," + dtStartMonth + "," + dtStartDay + ") and " 
                + selectionType + " <= DateTime (" + dtEndYear + "," + dtEndMonth + "," + dtEndDay + ")";
            cryRptViewer.RefreshReport();
        }

        private bool CatchFormatExceptions()
        {
            try
            {
                switch (ddlTextType.SelectedItem.ToString())
                { 
                    case "Issue ID":
                    case "Fine > [Number]":
                    case "Fine < [Number]":
                        Convert.ToInt32(txtSearch.Text);
                        break;

                    default: break;
                }
            }

            catch (FormatException)
            {
                MessageBox.Show("Enter only Number!");
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
                case "Issue ID": 
                    selectionType = "{IssueTable.issueid}";
                    
                    cryRptViewer.SelectionFormula = selectionType + "=" + txtSearch.Text;
                    cryRptViewer.RefreshReport();
                    return;

                case "Fine > [Number]":
                    selectionType = "{IssueTable.fine}";

                    cryRptViewer.SelectionFormula = selectionType + ">" + txtSearch.Text + " and " + selectionType + " <> 0";
                    cryRptViewer.RefreshReport();
                    return;

                case "Fine < [Number]":
                    selectionType = "{IssueTable.fine}";

                    cryRptViewer.SelectionFormula = selectionType + "<" + txtSearch.Text + " and " + selectionType + " <> 0";
                    cryRptViewer.RefreshReport();
                    return;

                case "Member ID": selectionType = "{IssueTable.memberid}"; break;
                case "Accession No": selectionType = "{IssueTable.accno}"; break;
                case "Status = Issued": selectionType = "{IssueTable.status}"; break;
                case "Status = Returned": selectionType = "{IssueTable.status}"; break;

                default: Interaction.Beep(); return;
            }

            cryRptViewer.SelectionFormula = selectionType + " ='" + txtSearch.Text + "'";
            cryRptViewer.RefreshReport();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cryRptViewer.SelectionFormula = "1=1";
            cryRptViewer.RefreshReport();
        }

        private void ddlTextType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ddlTextType.SelectedItem.Equals("Status = Issued"))
            {
                txtSearch.Text = "Issued";
            }

            if (ddlTextType.SelectedItem.Equals("Status = Returned"))
            {
                txtSearch.Text = "Returned";
            }
        }
    }
}