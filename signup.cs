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
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Freelancing\atmsystem\atmsystem\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if(AccNametb.Text== "  "||AccNumTb.Text==" "||FaNameTb.Text==""||PhoneTb.Text==" "|| Addresstb.Text==" "||occupationtb.Text==""|| pintb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Insert into AccountTb1 values('" + AccNumTb.Text + "','"+AccNametb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+Addresstb.Text+"','"+educationcb.SelectedItem.ToString()+"','"+occupationtb.Text+"',"+pintb.Text+","+bal+")";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account created successfully");
                    Con.Close();
                    Form1 log = new Form1();
                    log.Show();
                    this.Hide();
                }
                catch(Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            log.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
