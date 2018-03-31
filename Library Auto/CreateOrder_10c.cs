using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using Library_Auto.Crystal_Reports;

namespace Library_Auto
{
    public partial class CreateOrder_10c : Form
    {

        public Administration_03 adminInstance;

        Connect c = new Connect();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter();

        bool clearSkip = false;

        public CreateOrder_10c()
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

            if (clearSkip) return;
            if (adminInstance != null) adminInstance.Show();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            c.cmd.CommandText = "delete from CreateOrderDummy";
            c.cmd.ExecuteNonQuery();

            clearSkip = true;

            this.Close();
            adminInstance.createOrderToolStripMenuItem1_Click(this, EventArgs.Empty);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnNext.Enabled = false;

            grpBookInfo.Enabled = true;

            foreach (Control ctr in grpVendorInfo.Controls)
            {
                if (ctr is TextBox)
                {   
                    (ctr as TextBox).ReadOnly = true;
                }
            }

            foreach (Control ctr in grpBookInfo.Controls)
            {
                if (ctr is TextBox)
                {
                    (ctr as TextBox).ReadOnly = false;
                }
            }

            txtOrderNo.ReadOnly = true;
            ddlAccno.SelectedItem = null;

            foreach (Control ctr in grpBookInfo.Controls)
            {
                if (ctr is TextBox)
                {
                  if  ((ctr as TextBox).Name != txtOrderNo.Name)
                    (ctr as TextBox).Clear();
                }
            }

        }

        private void DdlUpdate(string cmdText, ComboBox ddlToFill)
        {
            DataTable dtDummy = new DataTable();
            string itemToAdd = "";

            try
            {

                c.cmd.CommandText = cmdText;
                adp.SelectCommand = c.cmd;
                adp.Fill(dtDummy);

                for (int i = 0; i < dtDummy.Rows.Count; i++)
                {
                    itemToAdd = (string)dtDummy.Rows[i].ItemArray[0] ;

                    if (!ddlToFill.Items.Contains(itemToAdd))
                    {
                        ddlToFill.Items.Add(itemToAdd);
                    }
                }
            }

            catch (Exception ex)
            {
                adminInstance.errObj.txtException.Text += ex.ToString();
                adminInstance.errObj.Show();

                this.Close();
            }
        }

        private void CreateOrder_10c_Load(object sender, EventArgs e)
        {

            foreach (Control ctr in grpVendorInfo.Controls)
            {
                if (ctr is TextBox)
                {
                    (ctr as TextBox).ReadOnly = true;
                }
            }

            ddlVenId.Enabled = false;
            OrderDatePicker.Enabled = false;
            ddlAccno.Enabled = false;
            
            foreach (Control ctr in grpBookInfo.Controls)
            {
                if (ctr is TextBox)
                {
                    (ctr as TextBox).ReadOnly = true;
                }
            }

            btnNext.Enabled = false;
            btnClear.Enabled = false;

            DdlUpdate("select * from VendorTable", ddlVenId);
            DdlUpdate2("select * from AccRegTable", ddlAccno);
        }

        private void DdlUpdate2(string p, ComboBox ddlAccno)
        {
            DataTable dtDummy2 = new DataTable();
            string ItemToAdd = "";
            try
            {
                //if (!ddlToFill.Items.Contains("(None)"))
                //    ddlToFill.Items.Add("(None)");

                c.cmd.CommandText = p;
                adp.SelectCommand = c.cmd;
                adp.Fill(dtDummy2);

                for (int i = 0; i < dtDummy2.Rows.Count; i++)
                {
                    ItemToAdd = (string)dtDummy2.Rows[i].ItemArray[0];

                    if (!ddlAccno.Items.Contains(ItemToAdd))
                    {
                        ddlAccno.Items.Add(ItemToAdd);
                    }
                }
            }

            catch (Exception)
            {
                //adminInstance.errObj.txtException.Text += ex.ToString();
                //adminInstance.errObj.Show();

                //this.Close();
            }
            
        }

        private void UpdateVendorInfo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dtVendor = new DataTable();

            c.cmd.CommandText = "select name, address, phoneno, email from VendorTable where vendorid ='" + ddlVenId.SelectedItem + "'";
            adp.SelectCommand = c.cmd;
            adp.Fill(dtVendor);

