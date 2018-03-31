using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace Library_Auto
{
    public partial class Staff_07 : Form
    {
        //Variable Declarations
        public Administration_03 adminInstance;

        Connect c = new Connect();
        SqlDataAdapter adp = new SqlDataAdapter();
        BindingSource bds = new BindingSource();
        DataTable dt = new DataTable();

        string state;

        public Staff_07()
        {
            InitializeComponent();

            panelNavigation.Enabled = false;
            grpStaffdetails.Enabled = false;
        }

        public void StaffButtonActions(string action)
        {
            switch (action)
            {
                case "View": btnView_Click(this, EventArgs.Empty); break;
                case "Add": btnAdd_Click(this, EventArgs.Empty); break;
                case "Edit": btnEdit_Click(this, EventArgs.Empty); break;
                case "Delete": btnDelete_Click(this, EventArgs.Empty); break;

                default: return;
            }
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
            adminInstance.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            EnableAllMainButtons();

            txtID.Clear();
            txtID.ReadOnly = false;
            ddlUserType.Text = "";
            txtFName.Clear();
            txtLName.Clear();
            radioFMale.Checked= false;
            radioMale.Checked= false;
            dtDOB.Value = DateTime.Today;
            txtAdd1 .Clear();
            txtAdd2.Clear();
            txtPincode.Clear();
            txtState.Clear();
            txtEmail.Clear();
            txtPhNo.Clear();
            dtDOJ.Value = DateTime.Today;
            ddlStatus.Text = "";

            grpStaffdetails.Enabled = false;
            panelNavigation.Enabled = false;

            lblError.Text = "...";
            state = "";
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            EnableAllMainButtons();
            btnClear_Click(this, EventArgs.Empty);
            grpStaffdetails.Enabled = false;
            panelNavigation.Enabled = true;

            c.cmd.CommandText = "select * from StaffTable";
            adp.SelectCommand = c.cmd;
            dt.Clear();
            adp.Fill(dt);
            bds.DataSource = dt;

            ClearDataBindings();
            AddDataBindings();

            SetRadoGender();

            state = "View";
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableAllMainButtons();

            txtID.Focus();
            panelNavigation.Enabled = false;
            btnClear_Click(this, EventArgs.Empty);

            btnView.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            dtDOB.Value = new DateTime(2000, 01, 01);
            ddlUserType.Enabled = true;

            grpStaffdetails.Enabled = true;
            state = "Add";
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableAllMainButtons();

            txtID.ReadOnly = true;
            panelNavigation.Enabled = false;
            grpStaffdetails.Enabled = true;

            if (state == "View")
            {
                txtFName.Focus();
                state = "Edit";

                if (ddlUserType.SelectedItem.ToString() == "Administrator")
                {
                    ddlUserType.Enabled = false;
                }

                else ddlUserType.Enabled = true;

                return;
            }

            else
            {
                string staffID = Interaction.InputBox("Enter the Staff ID:", "Edit Staff Details", "", -1, -1);

                if (adminInstance.staffID == staffID
                    || (adminInstance.staffID as string).ToUpper() == staffID)
                {
                    panelNavigation.Enabled = false;
                    grpStaffdetails.Enabled = false;

                    btnClear_Click(this, EventArgs.Empty);
                    MessageBox.Show("Cannot Edit self!");

                    return;
                }

                int counter;
                c.cmd.CommandText = "select count(*) from StaffTable where staffid='" + staffID + "'";

                counter = (int)c.cmd.ExecuteScalar();

                if (counter > 0)
                {
                    c.cmd.CommandText = "select * from StaffTable where staffid='" + staffID + "'";

                    adp.SelectCommand = c.cmd;
                    dt.Clear();
                    adp.Fill(dt);
                    bds.DataSource = dt;

                    ClearDataBindings();
                    AddDataBindings();
                    SetRadoGender();
                }

                else
                {
                    panelNavigation.Enabled = false;
                    grpStaffdetails.Enabled = false;
                    MessageBox.Show("Staff Member not found!");
                } 
            }

            if (ddlUserType.SelectedItem.ToString() == "Administrator")
            {
                ddlUserType.Enabled = false;
            }

            else ddlUserType.Enabled = true;

            state = "Edit";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EnableAllMainButtons();

            panelNavigation.Enabled = false;
            grpStaffdetails.Enabled = false;

            if (state == "View")
            {
                DeleteRecords(); 
                state = "Delete";
                return;
            }

            else
            {

                string staffID = Interaction.InputBox("Enter the Staff ID:", "Delete Staff Details", "", -1, -1);
                int counter;

                if (adminInstance.staffID == staffID
                    || (adminInstance.staffID as string).ToUpper() == staffID)
                {
                    panelNavigation.Enabled = false;
                    grpStaffdetails.Enabled = false;

                    btnClear_Click(this, EventArgs.Empty);
                    MessageBox.Show("Cannot Delete self!");

                    return;
                }

                c.cmd.CommandText = "select count(*) from StaffTable where staffid='" + staffID + "'";

                counter = (int)c.cmd.ExecuteScalar();

                if (counter > 0)
                {
                    c.cmd.CommandText = "select * from StaffTable where staffid='" + staffID + "'";

                    adp.SelectCommand = c.cmd;
                    dt.Clear();
                    adp.Fill(dt);
                    bds.DataSource = dt;

                    ClearDataBindings();
                    AddDataBindings();

                    DeleteRecords();
                    panelNavigation.Enabled = false;
                }

                else
                {
                    panelNavigation.Enabled = false;
                    grpStaffdetails.Enabled = false;
                    MessageBox.Show("Invalid ID!");
                }
            }

            state = "Delete";
        }

        void DeleteRecords()
        {
            DialogResult dialogRes = MessageBox.Show("Delete this record?", "Delete Staff", MessageBoxButtons.OKCancel);

            if (dialogRes == DialogResult.OK)
            {

                c.cmd.CommandText = "delete from LoginTable where staffid='" + txtID.Text + "'";
                c.cmd.ExecuteNonQuery();

                c.cmd.CommandText = "delete from StaffTable where staffid='" + txtID.Text + "'";
                c.cmd.ExecuteNonQuery();

                MessageBox.Show("Record Deleted!");
            }

            else if (dialogRes == DialogResult.Cancel)
            {
                return;
            }

        }

        //DataBindings.functions()

        void ClearDataBindings()
        {
            txtID.DataBindings.Clear();
            ddlUserType.DataBindings.Clear();
            txtFName.DataBindings.Clear();
            txtLName.DataBindings.Clear();

            txtGender.DataBindings.Clear();

            radioFMale.Checked = false;
            radioMale.Checked = false;

            dtDOB.DataBindings.Clear();
            dtDOJ.DataBindings.Clear();

            txtAdd1.DataBindings.Clear();
            txtAdd2.DataBindings.Clear();

            txtPincode.DataBindings.Clear();
            txtState.DataBindings.Clear();
            txtPhNo.DataBindings.Clear();
            txtEmail.DataBindings.Clear();

            ddlStatus.DataBindings.Clear();
        }

        void AddDataBindings()
        {
            
            txtID.DataBindings.Add("text", bds, "staffid");
            ddlUserType.DataBindings.Add("text", bds, "stafftype");
            txtFName.DataBindings.Add("text", bds, "fname");
            txtLName.DataBindings.Add("text", bds, "lname");
            
            txtGender.DataBindings.Add("text", bds, "gender");

            dtDOB.DataBindings.Add("text", bds, "dob");
            dtDOJ.DataBindings.Add("text", bds, "doj");

            txtAdd1.DataBindings.Add("text", bds, "address1");
            txtAdd2.DataBindings.Add("text", bds, "address2");

            txtPincode.DataBindings.Add("text", bds, "pin");
            txtState.DataBindings.Add("text", bds, "state");
            txtEmail.DataBindings.Add("text", bds, "email");
            txtPhNo.DataBindings.Add("text", bds, "phoneno");
            ddlStatus.DataBindings.Add("text", bds, "status");
            //Test the Dropdownlist to check if the databindings match!
        }

        void SetRadoGender()
        {
            radioFMale.Checked = (txtGender.Text.Equals("F")) ? true : false;
            radioMale.Checked = (txtGender.Text.Equals("M")) ? true : false;

            if (adminInstance.staffID == txtID.Text
                || (adminInstance.staffID as string).ToUpper() == txtID.Text)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;

            }

            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            } 
        }

        // _DataBindings.functions().end 


        private void btnFirst_Click(object sender, EventArgs e)
        {
            bds.MoveFirst();
            SetRadoGender();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bds.MoveLast();
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

        

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isInvalid;
            isInvalid = InputValidations();

            if (isInvalid)
            {
                return;
            }

            //Test Phone Number
            long pno = Convert.ToInt64(txtPhNo.Text);
            string pnoStr = "" + pno;

            if (pnoStr.Length < 10)
            {
                lblError.Text = "Invalid Phone Number!";
                txtPhNo.Focus();
                return;
            }

            switch (state)
            {
                case "Add":
                    c.cmd.CommandText = "select count(*) from StaffTable where staffid='" + txtID.Text + "'";
                    int count = (int) c.cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("A Record with the same StaffID found!");
                        txtID.Focus();
                        return;
                    }

                    c.cmd.CommandText = "insert into StaffTable values(@staffid,@stafftype,@fname,@lname,@gender,@dob,@address1,@address2,@pin,@state,@email,@phoneno,@doj,@status)";

                    break;

                case "Edit":
                    txtID.ReadOnly = false;
                    c.cmd.CommandText = "update StaffTable set stafftype=@stafftype, fname=@fname, lname=@lname, gender=@gender, dob=@dob, address1=@address1, address2=@address2, pin=@pin, state=@state, email=@email, phoneno=@phoneno, doj=@doj, status=@status where staffid=@staffid";
                    
                    break;

                default: return;
            }
            
            c.cmd.Parameters.Clear();

            c.cmd.Parameters.Add("@staffid", SqlDbType.VarChar).Value = txtID.Text;
            c.cmd.Parameters.Add("@stafftype", SqlDbType.VarChar).Value = ddlUserType.Text;
            c.cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = txtFName.Text;
            c.cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = txtLName.Text;
            c.cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = (radioFMale.Checked) ? "F" : "M";
            c.cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = dtDOB.Value.ToString();
            c.cmd.Parameters.Add("@address1", SqlDbType.VarChar).Value = txtAdd1.Text;
            c.cmd.Parameters.Add("@address2", SqlDbType.VarChar).Value = txtAdd2.Text;
            c.cmd.Parameters.Add("@pin", SqlDbType.VarChar).Value = txtPincode.Text;
            c.cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = txtState.Text;
            c.cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text;
            c.cmd.Parameters.Add("@phoneno", SqlDbType.VarChar).Value = txtPhNo.Text;
            c.cmd.Parameters.Add("@doj", SqlDbType.DateTime).Value = dtDOJ.Value;
            c.cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = ddlStatus.Text;

            c.cmd.ExecuteNonQuery();

            switch (state)
            { 
                case "Add":
                    c.cmd.CommandText = "insert into LoginTable values(@staffid, @password, @usertype, @resetpassword, @sQuestion, @sAnswer)";

                    c.cmd.Parameters.Clear();
                    c.cmd.Parameters.Add("@staffid", SqlDbType.VarChar).Value = txtID.Text;
                    c.cmd.Parameters.Add("@password", SqlDbType.VarBinary).Value = DBNull.Value;
                    c.cmd.Parameters.Add("@usertype", SqlDbType.VarChar).Value = ddlUserType.Text;
                    c.cmd.Parameters.Add("@resetpassword", SqlDbType.VarChar).Value = "Reset_Full";
                    c.cmd.Parameters.Add("@sQuestion", SqlDbType.VarBinary).Value = DBNull.Value;
                    c.cmd.Parameters.Add("@sAnswer", SqlDbType.VarBinary).Value = DBNull.Value;
                    c.cmd.ExecuteNonQuery();

                    break;
            }
            MessageBox.Show("Process Complete!");

            btnView_Click(this, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            switch (state)
            { 
                case "Add":
                    panelNavigation.Enabled = true;
                    btnClear_Click(this, EventArgs.Empty);

                    btnView.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    grpStaffdetails.Enabled = false;
                    break;

                case "View":
                    btnClear_Click(this, EventArgs.Empty);

                    panelNavigation.Enabled = false;
                    grpStaffdetails.Enabled = false;
                    break;

                case "Edit":
                    btnClear_Click(this, EventArgs.Empty);
                    break;

                default: btnClear_Click(this, EventArgs.Empty); break;
            }

        }

        void EnableAllMainButtons()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnView.Enabled = true;
            btnDelete.Enabled = true;

            btnPrev.Enabled = true;
            btnNext.Enabled = true;
            btnFirst.Enabled = true;
            btnLast.Enabled = true;

            btnClear.Enabled = true;
        }


        private void NumValidations(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                && e.KeyChar != 0)
            {
                lblError.Text = "Enter only numbers!";
                e.Handled = true;

                return;
            }

            ResetLblValidation();
        }

        private void AlphaValidations(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                lblError.Text = "Enter only Letters!";
                e.Handled = true;

                return;
            }

            ResetLblValidation();
        }

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

            ResetLblValidation();
        }

        

        private void ResetLblValidation()
        {
            lblError.Text = "...";
        }

        private bool InputValidations()
        {
            bool isRadioChecked = false;

            foreach (Control ctrl in grpStaffdetails.Controls)
            {

                if (ctrl is TextBox)
                {

                    if ((ctrl as TextBox).Name != "txtGender"
                        && (ctrl as TextBox).Text == "")
                    {
                        lblError.Text = "Empty TextBox detected!";
                        return true;
                    }
                }

                else if (ctrl is ComboBox)
                {
                    if ((ctrl as ComboBox).SelectedItem == null)
                    {
                        lblError.Text = "Unselected Item detected!";
                        return true;
                    }
                }

                else if (ctrl is DateTimePicker)
                {
                    DateTime checkDate = DateTime.Today.AddYears(-18);

                    if ((ctrl as DateTimePicker).Name == dtDOB.Name
                        && (ctrl as DateTimePicker).Value > checkDate)
                    {
                        lblError.Text = "DOB < 18 years!";
                        return true;
                    }

                    if ((ctrl as DateTimePicker).Name == dtDOJ.Name
                        && (ctrl as DateTimePicker).Value < dtDOB.Value)
                    {
                        lblError.Text = "DOJ < DOB!";
                        return true;
                    }
                }
            }

            foreach (Control ctrl in grpStaffdetails.Controls)
            {
                if (ctrl is RadioButton)
                {
                    if ((ctrl as RadioButton).Checked == true)
                    {
                        isRadioChecked = true;
                    }
                }
            }

            if (!isRadioChecked)
            {
                lblError.Text = "Select Gender!";
                return true;
            }
            
            //Set the bool isInvalid to True if the Email is Invalid.
            if (InvalidEmail()) return true;

            ResetLblValidation();
            return false;
        }

        public bool InvalidEmail()
        {
            string emailExpr = null;
            emailExpr = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (Regex.IsMatch(txtEmail.Text, emailExpr))
            {
                //Since the Email is Valid, retutn IsInvalidEmail as False.
                return false;
            }

            lblError.Text = "Invalid Email!";
            return true;
        }
    }
}