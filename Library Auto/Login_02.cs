using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Reflection;
using Microsoft.VisualBasic;

namespace Library_Auto
{
    public partial class Login_02 : Form
    {
        public static Administration_03 adminMaster = new Administration_03();

        Connect c = new Connect();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataTable dt = new DataTable();

       

        public Login_02()
        {
            InitializeComponent();
        }

        private void Login_02_Load(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            adminMaster.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            try
            {
                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                c.cmd.CommandText = "select count(*) from LoginTable where staffid='" + txtUsername.Text + "'";

                if ((int)c.cmd.ExecuteScalar() <= 0)
                {
                    txtUsername.Focus();
                    lblError.Text = "Username not found!";
                    Interaction.Beep();
                    return;
                }

                else
                {

                    c.cmd.CommandText = "select resetpassword from LoginTable where staffid=@staffid";
                    c.cmd.Parameters.Clear();
                    c.cmd.Parameters.Add("@staffid", SqlDbType.VarChar).Value = txtUsername.Text;
                    string resetpassword = (string) c.cmd.ExecuteScalar();

                    switch (resetpassword)
                    {
                        case "Reset_Full":
                            Login_CP_02b objCPFull = new Login_CP_02b();
                            objCPFull.state = "Reset_Full";
                            objCPFull.txtUsername.Text = txtUsername.Text;
                            objCPFull.Show();

                            break;

                        case "Reset_Password":
                            Login_CP_02b objChangePassword = new Login_CP_02b();
                            objChangePassword.state = "Reset_Password";
                            objChangePassword.txtUsername.Text = txtUsername.Text;
                            objChangePassword.Show();
                            break;

                        case "Not_Required":
                            c.cmd.CommandText = "select count(*) from LoginTable where staffid=@staffid and password=@password";
                            c.cmd.Parameters.Clear();

                            c.cmd.Parameters.Add("@staffid", SqlDbType.VarChar).Value = txtUsername.Text;
                            c.cmd.Parameters.Add("@password", SqlDbType.VarBinary).Value = ConvertToByteArray(txtpword.Text);

                            if ((int)c.cmd.ExecuteScalar() > 0)
                            {
                                this.Hide();
                                adminMaster.staffID = txtUsername.Text;
                                adminMaster.Show();

                                adminMaster.Closed += new EventHandler(adminMaster_Closed);
                            }

                            else
                            {
                                txtpword.Clear();
                                lblError.Text = "Wrong Password!";
                            }

                            break;
                        default: MessageBox.Show(""); break;
                    }
                }
            }

            catch (Exception ex)
            {
                this.Hide();
                adminMaster.errObj.txtException.Text += ex.ToString();
                adminMaster.errObj.Show();
            }

            finally
            {
                c.cnn.Close();
            }

        }

        void adminMaster_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbShowPw_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPw.Checked)
            {
                txtpword.UseSystemPasswordChar = false;
            }

            else if (!cbShowPw.Checked)
            {
                txtpword.UseSystemPasswordChar = true;
            }
        }

        private static byte[] ConvertToByteArray(string password)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetBytes(password);
        }

        private void linkForgotPW_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            adminMaster.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;
            if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

            c.cmd.CommandText = "select count(*) from LoginTable where staffid='" + txtUsername.Text + "'";

            if ((int)c.cmd.ExecuteScalar() <= 0)
            {
                txtUsername.Focus();
                lblError.Text = "Username not found!";
                Interaction.Beep();
                return;

            }

            Login_CP_02b objChangePassword = new Login_CP_02b();
            objChangePassword.state = "Reset_Password";
            objChangePassword.txtUsername.Text = txtUsername.Text;
            objChangePassword.Show();
        }
    }
}