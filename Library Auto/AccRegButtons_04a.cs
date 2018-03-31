using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace Library_Auto
{
    public partial class AccRegButtons_04a : Form
    {
        public string currentTable;
        Connect c = new Connect();

        SqlDataAdapter adp = new SqlDataAdapter();
        DataTable dt = new DataTable();


        public AccRegButtons_04a()
        {
            InitializeComponent();
        }

        private void AccRegButtons_04a_Load(object sender, EventArgs e)
        {
            string ops = currentTable;

            ops = ops.Substring(1, ops.Length - 6);
            lblOps.Text += ops;
            this.Text = "Add : " + ops;

            SelectList();
        }

        private void SelectList()
        {
            string itemToAdd;

            c.cmd.CommandText = "select list from " + currentTable;
            adp.SelectCommand = c.cmd;
            dt.Clear();
            adp.Fill(dt);

            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                itemToAdd = (string)dt.Rows[i].ItemArray[0];
                if (!adderList.Items.Contains(itemToAdd))
                    adderList.Items.Add(itemToAdd);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAdd.Text == "") return;

            c.cmd.CommandText = "select count(*) from " + currentTable + " where list = '" + txtAdd.Text + "'";

            if ((int)c.cmd.ExecuteScalar() <= 0)
            {
                c.cmd.CommandText = "insert into " + currentTable + " values(@list)";
                c.cmd.Parameters.Clear();
                c.cmd.Parameters.Add("@list", SqlDbType.VarChar).Value = txtAdd.Text;
                c.cmd.ExecuteNonQuery();
            }

            txtAdd.Clear();
            txtAdd.Focus();

            SelectList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            c.cmd.CommandText = "select count(*) from " + currentTable + " where list = '" + adderList.SelectedItem.ToString() +"'";

            if ((int)c.cmd.ExecuteScalar() > 0)
            {
                c.cmd.CommandText = "delete from " + currentTable + " where list=@list";
                c.cmd.Parameters.Clear();
                c.cmd.Parameters.Add("@list", SqlDbType.VarChar).Value = adderList.SelectedItem.ToString();
                c.cmd.ExecuteNonQuery();

                adderList.Items.Remove(adderList.SelectedItem.ToString());
                
            }

            SelectList();
        }

    }
}