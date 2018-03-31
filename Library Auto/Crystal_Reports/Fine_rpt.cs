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
    public partial class Fine_rpt : Form
    {
        public Administration_03 adminInstance;

        Connect c = new Connect();
        SqlDataAdapter adp = new SqlDataAdapter();

        public Fine_rpt()
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
        }

        private void btnDisplayType_Click(object sender, EventArgs e)
        {

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
                default: Interaction.Beep(); return;
            }

            cryRptViewer.SelectionFormula
                = selectionType + " ='" + txtSearch.Text + "'";
            cryRptViewer.RefreshReport();

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

        private void btnReset_Click(object sender, EventArgs e)
        {
            cryRptViewer.SelectionFormula = "1=1 and {MembersTable.fine} <> 0";
            cryRptViewer.RefreshReport();
        }

        private void cryRptViewer_Load(object sender, EventArgs e)
        {
            cryRptViewer.SelectionFormula = "1=1 and {MembersTable.fine} <> 0";
            cryRptViewer.RefreshReport();
        }
    }
}