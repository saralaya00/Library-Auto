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
    public partial class GenerateBill_10d : Form
    {
        public Administration_03 adminInstance = new Administration_03();

        Connect c = new Connect();
        DataTable dt = new DataTable();
        DataTable dtAcc = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter();
        SqlDataAdapter adp2 = new SqlDataAdapter();
        BindingSource bds = new BindingSource();
        BindingSource bds2 = new BindingSource();

        bool clearSkip = false;
        bool noPurOrd = false;

        public GenerateBill_10d()
        {
            InitializeComponent();
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

            if (clearSkip) return;

            if (adminInstance != null)
            {
                adminInstance.Show();
            }

            if (noPurOrd)
            {
                adminInstance.createOrderToolStripMenuItem1_Click(this, EventArgs.Empty);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearSkip = true;

            this.Close();
            adminInstance.generateBillToolStripMenuItem1_Click(this, null);
        }

        private void GenerateBill_10d_Load(object sender, EventArgs e)
        {
            BillDatePicker.Value = DateTime.Today;
            grpBookInfo.Enabled = false;
            btnSave.Enabled = false;
            btnNext.Enabled = false;
            btnClear.Enabled = false;
            c.cmd.CommandText = "select distinct orderno from CreateOrderTable";
            adp.SelectCommand = c.cmd;
            dt.Clear();
            adp.Fill(dt);
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
              ddlOrderNo.Items.Add(dt.Rows[i].ItemArray[0]);
            }

            if (ddlOrderNo.Items.Count <= 0)
            {
                MessageBox.Show("No Purchase Orders present to Generate the Bill \nUse the Purchase Bill to create a Order",
                    "No Purchase Order!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                noPurOrd = true;
                this.Close();
            }
           
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            grpBookInfo.Enabled = true;
            grpBillDetails.Enabled = true;
            grpOrderInfo.Enabled = true;

            foreach (Control ctrl in grpBookInfo.Controls)
            {
                if (ctrl is TextBox) (ctrl as TextBox).Clear();
            }

            foreach (Control ctrl in grpOrderInfo.Controls)
            {
                if (ctrl is TextBox) (ctrl as TextBox).Clear();
            }

            BillDatePicker.Text = DateTime.Today.Date.ToString();

            ddlOrderNo.SelectedItem = null;
            ddlAccno.SelectedItem = null;

            dtODate.Enabled = false;
            txtVenId.Enabled = false;
            txtName.Enabled = false;
            txtEmail.Enabled = false;
            txtAddress.Enabled = false;

            txtTitle.Enabled = false;
            txtAuthor.Enabled = false;
            txtPublisher.Enabled = false;

            btnSave.Enabled = true;
            btnNext.Enabled = false;
            btnClear.Enabled = true;

            c.cmd.CommandText = "select max(billno) from GenerateBillTable";
            txtBillNo.Text = (c.cmd.ExecuteScalar() == DBNull.Value) ? "1" : Convert.ToString(1 + (int)c.cmd.ExecuteScalar());
            txtBillNo.ReadOnly = true;
            
        }
        
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ddlAccno.Items.Count <= 0)
            {
                MessageBox.Show("No More items in this Purchase Order!", "No Item!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNew_Click(this, EventArgs.Empty);   
            }

            ddlAccno.SelectedItem = null;
            ddlAccno.Enabled = true;

            txtTitle.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            txtNoCopy.Clear();
            txtPrice.Clear();
            txtDiscount.Clear();
            txtNetCost.Clear();
            txtTAmount.Clear();

            btnSave.Enabled = true;
            btnNext.Enabled = false;
        }

        private void ddlOrderNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
            string orderNo;
            BindingSource bds = new BindingSource();

            orderNo = ddlOrderNo.SelectedItem.ToString();
            
            c.cmd.Parameters.Clear();
            c.cmd.CommandText = "select orderdate, vendorid, name, email, address from CreateOrderTable where orderno='" + orderNo + "'";
            
            adp.SelectCommand = c.cmd;
            dt.Clear();
            adp.Fill(dt);
            bds.Clear();
            bds.DataSource = dt;

            dtODate.DataBindings.Clear();
            txtVenId.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtAddress.DataBindings.Clear();

            dtODate.DataBindings.Add("text", bds, "orderdate");
            txtVenId.DataBindings.Add("text", bds, "vendorid");
            txtName.DataBindings.Add("text", bds, "name");
            txtEmail.DataBindings.Add("text", bds, "email");
            txtAddress.DataBindings.Add("text", bds, "address");


            ddlAccno.Items.Clear();

            c.cmd.CommandText="select accno from CreateOrderTable where orderno ='" + orderNo + "'";
            adp.SelectCommand=c.cmd;
            dtAcc.Clear();
            adp.Fill(dtAcc);

            DataTable dtAccBill = new DataTable();
            c.cmd.CommandText = "select accno from GenerateBillTable where orderno ='" + orderNo + "'";
            adp.SelectCommand = c.cmd;
            adp.Fill(dtAccBill);

            for(int i = 0; i < dtAcc.Rows.Count; i++)
            {
                ddlAccno.Items.Add(dtAcc.Rows[i].ItemArray[0]);
            }

            for (int i = 0; i < dtAccBill.Rows.Count; i++)
            {
                if (ddlAccno.Items.Contains((string)dtAccBill.Rows[i].ItemArray[0]))
                {
                    ddlAccno.Items.Remove((string)dtAccBill.Rows[i].ItemArray[0]);
                }
            }

            DataTable dtGrid = new DataTable();
            c.cmd.CommandText = "select * from GenerateBillTable where orderno ='" + orderNo + "'";
            adp.SelectCommand = c.cmd;
            adp.Fill(dtGrid);
            dataGridView1.DataSource = dtGrid;
        }

        private void ddlAccno_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //SqlDataAdapter adp  =new SqlDataAdapter();    
            //DataTable dt=new DataTable();
            //BindingSource bds =new BindingSource();

            if (c.cnn.State != ConnectionState.Open) { c.cnn.Close(); c.cnn.Open(); }
           
            c.cmd.CommandText="select count(*) from GenerateBillTable where accno='" + ddlAccno.SelectedItem.ToString() + "' and  orderno='"+ddlOrderNo.Text+"'";
            int a = (int) c.cmd.ExecuteScalar();
            
            if (a > 0)
            {
                MessageBox.Show("Invoice already generated for  this Book", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
            else
            {
                DataTable dtDummy = new DataTable();
                
                c.cmd.CommandText = "select title, author, publisher, noofcopies from CreateOrderTable where orderno ='"+ddlOrderNo.SelectedItem.ToString()+"' and accno ='"+ddlAccno.SelectedItem.ToString()+"'";
                adp.SelectCommand = c.cmd;
                adp.Fill(dtDummy);
                bds2.DataSource = dtDummy;
                
                txtTitle.DataBindings.Clear();
			    txtAuthor.DataBindings.Clear();
			    txtPublisher.DataBindings.Clear();
			    txtNoCopy.DataBindings.Clear();
																
                txtTitle.DataBindings.Add("text", bds2, "title");
                txtAuthor.DataBindings.Add("text", bds2, "author");
                txtPublisher .DataBindings.Add("text", bds2, "publisher");
                txtNoCopy.DataBindings.Add("text", bds2, "noofcopies");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlAccno.SelectedItem == null)
            {
                MessageBox.Show("Select an Item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPrice.Text == "" || txtDiscount.Text == "") 
            {
                MessageBox.Show("Enter the price and Discount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                c.cmd.Parameters.Clear();
                c.cmd.CommandText="insert into GenerateBilltable values(@billno,@billdate,@orderno,@orderdate,@vendorid,@name,@accno,@title,@author,@publisher,@noofcopies,@price,@totamt)";
               
                c.cmd.Parameters.Add("@billno", SqlDbType.VarChar).Value = txtBillNo.Text;
                c.cmd.Parameters.Add("@billdate",SqlDbType.VarChar).Value=BillDatePicker.Text;
                c.cmd.Parameters.Add("@orderno",SqlDbType.VarChar).Value=ddlOrderNo.Text;
                c.cmd.Parameters.Add("@orderdate",SqlDbType.VarChar).Value=dtODate.Text;
                c.cmd.Parameters.Add("@vendorid",SqlDbType.VarChar).Value=txtVenId.Text;
                c.cmd.Parameters.Add("@name",SqlDbType.VarChar).Value=txtName.Text;
                c.cmd.Parameters.Add("@accno",SqlDbType.VarChar).Value=ddlAccno.Text;
                c.cmd.Parameters.Add("@title",SqlDbType.VarChar).Value=txtTitle.Text;
                c.cmd.Parameters.Add("@author",SqlDbType.VarChar).Value=txtAuthor.Text;
                c.cmd.Parameters.Add("@publisher",SqlDbType.VarChar).Value=txtPublisher.Text;
                c.cmd.Parameters.Add("@noofcopies",SqlDbType.VarChar).Value=txtNoCopy.Text;
                c.cmd.Parameters.Add("@price", SqlDbType.VarChar).Value = txtPrice.Text;
              
                int noofcopies, price;
                noofcopies = Convert.ToInt16(txtNoCopy.Text);
                price = Convert.ToInt16(txtPrice.Text);
                txtTAmount.Text = "" + noofcopies * price;

                c.cmd.Parameters.Add("@totamt",SqlDbType.VarChar).Value=txtTAmount.Text;
                c.cmd.ExecuteNonQuery();

                MessageBox.Show("Invoice information saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnSave.Enabled = false;
                btnNext.Enabled = true;

                DataTable dtBill = new DataTable();
                c.cmd.CommandText = "select * from GenerateBillTable ORDER BY billno ASC";
                adp.SelectCommand = c.cmd;
                adp.Fill(dtBill);
                dataGridView1.DataSource = dtBill;

                //Auto Insert to StockTable
                c.cmd.CommandText = "select count(*) from StockTable where accno = '" + ddlAccno.Text + "'";

                if ((int)c.cmd.ExecuteScalar() <= 0)
                {
                    MessageBox.Show("Could not find copy details of the Book!"
                        + " \nManually insert the Book details in AccRegister");

                    ddlAccno.Items.Remove(ddlAccno.SelectedItem.ToString());
                    ddlAccno.Enabled = false;
                    return;
                }

                c.cmd.CommandText = "select max(copyno) from StockTable where accno = '" + ddlAccno.Text + "'";
                if (((int) c.cmd.ExecuteScalar() + noofcopies) > 999)
                {
                    MessageBox.Show("Maximum Number of Copies have been added!!"
                        + " \nManually insert the Book details as new in AccRegister");

                    ddlAccno.Items.Remove(ddlAccno.SelectedItem.ToString());
                    ddlAccno.Enabled = false;
                    return;
                }

                string msg;
                msg = noofcopies + " copies added to Stock, \n Copy Numbers are :";

                for (int i = 0; i < noofcopies; i++)
                {
                    c.cmd.CommandText = "select max(copyno) from StockTable where accno = '" + ddlAccno.Text + "'";
                    int copyno = (c.cmd.ExecuteScalar() == DBNull.Value) ? 1 : 1 + (int)c.cmd.ExecuteScalar();
                    msg += " " + copyno;

                    c.cmd.CommandText = "select * from StockTable where accno ='" + ddlAccno.Text + "' and copyno =" + (copyno - 1);
                    DataTable dtStock = new DataTable();
                    adp.SelectCommand = c.cmd;
                    adp.Fill(dtStock);

                    c.cmd.CommandText = "insert into StockTable values(@accno, @copyno, @vendor, @source, @currency, @dept, @edition, @billno, @billdate, @discount, @status, @category, @price, @netcost, @pages, @location, @binding, @copyyear)";
                    c.cmd.Parameters.Clear();
                    c.cmd.Parameters.AddWithValue("@accno", ddlAccno.Text);
                    c.cmd.Parameters.AddWithValue("@copyno", copyno);
                    c.cmd.Parameters.AddWithValue("@vendor", txtName.Text + " " + txtAddress.Text + " ");
                    c.cmd.Parameters.AddWithValue("@source", (string)dtStock.Rows[0].ItemArray[3]);
                    c.cmd.Parameters.AddWithValue("@currency", (string)dtStock.Rows[0].ItemArray[4]);
                    c.cmd.Parameters.AddWithValue("@dept", (string)dtStock.Rows[0].ItemArray[5]);
                    c.cmd.Parameters.AddWithValue("@edition", (string)dtStock.Rows[0].ItemArray[6]);
                    c.cmd.Parameters.AddWithValue("@billno", txtBillNo.Text);
                    c.cmd.Parameters.AddWithValue("@billdate", BillDatePicker.Value);
                    c.cmd.Parameters.AddWithValue("@discount", txtDiscount.Text);
                    c.cmd.Parameters.AddWithValue("@status", "Available");
                    c.cmd.Parameters.AddWithValue("@category", (string)dtStock.Rows[0].ItemArray[11]);
                    c.cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                    c.cmd.Parameters.AddWithValue("@netcost", txtNetCost.Text);
                    c.cmd.Parameters.AddWithValue("@pages", (string)dtStock.Rows[0].ItemArray[14]);
                    c.cmd.Parameters.AddWithValue("@location", (string)dtStock.Rows[0].ItemArray[15]);
                    c.cmd.Parameters.AddWithValue("@binding", (string)dtStock.Rows[0].ItemArray[16]);
                    c.cmd.Parameters.AddWithValue("@copyyear", (string)dtStock.Rows[0].ItemArray[17]);

                    c.cmd.ExecuteNonQuery();
                }

                MessageBox.Show(msg, "Copies Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ddlAccno.Items.Remove(ddlAccno.SelectedItem.ToString());
                ddlAccno.Enabled = false;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Enter Only Numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }  
        }

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Enter Only Numbers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }  
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int price, discount, netCost, copies;
                price = Convert.ToInt32(txtPrice.Text);
                discount = Convert.ToInt32(txtDiscount.Text);

                if (discount > 100 || discount < 0)
                {
                    throw new FormatException();
                }

                copies = Convert.ToInt32(txtNoCopy.Text);

                netCost =  price - (price * discount / 100);
                txtNetCost.Text = "" + netCost;
                txtTAmount.Text = "" + copies * netCost;

                btnSave.Enabled = true;
            }

            catch (FormatException)
            {
                btnSave.Enabled = false;
            }
        }

        //Number Validations
        private void NumValidations(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                && e.KeyChar != 0)
            {
                MessageBox.Show("Enter only numbers!");
                e.Handled = true;

                return;
            }
        }

        
    }
}