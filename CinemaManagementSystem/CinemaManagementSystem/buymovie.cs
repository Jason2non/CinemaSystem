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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CinemaManagementSystem
{
    public partial class buymovie : Form
    {
        public buymovie()
        {
            InitializeComponent();
            moviename();
            showthet();
            shoprice();
        }
        OleDbConnection con = new OleDbConnection(Global.connectionString);
        private void moviename()
        {
            con.Open();
            string query = "Select Moviename from Movie";
            OleDbDataAdapter sda = new OleDbDataAdapter(query, con);
            OleDbCommandBuilder Builder = new OleDbCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            mnameCb.DisplayMember = "Moviename";
            mnameCb.ValueMember = "Moviename";
            mnameCb.DataSource = ds.Tables[0];
            con.Close();
        }
        private void showthet()
        {
            /*con.Open();
            string query = "Select Thename from Theatre";
            OleDbDataAdapter sda = new OleDbDataAdapter(query, con);
            OleDbCommandBuilder Builder = new OleDbCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            thCb.DisplayMember = "Thename";
            thCb.ValueMember = "Thename";
            thCb.DataSource = ds.Tables[0];
            con.Close();*/
            OleDbCommand cmd = new OleDbCommand("SELECT Thename FROM Theatre", con);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Thename");
            thCb.DisplayMember = "Thename";
            thCb.ValueMember = "Thename";
            thCb.DataSource = ds.Tables["Thename"];
        }
        private void shoprice()
        {
            OleDbDataReader cap;
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("Select Movieprice FROM Movie WHERE Moviename IS NOT NULL", con);
                cap = cmd.ExecuteReader();
                while (cap.Read())
                {
                    string price = cap.GetInt32(0).ToString();
                    priceTxt.Text = price;
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ynameTxt.Text == "")
            {
                MessageBox.Show("Fill the empty spaces");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO ticket([name],[movie],[theatre],[price])values(@Na,@Mo,@Th,@Pr)", con);
                    cmd.Parameters.AddWithValue("@Na", ynameTxt);
                    cmd.Parameters.AddWithValue("@Mo", mnameCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Th", thCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Pr", priceTxt.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("You bought a seat, enjoy!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close() ;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login form = new login();
            this.Hide();
            form.Show();
        }
    }
}
