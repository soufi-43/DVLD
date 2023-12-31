using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Buisness
{
    public class clsInternationalLicensee : clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int InternationalLicenseID { get; set; }
        //public int ApplicationID { get; set; }
        clsApplication ApplicationInfo;
        //public int DriverID { get; set; }
        //public clsDriver DriverInfo; 
        public int IssuedByLocalLicenseID { get; set; }
        clsLicenseClass LicenseInfo;
        //public DateTime IssueDate { set; get; }
        //public DateTime ExpirationDate { set; get; }

        //public bool IsActive { set; get; }

        public int UserCreatorID;
        public clsUser UserCreatorInfo;

        public clsInternationalLicensee()
        {
            this.InternationalLicenseID = 0;
            this.UserCreatorID = 0;
            this.IsActive = false;
            this.ApplicationID = 0;
            this.ExpirationDate = DateTime.Now;
            this.IssueDate = DateTime.Now;
            this.DriverID = 0;
            this.UserCreatorID = 1;

            this.Mode = enMode.AddNew;
        }
        public clsInternationalLicensee(int InternationalLicenseID, int ApplicationID, int DriverID,
                int IssuedByLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.IssuedByLocalLicenseID = IssuedByLocalLicenseID;
            this.IsActive = IsActive;
            this.ApplicationID = ApplicationID;
            this.ExpirationDate = ExpirationDate;
            this.IssueDate = IssueDate;
            this.DriverID = DriverID;
            this.UserCreatorID = CreatedByUserID;
            this.UserCreatorInfo = clsUser.FindByUserID(UserCreatorID);
            this.LicenseInfo = clsLicenseClass.Find(this.LicenseClass);
            this.Mode = enMode.Update;
        }

        public static clsInternationalLicensee GetInternationalLicenseByID(int InternationalLicenseID)
        {

            //InternationalLicenseID = 1;
            int ApplicationID = -1; int DriverID = 1; int IssuedByLocalLicenseID = 1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now; bool IsActive = true;
            int CreatedByUserID = -1;

            if (clsInternationalLicenseDataa.GetInternationalLicenseByID(InternationalLicenseID, ref ApplicationID, ref DriverID,
                ref IssuedByLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicensee(InternationalLicenseID, ApplicationID, DriverID, IssuedByLocalLicenseID,
                    IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllInternarionalLicenses()
        {
            return clsInternationalLicenseDataa.GetAllInternarionalLicenses();
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicenseDataa.GetDriverInternationalLicenses(DriverID);
        }

        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicense, 
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            return clsInternationalLicenseDataa.AddNewInternationalLicense(ApplicationID,DriverID,IssuedUsingLocalLicense,IssueDate,ExpirationDate,IsActive,CreatedByUserID); 
        }

        public static bool UpdateInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicense,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            
            return clsInternationalLicenseDataa.UpdateInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicense, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseDataa.AddNewInternationalLicense(this.ApplicationID,this.DriverID,this.IssuedByLocalLicenseID,
                this.IssueDate,this.ExpirationDate,this.IsActive,this.CreatedByUserID);

            return (this.InternationalLicenseID == -1); 
        }

        private bool _UpdateInternationalLicense()
        {
            
            return clsInternationalLicenseDataa.UpdateInternationalLicense(this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedByLocalLicenseID,
                this.IssueDate, this.ExpirationDate, this.IsActive, this.UserCreatorID); 
           
            
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateInternationalLicense();
       
                
                default:
                    break;
            }
            return false; 
        }
        

        
    }
}
