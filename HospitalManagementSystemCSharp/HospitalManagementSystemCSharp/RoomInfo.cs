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
    public partial class RoomInfo : Form
    {
        private SqlConnection xConn;
        SqlCommand cmd;
        public RoomInfo()
        {
            InitializeComponent();
            xConn = new SqlConnection("Server=DESKTOP-467UO53\\SQLEXPRESS;DataBase=CIMS;UID=sa;PWD=123");
            txtRID.ReadOnly = true;
        }

        private void RoomInfo_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            xConn.Open();

            string str = "INSERT INTO RoomInfo(Building,RoomType,RoomNo,NumOfBed,Price) VALUES('"+ cmbbuild.Text + "','" + cmbtype.Text + "','" + txtRNo.Text + "','" + txtbed.Text + "','" + txtprice.Text + "'); ";
            cmd = new SqlCommand(str, xConn);
            int N = cmd.ExecuteNonQuery();
            xConn.Close();
            MessageBox.Show("Room Information Added Successfully..");
            
            txtRID.Text=cmbbuild.Text = cmbtype.Text = txtRNo.Text = txtbed.Text = txtprice.Text = null;
            disp_data();
        }
        public void disp_data()
        {
            xConn.Open();
            cmd = xConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from RoomInfo";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            xConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtRID.Text=cmbtype.Text = txtRNo.Text = txtbed.Text = txtprice.Text = null;
            cmbtype.Focus();
     
        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            } */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xConn.Open();
            try
            {
                if (txtRID.Text == "") { MessageBox.Show("Please Select Room ID"); }
                else
                {
                    string str = "DELETE FROM RoomInfo WHERE RID = '" + txtRID.Text + "'";

                    SqlCommand cmd = new SqlCommand(str, xConn);
                    cmd.ExecuteNonQuery();
                    xConn.Close();
                    MessageBox.Show(" RoomInfo Successfully Deleted ");
                    disp_data();
                    txtRID.Text = cmbtype.Text = txtRNo.Text = txtbed.Text = txtprice.Text = null;
                    
 }

            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            txtRID.Text = selectedRow.Cells[0].Value.ToString();
            cmbtype.Text = selectedRow.Cells[2].Value.ToString();
            txtRNo.Text = selectedRow.Cells[3].Value.ToString();
            txtbed.Text = selectedRow.Cells[4].Value.ToString();
            txtprice.Text = selectedRow.Cells[5].Value.ToString();
                      
        }

        private void txtRID_TextChanged(object sender, EventArgs e)
        {
            txtRID.ReadOnly = true;
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtRID.Text == "")
                {
                    MessageBox.Show("Select Room Id To Update");
                }
                else
                {

                    xConn.Open();
                    SqlCommand cmupd = new SqlCommand("Update RoomInfo SET Building='" + cmbbuild.Text + "',RoomType='" + cmbtype.Text + "',RoomNo='" + txtRNo.Text + "',NumOfBed='" + txtbed.Text + "',Price='" + txtprice.Text + "' where RID=" + txtRID.Text +"", xConn);
                    
                    cmupd.CommandType = CommandType.Text;
                    cmupd.ExecuteNonQuery();
                    MessageBox.Show("Updated.......");
                    
                    txtRID.Text=cmbtype.Text = txtRNo.Text = txtbed.Text = txtprice.Text = null;
                    cmbtype.Focus();
                   
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
                    disp_data();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            HOME hm = new HOME();
            hm.ShowDialog();
        }
    }
}
