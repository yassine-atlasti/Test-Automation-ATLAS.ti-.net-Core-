﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.Data.SUT
{
    public  class AtlasVariables
    {
       

        public static string major = "23";
        public static string minor = "22";

        public static  string winVUT = "23.2.2.27458";
        public static string macVUT = "";

        public static  string winProduction = "23.2.1.26990";
        public static  string  macProduction = "23.2.0-4305";


        public static string winPreviousMajor = "22.2.5";
        public static string macPreviousMajor = "22.2.3-3738";
        public static string installationPath = @"C:\Program Files\Scientific Software\ATLASti." + major;

        public  static   string appPath = @"C:\Program Files\Scientific Software\ATLASti." + major + @"\Atlasti" + major + ".exe";

        public static  string backUpPath = @"C:\Program Files\Scientific Software\ATLASti." + major + @"\SSD.ATLASti.Backup.exe";

        public static string fileNameRC =  "Atlasti_" + AtlasVariables.winVUT + ".exe";

        public static string installerPathRC = @"C:\Users\yassinemahfoudh\Downloads\"+ fileNameRC;
       public static string installerPathNightly = @"C:\Users\yassinemahfoudh\Downloads\Atlasti_Nightly_develop.exe";
        public static string uninstallPath=@"Control Panel\Programs\Programs and Features\ATLAS.ti " + major;


         AtlasVariables() {
            //update
            //major = "";
            }
    }
}
