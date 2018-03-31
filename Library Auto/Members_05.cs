using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Library_Auto
{
    public partial class Members_05 : Form
    {
        public Administration_03 adminInstance;

        private Connect c = new Connect();
        private SqlDataAdapter adp = new SqlDataAdapter();
        private DataTable dt = new DataTable();
        private BindingSource bds = new BindingSource();

        string state, searchHandler;

        //Circulation to MemberDetails
        public bool sentByCirculation;
        public string memIDCirc;

        public Members_05()
        {
            InitializeComponent();
        }

        public void MembersButtonActions(string actionText)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            switch (actionText)
            {
                case "Add": btnAdd_Click(this, null); break;
                case "View": btnView_Click(this, null); break;
                case "Edit": btnEdit_Click(this, null); break;
                case "Delete": btnDelete_Click(this, null); break;
                case "Search": btnSearch_Click(this, null); break;
                default: return;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            base.OnFormClosing(e);

            switch (e.CloseReason)
            { 
                case CloseReason.TaskManagerClosing:
                case CloseReason.WindowsShutDown:
                    return;

                default: break;
            }

            if (!sentByCirculation && adminInstance != null)
            {
                adminInstance.Show();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            dt.Clear();

            switch (state)
            { 
                case "View":
                    state = "";
                    lblCurrOps.Text = "Current Operation: " + state;
                    break;

                case "Edit":

                    state = "";
                    lblCurrOps.Text = "Current Operation: " + state;

                    grpMemInfo.Enabled = false;
                    grpSubsInfo.Enabled = false;
                    break;

                case "Add":
                    state = "Add";
                    lblCurrOps.Text = "Current Operation: " + state;
                    break;

                case "Delete":
                    state = "";
                    lblCurrOps.Text = "Current Operation: " + state;
                    break;

            }

            SetControlsToDefault(grpMemInfo);
            SetControlsToDefault(grpSubsInfo);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            try
            {


                grpMemInfo.Enabled = true;
                grpSubsInfo.Enabled = true;

                txtMemID.ReadOnly = false;
                ddlMemberType.Enabled = true;
                grpNav.Enabled = false;

                btnClear_Click(this, EventArgs.Empty);

                dtDOB.Value = new DateTime(2000, 01, 01);
                dtExp.Value = DateTime.Today.AddYears(1);

                state = "Add";
                lblCurrOps.Text = "Current Operation: " + state;

                txtFine.Text = "0";
                btnSubmit.Enabled = true;
            }

            catch (Exception ex)
            {
                adminInstance.errObj.txtException.Text = ex.ToString();
                adminInstance.errObj.Show();

                this.Close();
            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            try
            {
                grpMemInfo.Enabled = false;
                grpSubsInfo.Enabled = false;
                btnSubmit.Enabled = false;

                state = "View";
                lblCurrOps.Text = "Current Operation: " + state;
                grpNav.Enabled = true;

                c.cmd.CommandText = "select * from MembersTable";
                adp.SelectCommand = c.cmd;

                dt.Clear();
                adp.Fill(dt);

                bds.DataSource = dt;
                bds.Sort = "memberid ASC";

                ClearMembersDataBindings();
                AddMembersDataBindings();
            }

            catch (Exception ex)
            {
                adminInstance.errObj.txtException.Text = ex.ToString();
                adminInstance.errObj.Show();

                this.Close();

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string memberid;

            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            try
            {
                if (c.cnn.State != ConnectionState.Open)
                {
                    c.cnn.Close();
                    c.cnn.Open();
                }

                btnClear_Click(this, EventArgs.Empty);

                if (sentByCirculation)
                {
                    memberid = memIDCirc;
                }

                else memberid = Interaction.InputBox("Enter the Member ID:", "Search using Member ID", "", -1, -1);
                

                c.cmd.CommandText = "select count(*) from MembersTable where memberid ='" + memberid + "'";

                if ((int)c.cmd.ExecuteScalar() <= 0)
                {
                    MessageBox.Show("Record not found!", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    grpMemInfo.Enabled = false;
                    grpSubsInfo.Enabled = false;

                    searchHandler = "Not Found";
                    return;
                }

                state = "View";
                lblCurrOps.Text = "Current Operation: " + "Search";

                grpSubsInfo.Enabled = false;
                grpMemInfo.Enabled = false;
                grpNav.Enabled = false;

                c.cmd.CommandText = "select * from MembersTable where memberid ='" + memberid + "'";

                adp.SelectCommand = c.cmd;
                dt.Clear();
                adp.Fill(dt);
                bds.DataSource = dt;

                ClearMembersDataBindings();
                AddMembersDataBindings();

                if (sentByCirculation)
                {
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is Button) { (ctrl as Button).Enabled = false; }
                    }
                }

                
            }

            catch (SqlException)
            {
                this.Close();
            }

            finally
            {
                c.cnn.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            searchHandler = "";

            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            if (state != "View")
            {
                btnSearch_Click(this, EventArgs.Empty);

                if (searchHandler == "Not Found")
                {
                    return;
                } 
            }

            txtMemID.ReadOnly = true;
            ddlMemberType.Enabled = false;

            grpMemInfo.Enabled = true;
            grpSubsInfo.Enabled = true;

            grpNav.Enabled = false;
            btnSubmit.Enabled = true;


            state = "Edit";
            lblCurrOps.Text = "Current Operation: " + state;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            try
            {
                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                if (state == "View")
                {
                    if (ddlStatus.Text == "With Issue")
                    {
                        MessageBox.Show("Cannot delete a Member with an Issue!");
                        return;
                    }

                    DialogResult dRes = MessageBox.Show("Delete this record? Member ID = " + txtMemID.Text, "Delete Records", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dRes == DialogResult.Cancel)
                    {
                        Interaction.Beep();
                        return;
                    }

                    else if (dRes == DialogResult.OK)
                    {
                        c.cmd.CommandText = "delete from MembersTable where memberid ='" + txtMemID.Text + "'";
                        c.cmd.ExecuteNonQuery();

                        MessageBox.Show("Record deleted!", "Delete Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        UpdateStats();

                        state = "";
                    }
                }

                else
                {
                    state = "View";
                    lblCurrOps.Text = "Current Operation: " + "Delete";

                    grpSubsInfo.Enabled = false;
                    grpMemInfo.Enabled = false;
                    grpNav.Enabled = false;

                    
                    string memberid = Interaction.InputBox("Enter the Member ID:", "Delete using Member ID", "", -1, -1);

                    c.cmd.CommandText = "select count(*) from MembersTable where memberid ='" + memberid + "'";

                    if ((int)c.cmd.ExecuteScalar() <= 0)
                    {
                        MessageBox.Show("Record not found!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    c.cmd.CommandText = "select * from MembersTable where memberid ='" + memberid + "'";

                    adp.SelectCommand = c.cmd;
                    adp.Fill(dt);
                    bds.DataSource = dt;

                    ClearMembersDataBindings();
                    AddMembersDataBindings();

                    //Do not delete members with Issue
                    if (ddlStatus.Text == "With Issue")
                    {
                        MessageBox.Show("Cannot delete a Member with an Issue!");
                        return;
                    }

                    c.cmd.CommandText = "delete from MembersTable where memberid ='" + memberid + "'";
                    c.cmd.ExecuteNonQuery();
                    
                    MessageBox.Show("Record deleted!", "Delete Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                    UpdateStats();
                    state = "";
                }

            }

            catch (SqlException)
            {
                this.Close();
            }

            finally
            {
                c.cnn.Close();
            }
        }

        void ClearMembersDataBindings()
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            foreach (Control ctrl in grpMemInfo.Controls)
            {
                ctrl.DataBindings.Clear();
            }

            foreach (Control ctrl in grpSubsInfo.Controls)
            {
                ctrl.DataBindings.Clear();
            }
        }
        
        void AddMembersDataBindings()
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            try
            {
                ddlMemberType.DataBindings.Add("text", bds, "membertype");
                txtMemID.DataBindings.Add("text", bds, "memberid");
                ddlStatus.DataBindings.Add("text", bds, "status");
                txtFName.DataBindings.Add("text", bds, "firstname");
                txtLName.DataBindings.Add("text", bds, "lastname");

                lblGender.DataBindings.Add("text", bds, "gender");
                SetRadoGender();

                dtDOB.DataBindings.Add("text", bds, "dob");
                txtCourse.DataBindings.Add("text", bds, "course");
                txtBranch.DataBindings.Add("text", bds, "branch");
                txtDept.DataBindings.Add("text", bds, "dept");

                dtSubsciption.DataBindings.Add("text", bds, "subsdate");
                dtExp.DataBindings.Add("text", bds, "expdate");
                txtFatherName.DataBindings.Add("text", bds, "fathername");
                txtOcupation.DataBindings.Add("text", bds, "occupation");

                txtPhNo.DataBindings.Add("text", bds, "phoneno");
                txtEmail.DataBindings.Add("text", bds, "email");
                txtAd1.DataBindings.Add("text", bds, "address1");
                txtAd2.DataBindings.Add("text", bds, "address2");
                txtPin.DataBindings.Add("text", bds, "pincode");
                txtState.DataBindings.Add("text", bds, "state");
                txtFine.DataBindings.Add("text", bds, "fine");
            }

            catch (SqlException)
            {
                throw;
            }

        }

        void SetRadoGender()
        {
            radioFem.Checked = (lblGender.Text == "F") ? true : false;
            radioMale.Checked = (lblGender.Text == "M") ? true : false;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bds.MoveFirst();
            SetRadoGender();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            bds.MovePrevious();
            SetRadoGender();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bds.MoveNext();
            SetRadoGender();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bds.MoveLast();
            SetRadoGender();
        }

        public void SetControlsToDefault(GroupBox dummy)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            foreach (Control ctrl in dummy.Controls)
            {
                if (ctrl is TextBox)
                {
                    if ((ctrl as TextBox).Name == txtMemID.Name && state == "Edit")
                    {

                    }

                    else
                    {
                        (ctrl as TextBox).Clear();
                        (ctrl as TextBox).Enabled = true;
                    }
                }

                if (ctrl is ComboBox)
                {
                    if ((ctrl as ComboBox).Name == ddlMemberType.Name && state == "Edit")
                    {
                        
                    }

                    else
                    {
                        (ctrl as ComboBox).SelectedItem = null;
                        (ctrl as ComboBox).Text = "";
                    }
                }

                if (ctrl is DateTimePicker)
                    (ctrl as DateTimePicker).Value = DateTime.Today;

                if (ctrl is RadioButton)
                    (ctrl as RadioButton).Checked = false;
            }
        }

        void MemTypeLibraryStaffControls()
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            string staffID = Interaction.InputBox("Enter Staff ID:", "Load Staff Info from Server", "", -1, -1);

            if (staffID == "") return;

            c.cmd.CommandText = "select * from StaffTable where staffid='" + staffID + "'";
            adp.SelectCommand = c.cmd;
            dt.Clear();
            adp.Fill(dt);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            bool isInvalid= false;
            string process = state;
            bool isEmailInvalid = false;

            isEmailInvalid = InvalidEmail();
            isInvalid = EmptyValidations();

            if (isInvalid || isEmailInvalid)
            {
                return;
            }

            else lblError.Text = "...";

            //Test Phone Number
            long pno = Convert.ToInt64(txtPhNo.Text);
            string pnoStr = "" + pno;

            if (pnoStr.Length < 10)
            {
                lblError.Text = "Invalid Phone Number!";
                txtPhNo.Focus();
                return;
            }

            //Check for SubsDate > ExpDate
            if (dtSubsciption.Value > dtExp.Value)
            {
                MessageBox.Show("Subscription date cannot be greater than Expiry date!");
                return;
            }

            if (dtExp.Value < DateTime.Today)
            {
                MessageBox.Show("Expiry date must be greater than Today's date");
                return;
            }

            try
            {
                if (c.cnn.State != ConnectionState.Open)
                {
                    c.cnn.Close();
                    c.cnn.Open();
                }

                switch (state)
                {
                    case "Add":

                        c.cmd.CommandText = "select count(*) from MembersTable where memberid ='" + txtMemID.Text + "'";

                        if ((int)c.cmd.ExecuteScalar() > 0)
                        {
                            Interaction.Beep();
                            MessageBox.Show("Member with same Member ID found!", "Add Member");
                            txtMemID.Focus();
                            return;
                        }


                        c.cmd.CommandText = "insert into MembersTable values (@membertype, @memberid, @firstname, @lastname,";
                        c.cmd.CommandText += " @course, @branch, @dept, @dob, @gender, @status, @subsdate, @expdate, @fathername,";
                        c.cmd.CommandText += " @occupation, @phoneno, @email, @address1, @address2, @pincode, @state, @fine)";

                        break;

                    case "Edit":

                        c.cmd.CommandText = "update MembersTable set firstname=@firstname, lastname=@lastname, course=@course, branch=@branch, dept=@dept,";
                        c.cmd.CommandText += " dob=@dob, gender=@gender, status=@status, subsdate=@subsdate, expdate=@expdate,";
                        c.cmd.CommandText += " fathername=@fathername, occupation=@occupation, phoneno=@phoneno, email=@email,";
                        c.cmd.CommandText += " address1=@address1, address2=@address2, pincode=@pincode, state=@state";
                        c.cmd.CommandText += " where membertype=@membertype and memberid=@memberid";

                        txtMemID.ReadOnly = false;
                        ddlMemberType.Enabled = true;

                        break;

                    default: return;
                }

                c.cmd.Parameters.Clear();

                c.cmd.Parameters.Add("@membertype", SqlDbType.VarChar).Value = ddlMemberType.Text;
                c.cmd.Parameters.Add("@memberid", SqlDbType.VarChar).Value = txtMemID.Text;
                c.cmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = txtFName.Text;
                c.cmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = txtLName.Text;
                c.cmd.Parameters.Add("@course", SqlDbType.VarChar).Value = txtCourse.Text;
                c.cmd.Parameters.Add("@branch", SqlDbType.VarChar).Value = txtBranch.Text;
                c.cmd.Parameters.Add("@dept", SqlDbType.VarChar).Value = txtDept.Text;
                c.cmd.Parameters.Add("@dob", SqlDbType.VarChar).Value = dtDOB.Value.ToString();

                string genderStr = (radioMale.Checked == true) ? "M" : "F";
                c.cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = genderStr;

                c.cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = ddlStatus.Text;
                c.cmd.Parameters.Add("@subsdate", SqlDbType.DateTime).Value = dtSubsciption.Value.ToString();
                c.cmd.Parameters.Add("@expdate", SqlDbType.DateTime).Value = dtExp.Value.ToString();

                c.cmd.Parameters.Add("@fathername", SqlDbType.VarChar).Value = txtFatherName.Text;
                c.cmd.Parameters.Add("@occupation", SqlDbType.VarChar).Value = txtOcupation.Text;
                c.cmd.Parameters.Add("@phoneno", SqlDbType.VarChar).Value = txtPhNo.Text;
                c.cmd.Parameters.Add("email", SqlDbType.VarChar).Value = txtEmail.Text;
                c.cmd.Parameters.Add("address1", SqlDbType.VarChar).Value = txtAd1.Text;
                c.cmd.Parameters.Add("address2", SqlDbType.VarChar).Value = txtAd2.Text;
                c.cmd.Parameters.Add("pincode", SqlDbType.VarChar).Value = txtPin.Text;
                c.cmd.Parameters.Add("state", SqlDbType.VarChar).Value = txtState.Text;
                c.cmd.Parameters.Add("fine", SqlDbType.Int).Value = Convert.ToInt32(txtFine.Text);

                c.cmd.ExecuteNonQuery();
                UpdateStats();
                MessageBox.Show(process + " Complete!", process);

                grpMemInfo.Enabled = false;
                grpSubsInfo.Enabled = false;
                btnSubmit.Enabled = false;
            }

            catch (SqlException)
            {
                this.Close();
            }

            finally
            {
                c.cnn.Close();
            }
        }

        private bool EmptyValidations()
        {
            foreach (Control ctrl in grpMemInfo.Controls)
            {
                if (ctrl is TextBox)
                {
                    if ((ctrl as TextBox).Text == "")
                    {
                        lblError.Text = "Error: Empty Textbox";
                        (ctrl as TextBox).Focus();
                        return true;
                    }

                    else lblError.Text = "...";
                }

                if (ctrl is ComboBox)
                {
                    if ((ctrl as ComboBox).SelectedItem == null)
                    {
                        lblError.Text = "Error: Unselected Item";
                        (ctrl as ComboBox).Focus();
                        return true;
                    }

                    else lblError.Text = "...";
                }
            }

            foreach (Control ctrl in grpSubsInfo.Controls)
            {
                if (ctrl is TextBox)
                {
                    if ((ctrl as TextBox).Text == "")
                    {
                        lblError.Text = "Error: Empty Textbox";
                        (ctrl as TextBox).Focus();
                        return true;
                    }

                    else lblError.Text = "...";
                }

                if (ctrl is ComboBox)
                {
                    if ((ctrl as ComboBox).SelectedItem == null)
                    {
                        lblError.Text = "Error: Unselected Item";
                        (ctrl as ComboBox).Focus();
                        return true;
                    }

                    else lblError.Text = "...";
                }
            }

            lblError.Text = "...";
            return false;
        }

        void UpdateStats()
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            try
            {
                if (c.cnn.State != ConnectionState.Open)
                {
                    c.cnn.Close();
                    c.cnn.Open();
                }

                c.cmd.CommandText = "select count(*) from MembersTable";
                lblTotalMembers.Text = "Total Member :" + (int)c.cmd.ExecuteScalar();

                c.cmd.CommandText = "select count(*) from MembersTable where status ='Active'";
                lblActiveMembers.Text = "Members Active :" + (int)c.cmd.ExecuteScalar();

                c.cmd.CommandText = "select count(*) from MembersTable where status ='Inactive'";
                lblMembersInactive.Text = "Members Inactive :" + (int)c.cmd.ExecuteScalar();

                c.cmd.CommandText = "select count(*) from MembersTable where status ='With Issue'";
                lblIssues.Text = "Members with Issues :" + (int)c.cmd.ExecuteScalar();
            }

            catch (Exception) { }
        }

        private void Members_05_Load(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            grpNav.Enabled = false;

            UpdateStats();

            DdlLoad();

            if (sentByCirculation)
            {
                btnSearch_Click(this, EventArgs.Empty);
            }
        }

        private void DdlLoad()
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

            c.cmd.CommandText = "select memtype from MemberParameters";
            DataTable memParaTable = new DataTable();
            adp.SelectCommand = c.cmd;
            adp.Fill(memParaTable);

            for (int i = 0; i < memParaTable.Rows.Count; i++)
            {
                if (!ddlMemberType.Items.Contains((string)memParaTable.Rows[i].ItemArray[0]))
                ddlMemberType.Items.Add((string)memParaTable.Rows[i].ItemArray[0]);
            } 
        }

        private void ddlMemType_SelectionChangeCommited(object sender, EventArgs e)
        {
            if (state != "View")
            {
                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                c.cmd.CommandText = "select mtypeidentifier from MemberParameters where memtype ='" + ddlMemberType.SelectedItem.ToString() + "'";
                txtMemID.Text = (string)c.cmd.ExecuteScalar();

                if (state == "Add" && ddlMemberType.SelectedItem.ToString() != "Student")
                {
                    txtCourse.Text = "-";
                    txtBranch.Text = "-";
                    txtDept.Text = "-";
                    txtFatherName.Text = "-";
                    txtOcupation.Text = "-";
                }

                else
                {
                    txtCourse.Text = "";
                    txtBranch.Text = "";
                    txtDept.Text = "";
                    txtFatherName.Text = "";
                    txtOcupation.Text = "";
                }

                if (state == "Add" && ddlMemberType.SelectedItem.ToString() == "Library Staff")
                {
                    //txtMemID.Clear();

                    string staffID = Interaction.InputBox("MemberType is set to Staff!"
                        + "\nEnter the Staff Username to automatically insert the Staff Details", "Enter StaffID", "", -1, -1);

                    c.cmd.CommandText = "select count(*) from StaffTable where staffid='" + staffID + "'";

                    if ((int)c.cmd.ExecuteScalar() <= 0)
                    {
                        MessageBox.Show("Staff Not found!");
                        btnAdd_Click(this, EventArgs.Empty);
                        return;
                    }

                    else
                    { 
                        DataTable dtStaff = new DataTable();

                        c.cmd.CommandText = "select * from StaffTable where staffid ='" + staffID + "'";
                        adp.SelectCommand = c.cmd;
                        adp.Fill(dtStaff);

                        txtMemID.Text += (string) dtStaff.Rows[0].ItemArray[0];
                        txtFName.Text = (string)dtStaff.Rows[0].ItemArray[2];
                        txtLName.Text = (string)dtStaff.Rows[0].ItemArray[3];

                        radioFem.Checked = ((string)dtStaff.Rows[0].ItemArray[4] == "F") ? true : false;
                        radioMale.Checked = ((string)dtStaff.Rows[0].ItemArray[4] == "M") ? true : false;

                        if (dtStaff.Rows[0].ItemArray[5] != DBNull.Value)
                        dtDOB.Value = Convert.ToDateTime(dtStaff.Rows[0].ItemArray[5]);

                        txtAd1.Text = (string)dtStaff.Rows[0].ItemArray[6];
                        txtAd2.Text = (string)dtStaff.Rows[0].ItemArray[7];
                        txtPin.Text = (string)dtStaff.Rows[0].ItemArray[8];
                        txtState.Text = (string)dtStaff.Rows[0].ItemArray[9];

                        txtEmail.Text = (string)dtStaff.Rows[0].ItemArray[10];
                        txtPhNo.Text = (string)dtStaff.Rows[0].ItemArray[11];

                    }
                }
            }

        }

        //Number Validations
        private void NumValidations(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                && e.KeyChar != 0)
            {
                lblError.Text = "Enter only numbers!";
                e.Handled = true;

                return;
            }

            lblError.Text = "...";
        }

        //Alphabets Validations
        private void AlphaValidations(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                lblError.Text = "Enter only Letters!";
                e.Handled = true;

                return;
            }

            lblError.Text = "...";
        }

        //Alpha Num Validations
        private void AlphaNumValidations(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar)
                && !char.IsWhiteSpace(e.KeyChar)
                && !char.Equals(e.KeyChar, '-'))
            {
                lblError.Text = "Enter only Letters or Digits";
                e.Handled = true;

                return;
            }

            lblError.Text = "...";
        }

        //Email Validations
        public bool InvalidEmail()
        {
            string emailExpr = null;
            emailExpr = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (Regex.IsMatch(txtEmail.Text, emailExpr))
            {
                //Since the Email is Valid, retutn IsInvalidEmail as False.
                lblError.Text = "...";
                return false;
            }

            lblError.Text = "Invalid Email!";
            return true;
        }

        private void dtExp_ValueChanged(object sender, EventArgs e)
        {
            lblError.Text = "...";

            if ((sender is DateTimePicker))
            {
                if ((sender as DateTimePicker).Value > DateTime.Today.AddYears(10))
                {
                    (sender as DateTimePicker).Value = DateTime.Today.AddYears(1);
                    lblError.Text = "Invalid Date!";
                }
            }
        }

    }
}