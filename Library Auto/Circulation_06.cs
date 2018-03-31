using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Reflection;

namespace Library_Auto
{
    public partial class Circulation_06 : Form
    {
        public Administration_03 adminInstance;
        
        Connect c = new Connect();
        SqlDataAdapter adp = new SqlDataAdapter();
        
        DataTable DTIssue = new DataTable();
        DataTable DTMem = new DataTable();
        DataTable DTAccReg = new DataTable();
        DataTable DTStock = new DataTable();

        string memStatus, bookStatus;
        int index;
        bool isViewing = false;

        string issueIDBookMemInfo;

        public Circulation_06()
        {
            InitializeComponent();
        }

        private void Circulation_06_Load(object sender, EventArgs e)
        {
            dtToday.Value = DateTime.Today;

            try
            {
                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }
                c.cmd.CommandText = "select count(*) from IssueTable";
                lblStats.Text += "" + (int)c.cmd.ExecuteScalar();
            }

            catch (SqlException) { }
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

            if (adminInstance != null)
            {
                adminInstance.Show();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            DTIssue.Reset();
            DTMem.Reset();
            DTAccReg.Reset();
            DTStock.Reset();

            txtAccno.Clear();
            txtMemID.Clear();
            txtCopy.Clear();

            txtAccno.ReadOnly = false;
            txtMemID.ReadOnly = false;
            txtCopy.ReadOnly = false;

            ClearGroupBoxContent(grpBookInfo);
            ClearGroupBoxContent(grpMemberInfo);
            ClearGroupBoxContent(grpIssueDetails);

            lblError.Text = "...";
            checkBoxOvernightCirc.Checked = false;
        }

        private void StopViewingClear_MouseClick(object sender, MouseEventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            if (isViewing)
            {
                isViewing = false;
                grpNavigator.Enabled = false;

                btnIssue.Enabled = true;
                btnReturn.Enabled = true;
                btnRenew.Enabled = true;

                ClearGroupBoxContent(grpIssueDetails);
            }
        }


