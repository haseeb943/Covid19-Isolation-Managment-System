using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalManagementSystemCSharp
{
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void viewCheckoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewwPatientCheckOut obj5 = new ViewwPatientCheckOut();
            obj5.ShowDialog();
        }

        private void patientsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void staffsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void patientRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientRegistration obj = new PatientRegistration();
            obj.ShowDialog();
        }

        private void patientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientInformation obj1 = new PatientInformation();
            obj1.ShowDialog();
        }

        private void checkoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientCheckOut obj2 = new PatientCheckOut();
            obj2.ShowDialog();
        }

        private void roomInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomInfo obj3 = new RoomInfo();
            obj3.ShowDialog();
        }

        private void viewCheckoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            StaffInformation obj5 = new StaffInformation();
            obj5.ShowDialog();
        }

        private void addStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            StaffAdd obj4 = new StaffAdd();
            obj4.ShowDialog();
        }

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            StaffAdd obj4 = new StaffAdd();
            obj4.ShowDialog();
        }

        private void editInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            StaffInformation obj5 = new StaffInformation();
            obj5.ShowDialog();
        }

        private void addPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientRegistration obj = new PatientRegistration();
            obj.ShowDialog();
        }

        private void editInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientInformation obj1 = new PatientInformation();
            obj1.ShowDialog();
        }

        private void aboutDevelopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Bahria Univerty Students ");
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // string exit;
            //exit = MessageBox.Show("Confirm if you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            Application.Exit();
        }
    }
}
