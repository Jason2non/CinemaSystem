using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CinemaManagementSystem
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(Global.connectionString);
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (usernameTxt.Text == "" || passwordTxt.Text == "")
            {
                MessageBox.Show("Fill in the blank spaces");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT Email,Password FROM Customer WHERE Email=@Em and Password=@Pa", con);
                    cmd.Parameters.AddWithValue("@Em", usernameTxt.Text);
                    cmd.Parameters.AddWithValue("@Pa", passwordTxt.Text);
                    cmd.ExecuteNonQuery();

                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    int i = cmd.ExecuteNonQuery();
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Successfully logged in");
                        buymovie form = new buymovie();
                        this.Hide();
                        form.Show();

                    }
                    else
                    {
                        MessageBox.Show("Please enter Correct Password");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer_register form = new customer_register();
            this.Hide();
            form.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (usernameTxt.Text == "" || passwordTxt.Text == "")
            {
                MessageBox.Show("Fill in the blank spaces");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT Admin,Password FROM Admin WHERE Admin=@Ad and Password=@Pa", con);
                    cmd.Parameters.AddWithValue("@Ad", usernameTxt.Text);
                    cmd.Parameters.AddWithValue("@Pa", passwordTxt.Text);
                    cmd.ExecuteNonQuery();

                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    int i = cmd.ExecuteNonQuery();
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Successfully logged in");
                        Admin form = new Admin();
                        this.Hide();
                        form.Show();

                    }
                    else
                    {
                        MessageBox.Show("Please enter Correct Password");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }   }
    }
}
