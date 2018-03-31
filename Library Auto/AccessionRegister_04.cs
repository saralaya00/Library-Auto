 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Microsoft.VisualBasic;

namespace Library_Auto
{
    public partial class AccessionRegister_04 : Form
    {
        public Administration_03 adminInstance;

        Connect c = new Connect();
        Connect c2 = new Connect();

        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        SqlDataAdapter adp = new SqlDataAdapter();
        SqlDataAdapter adp2 = new SqlDataAdapter();

        BindingSource bds = new BindingSource();
        BindingSource bds2 = new BindingSource();

        string stockCommandText;
        string state = "";

        //Circulation Variables
        public bool sentByCirculation = false;
        public string circAccno, circCopyNo;

        public AccessionRegister_04()
        {
            InitializeComponent();
        }

        private void Catalog_04_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;

            state = "";

            grpNav.Enabled = false;
            grpCopyNav.Enabled = false;

            btnSubmit.Enabled = false;
            btnCancel.Enabled = false;
           
            DisableMainGroupbox();

            ttBtnNet.SetToolTip(btnNet, "Calculate Net Amount using Price and Discount");

            if (sentByCirculation)
            {
                btnSearch_Click(this, EventArgs.Empty);
            }

            try
            {
                c.cmd.CommandText = "select count(*) from AccRegTable";
                lblTotal.Text = "Total Records: " + (int)c.cmd.ExecuteScalar();
            }

            catch (InvalidOperationException) { }
            catch (SqlException) { }

        }

