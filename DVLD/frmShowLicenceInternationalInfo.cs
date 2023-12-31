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
    public partial class frmShowLicenceInternationalInfo : Form
    {
        clsInternationalLicensee _InternationalLicense;
        int _InternationalLicenseID; 
        public frmShowLicenceInternationalInfo()
        {
            InitializeComponent();
        }
        public frmShowLicenceInternationalInfo(int InternationalLicenseID)
        {

         
            InitializeComponent();
            _InternationalLicense = clsInternationalLicensee.GetInternationalLicenseByID(InternationalLicenseID);

            //_InternationalLicenseID = _InternationalLicense.LicenseID; 

        }

        private void frmShowLicenceInternationalInfo_Load(object sender, EventArgs e)
        {

            txtApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            txtDriverID.Text = _InternationalLicense.DriverID.ToString();
            txtUsedLocalLicenseID.Text = _InternationalLicense.IssuedByLocalLicenseID.ToString();
            txtUserCreator.Text = _InternationalLicense.UserCreatorID.ToString();
            dtIssueDate.Text = _InternationalLicense.IssueDate.ToString();
            dtExpirationDate.Text = _InternationalLicense.ExpirationDate.ToString();
            chkIsActive.Checked = _InternationalLicense.IsActive;

        }

        //updating using static method 
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int InternationalLicenseID = _InternationalLicense.InternationalLicenseID; 
            int ApplicationID =int.Parse( txtApplicationID.Text ) ; 
            int DriverID = int.Parse(txtDriverID.Text);
            int IssuedUsingLocalLicense = int.Parse(txtUsedLocalLicenseID.Text)  ;
            DateTime IssueDate = dtIssueDate.Value;
            DateTime ExpirationDate = dtExpirationDate.Value;
            bool IsActive = chkIsActive.Checked;
            int CreatedByUserID = int.Parse(txtUserCreator.Text);

            //MessageBox.Show(DriverID.ToString()); 

           if (clsInternationalLicensee.UpdateInternationalLicense(InternationalLicenseID, ApplicationID,DriverID,IssuedUsingLocalLicense,
               IssueDate,ExpirationDate,IsActive,CreatedByUserID))
            {
                MessageBox.Show("updated succefully"); 
            } 
        }
    }
}
