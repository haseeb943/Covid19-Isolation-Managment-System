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
    public partial class ViewwPatientCheckOut : Form
    {
        private SqlConnection con;
      
        public ViewwPatientCheckOut()
        {
            InitializeComponent();
            con = new SqlConnection("Server=DESKTOP-467UO53\\SQLEXPRESS;DataBase=CIMS;UID=sa;PWD=123");

        }

        private void ViewwPatientCheckOut_Load(object sender, EventArgs e)
        {
            disp_data();

            // TODO: This line of code loads data into the 'hospitalDataSet3.checkout' table. You can move, or remove it, as needed.
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            disp();

        }

        public void disp() {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from checked where PID = '" + txtPID.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from checked";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                if (txtPID.Text == "") { MessageBox.Show("Please Enter Patient ID"); }
                else
                {
                    string str = "DELETE FROM checked WHERE PID = '" + txtPID.Text + "'";

                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show(" Record Successfully Deleted.... ");
                    disp_data();
                    disp();
                    
                }

            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            HOME hm = new HOME();
            hm.ShowDialog();
        }
    }
}
