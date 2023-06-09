using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.Data.SUT
{
    public  class AtlasVariables
    {
       

        public  static readonly string major = "23";

       public static readonly string winVUT = "23.2.0";
        public static readonly string macVUT = "";

        public static readonly string winProduction = "";
        public static readonly string  macProduction = "";


        public static readonly string winPreviousMajor = "";
        public static readonly string macPreviousMajor = "";


       public  static readonly string appPath = @"C:\Program Files\Scientific Software\ATLASti." + major + @"\Atlasti" + major + ".exe";

        public static readonly string backUpPath = @"C:\Program Files\Scientific Software\ATLASti." + major + @"\SSD.ATLASti.Backup.exe";


       


    }
}
