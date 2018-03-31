using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;


namespace Library_Auto
{
    public partial class MemberParameters_05b : Form
    {
        public Administration_03 adminInstance;
        
        Connect c = new Connect();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataTable dt = new DataTable();


        public MemberParameters_05b()
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

        private void btnMaster_Click(object sender, EventArgs e)
        {
            try
            {
                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                //Revalidate Everything
                bool emptyValidation = EmptyValidations();
                if (emptyValidation) return;

                try
                {
                    int finePD, issueDays;
                    finePD = Convert.ToInt32(txtFinePD.Text);
                    issueDays = Convert.ToInt32(txtMaxIssuedays.Text);

                    if (issueDays <= 1)
                    {
                        MessageBox.Show("Max Issue Days should be greater than 1");
                        txtMaxIssuedays.Focus();
                        return;
                    }
                }

                catch (FormatException)
                {
                    lblValidation.Text = "Incorrect Values!";
                    return;
                }

                c.cmd.CommandText = "select count(*) from MemberParameters where memtype='" + txtMemtype.Text + "'";
                if ((int)c.cmd.ExecuteScalar() <= 0)
                {
                    DialogResult diaRes = MessageBox.Show("Enter this Member parameter?\nMember Parameters cannot be deleted!", "Add Member Parameter",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (diaRes == DialogResult.Cancel)
                    {
                        return;
                    } 

                    c.cmd.CommandText = "insert into MemberParameters values(@memtype, @mtypeidentifier, @maxissuedays, @fineperday)";
                    c.cmd.Parameters.Clear();
                    c.cmd.Parameters.Add("@memtype", SqlDbType.VarChar).Value = txtMemtype.Text;
                    c.cmd.Parameters.Add("@mtypeidentifier", SqlDbType.VarChar).Value = txtMtypeID.Text;
                    c.cmd.Parameters.Add("@maxissuedays", SqlDbType.Int).Value = Convert.ToInt32(txtMaxIssuedays.Text);
                    c.cmd.Parameters.Add("@fineperday", SqlDbType.Int).Value = Convert.ToInt32(txtFinePD.Text);

                    c.cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Parameter Added! \nMembertype : " + txtMemtype.Text);
                }

                else MessageBox.Show("Parameter is already present! \nMembertype : " + txtMemtype.Text);
            }

            catch (SqlException)
            {
                throw;
            }

            finally
            {
                c.cnn.Close();
            }

        }

        private bool EmptyValidations()
        {
            foreach (Control ctrl in this.Controls)
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

        private void checkUnlock_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUnlock.Checked == true)
            {
                btnAdd.Enabled = true;
            }

            else if (checkUnlock.Checked == false)
            {
                btnAdd.Enabled = false;
            }
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

        //private void AlphaValidations(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) 
        //        && !char.IsLetter(e.KeyChar))
        //    {
        //        lblValidation.Text = "Enter only Letters!";
        //        e.Handled = true;

        //        return;
        //    }

        //    lblValidation.Text = "...";
        //}

        //Alpha Num Validations
        private void AlphaValidations(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) 
                && !char.IsLetterOrDigit(e.KeyChar)
                && !char.Equals(e.KeyChar, '-'))
            {
                lblValidation.Text = "Enter only Letters or Digits";
                e.Handled = true;

                return;
            }

            lblValidation.Text = "...";
        }
    }
}