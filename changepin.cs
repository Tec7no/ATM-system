using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace atmsystem
{
    public partial class changepin : Form
    {
        public changepin()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Freelancing\atmsystem\atmsystem\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Loginpage.AccNumber;
        private void xuiButton1_Click(object sender, EventArgs e)
        {
            if (Pin1Tb1.Text == " " || Pin2Tb.Text == "")
            {
                MessageBox.Show("input valid");
            }
            else if (Pin2Tb.Text != Pin1Tb1.Text)
            {
                MessageBox.Show("Pin1 And Pin2 Are Diffirent");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "update AccountTb1 set PIN=" + Pin1Tb1.Text + "where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);

                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("PIN Successfully Updated");

                    Loginpage home = new Loginpage();
                    home.Show();
                    this.Hide();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                    Con.Close();
                }

            }
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

       

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
