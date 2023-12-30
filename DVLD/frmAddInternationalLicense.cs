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
    public partial class frmAddInternationalLicense : Form
    {

        clsInternationalLicensee _InternationalLicense = new clsInternationalLicensee();

        public frmAddInternationalLicense()
        {
            InitializeComponent();
        }

        private void frmAddInternationalLicense_Load(object sender, EventArgs e)
        {
            
        }


        //submit using the static function 
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int ApplicationID = int.Parse(txtApplicationID.Text.ToString()); 
            int DriverID =   int.Parse(txtDriverID.Text.ToString());
            int IssuedByLocalLicenseID = int.Parse(txtUsedLocalLicenseID.Text.ToString());
            DateTime IssueDate= dtIssueDate.Value; ;
            DateTime ExpirationDate = dtExpirationDate.Value;
            bool IsActive = chkIsActive.Checked;
            int CreatedByUserID = int.Parse(txtUserCreator.Text.ToString());

            clsInternationalLicensee.AddNewInternationalLicense(ApplicationID,DriverID,IssuedByLocalLicenseID,
                IssueDate ,ExpirationDate ,IsActive , CreatedByUserID); 
        }
        // submit using the object 
        /*private void btnSubmit_Click(object sender, EventArgs e)
        {
            _InternationalLicense.ApplicationID =   int.Parse(txtApplicationID.Text.ToString());
            _InternationalLicense.CreatedByUserID = int.Parse(txtUserCreator.Text.ToString());
            _InternationalLicense.DriverID =        int.Parse(txtDriverID.Text.ToString());
            _InternationalLicense.IssuedByLocalLicenseID = int.Parse(txtUsedLocalLicenseID.Text.ToString());
            _InternationalLicense.IsActive = chkIsActive.Checked;
            _InternationalLicense.IssueDate = dtIssueDate.Value;
            _InternationalLicense.ExpirationDate = dtExpirationDate.Value;



            if (_InternationalLicense.Save())
            {
                MessageBox.Show("saved succefully"); 
            }

        }*/
    }
}
