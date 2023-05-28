using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CinemaManagementSystem
{
    public partial class customer_register : Form
    {
        public customer_register()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(Global.connectionString);
        private void button2_Click(object sender, EventArgs e)
        {
            if(fnameTxt.Text == "" || snameTxt.Text == "" || emailTxt.Text == "" || passTxt.Text == "")
            {
                MessageBox.Show("Fill in the empty spaces");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO Customer([Firstname],[Secondname],[Email],[Password])values(@Fn,@Sn,@Em,@Pa)", con);
                    cmd.Parameters.AddWithValue("@Fn", fnameTxt.Text);
                    cmd.Parameters.AddWithValue("@Sn", snameTxt.Text);
                    cmd.Parameters.AddWithValue("@Em", emailTxt.Text);
                    cmd.Parameters.AddWithValue("@Pa", passTxt.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration successful");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login form = new login();
            this.Hide();
            form.Show();

        }
    }
}
