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
    public partial class PatientInformation : Form
    {
        private SqlConnection con;
        public PatientInformation()
        {
            InitializeComponent();
            con = new SqlConnection("Server=DESKTOP-467UO53\\SQLEXPRESS;DataBase=CIMS;UID=sa;PWD=123");
            cmbbuild.ReadOnly = true;
            txtdis.ReadOnly = true;
            txtprice.ReadOnly = true;
        }

        private void PatientInformation_Load(object sender, EventArgs e)
        {
                   }

        private void button1_Click(object sender, EventArgs e)
        {
           
            con.Open();
            if (txtID.Text != "")
            {
                try
                {
                    string getCust = "select * from patient where PID=" + Convert.ToInt32(txtID.Text) + " ;";

                    SqlCommand cmd = new SqlCommand(getCust, con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtName.Text = dr.GetValue(1).ToString();
                        if (dr[2].ToString() == "Male")
                        {
                            radioButton1.Checked = true;
                        }
                        else
                        {
                            radioButton2.Checked = true;
                        }
                        txtAge.Text = dr.GetValue(3).ToString();
                        txtDate.Text = dr.GetValue(4).ToString();
                        txtCont.Text = dr.GetValue(5).ToString();
                        txtAdres.Text = dr.GetValue(6).ToString();
                        txtdis.Text = dr.GetValue(7).ToString();
                        cmbstatus.Text = dr.GetValue(8).ToString();
                        cmbbuild.Text = dr.GetValue(9).ToString();
                        cmbtype.Text = dr.GetValue(10).ToString();
                        txtRNo.Text = dr.GetValue(11).ToString();
                        txtprice.Text = dr.GetValue(12).ToString();
                        
                    }
                    else
                    {
                        MessageBox.Show(" Sorry, This ID, " + txtID.Text + " Staff is not Available.   ");
                        txtID.Text = "";
                    }
                }
                catch (SqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string gen;
            if (radioButton1.Checked)
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


                    SqlCommand cmupd = new SqlCommand("Update patient SET PName='" + txtName.Text + "',Gender='" + gen + "',Age='" + txtAge.Text + "',RDate='" + txtDate.Text + "',Contact='" + txtCont.Text + "',Adres='" + txtAdres.Text + "',Disease='" + txtdis.Text + "',PStatus='" + cmbstatus.Text + "',Building='" + cmbbuild.Text + "',RoomType='" + cmbtype.Text + "',RoomNo='" + txtRNo.Text + "',price='" + txtprice.Text + "' where PID=" + txtID.Text + "", con);
                    con.Open();
                    cmupd.CommandType = CommandType.Text;
                    cmupd.ExecuteNonQuery();
                    MessageBox.Show("Patient Information Successfully Updated..........");
                   txtbed.Text= txtAdres.Text = txtAge.Text = txtCont.Text = txtDate.Text = txtdis.Text = txtID.Text = txtName.Text = txtprice.Text = txtRNo.Text = cmbstatus.Text = cmbbuild.Text = cmbtype.Text = "";
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

       
        }

        private void button3_Click(object sender, EventArgs e)
        {
             con.Open();
            try
            {
                if (txtID.Text == "") { MessageBox.Show("Please Enter Patient ID"); }
                else
                {
                    string str = "DELETE FROM patient WHERE PID = '" + txtID.Text + "'";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show(" Patient Record Successfully Deleted ");
                    txtAdres.Text = txtAge.Text = txtCont.Text = txtDate.Text = txtdis.Text = txtID.Text = txtName.Text = txtprice.Text = txtRNo.Text = cmbstatus.Text = cmbbuild.Text = cmbtype.Text = "";
                } 
              
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
               }
        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sc;
            SqlDataReader rd;
            txtRNo.Items.Clear();
            txtprice.Text = null;
            
            string sql = "Select * from RoomInfo where RoomType='" + cmbtype.Text + "'";
            try
            {
                
                con.Open();
                sc = new SqlCommand(sql, con);
                rd = sc.ExecuteReader();
                while (rd.Read())
                {

                    //   cmbbuild.Items.Add(rd.GetValue(1).ToString());
                    //cmbtype.Items.Add(rd.GetValue(2).ToString());
                    
                    txtRNo.Items.Add(rd.GetValue(3).ToString());
                    //Price.Text = rd.GetValue(5).ToString();


                }

                sc.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
            
          /*  
            if (cmbtype.Text == "General")
            {
                int rs = 2000;
                txtprice.Text = rs.ToString();
            }
            else if (cmbtype.Text == "Private")
            {
                int rs = 5000;
                txtprice.Text = rs.ToString();
            }
            else if (cmbtype.Text == "Sweet")
            {
                int rs = 10000;
                txtprice.Text = rs.ToString();
            }
           */
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from patient";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            disp_data();
        }

        private void patientBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HOME hm = new HOME();
            hm.ShowDialog();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sc;
            SqlDataReader rd;
            
            // PRNo.Items.Clear();
            // Price.Text = null;
            string sql = "Select * from RoomInfo where RoomNo='" + txtRNo.Text + "'";
            try
            {
                con.Open();
                sc = new SqlCommand(sql, con);
                rd = sc.ExecuteReader();
                while (rd.Read())
                {

                    //   cmbbuild.Items.Add(rd.GetValue(1).ToString());
                    //cmbtype.Items.Add(rd.GetValue(2).ToString());

                    // PRNo.Items.Add(rd.GetValue(3).ToString());
                    txtprice.Text = rd.GetValue(5).ToString();
                    if (rd[4].ToString() != null)
                        txtbed.Text = "Available";
                    else
                        txtbed.Text = "Not Available";


                }

                sc.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
    
}
