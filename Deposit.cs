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
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Freelancing\atmsystem\atmsystem\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Loginpage.AccNumber;
        private void addtransaction()
        {
            string TrType = "Deposit";
            try
            {
                Con.Open();
                string query = "Insert into TransactionTb1 values('" + Acc + "','" + TrType + "'," + DepoAmTb.Text + ",'" + DateTime.Today.Date.ToString() +  "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
               // MessageBox.Show("Account created successfully");
                Con.Close();
                addtransaction();
                Loginpage log = new Loginpage();
                log.Show();
                this.Hide();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

         
        }
        private void xuiButton1_Click(object sender, EventArgs e)
        {

            if (DepoAmTb.Text == " " || Convert.ToInt32(DepoAmTb.Text) <= 0)
            {
                MessageBox.Show("Enter The Amount To Deposit ");
            }
            else
            {

                newbalance = oldbalance + Convert.ToInt32(DepoAmTb.Text);
                try
                {


                    Con.Open();
                    string query = "update AccountTb1 set Balance=" + newbalance + "where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("success Deposit");
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

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

       
        int oldbalance,newbalance;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter( "select Balance from AccountTb1 where AccNum='" + Acc + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldbalance = Convert.ToInt16( dt.Rows[0][0].ToString());
            Con.Close();


        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            
            getbalance();
        }
    }
}
