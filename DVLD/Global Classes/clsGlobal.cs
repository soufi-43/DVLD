using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using Microsoft.Win32;

namespace DVLD.Classes
{
    internal static  class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            //string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\YourSoftware";
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD"; ;
            string User = "UserName";
            string UserNameData = Username;
            string Pass = "Password";
            string PasswordData = Password;
            try
            {
                Registry.SetValue(keyPath,User, UserNameData, RegistryValueKind.String);
                Registry.SetValue(keyPath, Pass, PasswordData, RegistryValueKind.String);
                return true; 
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; 
            }
            try
            {
                //this will get the current project directory folder.
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();


                // Define the path to the text file where you want to save the data
                string filePath = currentDirectory + "\\data.txt";

                //incase the username is empty, delete the file
                if (Username=="" && File.Exists(filePath)) 
                { 
                     File.Delete(filePath);
                    return true;

                }

                // concatonate username and passwrod withe seperator.
                string dataToSave = Username + "#//#"+Password ;

                // Create a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the data to the file
                    writer.WriteLine(dataToSave);
                   
                  return true;
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show ($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            string valueName = "UserName";
            string valuePass = "Password";
            try
            {
                // Read the value from the Registry
                Username = Registry.GetValue(keyPath, valueName, null) as string;
                Password = Registry.GetValue(keyPath, valuePass, null) as string;



                if (valueName != null)
                {
                    
                    //Console.WriteLine($"The value of {valueName} is: {pass}");
                   
                    return true; 
                }
                else
                {
                    MessageBox.Show("ggggggggg"); 
                    Console.WriteLine($"Value {valueName} not found in the Registry.");
                    return false; 
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }

            try
            {
                //gets the current project's directory
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                

                // Path for the file that contains the credential.
                string filePath  = currentDirectory + "\\data.txt";
                MessageBox.Show(filePath);
                // Check if the file exists before attempting to read it
                if (File.Exists(filePath))
                {
                    // Create a StreamReader to read from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Read data line by line until the end of the file
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show ($"An error occurred: {ex.Message}");
                return false;   
            }

        }

        public static void RemoveCredentialsFromWinRegistry()
        {
            // Specify the registry key path and value name
            string keyPath = @"SOFTWARE\DVLD";
            string valueName = "YourValueName";


            try
            {
                // Open the registry key in read/write mode with explicit registry view
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(keyPath, true))
                    {
                        if (key != null)
                        {
                            // Delete the specified value
                            key.DeleteValue(valueName);


                            Console.WriteLine($"Successfully deleted value '{valueName}' from registry key '{keyPath}'");
                        }
                        else
                        {
                            Console.WriteLine($"Registry key '{keyPath}' not found");
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("UnauthorizedAccessException: Run the program with administrative privileges.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


            Console.ReadKey();
       
    }

        
    }
}
