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
    public partial class Vendor_10b : Form
    {
        public Administration_03 adminInstance;

        Connect c = new Connect();
        SqlDataAdapter adp = new SqlDataAdapter();
        BindingSource bds = new BindingSource();
        DataTable dt = new DataTable();

        public Vendor_10b()
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

        private void Vendor_10b_Load(object sender, EventArgs e)
        {
            foreach (Control ctr in grpVendorDetail.Controls)
            {
                if (ctr is TextBox)
                {
                    (ctr as TextBox).ReadOnly = false;
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            grpVendorDetail.Enabled = false;
            lblValidation.Text = "...";

            foreach (Control ctr in grpVendorDetail.Controls)
            {
                if (ctr is TextBox)
                {
                    (ctr as TextBox).ReadOnly = true;

                }
            }
            dt.Clear();

            try
            {
                if (c.cnn.State != ConnectionState.Open)
                {
                    c.cnn.Close();
                    c.cnn.Open();
                }
                c.cmd.CommandText = "select * from VendorTable";

                adp.SelectCommand = c.cmd;
                adp.Fill(dt);
                bds.DataSource = dt;

                ClearDataBindings();
                AddDataBindings();
            }

            catch
            {
                throw;
            }
            finally
            {
                c.cnn.Close();
            }
            
                
        }

        private void AddDataBindings()
        {
            txtVenId.DataBindings.Add("text", bds, "vendorid");
            txtVenName.DataBindings.Add("text", bds, "name");
            txtAddress.DataBindings.Add("text", bds, "address");
            txtPhno.DataBindings.Add("text", bds, "phoneno");
            txtEmail.DataBindings.Add("text", bds, "email");
        }

        private void ClearDataBindings()
        {
            foreach (Control ctr in grpVendorDetail.Controls)
            {
                if (ctr is TextBox)
                {
                    (ctr as TextBox).DataBindings.Clear();
                }
            }
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {

            grpVendorDetail.Enabled = true;
            dt.Clear();
            foreach (Control ctr in grpVendorDetail.Controls)
            {
                if (ctr is TextBox)
                {
                    (ctr as TextBox).ReadOnly = false;

                }
            }
            foreach (Control ctr in grpVendorDetail.Controls)
            {
                if (ctr is TextBox)
                {
                    (ctr as TextBox).Clear();

                }
            }

            if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }
            c.cmd.CommandText = "select max(vendorid) from VendorTable";

            try
            {
                int vendorid = 1 + Convert.ToInt16((string)c.cmd.ExecuteScalar());
                txtVenId.Text = "" + vendorid;
            }

            catch (Exception)
            { 
            
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                bool isEmailInvalid = InvalidEmail();
                bool isInvalid = EmptyValidations();

                if (isInvalid || isEmailInvalid) return;

                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                c.cmd.CommandText = "select count(*) from VendorTable where vendorid ='" +txtVenId.Text + "'";
                if ((int)c.cmd.ExecuteScalar() > 0)
                {
                    //Interaction.Beep();
                    MessageBox.Show("Vendor with same Vendor ID found!", "Add Vendor");
                    txtVenId.Focus();
                    return;
                }

                c.cmd.CommandText = "insert into VendorTable values(@vendorid, @name, @address, @phoneno,@email)";
                c.cmd.Parameters.Clear();
                c.cmd.Parameters.Add("@vendorid", SqlDbType.VarChar).Value = txtVenId.Text;
                c.cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = txtVenName.Text;
                c.cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = txtAddress.Text;
                c.cmd.Parameters.Add("@phoneno", SqlDbType.VarChar).Value = txtPhno.Text;
                c.cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text;

                c.cmd.ExecuteNonQuery();
                MessageBox.Show("Vendor Added!");
                foreach (Control ctr in grpVendorDetail.Controls)
                {
                    if (ctr is TextBox)
                    {
                        (ctr as TextBox).ReadOnly = true;

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                if (txtVenId.Text == "")
                {
                    string vendorid =Interaction.InputBox("Enter the Vendor ID:", "Delete using Vendor Id", "", -1, -1);

                    c.cmd.CommandText = "select count(*) from VendorTable where vendorid ='" + vendorid + "'";

                    if ((int)c.cmd.ExecuteScalar() <= 0)
                    {
                        MessageBox.Show("Record not found!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        c.cmd.CommandText = "delete from VendorTable where vendorid ='" + vendorid + "'";
                        c.cmd.ExecuteNonQuery();
                        MessageBox.Show("Record deleted!", "Delete Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                else
                {
                    c.cmd.CommandText = "select count(*) from VendorTable where vendorid ='" + txtVenId.Text + "'";

                    if ((int)c.cmd.ExecuteScalar() <= 0)
                    {
                        MessageBox.Show("Record not found!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult dRes = MessageBox.Show("Delete this record? Member ID = " + txtVenId.Text, "Delete Records", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dRes == DialogResult.Cancel)
                    {
                        return;
                    }

                    else if (dRes == DialogResult.OK)
                    {
                        c.cmd.CommandText = "delete from VendorTable where vendorid ='" + txtVenId.Text + "'";
                        c.cmd.ExecuteNonQuery();

                        MessageBox.Show("Record deleted!", "Delete Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        // UpdateStats();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            grpVendorDetail.Enabled = false;
            foreach (Control ctr in grpVendorDetail.Controls) 
            {
                if (ctr is TextBox)
                {
                    (ctr as TextBox).Clear();
                    
                }
            }
            ClearDataBindings();
        }

     

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bds.MoveFirst();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            bds.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bds.MoveNext();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bds.MoveLast();
        }

        private void NumValidations(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                && e.KeyChar != 0)
            {
                lblValidation.Text = "Enter only numbers!";
                e.Handled = true;

                return;
            }

            lblValidation.Text = "...";
        }

        private void AlphaValidations(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                lblValidation.Text = "Enter only Letters!";
                e.Handled = true;

                return;
            }

            lblValidation.Text = "...";
        }

        //Alpha Num Validations
        private void AlphaNumValidations(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar)
                && !char.IsWhiteSpace(e.KeyChar)
                && !char.Equals(e.KeyChar, '-')
                && !char.Equals(e.KeyChar, ','))
            {
                lblValidation.Text = "Enter only Letters or Digits";
                e.Handled = true;

                return;
            }

            lblValidation.Text = "...";
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

            lblValidation.Text = "Invalid Email!";
            return true;
        }

        private bool EmptyValidations()
        {
            foreach (Control ctrl in grpVendorDetail.Controls)
            {
                if (ctrl is TextBox)
                {
                    if ((ctrl as TextBox).Text == "")
                    {
                        lblValidation.Text = "Error: Empty Textbox";
                        (ctrl as TextBox).Focus();
                        return true;
                    }

                    else lblValidation.Text = "...";
                }
            }

            lblValidation.Text = "...";
            return false;
        }
    }
}