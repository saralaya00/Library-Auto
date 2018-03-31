using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace Library_Auto.Modules
{
    public partial class Error_Handler : Form
    {
        public Error_Handler()
        {
            InitializeComponent();
        }

        private void Error_Handler_Load(object sender, EventArgs e)
        {
            txtTitle.Text = "Library Auto Error Handler"
                + "\n\nAn Error occured please Contact the developer";

            txtException.Text = "Exception Occured :\n" + txtException.Text;
            txtStateChange.Text = "State Changes :\n" + txtStateChange.Text;
            txtBtnClicks.Text = "Functions & button Clicks:\n" + txtBtnClicks.Text;

            txtTitle.Text = txtTitle.Text.Replace("\n", Environment.NewLine);
            txtException.Text = txtException.Text.Replace("\n", Environment.NewLine);
            txtStateChange.Text = txtStateChange.Text.Replace("\n", Environment.NewLine);
            txtBtnClicks.Text = txtBtnClicks.Text.Replace("\n", Environment.NewLine);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string filename = "Library Auto Error Log-" + DateTime.Now.ToShortDateString()+ " " + DateTime.Now.ToShortTimeString() + ".txt";
            filename = filename.Replace("/", "");
            filename = filename.Replace(":", "");

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + filename;
            string lineText = Environment.NewLine + "----------------------------------------------------------------------------" + Environment.NewLine;


            File.Create( path , 4, FileOptions.None).Dispose();
            File.WriteAllText(path, txtTitle.Text 
                + lineText + txtBtnClicks.Text
                + lineText + txtStateChange.Text
                + lineText + txtException.Text, Encoding.Unicode);

            MessageBox.Show("File Created!\n" +  path);
        }
    }
}