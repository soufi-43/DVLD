using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLoggerError
    {
        public static void LoggerError(string ErrorMessage, string SourceName = "DVLD_App")
        {
            if (!EventLog.SourceExists(SourceName))
            {
                
                EventLog.CreateEventSource(SourceName, "Application");
                //Console.WriteLine("event source created ");

            }

            EventLog.WriteEntry(SourceName, ErrorMessage, EventLogEntryType.Error);


            
            
        }
    }
}





