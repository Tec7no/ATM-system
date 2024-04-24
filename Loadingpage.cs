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
    public partial class Loadingpage : Form
    {
        public Loadingpage()
        {
            InitializeComponent();
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 2;
            if (panel1.Width >= 399)
            {
                timer1.Stop();
                Loginpage fm = new Loginpage();
                this.Hide();
                fm.Show();
            }
        }

      
    }
}
