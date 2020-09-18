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
    public partial class PatientCheckOut : Form
    {
        string s;
        private SqlConnection con;
        public PatientCheckOut()
        {
            
            InitializeComponent();
            con = new SqlConnection("Server=DESKTOP-467UO53\\SQLEXPRESS;DataBase=CIMS;UID=sa;PWD=123");

            txtname.ReadOnly = true;
            txtage.ReadOnly = true;
            txtcont.ReadOnly = true;
            txtadres.ReadOnly = true;
            txtdis.ReadOnly = true;
            txtbuild.ReadOnly = true;
            txttype.ReadOnly = true;
            txtrno.ReadOnly = true;
            txtstatus.ReadOnly = true;
           // DateIn.ReadOnly = true;
            txttotaldays.ReadOnly = true;
            txtcharges.ReadOnly = true;
            txtextra.ReadOnly = true;
            txtbill.ReadOnly = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlCommand cmd;

            string gen = "";
            if (rdbtnmale.Checked)
            {
                gen = "Male";
            }
            else
            {
                gen = "Female";
            }

            con.Open();


         
                string str = "INSERT INTO checked(PID,PName,Gender,Age,Contact,Adres,Disease,Building,RoomType,RoomNo,RoomPrice,PStatus,DateIn,DateOut,TotalDays,Charges,ExtraCharges,TotalBill) VALUES('" + PID.Text + "','" + txtname.Text + "','" + gen + "','" + txtage.Text + "','" + txtcont.Text + "','" + txtadres.Text + "','" + txtdis.Text + "','" + txtbuild.Text + "','" + txttype.Text + "','" + txtrno.Text + "','" + txtprice.Text + "','" + txtstatus.Text + "','" + DateIn.Value + "','" + DateOut.Value + "','" + txttotaldays.Text + "','" + txtcharges.Text + "','" + txtextra.Text + "','" + txtbill.Text + "'); ";
                cmd = new SqlCommand(str, con);

                int N = cmd.ExecuteNonQuery();
                //con.Close();

               // MessageBox.Show("Patient Successfully Checked Out..");
                
                    string rem = "DELETE FROM patient WHERE PID = '" + PID.Text + "'";

                    SqlCommand cmd1 = new SqlCommand(rem, con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Patient Successfully Checked Out..");
                      
              

                PID.Text = "";
                txtname.Text = "";
                txtage.Text = "";
                txtcont.Text = "";
                txtadres.Text = "";
                txtdis.Text = "";
                DateIn.Text = "";
                DateOut.Text = "";
                txtbill.Text = "";
                txtbuild.Text = "";
                txtrno.Text = "";
                txtprice.Text = "";
                txttype.Text = "";
                txtcharges.Text = "";
                txtstatus.Text = "";
                txtextra.Text = "";
                txttotaldays.Text = "";


                //string ID = "select PID from patient where PName = '" + PName.Text + "'";
                //SqlCommand ncmd = new SqlCommand(ID, xConn);
                //SqlDataReader dr;
                //dr = ncmd.ExecuteReader();
                //if (dr.Read())
                // {
                //   string s = dr.GetValue(0).ToString();
                //txtName.Text = dr.GetValue(1).ToString();
                // MessageBox.Show("Your ID is " + s);
                // }

            }
        

        private void button2_Click(object sender, EventArgs e)
        {
            PID.Text = "";
            txtname.Text = "";
            txtage.Text = "";
            txtcont.Text = "";
            txtadres.Text = "";
            txtdis.Text = "";
            DateIn.Text = "";
            DateOut.Text = "";
            txtbill.Text = "";
            txtbuild.Text = "";
            txtrno.Text = "";
            txtprice.Text = "";
            txttype.Text = "";
            txtcharges.Text = "";
            txtstatus.Text = "";
            txtextra.Text = "";
            txttotaldays.Text = "";
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            if (PID.Text != "")
            {
                try
                {

                    string get = "select * from patient where PID=" + PID.Text + " ;";

                    SqlCommand cmd = new SqlCommand(get, con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtname.Text = dr.GetValue(1).ToString();
                        if (dr[2].ToString() == "Male")
                        {
                            rdbtnmale.Checked = true;
                        }
                        else
                        {
                            rdbtnfemale.Checked = true;
                        }
                        txtage.Text = dr.GetValue(3).ToString();
                        DateIn.Text = dr.GetValue(4).ToString();
                        txtcont.Text = dr.GetValue(5).ToString();
                        txtadres.Text = dr.GetValue(6).ToString();
                        txtdis.Text = dr.GetValue(7).ToString();
                        txtstatus.Text = dr.GetValue(8).ToString();
                        txtbuild.Text = dr.GetValue(9).ToString();
                        txttype.Text = dr.GetValue(10).ToString();
                        txtrno.Text = dr.GetValue(11).ToString();
                        txtprice.Text = dr.GetValue(12).ToString();
                    }
                    else
                    {
                        MessageBox.Show(" Sorry, This ID, " + PID.Text + "  is not Available.   ");
                        PID.Text = "";
                    }
                }
                catch (SqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
                con.Close();
            }
        }

        private void PatientCheckOut_Load(object sender, EventArgs e)
        {

        }

        private void txtdtout_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

                DateTime StartDate=
                    (DateTime)DateIn.Value;
                DateTime EndDate =
                    (DateTime)DateOut.Value;

                TimeSpan ts = EndDate.Subtract(StartDate);
                txttotaldays.Text = ts.Days.ToString();
                int price, days, charges, extracharges, total;
                int extra=500;
                price = int.Parse(txtprice.Text);
                days = int.Parse(txttotaldays.Text);
                charges = price * days;
                txtcharges.Text = charges.ToString();
                extracharges = extra * days;
                txtextra.Text = extracharges.ToString();
                total = charges + extra;
                txtbill.Text = total.ToString();
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewwPatientCheckOut view = new ViewwPatientCheckOut();
            view.ShowDialog();
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtrno_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
