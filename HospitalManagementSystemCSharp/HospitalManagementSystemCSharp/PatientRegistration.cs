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
    public partial class PatientRegistration : Form
    {
        private SqlConnection xConn;
        public PatientRegistration()
        {
            InitializeComponent();
            xConn = new SqlConnection("Server=DESKTOP-467UO53\\SQLEXPRESS;DataBase=CIMS;UID=sa;PWD=123");

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd;

            string gen = string.Empty;
            if (radioButton1.Checked)
            {
                gen = "Male";
            }
            else
            {
                gen = "Female";
            }

            xConn.Open();

            string str = "INSERT INTO patient(PName,Gender,Age,RDate,Contact,Adres,Disease,PStatus,Building,RoomType,RoomNo,Price) VALUES('" + PName.Text + "','" + gen + "','" + PAge.Text + "','" + dateTimePicker1.Text + "','" + Pcont.Text + "','" + PAdres.Text + "','" + lbldis.Text + "','" + cmbstatus.Text + "','" + cmbbuild.Text + "','" + cmbtype.Text + "','" + PRNo.Text + "','" + Price.Text + "'); ";
            cmd = new SqlCommand(str, xConn);
            //cmd.Parameters.Add(new SqlParameter("@images", images));
            int N = cmd.ExecuteNonQuery();
            MessageBox.Show("Patient Information Saved Successfully..");
            string ID = "select PID from patient where PName = '"+PName.Text+"'";
             SqlCommand ncmd = new SqlCommand(ID, xConn);
                    SqlDataReader dr;
                    dr = ncmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string s = dr.GetValue(0).ToString();
                        //txtName.Text = dr.GetValue(1).ToString();
                        MessageBox.Show("Your ID is " + s);
                    }
            xConn.Close();
           // MessageBox.Show("Patient Information Saved Successfully..");
            PName.Text = "";
            PAge.Text = "";
            dateTimePicker1.Text = "";
            Pcont.Text = "";
            PAdres.Text = "";
           // lbldis.Text = "";
            cmbstatus.Text = "";
           // cmbbuild.Text = "";
            cmbtype.Text = "";
            PRNo.Text = "";
            Price.Text = "";
            txtbed.Text = "";

         


        }

        private void PatientRegistration_Load(object sender, EventArgs e)
        {
          
   

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HOME hm = new HOME();
            hm.ShowDialog();
           
          
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlCommand sc;
            SqlDataReader rd;
            PRNo.Items.Clear();
            Price.Text = null;
            string sql = "Select * from RoomInfo where RoomType='"+cmbtype.Text+"'";
            try
            {
                xConn.Open();
                sc = new SqlCommand(sql, xConn);
                rd = sc.ExecuteReader();
                while (rd.Read())
                {

                    //   cmbbuild.Items.Add(rd.GetValue(1).ToString());
                    //cmbtype.Items.Add(rd.GetValue(2).ToString());
                   
                      PRNo.Items.Add(rd.GetValue(3).ToString());
                      //Price.Text = rd.GetValue(5).ToString();


                }
             
                sc.Dispose();
                xConn.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            /*if (cmbtype.Text == "General")
            {
                int rs = 2000;
                Price.Text = rs.ToString();
            }
            else if (cmbtype.Text == "Private")
            {
                int rs = 5000;
                Price.Text = rs.ToString();
            }
            else if (cmbtype.Text == "Sweet")
            {
                int rs = 10000;
                Price.Text = rs.ToString();
            }*/
        }

        private void txtRID_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtRID_SelectedIndexChanged(object sender, EventArgs e)
        {

        /*    SqlCommand sc;
            SqlDataReader rd;
            string sql = "Select * from RoomInfo where RID='" + txtRID.Text + "'";
            try
            {
                xConn.Open();
                sc = new SqlCommand(sql, xConn);
                rd = sc.ExecuteReader();
                while (rd.Read())
                {

                 //   cmbbuild.Items.Add(rd.GetValue(1).ToString());
                    cmbtype.Items.Add(rd.GetValue(2).ToString());
                    PRNo.Items.Add(rd.GetValue(3).ToString());
                    Price.Text = rd.GetValue(5).ToString();


                }
                sc.Dispose();
                xConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
         */
        }

        private void PRNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sc;
            SqlDataReader rd;
           // PRNo.Items.Clear();
           // Price.Text = null;
            string sql = "Select * from RoomInfo where RoomNo='" + PRNo.Text + "'";
            try
            {
                xConn.Open();
                sc = new SqlCommand(sql, xConn);
                rd = sc.ExecuteReader();
                while (rd.Read())
                {

                    //   cmbbuild.Items.Add(rd.GetValue(1).ToString());
                    //cmbtype.Items.Add(rd.GetValue(2).ToString());

                   // PRNo.Items.Add(rd.GetValue(3).ToString());
                    Price.Text = rd.GetValue(5).ToString();
                    if (rd[4].ToString() != null)
                        txtbed.Text = "Available";
                    else
                        txtbed.Text = "Not Available";


                }

                sc.Dispose();
                xConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