        private void btnIssue_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            try
            {
                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                //Empty Validaitions
                bool isInvalid = EmptyValidation();

                if (isInvalid)
                {
                    lblError.Text = "Error : Empty Textbox!";
                    Interaction.Beep();
                    return;
                }

                else lblError.Text = "...";

                btnBookInfo_Click(this, EventArgs.Empty);
                btnMemberInfo_Click(this, EventArgs.Empty);

                //Readonly check to proceed furthur
                if (txtAccno.ReadOnly == false
                    || txtCopy.ReadOnly == false
                    || txtMemID.ReadOnly == false)
                {
                    MessageBox.Show("Invalidated Issue Status!"
                    + "\nCheck the Accno, Copy No and MemberID", "Invalid Status!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //MemberStatus Validations
                bool memReturn = MemStatusValidations();
                if (memReturn) return;


                //BookStatus Validations
                if (bookStatus == "Unavailable")
                {
                    string msg1, msg2, msg3;
                    msg1 = "Book is Unavailable!";
                    msg2 = "\nThe Book might be already Issued.";
                    msg3 = "\n\nPlease check the Copy Number of the Book.";

                    MessageBox.Show(msg1 + msg2 + msg3, "Book Unavailable",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                //DueDate Validations
                int daysFinal = SetDueDays(txtMemID.Text, DateTime.Today);

                if (daysFinal == -1)
                {
                    return;
                }


                //Issue Master 
                int issueID = -1;
                c.cmd.CommandText = "insert into IssueTable values(@memberid, @accno, @copyno, @issuedate, @duedate, @returndate, @fine, @status, @renewdate, @staffIDIssue, @staffIDRenew, @staffIDReturn)"
                    + " set @issueid = SCOPE_IDENTITY()";

                c.cmd.Parameters.Clear();

                SqlParameter outIssueID = new SqlParameter("@issueid", SqlDbType.Int);
                outIssueID.Direction = ParameterDirection.Output;

                c.cmd.Parameters.Add(outIssueID);
                c.cmd.Parameters.Add("@memberid", SqlDbType.VarChar).Value = txtMemID.Text;
                c.cmd.Parameters.Add("@accno", SqlDbType.VarChar).Value = txtAccno.Text;
                c.cmd.Parameters.Add("@copyno", SqlDbType.VarChar).Value = txtCopy.Text;

                DateTime today = DateTime.Today;
                c.cmd.Parameters.Add("@issuedate", SqlDbType.DateTime).Value = today;
                c.cmd.Parameters.Add("@duedate", SqlDbType.DateTime).Value = today.AddDays(daysFinal);
                c.cmd.Parameters.Add("@returndate", SqlDbType.DateTime).Value = DBNull.Value;
                c.cmd.Parameters.Add("@fine", SqlDbType.Int).Value = DBNull.Value;
                c.cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "Issued";
                c.cmd.Parameters.Add("@renewdate", SqlDbType.DateTime).Value = DBNull.Value;
                c.cmd.Parameters.Add("@staffIDIssue", SqlDbType.VarChar).Value = adminInstance.staffID;
                c.cmd.Parameters.Add("@staffIDRenew", SqlDbType.VarChar).Value = DBNull.Value;
                c.cmd.Parameters.Add("@staffIDReturn", SqlDbType.VarChar).Value = DBNull.Value;

                c.cmd.ExecuteNonQuery();

                if (outIssueID.Value != DBNull.Value)
                {
                    issueID = (int)outIssueID.Value;
                }


                //MembersTable and MembersIssues
                MembersTableUpdate();

                //AccRegIssues, StockTable and StockIssues
                StockTableUpdate();

                //GroupBox Updates
                UpdateGrpIssue(issueID);

                c.cmd.CommandText = "select MAX(issueid) from issueTable";
                lblStats.Text = "Total Book Issue :" + (int)c.cmd.ExecuteScalar();

                MessageBox.Show("Book Issued! \nIssue ID:" + issueID, "Issue Book", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                btnBookInfo_Click(this, null);
                btnMemberInfo_Click(this, null);

                btnIssue.Enabled = false;
                btnRenew.Enabled = false;
                btnReturn.Enabled = false;
            }

            catch (Exception ex)
            {
                adminInstance.errObj.txtException.Text = ex.ToString();
                adminInstance.errObj.Show();

                this.Close();
            }
        }

        void MembersTableUpdate()
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;
            if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

            //MembersTable Update
            c.cmd.Parameters.Clear();
            c.cmd.CommandText = "update MembersTable set status=@status where memberid ='" + txtMemID.Text + "'";
            c.cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "With Issue";
            c.cmd.ExecuteNonQuery();

            //MembersIssues Insert
            //MembersIssues has a additional column as issueid with identity specification.
            //This Table is used to prevent changes inside of MembersTable 
            //which could render inaccuracies in IssueDetails.
            c.cmd.CommandText = "insert into MembersIssues"
                + " Select * from MembersTable where memberid ='" + txtMemID.Text + "'";
            c.cmd.ExecuteNonQuery();
        }

        void StockTableUpdate()
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;
            if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

            //StockTable Update
            c.cmd.Parameters.Clear();
            c.cmd.CommandText = "update StockTable set status=@status where accno ='" + txtAccno.Text + "' and copyno ='" + txtCopy.Text + "'";
            c.cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "Unavailable";
            c.cmd.ExecuteNonQuery();

            //AccRegIssues Insert
            c.cmd.CommandText = "insert into AccRegIssues"
            + " Select * from AccRegTable where accno ='" + txtAccno.Text + "'";
            c.cmd.ExecuteNonQuery();

            //StockIssues Insert
            c.cmd.CommandText = "insert into StockIssues"
            + " Select * from StockTable where accno='" + txtAccno.Text + "'and copyno='" + txtCopy.Text + "'";
            c.cmd.ExecuteNonQuery();
        }

        //Does the Same as SetValues()
        void UpdateGrpIssue(int issueID)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;
            if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

            ClearGroupBoxContent(grpIssueDetails);

            c.cmd.CommandText = "select * from IssueTable where issueid ='" + issueID + "'";
            adp.SelectCommand = c.cmd;

            DTIssue.Clear();
            adp.Fill(DTIssue);

            txtIssueID.Text = "" + DTIssue.Rows[0].ItemArray[0];
            IssueDatePicker.Value = (DateTime)DTIssue.Rows[0].ItemArray[4];
            DueDatePicker.Value = (DateTime)DTIssue.Rows[0].ItemArray[5];

            if (DTIssue.Rows[0].ItemArray[6] != DBNull.Value)
            {
                ReturnDatePicker.Value = (DateTime)DTIssue.Rows[0].ItemArray[6];
                ReturnDatePicker.Visible = true;
                lblReturnDate.Visible = true;
            }

            else
            {
                ReturnDatePicker.Visible = false;
                lblReturnDate.Visible = false;
            }


            txtIssueFine.Text = "" + DTIssue.Rows[0].ItemArray[7];
            txtIssueStatus.Text = "" + DTIssue.Rows[0].ItemArray[8];

            if (DTIssue.Rows[0].ItemArray[9] != DBNull.Value)
            {
                renewDatePicker.Value = (DateTime)DTIssue.Rows[0].ItemArray[9];
                renewDatePicker.Visible = true;
                lblRenewDate.Visible = true;
            }

            else 
            {
                renewDatePicker.Visible = false;
                lblRenewDate.Visible = false;
            }

            txtStaffIDIssue.Text = "" + DTIssue.Rows[0].ItemArray[10];
            txtStaffIDRenew.Text = "" + DTIssue.Rows[0].ItemArray[11];
            txtStaffIDReturn.Text = "" + DTIssue.Rows[0].ItemArray[12];
        }

        private void btnFine_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            Fine_06b objFine = new Fine_06b();
            objFine.Show();
        }

