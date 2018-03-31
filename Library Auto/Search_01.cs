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
    public partial class Search_01 : Form
    {
        public Administration_03 adminInstance;

        Connect c = new Connect();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataTable dt = new DataTable();
        
        public Search_01()
        {
            InitializeComponent();
        }

        private void Search_01_Load(object sender, EventArgs e)
        {
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
            adminInstance.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dt.Clear();

            foreach (Control ctrl in grpSimple.Controls)
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Clear();
                }

                if (ctrl is ComboBox)
                {
                    (ctrl as ComboBox).SelectedItem = null;
                    (ctrl as ComboBox).Text = "";
                }
            }

            foreach (Control ctrl in grpAdv.Controls)
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Clear();
                }

                if (ctrl is ComboBox)
                {
                    (ctrl as ComboBox).SelectedItem = null;
                    (ctrl as ComboBox).Text = "";
                }
            }

            foreach (Control ctrl in grpTxtFormat.Controls)
            {
                if (ctrl is RadioButton)
                {
                    (ctrl as RadioButton).Checked = false;
                } 
            }

            radoAll.Checked = true;
            radoFull.Checked = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dataGridView1.Refresh();

            if (cbAccno.Checked)
            {
                c.cmd.CommandText = "select * from AccRegTable where accno='" + txtAccno.Text + "'";
                FillGrid();

                return;
            }

            if (cbKeyword.Checked)
            {
                string keyword = (txtKeyword.Text == "") ? null : SearchType(txtKeyword.Text);

                if (radoFull.Checked)
                {
                    keyword = "%" + keyword + "%";    
                }

                if (keyword != null)
                {
                    c.cmd.CommandText = "select * from AccRegTable where keyword like '" + keyword + "'" + SetBookType();
                    FillGrid();
                    return;
                }

                else return;
            }

            if (cbYear.Checked)
            {
                string year = (txtYear.Text == "") ? null : txtYear.Text;

                if (year != null)
                {
                    c.cmd.CommandText = "select * from AccRegTable where pubyear like '" + year + "'" + SetBookType();
                    FillGrid();
                    return;
                }
                else return;
            }

            string title, author;
            title = (txtTitle1.Text == "") ? null : SearchType(txtTitle1.Text);
            author = (txtAuthor1.Text == "") ? null : SearchType(txtAuthor1.Text);

            if (title == null)
            {
                c.cmd.CommandText = "select * from AccRegTable where author like '" + author + "'" + SetBookType();
                FillGrid();
                return;
            }

            else if (author == null)
            {
                c.cmd.CommandText = "select * from AccRegTable where title like '" + title + "'" + SetBookType();
                FillGrid();
                return;
            }

            if (ddlLogical.SelectedItem == null)
            {
                return;
            } 

            c.cmd.CommandText = "select * from AccRegTable where title like '" + title + "' " + ddlLogical.SelectedItem + " author like '" + author + "'" + SetBookType();
            FillGrid();
            return;

        }

        private string SetBookType()
        {
            if (radoBook.Checked) return " and (type ='Book' or type ='Book + CD')";
            if (radoMagazine.Checked) return " and (type = 'Magazine' or type = 'Magazine + CD')";
            if (radoJournal.Checked) return " and (type = 'Journal' or type = 'Journal + CD')";
            if (radoAll.Checked) return "";

            return "";
        }

        private string SearchType(string str)
        {

            if (radoLetter.Checked)
            {
                str = str[0] + "%";
                return str;
            }

            if (radoWordBeg.Checked)
            {
                try
                {
                    str = str.Substring(0, str.IndexOf(" "));
                    str = str + "%";
                    return str;
                }

                catch (ArgumentOutOfRangeException)
                {
                    str = str + "%";
                    return str;
                }
            }

            if (radoFull.Checked)
            {
                return str;
            }

            return str;
        }

        private void FillGrid()
        {
            //Fills The grid based on the Command Text
            adp.SelectCommand = c.cmd;
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
        }



        private void txtTitle1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            c.cmd.CommandText = "select * from AccRegTable";
            adp.SelectCommand = c.cmd;
            dt.Clear();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;

        }

        private void cbAdvSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAdvSearch.Checked)
            {
                grpAdv.Enabled = true;
                grpSimple.Enabled = false;
            }

            else
            {
                grpAdv.Enabled = false;
                grpSimple.Enabled = true;

                foreach (Control rados in grpAdv.Controls)
                {
                    if (rados is RadioButton)
                    {
                        (rados as RadioButton).Checked = false;
                    }
                }
            }
        }

        private void cbAccno_CheckedChanged(object sender, EventArgs e)
        {
            dt.Clear();

            if (cbAccno.Checked)
            {
                txtAccno.Enabled = true;
            }

            else
            {
                txtAccno.Enabled = false;
                txtAccno.Clear();
            }
        }

        private void chSection_CheckedChanged(object sender, EventArgs e)
        {
            dt.Clear();

            if (cbSection.Checked)
            {
                ddlSection.Enabled = true;
            }

            else
            {
                ddlSection.Enabled = false;
                ddlSection.SelectedItem = null;
            } 
        }

        private void ddlSection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dt.Clear();
            c.cmd.CommandText = "select * from AccRegTable where section ='" + ddlSection.SelectedItem.ToString() + "'" + SetBookType();
            FillGrid();
        }

        private void cbLanguage_CheckedChanged(object sender, EventArgs e)
        {
            dt.Clear();

            if (cbLanguage.Checked)
            {
                ddlLanguage.Enabled = true;
            }

            else
            {
                ddlLanguage.Enabled = false;
                ddlLanguage.SelectedItem = null;
            } 

            DdlUpdate("select language from AccRegTable", ddlLanguage);
        }

        private void ddlLanguage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dt.Clear();
            c.cmd.CommandText = "select * from AccRegTable where language ='" + ddlLanguage.SelectedItem.ToString() + "'" + SetBookType();
            FillGrid();
        }

        private void cbSubject_CheckedChanged(object sender, EventArgs e)
        {
            dt.Clear();

            if (cbSubject.Checked)
            {
                ddlSubject.Enabled = true;
            }

            else
            {
                ddlSubject.Enabled = false;
                ddlSubject.SelectedItem = null;
            }

            DdlUpdate("select subject from AccRegTable", ddlSubject);
        }

        private void ddlSubject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dt.Clear();
            c.cmd.CommandText = "select * from AccRegTable where subject ='" + ddlSubject.SelectedItem.ToString() + "'" + SetBookType();
            FillGrid();
        }


        private void DdlUpdate(string cmdText, ComboBox ddlToFill)
        {
            DataTable dtDummy = new DataTable();
            string itemToAdd = "";

            try
            {
                ddlToFill.Items.Clear();

                c.cmd.CommandText = cmdText;
                adp.SelectCommand = c.cmd;
                adp.Fill(dtDummy);

                for (int i = 0; i < dtDummy.Rows.Count; i++)
                {
                    itemToAdd = "";

                    itemToAdd += dtDummy.Rows[i].ItemArray[0];

                    if (!ddlToFill.Items.Contains(itemToAdd))
                    {
                        ddlToFill.Items.Add(itemToAdd);

                    }
                }
            }

            catch (Exception ex)
            {
                if (adminInstance != null)
                {
                    adminInstance.errObj.txtException.Text = ex.ToString();
                    adminInstance.errObj.Show();
                }
            }
        }

        private void cbKeyword_CheckedChanged(object sender, EventArgs e)
        {
            dt.Clear();

            if (cbKeyword.Checked)
            {
                txtKeyword.Enabled = true;
            }

            else
            {
                txtKeyword.Enabled = false;
                txtKeyword.Clear();
            }
        }

        private void cbYear_CheckedChanged(object sender, EventArgs e)
        {
            dt.Clear();

            if (cbYear.Checked)
            {
                txtYear.Enabled = true;
            }

            else
            {
                txtYear.Enabled = false;
                txtYear.Clear();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            Point scaler = dataGridView1.Location;

            Size reSize = new Size(this.Size.Width - 30, this.Size.Height - scaler.Y - 40);
            dataGridView1.Size = reSize;


        }

    }
}