        public void AccRegButtonActions(string actionText)
        {
            switch (actionText)
            {
                case "Add": btnAdd_Click(this, EventArgs.Empty); break;
                case "View": btnView_Click(this, EventArgs.Empty); break;
                case "Edit": btnEdit_Click(this, EventArgs.Empty); break;
                case "Delete": btnDelete_Click(this, EventArgs.Empty); break;
                case "Search": btnSearch_Click(this, EventArgs.Empty); break;
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

            if (!sentByCirculation && adminInstance != null)
            {
                adminInstance.Show();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            bool clearStateValue;
            bool addCopyClearOnly = false;

            switch (state)
            {
                case "":
                    clearStateValue = true;
                    DisableMainGroupbox();

                    ddlSection.SelectedItem = null;
                    ddlType.SelectedItem = null;
                    txtAccNo.Text = "";

                    grpNav.Enabled = false;
                    grpCopyNav.Enabled = false;
                    break;

                case "BeginView":

                    state = "View";
                    DisableMainGroupbox();

                    clearStateValue = false;

                    ddlSection.SelectedItem = null;
                    ddlType.SelectedItem = null;
                    txtAccNo.Text = "";

                    grpNav.Enabled = false;
                    grpCopyNav.Enabled = false;
                    break;

                case "View":
                    DisableMainGroupbox();

                    clearStateValue = true;

                    ddlSection.SelectedItem = null;
                    ddlType.SelectedItem = null;
                    txtAccNo.Text = "";

                    grpNav.Enabled = false;
                    grpCopyNav.Enabled = false;
                    break;

                case "Add": 
                    clearStateValue = false; 
                    break;


                case "EditPrompt":
                    DisableMainGroupbox();
                    state = "Edit";
                    clearStateValue = false;
                    break;

                case "Edit": 
                    DisableMainGroupbox();

                    clearStateValue = true;

                    ddlSection.Text = "";
                    ddlType.Text = "";
                    txtAccNo.Text = "";
                    break;
                
                case "Add Copy":
                    clearStateValue = false;
                    addCopyClearOnly = true;
                    break;

                case "Delete Copy":
                    clearStateValue = true;
                    break;

                default: return;
            }


            if (clearStateValue)
            {
                state = "";
                stripCurrOps.Text = "Current Operation:" + state;
            }

            if (!addCopyClearOnly) dt.Clear();
            dt2.Clear();

            foreach (Control ctr in grpCatalogDetails.Controls)
            {
                if (addCopyClearOnly) break;

                if (ctr is TextBox)
                {
                    (ctr as TextBox).Clear();
                    (ctr as TextBox).ReadOnly = false;
                }
                
                if (ctr is ComboBox)
                {
                    (ctr as ComboBox).Text = "";
                } 
            }

            foreach (Control ctr in grpCopyDetails.Controls)
            {
                if (ctr is TextBox)
                {
                    (ctr as TextBox).Clear();
                    (ctr as TextBox).ReadOnly = false;
                }

                if (ctr is ComboBox)
                {
                    (ctr as ComboBox).Text = "";
                }

                if (ctr is DateTimePicker)
                {
                    (ctr as DateTimePicker).Value = DateTime.Today;
                }
            }
        }

        void DisableMainGroupbox()
        {
            ddlSection.Enabled = false;
            ddlType.Enabled = false;
            txtAccNo.Enabled = false;

            grpCatalogDetails.Enabled = false;
            grpCopyDetails.Enabled = false;
        }

        void EnableMainGroupBox()
        {
            ddlSection.Enabled = true;
            ddlType.Enabled = true;
            txtAccNo.Enabled = true;

            grpCatalogDetails.Enabled = true;
            grpCopyDetails.Enabled = true;
        }

        void EnableControls(string _state)
        {
            switch (_state)
            { 

                case "Add" :
                    grpNav.Enabled = false;
                    grpCopyNav.Enabled = false;

                    EnableMainGroupBox();

                    txtAccNo.ReadOnly = false;
                    txtCopyNo.ReadOnly = false;

                    btnSubmit.Enabled = true;
                    btnCancel.Enabled = true;
                    break;

                case "View":
                    DisableMainGroupbox();

                    grpNav.Enabled = true;
                    grpCopyNav.Enabled = true;

                    txtAccNo.ReadOnly = false;
                    txtCopyNo.ReadOnly = false;

                    btnSubmit.Enabled = false;
                    btnCancel.Enabled = false;
                    break;

                case "Edit":
                    //Only called for Prompt.
                    EnableMainGroupBox();

                    grpNav.Enabled = false;
                    grpCopyNav.Enabled = false;

                    txtAccNo.ReadOnly = true;
                    txtCopyNo.ReadOnly = true;

                    btnSubmit.Enabled = true;
                    btnCancel.Enabled = true;
                    break;

                case "Delete":
                    DisableMainGroupbox();
                    break;

                case "Add Copy":

                    ddlSection.Enabled = false;
                    ddlType.Enabled = false;
                    txtAccNo.Enabled = false;
               
                    grpCatalogDetails.Enabled = false;
                    grpCopyDetails.Enabled = true;

                    grpNav.Enabled = false;
                    grpCopyNav.Enabled = false;

                    txtCopyNo.ReadOnly = false;
                    txtAccNo.ReadOnly = false;

                    btnSubmit.Enabled = true;
                    btnCancel.Enabled = true;
                    break;

                default: return;
                    
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            state = "Add";
            stripCurrOps.Text = "Current Operation: " + state;

            btnClear_Click(this, EventArgs.Empty);
            EnableControls(state);

            ListUpdates();

        }

        private void DdlUpdate(string cmdText, ComboBox ddlToFill)
        {
            DataTable dtDummy = new DataTable();
            string itemToAdd = "";
            
            try
            {
                ddlToFill.Items.Clear();

                if (!ddlToFill.Items.Contains("(None)"))
                ddlToFill.Items.Add("(None)");

                c.cmd.CommandText = cmdText;
                adp.SelectCommand = c.cmd;
                adp.Fill(dtDummy);

                for (int i = 0; i < dtDummy.Rows.Count; i++)
                {
                    itemToAdd = "";
                    for (int j = 0; j < dtDummy.Columns.Count; j++)
                    {
                        itemToAdd += dtDummy.Rows[i].ItemArray[j] + " ";
                    }

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

        private void DdlListUpdate(string cmdText, ComboBox ddlToFill)
        {
            DataTable dtDummy = new DataTable();
            string itemToAdd = "";

            ddlToFill.Items.Clear();

            try
            {
                Connect c = new Connect();

                if (!ddlToFill.Items.Contains("(None)"))
                    ddlToFill.Items.Insert(0, "(None)");

                c.cmd.CommandText = cmdText;
                adp.SelectCommand = c.cmd;
                adp.Fill(dtDummy);

                for (int i = 0; i < dtDummy.Rows.Count; i++)
                {
                    itemToAdd = "" + dtDummy.Rows[i].ItemArray[0];

                    if (!ddlToFill.Items.Contains(itemToAdd))
                    {
                        ddlToFill.Items.Add(itemToAdd);
                    }
                }
            }

            catch (Exception)
            {
                //adminInstance.errObj.txtException.Text = ex.ToString();
                //adminInstance.errObj.Show();

                //Nevermind the Exception just ignore and move forwards
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            state = "BeginView";

            btnClear_Click(this, EventArgs.Empty);
            EnableControls(state);

            //The State is Set to "View" in Enable Controls
            stripCurrOps.Text = "Current Operation: " + state;

            try
            {
                if (c.cnn.State != ConnectionState.Open)
                {
                    c.cnn.Close();
                    c.cnn.Open();
                }

                stockCommandText = "";
                c.cmd.CommandText = "select * from AccRegTable";

                adp.SelectCommand = c.cmd;
                adp.Fill(dt);
                bds.DataSource = dt;
                bds.Sort = "accno ASC";


                ClearAccRegDataBindings();
                AddAccRegDataBindings();

                StockBindingUpdate();

                ClearStockDataBindings();
                AddStockDataBindings();
            }

            catch (SqlException)
            {
                throw;
            }

            finally
            {
                c.cnn.Close();
                c2.cnn.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            state = "View";
            stripCurrOps.Text = "Current Operation: " + "Search";

            btnClear_Click(this, EventArgs.Empty);
            state = "View";
            stripCurrOps.Text = "Current Operation: " + "Search";

            //Enable Controls sent down to work with only Found values
            try
            {
                if (c.cnn.State != ConnectionState.Open)
                {
                    c.cnn.Close();
                    c.cnn.Open();
                } 

                string accno;

                if (sentByCirculation)
                {
                    accno = circAccno;
                    lblAccReg.Text = "Searching Record | Accession Number : " + accno;
                }
                else
                {
                    accno = Interaction.InputBox("Enter the Accession Number:", "Search using Accno", "", -1, -1);
                }

                c.cmd.CommandText = "select count(*) from AccRegTable where accno ='" + accno + "'";

                if ((int)c.cmd.ExecuteScalar() <= 0)
                {
                    Interaction.Beep();
                    MessageBox.Show("Record not found!", "Search");

                    state = "";
                    stripCurrOps.Text = "Current Operation: " + state;
                    return;
                }

                stockCommandText = "";
                c.cmd.CommandText = "select * from AccRegTable where accno ='" + accno + "'";

                EnableControls(state);
                grpNav.Enabled = false;

                txtAccNo.Text = accno;

                dt.Clear();
                adp.SelectCommand = c.cmd;
                adp.Fill(dt);
                bds.DataSource = dt;

                ClearAccRegDataBindings();
                AddAccRegDataBindings();

                StockBindingUpdate();

                ClearStockDataBindings();
                AddStockDataBindings();

                //Set the State to Null here if Problem persists

            }

            catch (SqlException)
            {
                throw;
            }

            finally
            {
                c.cnn.Close();
                c2.cnn.Close();
            }

        }

        void StockBindingUpdate()
        {
            //updates the StockDatabindings on each >>, >, <<, <, of Catalog.

            try
            {
                if (c2.cnn.State != ConnectionState.Open)
                {
                    c2.cnn.Close();
                    c2.cnn.Open();
                }

                if (sentByCirculation)
                {
                    stockCommandText = "select * from StockTable where accno='" + circAccno + "' and copyno='" + circCopyNo + "'";

                    //Invalidate Everything
                    DisableMainGroupbox();
                    panelMain.Enabled = false;
                    btnClear.Enabled = false;
                    grpCopyNav.Enabled = false;
                }

                else stockCommandText = "select * from StockTable where accno='" + txtAccNo.Text + "'";

                dt2.Clear();
                c2.cmd.CommandText = stockCommandText;

                adp2.SelectCommand = c2.cmd;
                adp2.Fill(dt2);

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    if (!ddlVendor.Items.Contains(dt2.Rows[i].ItemArray[2].ToString()))
                    {
                        ddlVendor.Items.Add((string)dt2.Rows[i].ItemArray[2]);
                    }
                }

                bds2.DataSource = dt2;
                bds2.Sort = "copyno ASC";
            }

            catch (SqlException)
            {
                throw;
            }

            //finally
            //{
            //    c.cnn.Close();
            //    c2.cnn.Close();
            //}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                if (c.cnn.State != ConnectionState.Open)
                {
                    c.cnn.Close();
                    c.cnn.Open();
                } 

                if (state == "View")
                {
                    state = "Edit";
                    stripCurrOps.Text = "Current Operation: " + state;

                    c.cmd.CommandText = "select count(*) from StockTable where accno='" + txtAccNo.Text + "'";
                    if ((int)c.cmd.ExecuteScalar() == 0)
                    {
                        MessageBox.Show("No Copy found! Redirecting to Add Copy!", "Book Stock Empty");

                        state = "View";
                        stripCurrOps.Text = "Current Operation: " + state;

                        btnAddCopy_Click(this, EventArgs.Empty);
                        return;
                    }

                    EnableControls(state);
                    return;
                }

                else
                {
                    state = "EditPrompt";

                    btnClear_Click(this, EventArgs.Empty);
                    EnableControls(state);

                    //Enable Controls sets the State to Edit
                    stripCurrOps.Text = "Current Operation: " + state;

                    string accno = Interaction.InputBox("Enter the Accno:", "Edit Record", "", -1, -1);
                    c.cmd.CommandText = "select count(*) from AccRegTable where accno='" + accno + "'";

                    if ((int)c.cmd.ExecuteScalar() > 0)
                    {
                        string copyno = Interaction.InputBox("Search for Specific book using copy Number: \nEnter the Copy Number:", "Enter Copy Number", "", -1, -1);
                        c.cmd.CommandText = "select count(*) from StockTable where accno='" + accno + "'";

                        if ((int)c.cmd.ExecuteScalar() == 0)
                        {
                            MessageBox.Show("No Copy found! Redirecting to Add Copy!", "Book Stock Empty");
                            btnAddCopy_Click(this, EventArgs.Empty);
                            return;
                        }

                        c.cmd.CommandText = "select count(*) from StockTable where accno='" + accno + "' and copyno='" + copyno + "'";

                        if ((int)c.cmd.ExecuteScalar() <= 0)
                        {
                            Interaction.Beep();
                            MessageBox.Show("Book with Accno:" + accno + " and Copy Number:" + copyno + " not found!", "Edit");
                            btnCancel_Click(this, EventArgs.Empty);
                            return;
                        }

                        c.cmd.CommandText = "select * from AccRegTable where accno='" + accno + "'";
                        adp.SelectCommand = c.cmd;
                        dt.Clear();
                        adp.Fill(dt);
                        bds.DataSource = dt;

                        ClearAccRegDataBindings();
                        AddAccRegDataBindings();

                        stockCommandText = "select * from StockTable where accno='" + accno + "' and copyno='" + copyno + "'";
                        c2.cmd.CommandText = stockCommandText;

                        adp2.SelectCommand = c2.cmd;
                        dt2.Clear();
                        adp2.Fill(dt2);
                        bds2.DataSource = dt2;

                        ClearStockDataBindings();
                        AddStockDataBindings();
                    }

                    else
                    {
                        Interaction.Beep();
                        MessageBox.Show("Record not found!", "Edit");

                        state = "Edit";
                        stripCurrOps.Text = "Current Operation: " + state;
                        btnCancel_Click(this, EventArgs.Empty);
                    }
                }
            }

            catch (SqlException)
            {
                throw;
            }

            finally
            {
                c.cnn.Close();
                c2.cnn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (c.cnn.State != ConnectionState.Open)
                {
                    c.cnn.Close();
                    c.cnn.Open();
                } 

                if (state == "View")
                {
                    DialogResult dolores = MessageBox.Show("Delete this record? Accno = " 
                        + txtAccNo.Text + "\nAll Stock information of this book will be deleted!",
                        "Delete Records", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dolores == DialogResult.Cancel)
                    {
                        Interaction.Beep();
                        return;
                    }

                    else if (dolores == DialogResult.OK)
                    {
                        DeleteRecords(txtAccNo.Text);
                    }
                }

                else
                {
                    string inputText = Interaction.InputBox("Enter the Accno:", "Delete Records", "", -1, -1);
                    c.cmd.CommandText = "select count(*) from AccRegTable where accno='" + inputText + "'";

                    if ((int)c.cmd.ExecuteScalar() > 0)
                    {
                        c.cmd.CommandText = "select * from AccRegTable where accno='" + inputText + "'";
                        c2.cmd.CommandText = "select * from StockTable where accno='" + inputText + "'";

                        adp.SelectCommand = c.cmd;
                        adp2.SelectCommand = c2.cmd;

                        dt.Clear();
                        dt2.Clear();

                        adp.Fill(dt);
                        adp2.Fill(dt2);

                        bds.DataSource = dt;
                        bds2.DataSource = dt2;

                        ClearAccRegDataBindings();
                        ClearStockDataBindings();

                        AddAccRegDataBindings();
                        AddStockDataBindings();

                        DeleteRecords(inputText);
                    }

                    else
                    {
                        Interaction.Beep();
                        MessageBox.Show("Invalid!", "Delete Records");
                    }
                }
            }

            catch (SqlException)
            {
                throw;
            }

            finally
            {
                c.cnn.Close();
                c2.cnn.Close();
            }

        }

        void DeleteRecords(string accno)
        {
            c.cmd.CommandText = "delete from StockTable where accno='" + accno + "'";
            c.cmd.ExecuteNonQuery();

            string accCommandText = "delete from AccRegTable where accno='" + accno + "'";
            c.cmd.CommandText = accCommandText;
            c.cmd.ExecuteNonQuery();

            state = "";
            stripCurrOps.Text = "Current Operation: " + "Delete";

            MessageBox.Show("Records deleted!", "Delete Records");
        }

        bool EmptyValidations()
        {
            if (txtAccNo.Text == "" || ddlSection.SelectedItem == null
                || ddlType.SelectedItem == null)
            {
                MessageBox.Show("Main Fields Empty! \nPlease Check for Accession Number, Section or Type.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtAccNo.Focus();
                return true;
            }

            if (txtPubYear.Text != "")
            {
                if (Convert.ToInt16(txtPubYear.Text) > DateTime.Now.Year + 1)
                {
                    stripError.Text = "Error: Invalid Year!";
                    txtPubYear.Focus();
                    return true;
                }
            }

            btnNet_Click(this, EventArgs.Empty);

            foreach (Control ctrl in grpCatalogDetails.Controls)
            {
                if (ctrl is TextBox)
                {
                    if ((ctrl as TextBox).Text == "")
                    {
                        stripError.Text = "Error: Empty Textbox";
                        (ctrl as TextBox).Focus();
                        return true;
                    }
                }

                else if (ctrl is ComboBox)
                {
                    if ((ctrl as ComboBox).SelectedItem == null)
                    {
                        stripError.Text = "Error: Unselected Item";
                        (ctrl as ComboBox).Focus();
                        return true;
                    }
                }
            }

            foreach (Control ctrl in grpCopyDetails.Controls)
            {
                if (ctrl is TextBox)
                {
                    if ((ctrl as TextBox).Text == "")
                    {
                        stripError.Text = "Error: Empty Textbox";
                        (ctrl as TextBox).Focus();
                        return true;
                    }
                }

                else if (ctrl is ComboBox)
                {
                    if ((ctrl as ComboBox).SelectedItem == null)
                    {
                        stripError.Text = "Error: Unselected Item";
                        (ctrl as ComboBox).Focus();
                        return true;
                    }
                }
            }

            return false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (c.cnn.State != ConnectionState.Open)
                {
                    c.cnn.Close();
                    c.cnn.Open();
                } 

                string process = state;
                bool isInvalid;
                isInvalid = EmptyValidations();

                if (isInvalid)
                {
                    return;
                }

                else stripError.Text = "...";

                try
                {
                    //CopyNumber Test
                    if (Convert.ToInt32(txtCopyNo.Text) == 0) 
                    {
                        stripError.Text = "Invalid Copy Number!";
                        return;
                    }

                    //Pages Test
                    if (Convert.ToInt32(txtPages.Text) == 0)
                    {
                        stripError.Text = "Invalid Page!";
                        return;
                    }
                }

                catch (Exception) { }



                switch (state)
                {
                    case "Add":
                        c.cmd.CommandText = "select count(*) from AccRegTable where accno='" + txtAccNo.Text + "'";

                        if ((int)c.cmd.ExecuteScalar() > 0)
                        {
                            Interaction.Beep();
                            MessageBox.Show("Book already present! \nAccno Match found. \n\nEnter a New Accno!", "Add Book", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtAccNo.Focus();
                            return;
                        }

                        c.cmd.CommandText = "insert into AccRegTable values (@accno, @section, @type, @title, @subtitle, @author, @editor, @volume, @series, @isbn, @language, @keyword, @remarks, @subject, @subject2, @callno, @classno, @pubyear, @place, @publisher)";
                        stockCommandText = "insert into StockTable values (@accno, @copyno, @vendor, @source, @currency, @dept, @edition, @billno, @billdate, @discount, @status, @category, @price, @netcost, @pages, @location, @binding, @copyyear)";

                        state = "View";
                        stripCurrOps.Text = "Current Operation: " + state;

                        break;

                    case "Edit":
                        txtAccNo.ReadOnly = false;
                        txtCopyNo.ReadOnly = false;

                        c.cmd.CommandText = "update AccRegTable set section=@section, type=@type, title=@title, subtitle=@subtitle, author=@author, editor=@editor, volume=@volume, series=@series, isbn=@isbn, language=@language, keyword=@keyword, remarks=@remarks, subject=@subject, subject2=@subject2, callno=@callno, classno=@classno, pubyear=@pubyear, place=@place, publisher=@publisher where accno=@accno";
                        stockCommandText = "update StockTable set vendor=@vendor, source=@source, currency=@currency, dept=@dept, edition=@edition, billno=@billno, billdate=@billdate, discount=@discount, status=@status, category=@category, price=@price, netcost=@netcost, pages=@pages, location=@location, binding=@binding, copyyear=@copyyear where accno=@accno and copyno=@copyno";

                        state = "View";
                        stripCurrOps.Text = "Current Operation: " + state;
                        break;

                    case "Add Copy":

                        c.cmd.CommandText = "select count(*) from StockTable where accno='" + txtAccNo.Text + "' and copyno='" + txtCopyNo.Text + "'";
                        int tempCount = (int)c.cmd.ExecuteScalar();
                        
                        if (tempCount > 0)
                        {
                            MessageBox.Show("A Copy Number match has been found!, Insert a new copy Number!", "Add a Copy");
                            txtCopyNo.Focus();
                            return;
                        }

                        c.cmd.CommandText = "AddCopySkipAccRegTable";
                        stockCommandText = "insert into StockTable values (@accno, @copyno, @vendor, @source, @currency, @dept, @edition, @billno, @billdate, @discount, @status, @category, @price, @netcost, @pages, @location, @binding, @copyyear)";

                        grpNav.Enabled = false;
                        grpCopyNav.Enabled = false;

                        state = "View";
                        stripCurrOps.Text = "Current Operation: " + state;
                        break;

                    default: return;
                }

                c.cmd.Parameters.Clear();

                c.cmd.Parameters.Add("@accno", SqlDbType.VarChar).Value = txtAccNo.Text;
                c.cmd.Parameters.Add("@section", SqlDbType.VarChar).Value = ddlSection.Text;
                c.cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = ddlType.Text;
                c.cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = txtTitle.Text;
                c.cmd.Parameters.Add("@subtitle", SqlDbType.VarChar).Value = txtSubTitle.Text;
                c.cmd.Parameters.Add("@author", SqlDbType.VarChar).Value = txtAuthor.Text;
                c.cmd.Parameters.Add("@editor", SqlDbType.VarChar).Value = txtEditor.Text;
                c.cmd.Parameters.Add("@volume", SqlDbType.VarChar).Value = txtVolume.Text;
                c.cmd.Parameters.Add("@series", SqlDbType.VarChar).Value = txtSeries.Text;
                c.cmd.Parameters.Add("@isbn", SqlDbType.VarChar).Value = txtISBN.Text;
                c.cmd.Parameters.Add("@language", SqlDbType.VarChar).Value = ddlLanguage.Text;
                c.cmd.Parameters.Add("@keyword", SqlDbType.VarChar).Value = txtKeyword.Text;
                c.cmd.Parameters.Add("@remarks", SqlDbType.VarChar).Value = txtRemark.Text;
                c.cmd.Parameters.Add("@subject", SqlDbType.VarChar).Value = ddlSub1.Text;
                c.cmd.Parameters.Add("@subject2", SqlDbType.VarChar).Value = ddlSub2.Text;
                c.cmd.Parameters.Add("@callno", SqlDbType.VarChar).Value = txtCallNo.Text;
                c.cmd.Parameters.Add("@classno", SqlDbType.VarChar).Value = txtClsNo.Text;
                c.cmd.Parameters.Add("@pubyear", SqlDbType.VarChar).Value = txtPubYear.Text;
                c.cmd.Parameters.Add("@place", SqlDbType.VarChar).Value = txtPlace.Text;
                c.cmd.Parameters.Add("@publisher", SqlDbType.VarChar).Value = txtPublisher.Text;

                if (!c.cmd.CommandText.Equals("AddCopySkipAccRegTable"))
                {
                    c.cmd.ExecuteNonQuery();
                }

                c.cmd.Parameters.Clear();
                c.cmd.CommandText = stockCommandText;

                c.cmd.Parameters.Add("@accno", SqlDbType.VarChar).Value = txtAccNo.Text;
                c.cmd.Parameters.Add("@copyno", SqlDbType.Int).Value = Convert.ToInt32(txtCopyNo.Text);
                c.cmd.Parameters.Add("@vendor", SqlDbType.VarChar).Value = ddlVendor.Text;
                c.cmd.Parameters.Add("@source", SqlDbType.VarChar).Value = ddlSource.Text;
                c.cmd.Parameters.Add("@currency", SqlDbType.VarChar).Value = ddlCurency.Text;
                c.cmd.Parameters.Add("@dept", SqlDbType.VarChar).Value = ddlDept.Text;
                c.cmd.Parameters.Add("@edition", SqlDbType.VarChar).Value = txtEdition.Text;
                c.cmd.Parameters.Add("@billno", SqlDbType.VarChar).Value = txtBillNo.Text;
                c.cmd.Parameters.Add("@billdate", SqlDbType.VarChar).Value = dtBilldate.Value;
                c.cmd.Parameters.Add("@discount", SqlDbType.VarChar).Value = txtDiscount.Text;
                c.cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = ddlStatus.Text;
                c.cmd.Parameters.Add("@category", SqlDbType.VarChar).Value = ddlCategory.Text;
                c.cmd.Parameters.Add("@price", SqlDbType.VarChar).Value = txtPrice.Text;
                c.cmd.Parameters.Add("@netcost", SqlDbType.VarChar).Value = txtNetCost.Text;
                c.cmd.Parameters.Add("@pages", SqlDbType.VarChar).Value = txtPages.Text;
                c.cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = txtLocation.Text;
                c.cmd.Parameters.Add("@binding", SqlDbType.VarChar).Value = ddlBinding.Text;
                c.cmd.Parameters.Add("@copyyear", SqlDbType.VarChar).Value = txtCopyYear.Text;

                c.cmd.ExecuteNonQuery();

                btnSubmit.Enabled = false;
                btnCancel.Enabled = false;

                DisableMainGroupbox();

                c.cmd.CommandText = "select count(*) from AccRegTable";
                lblTotal.Text = "Total Records: " + (int)c.cmd.ExecuteScalar();
                MessageBox.Show(process + " Complete!", process, MessageBoxButtons.OK, MessageBoxIcon.Information);  

            }

            catch (SqlException)
            {
                throw;
            }

            finally
            {
                c.cnn.Close();
                c2.cnn.Close();
            }
        }

        private void btnAddCopy_Click(object sender, EventArgs e)
        {

            try
            {
                if (c.cnn.State != ConnectionState.Open)
                {
                    c.cnn.Close();
                    c.cnn.Open();
                } 

                if (state == "View")
                {
                    state = "Add Copy";
                    stripCurrOps.Text = "Current Operation: " + state;

                    EnableControls(state);

                    try
                    {
                        c.cmd.CommandText = "select max(copyno) from StockTable where accno ='" + txtAccNo.Text + "'";
                        int copy = (1 + (int)c.cmd.ExecuteScalar());

                        txtCopyNo.Text = "" + copy;

                        if (copy > 999)
                        {
                            txtCopyNo.Text = "999";
                            MessageBox.Show("Maximum Copies added! \nAdd as a new Book!", "Max Copies Added", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        txtCopyNo.Focus();
                    }

                    catch (Exception) { }
                }

                else
                {
                    string accno = Interaction.InputBox("Enter the Accno:", "Add a copy of the Book", "", -1, -1);

                    c.cmd.CommandText = "select count(*) from AccRegTable where accno='" + accno + "'";

                    if ((int)c.cmd.ExecuteScalar() > 0)
                    {
                        c.cmd.CommandText = "select * from AccRegTable where accno='" + accno + "'";
                        adp.SelectCommand = c.cmd;
                        dt.Clear();
                        adp.Fill(dt);
                        bds.DataSource = dt;

                        ClearAccRegDataBindings();
                        AddAccRegDataBindings();

                        ClearStockDataBindings();

                        state = "Add Copy";
                        stripCurrOps.Text = "Current Operation: " + state;
                        EnableControls(state);

                        try
                        {
                            c.cmd.CommandText = "select max(copyno) from StockTable where accno ='" + accno + "'";
                            int copy = (1 + (int)c.cmd.ExecuteScalar());
                            txtCopyNo.Text = "" + copy;

                            if (copy > 999)
                            {
                                txtCopyNo.Text = "999";
                                MessageBox.Show("Maximum Copies added! \nAdd as a new Book!", "Max Copies Added", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            txtCopyNo.Focus();
                        }

                        catch (Exception) { }

                    }

                    else
                    {
                        MessageBox.Show("Entry with accno:" + accno + " not found!", "Add Copy");
                        state = "";
                        stripCurrOps.Text = "Current Operation: " + state;
                        btnCancel_Click(this, EventArgs.Empty);
                    }
                }
            }

            catch (SqlException)
            {
                throw;
            }

            finally
            {
                c.cnn.Close();
                c2.cnn.Close();
            }
        }

        private void btnDeleteCopy_Click(object sender, EventArgs e)
        {

            try
            {
                if (c.cnn.State != ConnectionState.Open)
                {
                    c.cnn.Close();
                    c.cnn.Open();
                }

                if (state == "View")
                {
                    if (txtCopyNo.Text == "")
                    {
                        MessageBox.Show("No Copy found!", "Delete Copy");
                        return;
                    }

                    DialogResult diaRes = MessageBox.Show("Delete this Copy?\n\n Accno:" 
                        + txtAccNo.Text + "\n Copy Number:" + txtCopyNo.Text, 
                        "Delete Copy", MessageBoxButtons.OKCancel);

                    if (diaRes == DialogResult.Cancel)
                    {
                        return;
                    }

                    else if (diaRes == DialogResult.OK)
                    {
                        c.cmd.CommandText = "delete from StockTable where accno='"
                            + txtAccNo.Text + "' and copyno='" + txtCopyNo.Text + "'";

                        c.cmd.ExecuteNonQuery();
                        MessageBox.Show("Records Deleted!");

                        grpNav.Enabled = false;
                        grpCopyNav.Enabled = false;

                        DisableMainGroupbox();

                        state = "";
                        stripCurrOps.Text = "Current Operation: " + "Delete Copy";
                    }
                }

                else
                {
                    string accno = Interaction.InputBox("Enter the Accno:", "Enter Accno", "", -1, -1);

                    c.cmd.CommandText = "select count(*) from  AccRegTable where accno='" + accno + "'";

                    if ((int)c.cmd.ExecuteScalar() > 0)
                    {
                        string copyno = Interaction.InputBox("Enter the Copy Number:", "Copy Number", "", -1, -1);

                        c.cmd.CommandText = "select count(*) from StockTable where accno ='" + accno + "' and copyno='" + copyno + "'";

                        if ((int)c.cmd.ExecuteScalar() > 0)
                        {
                            c.cmd.CommandText = "select * from AccRegTable where accno='" + accno + "'";
                            c2.cmd.CommandText = "select * from StockTable where accno ='" + accno + "' and copyno ='" + copyno + "'";

                            dt.Clear();
                            dt2.Clear();

                            adp.SelectCommand = c.cmd;
                            adp.Fill(dt);
                            bds.DataSource = dt;

                            adp2.SelectCommand = c2.cmd;
                            adp2.Fill(dt2);
                            bds2.DataSource = dt2;

                            ClearAccRegDataBindings();
                            AddAccRegDataBindings();

                            ClearStockDataBindings();
                            AddStockDataBindings();

                            //Delete Copy starts here
                            c.cmd.CommandText = "delete from StockTable where accno ='" + accno + "' and copyno ='" + copyno + "'";
                            c.cmd.ExecuteNonQuery();
                            MessageBox.Show("Records Deleted! \nAccno:" + txtAccNo.Text + "\nCopy Number:" + copyno, "Delete Copy");

                            grpNav.Enabled = false;
                            grpCopyNav.Enabled = false;
                            DisableMainGroupbox();
                            //EnableControls();

                            state = "View";
                            stripCurrOps.Text = "Current Operation: " + "Delete Copy";
                        }

                        else MessageBox.Show("Invalid Copy Number!", "Delete Copy", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    else MessageBox.Show("Record with Accno:" + accno + " is Unavailable", "Delete Copy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (SqlException)
            {
                throw;
            }

            finally
            {
                c.cnn.Close();
                c2.cnn.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            state = "";
            btnClear_Click(this, EventArgs.Empty);
            DisableMainGroupbox();

            txtAccNo.ReadOnly = false;
            txtCopyNo.ReadOnly = false;

            btnSubmit.Enabled = false;
            btnCancel.Enabled = false;

            //switch (state)
            //{
            //    case "":
            //        btnClear_Click(this, EventArgs.Empty);
            //        DisableMainGroupbox();
            //        break;

            //    case "Add Copy":
            //        btnClear_Click(this, EventArgs.Empty);
            //        DisableMainGroupbox();
            //        break;

            //    case "Add":
            //        btnClear_Click(this, EventArgs.Empty);
            //        DisableMainGroupbox();
            //        break;

            //    case "Edit":
            //        btnClear_Click(this, EventArgs.Empty);
            //        DisableMainGroupbox();
            //        txtAccNo.ReadOnly = false;
            //        txtCopyNo.ReadOnly = false;
            //        break;

            //}


        }


        void ClearAccRegDataBindings()
        {
            ddlSection.DataBindings.Clear();
            ddlType.DataBindings.Clear();
            txtAccNo.DataBindings.Clear();

            foreach (Control c in grpCatalogDetails.Controls)
            {
                if (c is TextBox)
                {
                    (c as TextBox).DataBindings.Clear();
                }

                if (c is ComboBox)
                {
                    (c as ComboBox).DataBindings.Clear();
                }
                
            }
        }

        void ClearStockDataBindings()
        {
            foreach (Control c in grpCopyDetails.Controls)
            {
                if (c is TextBox)
                {
                    (c as TextBox).DataBindings.Clear();
                }

                if (c is ComboBox)
                {
                    (c as ComboBox).DataBindings.Clear();
                }

                if (c is DateTimePicker)
                    (c as DateTimePicker).DataBindings.Clear();
            }
        }

        void AddAccRegDataBindings()
        {
            txtAccNo.DataBindings.Add("text", bds, "accno");
            ddlSection.DataBindings.Add("text", bds, "section");
            ddlType.DataBindings.Add("text", bds, "type");

            txtTitle.DataBindings.Add("text", bds, "title");
            txtSubTitle.DataBindings.Add("text", bds, "subtitle");
            
            txtAuthor.DataBindings.Add("text", bds, "author");
            txtEditor.DataBindings.Add("text", bds, "editor");

            txtVolume.DataBindings.Add("text", bds, "volume");
            
            txtSeries.DataBindings.Add("text", bds, "series");
            txtISBN.DataBindings.Add("text", bds, "isbn");

            ddlLanguage.DataBindings.Add("text", bds, "language");
            txtKeyword.DataBindings.Add("text", bds, "keyword");
            txtRemark.DataBindings.Add("text", bds, "remarks");

            ddlSub1.DataBindings.Add("text", bds, "subject");
            ddlSub2.DataBindings.Add("text", bds, "subject2");
            
            txtCallNo.DataBindings.Add("text", bds, "callno");
            txtClsNo.DataBindings.Add("text", bds, "classno");

            txtPubYear.DataBindings.Add("text", bds, "pubyear");
            txtPlace.DataBindings.Add("text", bds, "place");
            txtPublisher.DataBindings.Add("text", bds, "publisher");
        
        }

        void AddStockDataBindings()
        {

            txtCopyNo.DataBindings.Add("text", bds2, "copyno");
            ddlVendor.DataBindings.Add("text", bds2, "vendor");
            ddlSource.DataBindings.Add("text", bds2, "source");
            ddlCurency.DataBindings.Add("text", bds2, "currency");
            ddlDept.DataBindings.Add("text", bds2, "dept");
            txtEdition.DataBindings.Add("text", bds2, "edition");

            txtBillNo.DataBindings.Add("text", bds2, "billno");
            dtBilldate.DataBindings.Add("text", bds2, "billdate");
            txtDiscount.DataBindings.Add("text", bds2, "discount");
            ddlStatus.DataBindings.Add("text", bds2, "status");
            ddlCategory.DataBindings.Add("text", bds2, "category");
            txtPrice.DataBindings.Add("text", bds2, "price");
            txtNetCost.DataBindings.Add("text", bds2, "netcost");
            txtPages.DataBindings.Add("text", bds2, "pages");
            txtLocation.DataBindings.Add("text", bds2, "location");
            ddlBinding.DataBindings.Add("text", bds2, "binding");
            txtCopyYear.DataBindings.Add("text", bds2, "copyyear");
        }

        private void NumValidations(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != 0)
            {

                stripError.Text = "Error: Enter a number!";
                e.Handled = true;

                return;
            }

            stripError.Text = "...";
        }

        private void AlphaValidations(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)
                && !char.IsWhiteSpace(e.KeyChar))
            {
                stripError.Text = "Enter only Letters!";
                e.Handled = true;

                return;
            }

            stripError.Text = "...";
        }

        private void AlphaNumValidations(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar)
                && !char.Equals(e.KeyChar, '-'))
            {
                stripError.Text = "Error: Enter only Letters or Digits";
                e.Handled = true;

                return;
            }

            stripError.Text = "...";
        }

        private void btnStockLookup_Click(object sender, EventArgs e)
        {
            Stock_08 objStockLookup = new Stock_08();

            if (state == "View")
            {
                objStockLookup.accno = txtAccNo.Text;
            } 
            objStockLookup.Show();
        }


        private void btnFirst_Click(object sender, EventArgs e)
        {
            bds.MoveFirst();
            StockBindingUpdate();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            bds.MovePrevious();
            StockBindingUpdate();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bds.MoveNext();
            StockBindingUpdate();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bds.MoveLast();
            StockBindingUpdate();
        }

        private void btnCopyFirst_Click(object sender, EventArgs e)
        {
            bds2.MoveFirst();
        }

        private void btnCopyPrev_Click(object sender, EventArgs e)
        {
            bds2.MovePrevious();
        }

        private void btnCopyNext_Click(object sender, EventArgs e)
        {
            bds2.MoveNext();
        }

        private void btnCopyLast_Click(object sender, EventArgs e)
        {
            bds2.MoveLast();
        }

        private void btnNet_Click(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "" || txtPrice.Text == "")
            {
                txtNetCost.Text = "";
                return;
            }

            int cost = Convert.ToInt16(txtPrice.Text);
            int discount = Convert.ToInt16(txtDiscount.Text);

            if (discount > 100)
            {
                stripError.Text = "Discount is Greater than 100%";
                txtNetCost.Text = "";
                return;
            }
            int net = (cost - (cost * discount / 100));

            txtNetCost.Text = net.ToString();
        }

        void ListUpdates()
        {
            DdlUpdate("select name, address from VendorTable", ddlVendor);

            DdlListUpdate("select list from _LanguageTable", ddlLanguage);
            DdlListUpdate("select list from _SubjectTable", ddlSub1);
            DdlListUpdate("select list from _SubjectTable", ddlSub2);
            DdlListUpdate("select list from _SourceTable", ddlSource);
            DdlListUpdate("select list from _CategoryTable", ddlCategory);
            DdlListUpdate("select list from _CurrencyTable", ddlCurency);
            DdlListUpdate("select list from _DeptTable", ddlDept);
        }

        private void btnLang_Click(object sender, EventArgs e)
        {
            AccRegButtons_04a objButton = new AccRegButtons_04a();
            objButton.currentTable = "_LanguageTable";
            objButton.Closed += new EventHandler(objButton_Closed);
            objButton.Show();
        }

        void objButton_Closed(object sender, EventArgs e)
        {
            ListUpdates();
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            AccRegButtons_04a objButton = new AccRegButtons_04a();
            objButton.currentTable = "_SubjectTable";
            objButton.Closed += new EventHandler(objButton_Closed);
            objButton.Show();
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            AccRegButtons_04a objButton = new AccRegButtons_04a();
            objButton.currentTable = "_SourceTable";
            objButton.Closed += new EventHandler(objButton_Closed);
            objButton.Show();
        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            AccRegButtons_04a objButton = new AccRegButtons_04a();
            objButton.currentTable = "_CurrencyTable";
            objButton.Closed += new EventHandler(objButton_Closed);
            objButton.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            AccRegButtons_04a objButton = new AccRegButtons_04a();
            objButton.currentTable = "_CategoryTable";
            objButton.Closed += new EventHandler(objButton_Closed);
            objButton.Show();
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            AccRegButtons_04a objButton = new AccRegButtons_04a();
            objButton.currentTable = "_DeptTable";
            objButton.Closed += new EventHandler(objButton_Closed);
            objButton.Show();
        }

    }
}