            txtName.Text = "" + dtVendor.Rows[0].ItemArray[0];
            txtAddress.Text = "" + dtVendor.Rows[0].ItemArray[1];
            txtPhno.Text = "" + dtVendor.Rows[0].ItemArray[2];
            txtEmail.Text = "" + dtVendor.Rows[0].ItemArray[3];
        }

        private void UpdateAccRegTableInfo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtTitle.ReadOnly = true;
            txtAuthor.ReadOnly = true;
            txtPublisher.ReadOnly = true;

            if (ddlAccno.SelectedItem == null) return;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (ddlAccno.SelectedItem.ToString() == (string) dt.Rows[i].ItemArray[2])
                {
                    lblError.Text = "Error : Item already selected!";
                    ddlAccno.SelectedItem = null;
                    foreach (Control ctrl in grpBookInfo.Controls) { if (ctrl is TextBox) (ctrl as TextBox).Clear(); }

                    return;
                }
            }

            lblError.Text = "...";

            DataTable dtAccReg = new DataTable();

            c.cmd.CommandText = "select title, author, publisher from AccRegTable where accno ='" + ddlAccno.SelectedItem + "'";
            adp.SelectCommand = c.cmd;
            adp.Fill(dtAccReg);

            txtTitle.Text = "" + dtAccReg.Rows[0].ItemArray[0];
            txtAuthor.Text = "" + dtAccReg.Rows[0].ItemArray[1];
            txtPublisher.Text = "" + dtAccReg.Rows[0].ItemArray[2];
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ddlVenId.Enabled = true;
            ddlAccno.Enabled = true;

            ddlVenId.SelectedItem = null;
            ddlAccno.SelectedItem = null;

            txtTitle.ReadOnly = false;
            txtAuthor.ReadOnly = false;
            txtPublisher.ReadOnly = false;
            txtNoCopy.ReadOnly = false;

            btnAdd.Enabled = true;
            btnNext.Enabled = false;
            btnClear.Enabled = true;
            btnSubmit.Enabled = false;

            grpBookInfo.Enabled = true;


            //Empty CreateOrderDummy
            c.cmd.CommandText = "delete from CreateOrderDummy";
            c.cmd.ExecuteNonQuery();

            dt.Clear();

            foreach (Control ctrl in grpBookInfo.Controls) { if (ctrl is TextBox) (ctrl as TextBox).Clear(); }
            foreach (Control ctrl in grpVendorInfo.Controls) { if (ctrl is TextBox) (ctrl as TextBox).Clear(); }

            int orderNo;
            c.cmd.CommandText = "select max(orderno) from CreateOrderTable";

            if (c.cmd.ExecuteScalar() == DBNull.Value)
            {
                orderNo = 1;
            }

            else orderNo = (int)c.cmd.ExecuteScalar() + 1;

            txtOrderNo.Text = "" + orderNo;
            txtOrderNo.ReadOnly = true;
        }

       private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlVenId.SelectedItem == null || ddlAccno.SelectedItem == null)
            {
                return;
            }

            if (txtNoCopy.Text == "")
            {
                lblError.Text = "Error : Enter the number of Copies!";
                return;
            }


            btnAdd.Enabled = false;
            btnNext.Enabled = true;
            btnSubmit.Enabled = true;

            c.cmd.Parameters.Clear();
            c.cmd.CommandText = "insert into CreateOrderDummy values (@orderno,@orderdate,@accno,@vendorid,@name,@email,@address,@phoneno,@title,@author,@publisher,@noofcopies)";

            c.cmd.Parameters.Add("@orderno", SqlDbType.Int).Value = Convert.ToInt32(txtOrderNo.Text);
            c.cmd.Parameters.Add("@orderdate", SqlDbType.DateTime).Value = OrderDatePicker.Value.ToShortDateString();
            c.cmd.Parameters.Add("@accno", SqlDbType.VarChar).Value = ddlAccno.Text;
            c.cmd.Parameters.Add("@vendorid", SqlDbType.VarChar).Value = ddlVenId.Text;
            c.cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = txtName.Text;
            c.cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text;
            c.cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = txtAddress.Text;
            c.cmd.Parameters.Add("@phoneno", SqlDbType.VarChar).Value = txtPhno.Text;
            c.cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = txtTitle.Text;
            c.cmd.Parameters.Add("@author", SqlDbType.VarChar).Value = txtAuthor.Text;
            c.cmd.Parameters.Add("@publisher", SqlDbType.VarChar).Value = txtPublisher.Text;
            c.cmd.Parameters.Add("@noofcopies", SqlDbType.Int).Value = Convert.ToInt32(txtNoCopy.Text);

            c.cmd.ExecuteNonQuery();
            MessageBox.Show("Books Inserted");

            ddlVenId.Enabled = false;
            grpBookInfo.Enabled = false;
            c.cmd.CommandText = "select * from CreateOrderDummy where orderno='" + txtOrderNo.Text + "'";
            adp.SelectCommand = c.cmd;
            dt.Clear();
            adp.Fill(dt);
            dgCreateOrder.DataSource = dt;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            c.cmd.CommandText = "insert into CreateOrderTable"
                                + " Select * from CreateOrderDummy";
            c.cmd.ExecuteNonQuery();

            MessageBox.Show("Order Created!");

            c.cmd.CommandText = "delete from CreateOrderDummy";
            c.cmd.ExecuteNonQuery();

            DialogResult diaRes = MessageBox.Show("Open Purchase Report?", "Export Report", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (diaRes == DialogResult.OK)
            {
                Purchase_Order_rpt objPurRpt = new Purchase_Order_rpt();
                objPurRpt.txtSearch.Text = txtOrderNo.Text;
                objPurRpt.ddlTextType.SelectedItem = "Order Number";
                objPurRpt.btnDisplayTextbased_Click(this, EventArgs.Empty);
                objPurRpt.TopMost = true;

                objPurRpt.Show();
            }

            this.Close();
            //btnClear_Click(this, EventArgs.Empty);
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

            lblError.Text = "...";
        }
    }
}