        private void btnBookInfo_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;
            
            try
            {
                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open();}

                ClearGroupBoxContent(grpBookInfo);

                if (isViewing)
                {
                    string accRegCText, stockCText;
                    accRegCText = "select * from AccRegIssues where issueid ='" + issueIDBookMemInfo + "'";
                    stockCText = "select * from StockIssues where issueid ='" + issueIDBookMemInfo + "'";

                    BookInfoSetup(accRegCText, stockCText);
                }
                else
                {

                    c.cmd.CommandText = "select count(*) from AccRegTable where accno ='" + txtAccno.Text + "'";

                    if ((int)c.cmd.ExecuteScalar() <= 0)
                    {
                        MessageBox.Show("Book not found! \nPlease register the book using the Accession Register!", "Book Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    else
                    {
                        c.cmd.CommandText = "select count(*) from StockTable where accno='" + txtAccno.Text + "' and copyno='" + txtCopy.Text + "'";

                        if ((int)c.cmd.ExecuteScalar() <= 0)
                        {
                            MessageBox.Show("Copy not found! \nPlease Recheck the Copy Number",
                                "Book Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        else
                        {
                            string accRegCText, stockCText;
                            accRegCText = "select * from AccRegTable where accno ='" + txtAccno.Text + "'";
                            stockCText = "select * from StockTable where accno ='" + txtAccno.Text + "' and copyno ='" + txtCopy.Text + "'";

                            BookInfoSetup(accRegCText, stockCText);

                            if (bookStatus == "Available")
                            {
                                txtAccno.ReadOnly = true;
                                txtCopy.ReadOnly = true;
                            }
                        }
                    } 
                }
            }

            catch (Exception ex)
            {
                adminInstance.errObj.txtException.Text = ex.ToString();
                adminInstance.errObj.Show();

                this.Close();
            }
            
        }

        void BookInfoSetup(string accRegCText, string stockCText)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;
            if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

            //Sets the AccReg/AccRegIssues and Stock/StockIssues
            int i;

            i = (isViewing) ? 1 : 0;
            lblError.Text = "...";

            c.cmd.CommandText = accRegCText;
            adp.SelectCommand = c.cmd;

            DTAccReg.Reset();
            adp.Fill(DTAccReg);

            txtBookType.Text = (string)DTAccReg.Rows[0].ItemArray[2 + i];
            txtTitle.Text = (string)DTAccReg.Rows[0].ItemArray[3 + i];
            txtAuthor.Text = (string)DTAccReg.Rows[0].ItemArray[5 + i];
            txtYear.Text = (string)DTAccReg.Rows[0].ItemArray[17 + i];
            txtLanguage.Text = (string)DTAccReg.Rows[0].ItemArray[10 + i];
            txtPublisher.Text = (string)DTAccReg.Rows[0].ItemArray[19 + i];

            c.cmd.CommandText = stockCText;
            adp.SelectCommand = c.cmd;

            DTStock.Reset();
            adp.Fill(DTStock);

            txtEdn.Text = (string)DTStock.Rows[0].ItemArray[6 + i];
            txtPages.Text = (string)DTStock.Rows[0].ItemArray[14 + i];
            txtBinding.Text = (string)DTStock.Rows[0].ItemArray[16 + i];

            txtBookStatus.Text = (string)DTStock.Rows[0].ItemArray[10 + i];
            bookStatus = (string)DTStock.Rows[0].ItemArray[10 + i];
        }

        private void btnMemberInfo_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            try
            {
                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                ClearGroupBoxContent(grpMemberInfo);

                if (isViewing)
                {
                    string memCText = "select * from MembersIssues where issueid ='" + issueIDBookMemInfo + "'";
                    MemInfoSetup(memCText);
                }

                else
                {
                    c.cmd.CommandText = "select count(*) from MembersTable where memberid='" + txtMemID.Text + "'";

                    if ((int)c.cmd.ExecuteScalar() <= 0)
                    {
                        MessageBox.Show("Member not found! \nPlease register the Member",
                            "Member Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        string memCText = "select * from MembersTable where memberid='" + txtMemID.Text + "'";

                        MemInfoSetup(memCText);

                        if (memStatus == "Active")
                        {
                            txtMemID.ReadOnly = true;
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                adminInstance.errObj.txtException.Text = ex.ToString();
                adminInstance.errObj.Show();

                this.Close();
            }

        }

        void MemInfoSetup(string memCText)
        {
            //Sets up the Member Info with MembersTable/MembersIssues
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;
            if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

            int i;
            i = (isViewing) ? 1 : 0;

            lblError.Text = "...";

            DTMem.Reset();

            c.cmd.CommandText = memCText;
            adp.SelectCommand = c.cmd;
            adp.Fill(DTMem);

            txtMType.Text = (string)DTMem.Rows[0].ItemArray[0 + i];
            txtName.Text = (string)DTMem.Rows[0].ItemArray[2 + i];
            txtEmail.Text = (string)DTMem.Rows[0].ItemArray[15 + i];
            txtPhNo.Text = (string)DTMem.Rows[0].ItemArray[14 + i];

            dtSubs.Text = Convert.ToString(DTMem.Rows[0].ItemArray[10 + i]);
            dtExp.Text = Convert.ToString(DTMem.Rows[0].ItemArray[11 + i]);

            txtAddress.Text = (string)DTMem.Rows[0].ItemArray[16 + i];
            txtFine.Text = DTMem.Rows[0].ItemArray[20 + i].ToString();
            txtMemStatus.Text = (string)DTMem.Rows[0].ItemArray[9 + i];

            memStatus = DTMem.Rows[0].ItemArray[9 + i].ToString();
        }

        
        void ClearGroupBoxContent(GroupBox grpBx)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            foreach (Control ctrl in grpBx.Controls)
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Clear();
                }

                if (ctrl is DateTimePicker)
                {
                    (ctrl as DateTimePicker).Value = DateTime.Today;
                }
            }
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            try
            {

                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                c.cmd.CommandText = "select count(*) from StockTable where accno ='" + txtAccno.Text + "' and copyno ='" + txtCopy.Text + "'";

                if ((int)c.cmd.ExecuteScalar() < 1)
                {
                    lblError.Text = "Record not found!";
                    return;
                }

                else lblError.Text = "...";

                AccessionRegister_04 objAccReg = new AccessionRegister_04();

                objAccReg.sentByCirculation = true;
                objAccReg.adminInstance = adminInstance;

                objAccReg.circAccno = txtAccno.Text;
                objAccReg.circCopyNo = txtCopy.Text;

                objAccReg.Show();
            }

            catch (Exception ex)
            {
                adminInstance.errObj.txtException.Text = ex.ToString();
                adminInstance.errObj.Show();

                this.Close();
            }

            finally
            {
                c.cnn.Close();
            }

        }

        private void btnMemberDetails_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            try
            {
                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                c.cmd.CommandText = "select count(*) from MembersTable where memberid ='" + txtMemID.Text + "'";

                if ((int)c.cmd.ExecuteScalar() < 1)
                {
                    lblError.Text = "Record not found!";
                    return;
                }

                else lblError.Text = "...";

                Members_05 objMem = new Members_05();

                objMem.sentByCirculation = true;
                objMem.adminInstance = adminInstance;
                objMem.memIDCirc = txtMemID.Text;

                objMem.Show();
            }

            catch (Exception ex)
            {
                adminInstance.errObj.txtException.Text = ex.ToString();
                adminInstance.errObj.Show();

                this.Close();
            }

            finally
            {
                c.cnn.Close();
            }
        }

