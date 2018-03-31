using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using Library_Auto.Modules;
using Library_Auto.Crystal_Reports;

namespace Library_Auto
{
    public partial class Administration_03 : Form
    {
        public Error_Handler errObj = new Error_Handler();
        Login_CP_02b objCP = new Login_CP_02b();

        Connect c = new Connect();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataTable dt = new DataTable();
        BindingSource bds = new BindingSource();

        public bool isAdmin;
        public string staffID;

        public Administration_03()
        {
            InitializeComponent();
        }


        private void Administration_03_Load(object sender, EventArgs e)
        {
            SetUserDetails();

            if (!isAdmin)
            {
                staffToolStripMenuItem1.Enabled = false;
                staffToolStripMenuItem1.Visible = false;

                purchaseToolStripMenuItem1.Enabled = false;
                purchaseToolStripMenuItem1.Visible = false;

                parametersToolStripMenuItem1.Enabled = false;
            }
        }

        void SetUserDetails()
        {
            //For testing purpose

            try
            {
                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                c.cmd.CommandText = "select * from StaffTable where staffid='" + staffID + "'";
                adp.SelectCommand = c.cmd;
                adp.Fill(dt);

                lblID.Text += "" + dt.Rows[0].ItemArray[0];
                lblName.Text += "" + dt.Rows[0].ItemArray[2] + " " + dt.Rows[0].ItemArray[3];
                lblDesg.Text += "" + dt.Rows[0].ItemArray[1];

                txtAdd.Text = "" + dt.Rows[0].ItemArray[6];
                lblEmail.Text += "" + dt.Rows[0].ItemArray[10];
                lblPhno.Text += "" + dt.Rows[0].ItemArray[11];

                DateTime dtDOJ = Convert.ToDateTime(dt.Rows[0].ItemArray[12]);
                lblDOJ.Text += "" + dtDOJ.ToShortDateString();
                lblStatus.Text += "" + dt.Rows[0].ItemArray[13];

                if ((string)dt.Rows[0].ItemArray[13] != "Active")
                {
                    menuStrip1.Enabled = false;
                    lblStatus.ForeColor = Color.Red;
                }

                if ((string)dt.Rows[0].ItemArray[1] == "Administrator")
                {
                    isAdmin = true;
                }

                else isAdmin = false;

                grpUserInfo.Focus();
            }

            catch (IndexOutOfRangeException)
            {

            }
        }


        //Circulation Actions
        private void CreateCirculationObject()
        {
            Circulation_06 objCirc = new Circulation_06();
            objCirc.adminInstance = this;
            this.Hide();

            objCirc.Show();
        }

        private void issueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateCirculationObject();
        }

