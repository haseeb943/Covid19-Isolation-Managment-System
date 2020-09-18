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
using System.IO;

namespace HospitalManagementSystemCSharp
{
    public partial class StaffInformation : Form
    {
     //   SqlCommand cmd;
        private SqlConnection xConn;
        public StaffInformation()
        {
            InitializeComponent();
           
        }

        private void StaffInformation_Load(object sender, EventArgs e)
        {
          
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xConn = new SqlConnection("Server=DESKTOP-467UO53\\SQLEXPRESS;DataBase=CIMS;UID=sa;PWD=123");
            xConn.Open();
            if (txtID.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select * from staff where StID=@ID", xConn);
               
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
                SqlDataReader da = cmd.ExecuteReader();
                
                while (da.Read())
                {
                    txtName.Text = da.GetValue(1).ToString();
                    txtadres.Text = da.GetValue(2).ToString();
                    txtcont.Text = da.GetValue(3).ToString();
                    txtnic.Text = da.GetValue(4).ToString();
                    if (da[5].ToString() == "Male")
                    {
                        rdbtnmale.Checked = true;
                    }
                    else
                    {
                        rdbtnfemale.Checked = true;
                    }
                    txtpos.Text = da.GetValue(6).ToString();
                    txtsal.Text = da.GetValue(7).ToString();

                    byte[] img = (byte[])(da["Picture"]);
                    if (img == null)
                    {
                        picbox.Image = null;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(img);
                        picbox.Image = System.Drawing.Image.FromStream(mstream);
                    }

                }

               


            } xConn.Close();
            disp_data();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string gen;
            if (rdbtnmale.Checked)
            {
                gen = "Male";
            }
            else
            {
                gen = "Female";
            }

            try
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("Enter Patient Id To Update");
                }
                else
                {

                    SqlCommand cmupd = new SqlCommand("Update staff SET FullName='" + txtName.Text + "',Adres='" + txtadres.Text + "',Contact='" + txtcont.Text + "',CNIC='" + txtnic.Text + "',Gender='" + gen + "',Position='" + txtpos.Text + "',Salary='" + txtsal.Text +  "' where StID=" + txtID.Text + "", xConn);
                    xConn.Open();
                    cmupd.CommandType = CommandType.Text;
                    cmupd.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                    txtName.Text = txtadres.Text = txtcont.Text = txtnic.Text = gen = txtpos.Text = txtsal.Text = null;
           
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (xConn.State == ConnectionState.Open)
                {
                    xConn.Close();
                }
                disp_data();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xConn.Open();
            try
            {
                if (txtID.Text == "") { MessageBox.Show("Please Enter staff ID"); }
                else
                {
                    string str = "DELETE FROM staff WHERE StID = '" + txtID.Text + "'";

                    SqlCommand cmd = new SqlCommand(str, xConn);
                    cmd.ExecuteNonQuery();
                    xConn.Close();
                    MessageBox.Show(" Staff Record Successfully Deleted ");
                    disp_data();

                    txtName.Text = txtadres.Text = txtcont.Text = txtnic.Text  = txtpos.Text = txtsal.Text = null;
                }

            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void disp_data()
        {
            xConn.Open();
            SqlCommand cmd = xConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from staff";
            //cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            xConn.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            HOME hm = new HOME();
            hm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StaffAdd hm = new StaffAdd();
            hm.ShowDialog();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            xConn.Open();

            string fm = "select FullName from Staff where Salary > 500000";

            SqlCommand cmd = new SqlCommand(fm, xConn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                button1.Text = dr.GetValue(0).ToString();
                MessageBox.Show("Dr " + button1.Text.ToString() + " is available");


            }
            else
            {
                MessageBox.Show(" Not Available in this time....   ");
                txtID.Text = "";
            }

            xConn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            xConn.Open();

            string fm = "select FullName from Staff where Salary < 50000";

            SqlCommand cmd = new SqlCommand(fm, xConn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                button2.Text = dr.GetValue(0).ToString();
                MessageBox.Show("Dr " + button2.Text.ToString() + " is available");


            }
            else
            {
                MessageBox.Show(" Not Available in this time....   ");
                txtID.Text = "";
            }

            xConn.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            button1.Text = null;
            button2.Text = null;
            button1.Text = "Most Senior Doctor";
            button2.Text = "Most Junior Doctor";
        }
    }
}
