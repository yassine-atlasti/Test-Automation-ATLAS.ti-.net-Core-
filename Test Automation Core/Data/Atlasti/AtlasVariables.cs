using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.Data.SUT
{
    public  class AtlasVariables
    {
       

        public  static string major = "23";

       public static  string winVUT = "23.2.0";
        public static string macVUT = "";

        public static  string winProduction = "";
        public static  string  macProduction = "";


        public static string winPreviousMajor = "";
        public static string macPreviousMajor = "";


       public  static   string appPath = @"C:\Program Files\Scientific Software\ATLASti." + major + @"\Atlasti" + major + ".exe";

        public static  string backUpPath = @"C:\Program Files\Scientific Software\ATLASti." + major + @"\SSD.ATLASti.Backup.exe";


       


    }
}
