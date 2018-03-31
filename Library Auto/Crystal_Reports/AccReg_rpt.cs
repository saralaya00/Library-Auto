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
    public partial class AccReg_rpt : Form
    {
        public Administration_03 adminInstance;

        Connect c = new Connect();
        SqlDataAdapter adp = new SqlDataAdapter();


        string selectionType;

        public AccReg_rpt()
        {
            InitializeComponent();
        }

        private void Reports_Base_Load(object sender, EventArgs e)
        {
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

        private void ddlType_SelectionChangeCommitted(object sender, EventArgs e)
        {

            switch (ddlType.SelectedItem.ToString())
            {
                case "Section":
                    DdlUpdate("select distinct section from AccRegTable", ddlRpt);
                    selectionType = "{AccRegTable.section}";
                    break;

                case "Type":
                    DdlUpdate("select distinct type from AccRegTable", ddlRpt);
                    selectionType = "{AccRegTable.type}";
                    break;

                case "Language":
                    DdlUpdate("select distinct language from AccRegTable", ddlRpt);
                    selectionType = "{AccRegTable.language}";
                    break;

                case "Subject":
                    DdlUpdate("select distinct subject from AccRegTable", ddlRpt);
                    selectionType = "{AccRegTable.subject}";
                    break;

                case "Publisher":
                    DdlUpdate("select distinct publisher from AccRegTable", ddlRpt);
                    selectionType = "{AccRegTable.publisher}";
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

        private void btnDisplayTextbased_Click(object sender, EventArgs e)
        {
            string selectionType;

            //No Format Exceptions to catch in this form.

            if (ddlTextType.SelectedItem == null)
            {
                MessageBox.Show("Select an Item!");
                return;
            }

            switch (ddlTextType.SelectedItem.ToString())
            {
                case "Accno": selectionType = "{AccRegTable.accno}"; break;
                case "Title": selectionType = "{AccRegTable.title}"; break;
                case "Author": selectionType = "{AccRegTable.author}"; break;

                default: Interaction.Beep(); return;
            }

            cryRptViewer.SelectionFormula = selectionType + " ='" + txtSearch.Text + "'";
            cryRptViewer.RefreshReport();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cryRptViewer.SelectionFormula = "1=1";
            cryRptViewer.RefreshReport();
        }
    }
}