using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HospitalManagementSystemCSharp
{
    public partial class StaffAdd : Form
    {
        private SqlConnection xConn;
        public StaffAdd()
        {
            InitializeComponent();
            xConn = new SqlConnection("Server=DESKTOP-467UO53\\SQLEXPRESS;DataBase=CIMS;UID=sa;PWD=123");

        }
        string imgLocation="";
        SqlCommand cmd;

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HOME hm = new HOME();
            hm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string gen = "";
            byte[] images = null;
            FileStream streem = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);



            if (rdbtnmale.Checked == true)
            {
                gen = "Male";
            }
            else
            {
                gen = "Female";

            }



            xConn.Open();
            string sqlQuery = "Insert into staff(FullName,Adres,Contact,CNIC,Gender,Position,Salary,Picture) values('" + txtName.Text + "','" + txtadres.Text+ "','" + txtcont.Text + "','" + txtnic.Text + "','" + gen + "','" + txtpos.Text +"','"+txtsal.Text+ "',@images)";
            cmd = new SqlCommand(sqlQuery, xConn);
            cmd.Parameters.Add(new SqlParameter("@images", images));
            int N = cmd.ExecuteNonQuery();
            xConn.Close();
            MessageBox.Show("1 Staff Added Successfully....!");

            txtName.Text = txtadres.Text = txtcont.Text = txtnic.Text =gen=txtpos.Text=txtsal.Text= null;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                imgLocation = opf.FileName.ToString();
                picbox.ImageLocation = imgLocation;
            }
            else
            {
                MessageBox.Show("Error in uploading the picture!!!", "ERROR",
                                 MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
