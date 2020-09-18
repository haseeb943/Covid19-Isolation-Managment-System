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

namespace HospitalManagementSystemCSharp
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }


       
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection xConn = new SqlConnection("Server=DESKTOP-467UO53\\SQLEXPRESS;DataBase=CIMS;UID=sa;PWD=123");
            string str="Select * from tblLogin where Username ='"+txtuser.Text+"' and Pass ='" + txtpass.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(str, xConn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            
            if (dt.Rows.Count==1)
            {
                this.Hide();
                HOME obj2 = new HOME();
                obj2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username and Password.");
            }
         }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToShortTimeString();
            lbldate.Text = DateTime.Now.ToShortDateString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtpass.Clear();
            txtuser.Clear();
            txtuser.Focus();
        }
    }
}
