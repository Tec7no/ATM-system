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
    public partial class Loginpage : Form
    {

        public Loginpage()
        {
            InitializeComponent();
        }      
        //(Event) this button closes the login page and open the sign up page
        private void xuiButton2_Click(object sender, EventArgs e)
        {
            signuppage acc = new signuppage();
            acc.Show();
            this.Hide();
        }
        
        public static string AccNumber;
        
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Freelancing\atmsystem\atmsystem\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");

        //(Event) this button closes the login page and open the Home  page
        private void xuiButton1_Click(object sender, EventArgs e)
        {
            //here we are handling the exception of the login button in case something happend
            try {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from AccountTb1 where Accnum='" + AccNumtb.Text + "' and PIN = " + PinTb.Text + "", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                    {
                        AccNumber = AccNumtb.Text;
                        Home home = new Home();
                        home.Show();
                        this.Hide();
                        Con.Close();                   
                    }
                
                else
                   {
                        MessageBox.Show("Wrong Account Number Or PIN Code");
                   }
                Con.Close();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
        }              

        private void xuiButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Loginpage_Load(object sender, EventArgs e)
        {

        }
    }
}
