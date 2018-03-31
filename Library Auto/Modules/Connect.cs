using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Library_Auto
{
    class Connect
    {
        public SqlCommand cmd = new SqlCommand();
        public SqlConnection cnn = new SqlConnection();

        public Connect()
        {

            try
            {
                //cnn.ConnectionString = "data source=mgm-server; initial catalog=bgroup11; integrated security=true";
                cnn.ConnectionString = "data source=ONRA\\SQLEXPRESS; initial catalog=bgroup11; integrated security=true";
                cnn.Open();
                cmd.Connection = cnn;
            }

            catch (SqlException)
            {
                string msg1, msg2;
                msg1 = "An Error Occured!\nCould not create a connection to the Server, \nPlease check that you have an Active Internet Connection.";
                msg2 = "\nIf the problem persists, restart the Software.";

                MessageBox.Show(msg1 + msg2, "SQL Exception: Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
