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
    public partial class Stock_rpt : Form
    {
        public Administration_03 adminInstance;

        Connect c = new Connect();
        SqlDataAdapter adp = new SqlDataAdapter();

        string selectionType;

        public Stock_rpt()
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

        private void Stock_rpt_Load(object sender, EventArgs e)
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
                case "Bill Date": selectionType = "{StockTable.billdate}"; break;
                
                default: Interaction.Beep(); return;
            }

            cryRptViewer.SelectionFormula =
                 selectionType + " >= DateTime (" + dtStartYear + "," + dtStartMonth + "," + dtStartDay + ") and "
                + selectionType + " <= DateTime (" + dtEndYear + "," + dtEndMonth + "," + dtEndDay + ")";
            cryRptViewer.RefreshReport();
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

        private void ddlType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (ddlType.SelectedItem.ToString())
            {
                case "Vendor":
                    DdlUpdate("select distinct vendor from StockTable", ddlRpt);
                    selectionType = "{StockTable.vendor}";
                    break;

                    case "Status":
                    DdlUpdate("select distinct status from StockTable", ddlRpt);
                    selectionType = "{StockTable.status}";
                    break;

                    case "Binding":
                    DdlUpdate("select distinct binding from StockTable", ddlRpt);
                    selectionType = "{StockTable.binding}";
                    break;

                default: Interaction.Beep(); break;
            }
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

        private void btnDisplayTextbased_Click(object sender, EventArgs e)
        {
            string selectionType;

            if (ddlTextType.SelectedItem == null)
            {
                MessageBox.Show("Select an Item!");
                return;
            }

            switch (ddlTextType.SelectedItem.ToString())
            {
                case "Accno": selectionType = "{StockTable.accno}"; break;
                case "Title": selectionType = "{AccRegTable.title}"; break;
                case "Author": selectionType = "{AccRegTable.author}"; break;
                case "Billno": selectionType = "{StockTable.billno}"; break;
                case "Year": selectionType = "{StockTable.copyyear}"; break;

                default: Interaction.Beep(); return;
            }

            cryRptViewer.SelectionFormula = selectionType + " ='" + txtSearch.Text + "'";
            cryRptViewer.RefreshReport();

        }
    }
}