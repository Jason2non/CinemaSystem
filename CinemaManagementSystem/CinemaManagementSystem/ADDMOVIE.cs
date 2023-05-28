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
    public partial class ADDMOVIE : Form
    {
        public ADDMOVIE()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(Global.connectionString);
        private void addBtn_Click(object sender, EventArgs e)
        {
            if(miTxt.Text == "" || mnTxt.Text == "" || mgTxt.Text == "" || mdTxt.Text == "" || mpTxt.Text == "")
            {
                MessageBox.Show("Fill the empty spaces");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO Movie([ID],[Moviename],[Moviegenre],[Movieduration],[Movieprice])values(@Id,@Mn,@Mg,@Md,@Mp)",con);
                    cmd.Parameters.AddWithValue("@Id", miTxt.Text);
                    cmd.Parameters.AddWithValue("@Mn", mnTxt.Text);
                    cmd.Parameters.AddWithValue("@Mg", mgTxt.Text);
                    cmd.Parameters.AddWithValue("@Md", mdTxt.Text);
                    cmd.Parameters.AddWithValue("@Mp", mpTxt.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Movie successfully Added");
                }
                catch(Exception ex) 
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
