
using DVLD.Classes;
using DVLD.Licenses.International_License;
using DVLD.Licenses.International_Licenses;
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
    public partial class frmNewInternationalLicenseApplication : Form
    {

        clsInternationalLicensee _InternationalLicense = new clsInternationalLicensee();
        private int _InternationalLicenseID = -1;

        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmAddInternationalLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));//add one year.
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;

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

            int SelectedLicenseID = obj;

            lblLocalLicenseID.Text = SelectedLicenseID.ToString(); 
            llShowLicenseHistory.Enabled = (SelectedLicenseID!=-1);

            if (SelectedLicenseID == -1)

            {
                return;
            }


            //check the license class, person could not issue international license without having
            //normal license of class 3.

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if person already have an active international license
            int ActiveInternaionalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llShowLicenseInfo.Enabled = true;
                _InternationalLicenseID = ActiveInternaionalLicenseID;
                btnIssueLicense.Enabled = false;
                return;
            }

            btnIssueLicense.Enabled = true;


            
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            clsInternationalLicense InternationalLicense = new clsInternationalLicense();
            //those are the information for the base application, because it inhirts from application, they are part of the sub class.

            InternationalLicense.ApplicantPersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees;
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;


            InternationalLicense.DriverID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);

            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueLicense.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm =
              new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm =
                new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void frmNewInternationalLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

        }
    }
}
