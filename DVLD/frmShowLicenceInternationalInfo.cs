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
            _InternationalLicense = clsInternationalLicensee.Find(InternationalLicenseID);
           

            //_InternationalLicenseID = _InternationalLicense.LicenseID; 

        }

        private void frmShowLicenceInternationalInfo_Load(object sender, EventArgs e)
        {


            txtApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            txtDriverID.Text = _InternationalLicense.DriverID.ToString();
            txtUsedLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            txtUserCreator.Text = _InternationalLicense.CreatedByUserID.ToString();
            dtIssueDate.Text = _InternationalLicense.IssueDate.ToString();
            dtExpirationDate.Text = _InternationalLicense.ExpirationDate.ToString();
            chkIsActive.Checked = _InternationalLicense.IsActive;

        }

        //updating using static method 
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            //updating using static method 


            /*int InternationalLicenseID = _InternationalLicense.InternationalLicenseID; 
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
            } */

            // Update Using The Object 
           
            _InternationalLicense.ApplicationID = int.Parse(txtApplicationID.Text);
            _InternationalLicense.DriverID = int.Parse(txtDriverID.Text);
            _InternationalLicense.IssuedUsingLocalLicenseID = int.Parse(txtUsedLocalLicenseID.Text);
            _InternationalLicense.IssueDate = dtIssueDate.Value;
            _InternationalLicense.ExpirationDate= dtExpirationDate.Value;
            _InternationalLicense.IsActive = chkIsActive.Checked;
            _InternationalLicense.CreatedByUserID= int.Parse(txtUserCreator.Text);


            if (_InternationalLicense.Save())
            {
                MessageBox.Show("License Updated Succefully") ;
            }
        }

        private void btnActiveLicenses_Click(object sender, EventArgs e)
        {
            frmListActiveLicences frm = new frmListActiveLicences(_InternationalLicense.DriverID);
            frm.ShowDialog(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog(); 
        }
    }
}
