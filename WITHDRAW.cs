using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atmsystem
{
    public partial class withdraw : Form
    {
        public withdraw()
        {
            InitializeComponent();
        }

       
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Freelancing\atmsystem\atmsystem\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Loginpage.AccNumber;
        int bal;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTb1 where AccNum='" + Acc + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelbl.Text = "RS " + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }

        
        private void withdraw_Load(object sender, EventArgs e)
        {
            getbalance();
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        int newbalance;
        private void xuiButton1_Click(object sender, EventArgs e)
        {
            if (wdamtTb.Text == "")
            {

                MessageBox.Show("Missing Information");
            }
            else if (Convert.ToInt32(wdamtTb.Text) <= 0)
            {
                MessageBox.Show("Enter a Valid Amount");
            }
            else if (Convert.ToInt32(wdamtTb.Text) > bal)
            {
                MessageBox.Show("Not enough Cash in your account");
            }
            else
            {              

                if (wdamtTb.Text == " " || Convert.ToInt32(wdamtTb.Text) <= 0)
                {
                    MessageBox.Show("Enter The Amount To Deposit ");
                }
                else
                {

                    newbalance = bal - Convert.ToInt32(wdamtTb.Text);
                    try
                    {
                        Con.Open();
                        string query = "update AccountTb1 set Balance=" + newbalance + "where AccNum='" + Acc + "'";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("success WithDraw");
                        Con.Close();
                        Home home = new Home();
                        home.Show();
                        this.Hide();
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show(EX.Message);
                    }

                }
            }
        }

       
        private void xuiButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
