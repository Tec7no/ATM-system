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
    public partial class Balance : Form
    {
        public Balance()
        {
            InitializeComponent();
        }

       
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Freelancing\atmsystem\atmsystem\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        private  void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTb1 where AccNum='"+AccNumberlbl.Text+"'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            Balancelbl.Text ="Rs   " + dt.Rows[0][0].ToString();
            Con.Close();
        }

        //this links the acc number to the ui
        private void Balance_Load(object sender, EventArgs e)        
        {
            AccNumberlbl.Text = Home.AccNumber;
            getbalance();

        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
