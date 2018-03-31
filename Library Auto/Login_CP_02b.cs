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
    public partial class Login_CP_02b : Form
    {
        Connect c = new Connect();
        SqlDataAdapter adp = new SqlDataAdapter();
        public string state;
        public bool saveClicked = false;

        public Login_CP_02b()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if ((txtpword.Text as string).Length <= 5)
            {
                txtpword.Clear();
                txtConfirmPW.Clear();

                MessageBox.Show("Password should be 6 Characters or more!");
                txtpword.Focus();
                return;
            }

            if (txtpword.Text != txtConfirmPW.Text)
            {
                txtpword.Clear();
                txtConfirmPW.Clear();

                lblError.Text = "Password doesn't match!";
                txtpword.Focus();
                return;
            }

            switch (state)
            { 
                case "Reset_Password":
                    c.cmd.CommandText = "select count(*) from LoginTable where staffid ='" + txtUsername.Text +"' and sAnswer=@sAnswer";
                    c.cmd.Parameters.Clear();
                    c.cmd.Parameters.Add("@sAnswer", SqlDbType.VarBinary).Value = ConvertToByteArray(txtSAnswer.Text);

                    if ((int)c.cmd.ExecuteScalar() <= 0)
                    {
                        MessageBox.Show("Wrong Security Answer!");
                    }

                    else
                    {
                        c.cmd.CommandText = "update LoginTable set password=@password, resetpassword=@resetpassword where staffid=@staffid";
                        c.cmd.Parameters.Clear();
                        c.cmd.Parameters.Add("@staffid", SqlDbType.VarChar).Value = txtUsername.Text;
                        c.cmd.Parameters.Add("@password", SqlDbType.VarBinary).Value = ConvertToByteArray(txtpword.Text);
                        c.cmd.Parameters.Add("@resetpassword", SqlDbType.VarChar).Value = "Not_Required";
                        c.cmd.ExecuteNonQuery();

                        MessageBox.Show("Password Changed!");
                        saveClicked = true;
                        this.Close();
                    }

                    break;

                case "Reset_Full":
                    c.cmd.CommandText = "update LoginTable set password=@password, resetpassword=@resetpassword, sQuestion=@sQuestion, sAnswer=@sAnswer where staffid=@staffid";
                    c.cmd.Parameters.Clear();
                    c.cmd.Parameters.Add("@staffid", SqlDbType.VarChar).Value = txtUsername.Text;
                    c.cmd.Parameters.Add("@password", SqlDbType.VarBinary).Value = ConvertToByteArray(txtpword.Text);
                    c.cmd.Parameters.Add("@resetpassword", SqlDbType.VarChar).Value = "Not_Required";
                    c.cmd.Parameters.Add("@sQuestion", SqlDbType.VarBinary).Value = ConvertToByteArray(txtSQuestion.Text);
                    c.cmd.Parameters.Add("@sAnswer", SqlDbType.VarBinary).Value = ConvertToByteArray(txtSAnswer.Text);
                    c.cmd.ExecuteNonQuery();

                    MessageBox.Show("User details Reset!");
                    saveClicked = true;
                    this.Close();
                    break;
            }
        }

        private static byte[] ConvertToByteArray(string str)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetBytes(str);
        }

        private static string ConvertToASCIIString(byte[] byteArray)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetString(byteArray);
        }

        private void Login_CP_02b_Load(object sender, EventArgs e)
        {
            if (state == "Reset_Password")
            {
                ResetPasswordPrompt();
            }
        }

        private void ResetPasswordPrompt()
        {
            c.cmd.CommandText = "select sQuestion from LoginTable where staffid ='" + txtUsername.Text + "'";

            lblSecQuestion.Visible = false;
            txtSQuestion.BackColor = this.BackColor;
            txtSQuestion.BorderStyle = BorderStyle.None;
            txtSQuestion.TextAlign = HorizontalAlignment.Center;
            txtUsername.ReadOnly = true;

            string sQuestionString = ConvertToASCIIString((byte[]) c.cmd.ExecuteScalar());

            sQuestionString += (sQuestionString[sQuestionString.Length - 1].Equals('?')) ? "" : "?";
            txtSQuestion.Text = "" + sQuestionString;
            txtSQuestion.ReadOnly = true;
        }
    }
}