        private void reportsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateCirculation_rpt();
        }

        private void fineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fine_06b objFine = new Fine_06b();
            this.Hide();

            objFine.adminInstance = this;
            objFine.Show();
        }


        //Accession Register Actions
        private void CreateAccRegObject(string action)
        {
            AccessionRegister_04 objAccReg = new AccessionRegister_04();

            this.Hide();
            objAccReg.adminInstance = this;

            objAccReg.Show();
            objAccReg.AccRegButtonActions(action);

        }

        private void viewCatalogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateAccRegObject("View");
        }

        private void addCatalogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateAccRegObject("Add");
        }

        private void editCatalogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateAccRegObject("Edit");
        }

        private void deleteCatalogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateAccRegObject("Delete");
        }

        private void searchBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAccRegObject("Search");
        }

        private void oPACToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search_01 objSearch = new Search_01();
            this.Hide();

            objSearch.adminInstance = this;
            objSearch.Show();
        }


        //Staff Actions     
        public void CreateStaffObjects(string action)
        {
            Staff_07 objStaff = new Staff_07();
            objStaff.adminInstance = this;
            this.Hide();

            objStaff.Show();
            objStaff.StaffButtonActions(action);
        }

        private void viewStaffToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateStaffObjects("View");
        }

        private void addStaffToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateStaffObjects("Add");
        }

        private void editStaffToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateStaffObjects("Edit");
        }

        private void deleteStaffToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateStaffObjects("Delete");
        }



        //Member Actions
        public void CreateMembersObject(string action)
        {
            Members_05 objMembers = new Members_05();
            objMembers.adminInstance = this;
            this.Hide();

            objMembers.Show();
            objMembers.MembersButtonActions(action);
        }

        private void viewMemberToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateMembersObject("View");
        }

        private void addMemberToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateMembersObject("Add");
        }

        private void editMemberToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateMembersObject("Edit");
        }

        private void deleteMemberToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateMembersObject("Delete");
        }

        private void searchMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMembersObject("Search");
        }

        private void parametersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MemberParameters_05b objMemP = new MemberParameters_05b();
            objMemP.adminInstance = this;

            this.Hide();
            objMemP.Show();
        }


        //Stock Button Actions
        public void CreateStockObjects()
        {
            Stock_08 objStock = new Stock_08();
            objStock.adminInstance = this;
            this.Hide();

            objStock.Show();
        }

        private void viewStocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateStockObjects();
        }

        private void editStocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAccRegObject("Edit");    
        }

        //Reports Button Clicks
        void CreateReportObjects(string reName)
        {
            Report_09 objReport = new Report_09();
            objReport.adminInstance = this;

            this.Hide();
            objReport.Show();
            objReport.ShowReport(reName); 

        }

        private void CreateCirculation_rpt()
        {
            Circulation_rpt objCircRpt = new Circulation_rpt();
            objCircRpt.adminInstance = this;
            this.Hide();
            objCircRpt.Show();
        }

        private void CreateMembers_rpt()
        {
            Members_rpt objMembersRpt = new Members_rpt();
            objMembersRpt.adminInstance = this;
            this.Hide();
            objMembersRpt.Show();
        }

        private void CreateStock_rpt()
        {
            Stock_rpt objStock_rpt = new Stock_rpt();
            objStock_rpt.adminInstance = this;
            this.Hide();
            objStock_rpt.Show();
        }

        private void circulationReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateCirculation_rpt();
        }

        private void stockReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateStock_rpt();
        }

        private void membersReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMembers_rpt();
        }

        private void purchaseOrderReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Purchase_Order_rpt objPurOrd = new Purchase_Order_rpt();
            objPurOrd.adminInstance = this;
            this.Hide();
            objPurOrd.Show();
        }

        private void purchaseBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create_Bill_rpt objCreateBill = new Create_Bill_rpt();
            objCreateBill.adminInstance = this;
            this.Hide();
            objCreateBill.Show();
        }

        private void defaultersReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Fine_rpt objFine = new Fine_rpt();
            objFine.adminInstance = this;
            this.Hide();
            objFine.Show();
        }

        private void bookReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccReg_rpt objAccreg = new AccReg_rpt();
            objAccreg.adminInstance = this;
            this.Hide();
            objAccreg.Show();
        }


        //Holiday Objects
        private void holdiaysSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HolidaySetup_06c objHoliday = new HolidaySetup_06c();
            objHoliday.adminInstance = this;

            this.Hide();
            objHoliday.Show();
        }


        //Vendors Object
        void CreateVendorsObject()
        {
            Vendor_10b objVendor = new Vendor_10b();
            objVendor.adminInstance = this;

            this.Hide();
            objVendor.Show();
        }


        private void viewVendorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateVendorsObject();
        }

        private void addVendorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Vendor_10b objVendor = new Vendor_10b();
            objVendor.adminInstance = this;

            this.Hide();
            objVendor.Show();
            objVendor.btnAdd_Click(this, EventArgs.Empty);
        }

        private void editVendorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateVendorsObject();
        }

        private void deleteVendorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateVendorsObject();
        }

        //Create Orders
        public void createOrderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateOrder_10c objCreateOrder = new CreateOrder_10c();
            objCreateOrder.adminInstance = this;

            this.Hide();
            objCreateOrder.Show();
        }

        public void generateBillToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GenerateBill_10d objGenBill = new GenerateBill_10d();
            objGenBill.adminInstance = this;

            this.Hide();
            objGenBill.Show();
        }

        //Password
        private void ChangePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objCP = new Login_CP_02b();
            objCP.txtUsername.Text = staffID;
            objCP.state = "Reset_Full";

            objCP.Closed += new EventHandler(objCP_Closed);
            objCP.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objCP = new Login_CP_02b();
            objCP.txtUsername.Text = staffID;
            objCP.state = "Reset_Password";

            objCP.Closed += new EventHandler(objCP_Closed);
            objCP.Show();
        }

        void objCP_Closed(object sender, EventArgs e)
        {
            if (objCP.saveClicked == true)
            {
                Application.Restart();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string msgString = " Library Auto v1.0(2017) BCA Final Sem Project";

            MessageBox.Show(msgString, "Library Auto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        //End Times
    }
}