        private void btnBookStock_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            Stock_08 objStock = new Stock_08();

            if (txtAccno.Text != "")
            {
                objStock.accno = txtAccno.Text;
            }

            objStock.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //No Issue State check
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;
            if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

            c.cmd.CommandText = "Select count(*) from IssueTable";
            if ((int)c.cmd.ExecuteScalar() <= 0)
            {
                MessageBox.Show("No Book-Issues found!", "View Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            grpNavigator.Enabled = true;

            btnIssue.Enabled = false;
            btnRenew.Enabled = false;

            btnClear_Click(this, null);

            txtAccno.ReadOnly = true;
            txtCopy.ReadOnly = true;
            txtMemID.ReadOnly = true;

            try
            {
                if (c.cnn.State != ConnectionState.Open)
                {
                    c.cnn.Close();
                    c.cnn.Open();
                }

                c.cmd.CommandText = "select * from IssueTable";
                adp.SelectCommand = c.cmd;

                DTIssue.Clear();
                adp.Fill(DTIssue);

                index = 0;
                isViewing = true;

                SetIssueValues(index);
            }

            catch (Exception ex)
            {
                adminInstance.errObj.txtException.Text = ex.ToString();
                adminInstance.errObj.Show();

                this.Close();
            }

            finally
            {
                c.cnn.Close();
            }
        }

        void SetIssueValues(int i)
        {
            try
            {
                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                issueIDBookMemInfo = "" + (i + 1);
                txtIssueID.Text = "" + DTIssue.Rows[i].ItemArray[0];

                IssueDatePicker.Value = (DateTime) DTIssue.Rows[i].ItemArray[4];
                DueDatePicker.Value = (DateTime) DTIssue.Rows[i].ItemArray[5];

                txtIssueFine.Text = "" + DTIssue.Rows[i].ItemArray[7];
                txtIssueStatus.Text = "" + DTIssue.Rows[i].ItemArray[8];

                if (DTIssue.Rows[i].ItemArray[6] == DBNull.Value)
                {
                    ReturnDatePicker.Visible = false;
                    lblReturnDate.Visible = false;
                }

                else
                {

                    ReturnDatePicker.Value = (DateTime)DTIssue.Rows[i].ItemArray[6];
                    ReturnDatePicker.Visible = true;
                    lblReturnDate.Visible = true;
                }


                txtIssueFine.Text = "" + DTIssue.Rows[i].ItemArray[7];
                txtIssueStatus.Text = "" + DTIssue.Rows[i].ItemArray[8];

                if (DTIssue.Rows[i].ItemArray[9] == DBNull.Value)
                {
                    renewDatePicker.Visible = false;
                    lblRenewDate.Visible = false;
                }

                else
                {
                    renewDatePicker.Value = (DateTime)DTIssue.Rows[i].ItemArray[9];
                    renewDatePicker.Visible = true;
                    lblRenewDate.Visible = true;
                }

                txtStaffIDIssue.Text = "" + DTIssue.Rows[i].ItemArray[10];
                txtStaffIDRenew.Text = "" + DTIssue.Rows[i].ItemArray[11];
                txtStaffIDReturn.Text = "" + DTIssue.Rows[i].ItemArray[12];


                //Setup Buttons
                if ((string)DTIssue.Rows[i].ItemArray[8] == "Issued")
                {
                    btnReturn.Enabled = true;
                    btnRenew.Enabled = true;
                }

                else
                {
                    btnReturn.Enabled = false;
                    btnRenew.Enabled = false;
                }

                txtMemID.Text = "" + DTIssue.Rows[i].ItemArray[1];
                txtAccno.Text = "" + DTIssue.Rows[i].ItemArray[2];
                txtCopy.Text = "" + DTIssue.Rows[i].ItemArray[3];

                btnBookInfo_Click(this, null);
                btnMemberInfo_Click(this, null);

            }

            catch (Exception e)
            {
                adminInstance.errObj.txtException.Text = e.ToString();
                adminInstance.errObj.Show();

                this.Close();
            }

            finally
            {
                c.cnn.Close();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            index = 0;
            SetIssueValues(index);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            index--;
            if (index < 0) index = 0;

            SetIssueValues(index);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            index++;
            if (index > DTIssue.Rows.Count - 1) index = DTIssue.Rows.Count - 1;

            SetIssueValues(index);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            index = DTIssue.Rows.Count - 1;
            SetIssueValues(index);
        }


        bool EmptyValidation()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    if ((ctrl as TextBox).Text == "") return true;
                }
            }

