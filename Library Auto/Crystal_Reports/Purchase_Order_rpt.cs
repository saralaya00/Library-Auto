using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Library_Auto.Crystal_Reports
{
    public partial class Purchase_Order_rpt : Form
    {
        public Administration_03 adminInstance;

        Connect c = new Connect();
        SqlDataAdapter adp = new SqlDataAdapter();

        public Purchase_Order_rpt()
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
                case "Order Date": selectionType = "{CreateOrderTable.orderdate}"; break;
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
                    case "Order Number":
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

        public void btnDisplayTextbased_Click(object sender, EventArgs e)
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
                case "Order Number":
                    selectionType = "{CreateOrderTable.orderno}";

                    cryRptViewer.SelectionFormula = selectionType + "=" + txtSearch.Text;
                    cryRptViewer.RefreshReport();
                    return;

                case "Accession Number": selectionType = "{CreateOrderTable.accno}"; break;
                case "Vendor ID": selectionType = "{CreateOrderTable.vendorid}"; break;

                default: Interaction.Beep(); return;
            }

            cryRptViewer.SelectionFormula
                = selectionType + " ='" + txtSearch.Text + "'";
            cryRptViewer.RefreshReport();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cryRptViewer.SelectionFormula = "1=1";
            cryRptViewer.RefreshReport();
        }
    }
}