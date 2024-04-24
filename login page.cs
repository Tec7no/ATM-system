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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            signup acc = new signup();
            acc.Show();
            this.Hide();
        }
        public static string AccNumber;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Freelancing\atmsystem\atmsystem\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void xuiButton1_Click(object sender, EventArgs e)
        {
            try
            {
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
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void xuiWidgetPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
