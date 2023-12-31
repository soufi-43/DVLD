using DVLD.Licenses.International_License;
using DVLD.People;
using DVLD.User;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt = clsInternationalLicensee.GetDriverInternationalLicenses(9); 
            dgvDetainedLicenses.DataSource = dt;
        }

        private void getDetailsOfLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmUserInfo frm = new frmUserInfo((int)dgvDetainedLicenses.CurrentRow.Cells[7].Value);
            frm.ShowDialog(); 
        }
        
        private void addNewInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddInternationalLicense frm = new frmAddInternationalLicense();
            frm.ShowDialog();
        }

        private void showLicenceInternationalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenceInternationalInfo frm = new frmShowLicenceInternationalInfo((int)dgvDetainedLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog(); 
        }
    }
}
