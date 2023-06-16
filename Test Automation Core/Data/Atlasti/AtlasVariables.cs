using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.Data.SUT
{
    public  class AtlasVariables
    {
       

        public static string major = "23";

       public static  string winVUT = "23.2.26825";
        public static string macVUT = "";

        public static  string winProduction = "23.1.1";
        public static  string  macProduction = "23.1.0-4207";


        public static string winPreviousMajor = "22.2.5";
        public static string macPreviousMajor = "22.2.3-3738";
        public static string installationPath = @"C:\Program Files\Scientific Software\ATLASti." + major;

       public  static   string appPath = @"C:\Program Files\Scientific Software\ATLASti." + major + @"\Atlasti" + major + ".exe";

        public static  string backUpPath = @"C:\Program Files\Scientific Software\ATLASti." + major + @"\SSD.ATLASti.Backup.exe";


       

         AtlasVariables() {
            //update
            //major = "";
            }
    }
}
