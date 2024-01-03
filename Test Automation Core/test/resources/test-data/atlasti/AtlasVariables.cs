using System.Diagnostics;
using Test_Automation_Core.test.resources.test_data.local_config;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.resources.test
{
    public class AtlasVariables
    {


        public static string actualMajor = "23";
        public static string previousMajor = "22";

        public static string InstalledVersion { get => SystemActions.GetCurrentInstalledVersion(); }
        public static string macVUT = "";

        public static string winRC = "23.4.0.29344";

        public static string winProduction = "23.3.4";
        public static string macProduction = "23.3.0-28730";


        public static string winPreviousMajor = "22.2.5";
        public static string macPreviousMajor = "22.2.3-3738";
        public static string installationPath = AtlastiConfig.installationPath;

        public static string atlasVersionTextFile = installationPath + "\\" + "ATLAS.ti.txt";
        public static string appPath = installationPath + @"\Atlasti" + actualMajor + ".exe";

        public static string backUpPath = installationPath + @"\SSD.ATLASti.Backup.exe";

        public static string fileNameRC = "ATLASti.exe";
        public static string fileNameNightly = "ATLASti-Win-DEV.exe";

        // This stores automatically the path of the Downloads Folder
        public static string downloadPath { get => SystemActions.GetDownloadsFolderPath(); }

        public static string installerPathRC =downloadPath+ @"\" + fileNameRC;
        public static string installerPathNightly = downloadPath + @"\" + fileNameNightly;

        
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