            return false;
        }

        bool MemStatusValidations()
        {
            if (memStatus == "Inactive")
            {
                string msg1, msg2, msg3;
                msg1 = "Member's Status is set to Inactive!";
                msg2 = "\nThe Member's Subscription has ended! ";
                msg3 = "\n\nPlease setup the Member's Subscription to proceed";

                MessageBox.Show(msg1 + msg2 + msg3, "Member Inactive", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return true;
            }

            if (memStatus == "With Issue")
            {
                string msg1, msg2, msg3;
                msg1 = "Member's Status is set to \"With Issue\"";
                msg2 = "\nThis member has already issued a Book";
                msg3 = "\n\nThis member can Re-issue only after returning the Book";

                MessageBox.Show(msg1 + msg2 + msg3, "Member Status : With Issue", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return true;
            }

            return false;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;
            if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

            string issueID;

            if (isViewing)
            {
                issueID = txtIssueID.Text;

                grpNavigator.Enabled = false;
                btnReturn.Enabled = false;
                btnRenew.Enabled = false;
            }

            else
            {

                try
                {
                    issueID = Interaction.InputBox("Enter the Issue ID:", "Book Return", "", -1, -1);
                    c.cmd.CommandText = "select count(*) from IssueTable where issueid ='" + issueID + "'";

                    if ((int)c.cmd.ExecuteScalar() <= 0)
                    {
                        MessageBox.Show("Issue with Issue ID:" + issueID + " not found!",
                            "Book Return", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                catch (SqlException)
                {
                    MessageBox.Show("Incorrect Issue ID!",
                        "Book Renew", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            c.cmd.CommandText = "select * from IssueTable where issueid ='" + issueID + "'";
            adp.SelectCommand = c.cmd;

            DTIssue.Clear();
            adp.Fill(DTIssue);

            issueIDBookMemInfo = issueID;

            txtMemID.Text = "" + DTIssue.Rows[0].ItemArray[1];
            txtAccno.Text = "" + DTIssue.Rows[0].ItemArray[2];
            txtCopy.Text = "" + DTIssue.Rows[0].ItemArray[3];

            isViewing = true;
             
            btnBookInfo_Click(this, null);
            btnMemberInfo_Click(this, null);
            UpdateGrpIssue(Convert.ToInt16(issueIDBookMemInfo));

            //I don't think this is really required
            txtMemID.Text = "" + DTIssue.Rows[0].ItemArray[1];
            txtAccno.Text = "" + DTIssue.Rows[0].ItemArray[2];
            txtCopy.Text = "" + DTIssue.Rows[0].ItemArray[3];

            if (DTIssue.Rows[0].ItemArray[8].ToString() != "Issued")
            {
                MessageBox.Show("The issue status is " + DTIssue.Rows[0].ItemArray[8]
                    + "\n\n To Return a Book, the Issue Status must be \"Issued\"",
                    "Book Return", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                btnIssue.Enabled = false;
                btnRenew.Enabled = false;
                btnReturn.Enabled = false;

                return;
            }

            DateTime dueDate = (DateTime) DTIssue.Rows[0].ItemArray[5];
            
            if (DateTime.Today > dueDate)
            {
                CalculateFine(DTIssue, dueDate);
            }

            c.cmd.CommandText = "update IssueTable set status=@status, returndate=@returndate, fine=@fine, staffIDReturn=@staffIDReturn where issueid ='" + DTIssue.Rows[0].ItemArray[0] + "'";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "Returned";
            c.cmd.Parameters.Add("@returndate", SqlDbType.DateTime).Value = DateTime.Today;

            if (txtIssueFine.Text == "") txtIssueFine.Text = "0";
            c.cmd.Parameters.Add("@fine", SqlDbType.Int).Value = Convert.ToInt32(txtIssueFine.Text);
            c.cmd.Parameters.Add("@staffIDReturn", SqlDbType.VarChar).Value = adminInstance.staffID;
            c.cmd.ExecuteNonQuery();

            //Members Update
            c.cmd.CommandText = "select expdate from MembersTable where memberid ='" + DTIssue.Rows[0].ItemArray[1] + "'";
            adp.SelectCommand = c.cmd;

            DTMem.Reset();
            adp.Fill(DTMem);
            DateTime expdate = (DateTime) DTMem.Rows[0].ItemArray[0];

            MemberStatusUpdate(expdate);
            AccRegStatusUpdate();

            MessageBox.Show("Book Returned \nIssue ID:" + issueID, "Return Book", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            UpdateGrpIssue(Convert.ToInt16(issueID));

            txtMemID.Text = "" + DTIssue.Rows[0].ItemArray[1];
            txtAccno.Text = "" + DTIssue.Rows[0].ItemArray[2];
            txtCopy.Text = "" + DTIssue.Rows[0].ItemArray[3];

            btnBookInfo_Click(this, null);
            btnMemberInfo_Click(this, null);

            btnIssue.Enabled = false;
            btnRenew.Enabled = false;
            btnReturn.Enabled = false;
        }

        void MemberStatusUpdate(DateTime expdate)
        {
            string status = (DateTime.Today > expdate) ? "Inactive" : "Active";

            c.cmd.CommandText = "update MembersTable set status=@status where memberid ='" + DTIssue.Rows[0].ItemArray[1] + "'";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            c.cmd.ExecuteNonQuery();

            c.cmd.CommandText = "update MembersIssues set status=@status where issueid ='" + DTIssue.Rows[0].ItemArray[0] + "'";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            c.cmd.ExecuteNonQuery();
        }

        void AccRegStatusUpdate()
        {
            c.cmd.CommandText = "update StockTable set status=@status where accno ='" + DTIssue.Rows[0].ItemArray[2] + "' and copyno ='" + DTIssue.Rows[0].ItemArray[3] + "'";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "Available";
            c.cmd.ExecuteNonQuery();

            c.cmd.CommandText = "update StockIssues set status=@status where issueid ='" + DTIssue.Rows[0].ItemArray[0] + "'";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "Available";
            c.cmd.ExecuteNonQuery();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            try
            {
                checkBoxOvernightCirc.Checked = false;
                string issueID;

                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                if (isViewing)
                {
                    issueID = txtIssueID.Text;

                    grpNavigator.Enabled = false;
                    btnReturn.Enabled = false;
                    btnRenew.Enabled = false;
                }

                else
                {
                    try
                    {
                        issueID = Interaction.InputBox("Enter the Issue ID:", "Book Return", "", -1, -1);
                        c.cmd.CommandText = "select count(*) from IssueTable where issueid ='" + issueID + "'";

                        if ((int)c.cmd.ExecuteScalar() <= 0)
                        {
                            MessageBox.Show("Issue with Issue ID:" + issueID + " not found!",
                                "Book Renew", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    catch (SqlException)
                    {
                        MessageBox.Show("Incorrect Issue ID!",
                            "Book Renew", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                c.cmd.CommandText = "select * from IssueTable where issueid ='" + issueID + "'";
                adp.SelectCommand = c.cmd;

                DTIssue.Clear();
                adp.Fill(DTIssue);

                issueIDBookMemInfo = issueID;
                txtMemID.Text = "" + DTIssue.Rows[0].ItemArray[1];
                txtAccno.Text = "" + DTIssue.Rows[0].ItemArray[2];
                txtCopy.Text = "" + DTIssue.Rows[0].ItemArray[3];

                isViewing = true;

                btnBookInfo_Click(this, null);
                btnMemberInfo_Click(this, null);
                UpdateGrpIssue(Convert.ToInt16(issueIDBookMemInfo));

                //Do I really need this?
                txtMemID.Text = "" + DTIssue.Rows[0].ItemArray[1];
                txtAccno.Text = "" + DTIssue.Rows[0].ItemArray[2];
                txtCopy.Text = "" + DTIssue.Rows[0].ItemArray[3];

                if (DTIssue.Rows[0].ItemArray[8].ToString() != "Issued")
                {
                    MessageBox.Show("The issue status is " + DTIssue.Rows[0].ItemArray[8]
                        + "\n\n To Renew a Book, the Issue Status must be \"Issued\"",
                        "Book Renew", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    btnIssue.Enabled = false;
                    btnRenew.Enabled = false;
                    btnReturn.Enabled = false;

                    return;
                }

                DateTime issueDate = (DateTime)DTIssue.Rows[0].ItemArray[4];
                int numOfDays = SetDueDays(txtMemID.Text, issueDate);

                DateTime dueDateO = issueDate.AddDays(numOfDays);
                DateTime dueDateNow = (DateTime)DTIssue.Rows[0].ItemArray[5];

                if (issueDate == DateTime.Today)
                {
                    MessageBox.Show("The Book was issued today!");

                    btnRenew.Enabled = true;
                    btnReturn.Enabled = true;

                    isViewing = false;
                    return;
                }

                if (dueDateNow == issueDate.AddDays(1))
                {
                    MessageBox.Show("Cannot Renew a Overnight Circulation!");

                    btnRenew.Enabled = true;
                    btnReturn.Enabled = true;

                    isViewing = false;
                    return;
                }

                if (DateTime.Today > dueDateNow)
                {
                    MessageBox.Show("Cannot Renew! \nThe Due-date has passed");

                    btnRenew.Enabled = true;
                    btnReturn.Enabled = true;

                    isViewing = false;
                    return;
                }

                if (dueDateNow > dueDateO)
                {
                    MessageBox.Show("The Book has already been renewed once,"
                        + "\nPress Return to return the book");

                    btnRenew.Enabled = true;
                    btnReturn.Enabled = true;

                    isViewing = false;
                    return;
                }

                else
                {
                    numOfDays = SetDueDays(txtMemID.Text, DateTime.Today);

                    c.cmd.Parameters.Clear();
                    c.cmd.CommandText = "update IssueTable set duedate=@duedate, renewdate=@renewdate, staffIDRenew=@staffIDRenew where issueid ='" + issueID + "'";
                    c.cmd.Parameters.Add("@duedate", SqlDbType.DateTime).Value = DateTime.Today.AddDays(numOfDays);
                    c.cmd.Parameters.Add("@renewdate", SqlDbType.DateTime).Value = DateTime.Today;
                    c.cmd.Parameters.Add("@staffIDRenew", SqlDbType.VarChar).Value = adminInstance.staffID;

                    c.cmd.ExecuteNonQuery();

                    MessageBox.Show("Book Renewed! \nIssueId :" + txtIssueID.Text);
                }

                UpdateGrpIssue(Convert.ToInt16(issueID));

                btnIssue.Enabled = true;
                btnRenew.Enabled = true;
                btnReturn.Enabled = true;
            }

            catch (Exception ex)
            {
                adminInstance.errObj.txtException.Text = ex.ToString();
                adminInstance.errObj.Show();

                this.Close();
            }
        }

        int SetDueDays(string memID, DateTime today)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            Connect x = new Connect();
            DateTime tomorrow = DateTime.Today.AddDays(1);
            DataTable memTable = new DataTable();
            DataTable memParaTable = new DataTable();

            if (checkBoxOvernightCirc.Checked)
            {
                x.cmd.CommandText = "select count(*) from HolidayTable where date='" + tomorrow + "'";

                if ((int)x.cmd.ExecuteScalar() <= 0)
                {
                    return 1;
                }

                else
                {
                    MessageBox.Show("Cannot set Due-date to " + tomorrow.ToShortDateString() 
                        + "\nAs Tomorrow is a Holiday!"
                        + "\nAborting!", "Overnight-Circulation", 
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return -1;
                }

            }
             
            //Bring values from Member parameters
            x.cmd.CommandText = "select membertype from MembersTable where memberid ='" + memID + "'";
            
            string memType = (string)x.cmd.ExecuteScalar();
            x.cmd.CommandText = "select maxissuedays from MemberParameters where memtype ='" + memType +"'";

            int numOfDays = (int) x.cmd.ExecuteScalar();
            DateTime dueDate = DateTime.Today.AddDays(numOfDays);

            bool isHoliday = true;

            do
            {
                x.cmd.CommandText = "select count(*) from HolidayTable where date='" + dueDate + "'";

                if ((int)x.cmd.ExecuteScalar() <= 0)
                {
                    isHoliday = false;
                }

                else
                {
                    numOfDays++;
                    dueDate = DateTime.Today.AddDays(numOfDays);
                }   
            }

            while (isHoliday);

            return numOfDays;
        }

        void CalculateFine(DataTable issueTable, DateTime dueDate)
        {
            string memID, accno, copyno, memType;
            DataTable memTable = new DataTable();
            DataTable memParaTable = new DataTable();

            memID = "" + issueTable.Rows[0].ItemArray[1];
            accno = "" + issueTable.Rows[0].ItemArray[2];
            copyno = "" + issueTable.Rows[0].ItemArray[3];

            c.cmd.CommandText = "select membertype, fine from MembersTable where memberid ='" + memID + "'";
            adp.SelectCommand = c.cmd;
            memTable.Clear();
            adp.Fill(memTable);

            memType = (string)memTable.Rows[0].ItemArray[0];
            int currentFine = (int)memTable.Rows[0].ItemArray[1];

            c.cmd.CommandText = "select fineperday from MemberParameters where memtype ='" + memType + "'";
            adp.SelectCommand = c.cmd;
            memParaTable.Clear();
            adp.Fill(memParaTable);

            int finePD = Convert.ToInt16(memParaTable.Rows[0].ItemArray[0]);
            int days = (int)(DateTime.Today - dueDate).TotalDays;

            txtIssueFine.Text =Convert.ToString(days * finePD);

            int fine = currentFine + (days * finePD);

            c.cmd.CommandText = "update MembersTable set fine=@fine where memberid ='" + memID + "'";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@fine", SqlDbType.Int).Value = fine;
            c.cmd.ExecuteNonQuery();

            c.cmd.CommandText = "update MembersIssues set fine=@fine where issueid ='" + txtIssueID.Text + "'";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@fine", SqlDbType.Int).Value = fine;
            c.cmd.ExecuteNonQuery();

            MessageBox.Show("Fine has been added! \nMember ID:" + memID,
                "Return Book", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnBookLost_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            try
            {
                string memID;

                if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }

                try
                {
                    memID = Interaction.InputBox("Enter the Member ID:", "Book Lost", "", -1, -1);
                    c.cmd.CommandText = "select count(*) from IssueTable where memberid ='" + memID + "'";

                    if ((int)c.cmd.ExecuteScalar() <= 0)
                    {
                        MessageBox.Show("Member with Member ID:" + memID + " not found!",
                            "Book Lost", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    ViewIssued_11 objBookLost = new ViewIssued_11();
                    objBookLost.txtMemID.Text = memID;
                    objBookLost.Show();
                }

                catch (Exception)
                {
                    MessageBox.Show("Incorrect Member ID!",
                        "Book Lost", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

        private void btnViewIssuedGrid_Click(object sender, EventArgs e)
        {
            adminInstance.errObj.txtBtnClicks.Text += "\n" + MethodBase.GetCurrentMethod().Name;

            ViewIssued_11 objBL = new ViewIssued_11();
            objBL.state = "View Issued";
            objBL.Show();


        }

        private void btnViewIssuedDetails_Click(object sender, EventArgs e)
        {
            string infoText = "View Issued : The Information stored is only accurate to the time of Issue/Renew/Return."
                + "For the latest Updated details please check the Members-Management/Accession-Register.";
            MessageBox.Show(infoText, "View Issued",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}