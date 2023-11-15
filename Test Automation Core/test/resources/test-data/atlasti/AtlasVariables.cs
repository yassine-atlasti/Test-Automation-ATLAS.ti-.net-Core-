namespace Test_Automation_Core.test.resources.test
{
    public class AtlasVariables
    {


        public static string actualMajor = "23";
        public static string previousMajor = "22";

        public static string winVUT = "23.3.4";
        public static string macVUT = "";

        public static string winProduction = "23.3.4";
        public static string macProduction = "23.3.0-28730";


        public static string winPreviousMajor = "22.2.5";
        public static string macPreviousMajor = "22.2.3-3738";
        public static string installationPath = @"C:\Program Files\Scientific Software\ATLASti." + actualMajor;

        public static string appPath = @"C:\Program Files\Scientific Software\ATLASti." + actualMajor + @"\Atlasti" + actualMajor + ".exe";

        public static string backUpPath = @"C:\Program Files\Scientific Software\ATLASti." + actualMajor + @"\SSD.ATLASti.Backup.exe";

        public static string fileNameRC = "ATLASti.exe";
        public static string fileNameNightly = "ATLASti-Win-DEV.exe";

        public static string installerPathRC = @"C:\Users\yassinemahfoudh\Downloads\" + fileNameRC;
        public static string installerPathNightly = @"C:\Users\yassinemahfoudh\Downloads\"+fileNameNightly;

        
        public static string uninstallPathDirectory = @"Control Panel\Programs\Programs and Features";


        public static string downloadUrlNightly = @"https://releases.atlasti.com/dev-87fa7d2f-b398-4b13-96b5-d0b1a290061f/win/ATLASti-DEV.exe";
        public static string downloadUrlRC = @"https://releases.atlasti.com/rc-9710692f-a8c8-42a8-9fc4-ace17887b635/win/ATLASti.exe";

        AtlasVariables()
        {
            //update
            //major = "";
        }
    }
}
