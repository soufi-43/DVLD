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
    public partial class frmListActiveLicences : Form
    {
        DataTable dt; 
        public frmListActiveLicences()
        {
            InitializeComponent();
        }
        public frmListActiveLicences(int DriverID)
        {
            dt = clsInternationalLicensee.GetDriverInternationalLicenses(DriverID); 
            InitializeComponent();

        }

        private void frmListActiveLicences_Load(object sender, EventArgs e)
        {
            dgvListActiveLicenses.DataSource = dt; 
        }
    }
}
