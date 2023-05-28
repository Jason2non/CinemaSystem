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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            showmovies();
            showtheatre();
            showpurchase();
        }
        OleDbConnection con = new OleDbConnection(Global.connectionString);
        private void showmovies()
        {
            con.Open();
            string query = "Select * from Movie";
            OleDbDataAdapter sda = new OleDbDataAdapter(query, con);
            OleDbCommandBuilder Builder = new OleDbCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            movieDVG.DataSource = ds.Tables[0];
            con.Close();
        }
        private void showtheatre()
        {
            con.Open();
            string query = "Select * from Theatre";
            OleDbDataAdapter sda = new OleDbDataAdapter(query, con);
            OleDbCommandBuilder Builder = new OleDbCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            thDVG.DataSource = ds.Tables[0];
            con.Close();
        }
        private void showpurchase()
        {
            con.Open();
            string query = "Select * from ticket";
            OleDbDataAdapter sda = new OleDbDataAdapter(query, con);
            OleDbCommandBuilder Builder = new OleDbCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            movDVG.DataSource = ds.Tables[0];
            con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            theater form = new theater();
            this.Hide();
            form.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ADDMOVIE form = new ADDMOVIE();
            this.Hide();
            form.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            login form = new login();
            this.Hide();
            form.Show();
        }

        private void movieDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
