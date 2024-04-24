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
    public partial class FASTCASH : Form
    {
        public FASTCASH()
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
            // this function links the data base variables 
        }

        private void FASTCASH_Load(object sender, EventArgs e)
        {
            getbalance();
        }

        private void xuiButton7_Click(object sender, EventArgs e)
        {
            // return to home
            Home home = new Home();
            home.Show();
            this.Hide();
            
        }



        private void xuiButton1_Click(object sender, EventArgs e)
        {

            int WithDrawAmount = 100;
            C_FastCash fastcash_button1 = new C_FastCash(bal, WithDrawAmount,Con,Acc,this);
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            int WithDrawAmount = 500;
            C_FastCash fastcash_button1 = new C_FastCash(bal, WithDrawAmount, Con, Acc,this);
        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            int WithDrawAmount = 1000;
            C_FastCash fastcash_button1 = new C_FastCash(bal, WithDrawAmount, Con, Acc, this);
        }
        private void xuiButton4_Click(object sender, EventArgs e)
        {
            int WithDrawAmount = 2000;
            C_FastCash fastcash_button1 = new C_FastCash(bal, WithDrawAmount, Con, Acc, this);
        }
        private void xuiButton5_Click(object sender, EventArgs e)
        {
            int WithDrawAmount = 5000;
            C_FastCash fastcash_button1 = new C_FastCash(bal, WithDrawAmount, Con, Acc, this);
        }
        private void xuiButton6_Click(object sender, EventArgs e)
        {
            int WithDrawAmount = 8000;
            C_FastCash fastcash_button1 = new C_FastCash(bal, WithDrawAmount, Con, Acc, this);
        }

       

       
        // this class handles the fast cash proc
        class C_FastCash
        {
            private int balance;
            private int with_Draw_Amount;
            private SqlConnection Con;
            string Acc = Loginpage.AccNumber;
            public C_FastCash(int balance, int with_Draw_Amount, SqlConnection con, string acc,Form thisform)
            {
                this.balance = balance;
                this.with_Draw_Amount = with_Draw_Amount;               
                Con = con;
                Acc = acc;
                if (with_Draw_Amount > balance)
                {
                    MessageBox.Show("not enough cash");
                }
                else
                {
                    Calculate_Current_Balance();
                    Handle_DataBase_Operation();
                    thisform.Hide();
                }              
            }
            public void Calculate_Current_Balance()
            {              
                balance -= with_Draw_Amount;               
            }
            public void Handle_DataBase_Operation()
            {
                try
                {
                    Con.Open();
                    string query = "update AccountTb1 set Balance=" + balance + "where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("success WithDraw");
                    Con.Close();
                    Home home = new Home();
                    home.Show();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }

            }


        }

        private void xuiButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
    
}
