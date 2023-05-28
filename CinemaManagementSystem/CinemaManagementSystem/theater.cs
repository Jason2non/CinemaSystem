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
    public partial class theater : Form
    {
        public theater()
        {
            InitializeComponent();
            //OleDbConnection con = new OleDbConnection(Global.connectionString);
        }
        
        OleDbConnection con = new OleDbConnection(Global.connectionString);
        private void button2_Click(object sender, EventArgs e)
        {
            if(tidTxt.Text == "" || tnameTxt.Text == "" || tlocTxt.Text == "" || nosTxt.Text == "")
            {
                MessageBox.Show("Fill in the empty spaces");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO Theatre([ID],[Thename],[Thelocation],[numofseat])values(@Id,@Tn,@Tl,@Ns)", con);
                    cmd.Parameters.AddWithValue("@Id", tidTxt.Text);
                    cmd.Parameters.AddWithValue("@Tn", tnameTxt.Text);
                    cmd.Parameters.AddWithValue("@Tl", tlocTxt.Text);
                    cmd.Parameters.AddWithValue("@Ns", nosTxt.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Theatre well registered");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin form = new Admin();
            this.Hide();
            form.Show();
        }
    }
}
