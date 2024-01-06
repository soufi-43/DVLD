﻿using DVLD_Buisness;
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
    public partial class frmNewInternationalLicenseApplication : Form
    {

        clsInternationalLicensee _InternationalLicense = new clsInternationalLicensee();
        clsApplication _Application = new clsApplication();

        clsLicense _license = new clsLicense(); 
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmAddInternationalLicense_Load(object sender, EventArgs e)
        {
            
        }


        //submit using the static function 
        /*private void btnSubmit_Click(object sender, EventArgs e)
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
        }*/
        // submit using the object 
        private void btnSubmit_Click(object sender, EventArgs e)
        {
           

            /*_InternationalLicense.ApplicationID =   int.Parse(txtApplicationID.Text.ToString());
            _InternationalLicense.CreatedByUserID = int.Parse(txtUserCreator.Text.ToString());
            _InternationalLicense.DriverID =        int.Parse(txtDriverID.Text.ToString());
            _InternationalLicense.IssuedUsingLocalLicenseID = int.Parse(txtUsedLocalLicenseID.Text.ToString());
            _InternationalLicense.IsActive = chkIsActive.Checked;
            _InternationalLicense.IssueDate = dtIssueDate.Value;
            _InternationalLicense.ExpirationDate = dtExpirationDate.Value;
            _InternationalLicense.ApplicantPersonID = clsUser.FindByUserID(_InternationalLicense.CreatedByUserID).PersonID;
            */


           /* _Application.ApplicationID = _InternationalLicense.ApplicationID;
            _Application.ApplicantPersonID = clsUser.FindByUserID(_InternationalLicense.CreatedByUserID).PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            _Application.ApplicationStatus = clsApplication.enApplicationStatus.New; 
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = 15; 
            _Application.CreatedByUserID = _InternationalLicense.CreatedByUserID;*/


           
            if (_InternationalLicense.Save())
            {
                MessageBox.Show("international saved succefully"); 
            }

        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClass!=3)
            {
                MessageBox.Show("you cannot not it is not class 3"); 
            }
        }
    }
}