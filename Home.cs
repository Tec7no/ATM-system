using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atmsystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        public static string AccNumber;

        //logout button
        private void xuiButton7_Click(object sender, EventArgs e)
        {
            Loginpage home = new Loginpage();
            home.Show();
            this.Hide();
        }
        //shows balance form
        private void xuiButton4_Click(object sender, EventArgs e)
        {
            Balance bal = new Balance();
            bal.Show();
            this.Hide();
        }
        //this happens when the form first loads up 
        private void Home_Load(object sender, EventArgs e)
        {
            AccNumlbl.Text = "Account Number:" + Loginpage.AccNumber;
            AccNumber = Loginpage.AccNumber;

        }
        // opens deposit page
        private void xuiButton2_Click(object sender, EventArgs e)
        {
            Deposit depo = new Deposit();
            depo.Show();
            this.Hide();
        }
        //opens change  pin page
        private void xuiButton6_Click(object sender, EventArgs e)
        {
            changepin Pin = new changepin();
            Pin.Show();
            this.Hide();

        }
        //opens withdraw page
        private void xuiButton1_Click(object sender, EventArgs e)
        {
            withdraw WITHDRAW = new withdraw();
            WITHDRAW.Show();
            this.Hide();

        }
        //opens fastcash page
        private void xuiButton5_Click(object sender, EventArgs e)
        {
            FASTCASH fastcash = new FASTCASH();
            fastcash.Show();
            this.Hide();
        }
        private void xuiButton3_Click(object sender, EventArgs e)
        {
           
        }
        // closes the App
        private void xuiButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        
    }
}
