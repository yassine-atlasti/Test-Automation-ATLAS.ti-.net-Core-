using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.Data.SUT
{
    public  class AtlasVariables
    {
       

        public static string actualMajor = "23";
        public static string previousMajor = "22";

        public static  string winVUT = "23.3.3"; 
        public static string macVUT = "";

        public static  string winProduction = "23.3.3";
        public static  string  macProduction = "23.3.0-28730";


        public static string winPreviousMajor = "22.2.5(20221031.1).01";
        public static string macPreviousMajor = "22.2.3-3738";
        public static string installationPath = @"C:\Program Files\Scientific Software\ATLASti." + actualMajor;

        public  static   string appPath = @"C:\Program Files\Scientific Software\ATLASti." + actualMajor + @"\Atlasti" + actualMajor + ".exe";

        public static  string backUpPath = @"C:\Program Files\Scientific Software\ATLASti." + actualMajor + @"\SSD.ATLASti.Backup.exe";

        public static string fileNameRC =  "Atlasti_" + AtlasVariables.winVUT + ".exe";
        public static string fileNameNightly = "Atlasti_Nightly_develop.exe";

        public static string installerPathRC = @"C:\Users\yassinemahfoudh\Downloads\"+ fileNameRC;
       public static string installerPathNightly = @"C:\Users\yassinemahfoudh\Downloads\Atlasti_Nightly_develop.exe";

        public static string uninstallPath=@"Control Panel\Programs\Programs and Features\ATLAS.ti " + actualMajor;


         AtlasVariables() {
            //update
            //major = "";
            }
    }
}
