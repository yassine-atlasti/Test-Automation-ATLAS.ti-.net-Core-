using System.Diagnostics;
using Test_Automation_Core.test.resources.test_data.local_config;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.resources.test
{
    public class AtlasVariables
    {


        //The order of this variables is important


        public static string macVUT = "";

        public static string winRC = "24.0.0.29576";

        public static string winProduction = "23.4.0.29360";
        public static string macProduction = "23.4.0-29342";


        public static string winPreviousMajor = "22.2.5";
        public static string macPreviousMajor = "22.2.3-3738";

        public static string prodMajor = winProduction.Substring(0, 2);
        public static string previousMajor = winPreviousMajor.Substring(0, 2);
        public static string rcMajor = winRC.Substring(0, 2);
        public static string installationPath = AtlastiConfig.installationPath;

        public static string InstalledVersion { get => SystemActions.GetCurrentInstalledVersion(); }
        public static string vutMajor = InstalledVersion.Substring(0, 2);


        public enum ExportTypes
        {
            QDPX,
            atlasti,
            atlproj

        }

        public static string rcExportType = ExportTypes.atlasti.ToString();
        public static string prodExportType = ExportTypes.atlproj.ToString();
        public static string previousExportType = ExportTypes.atlproj.ToString();




        public static string atlasVersionTextFile = installationPath + "\\" + "ATLAS.ti.txt";
        public static string appPath = installationPath + @"\Atlasti" + vutMajor + ".exe";

        public static string backUpPath = installationPath + @"\SSD.ATLASti.Backup.exe";
        public static string updaterPath = installationPath + @"\SSD.ATLASti.Updater.exe";

        public static string fileNameRCMSI = "ATLASti.msi";
        public static string fileNameNightlyMSI = "ATLASti-DEV.msi";

        public static string fileNameRCEXE = "ATLASti.exe";
        public static string fileNameNightlyEXE = "ATLASti-Win-DEV.exe";

        // This stores automatically the path of the Downloads Folder
        public static string downloadPath { get => SystemActions.GetDownloadsFolderPath(); }

        public static string installerPathRCMSI =downloadPath+ @"\" + fileNameRCMSI;
        public static string installerPathNightlyMSI = downloadPath + @"\" + fileNameNightlyMSI;

        public static string installerPathRCEXE = downloadPath + @"\" + fileNameRCEXE;
        public static string installerPathNightlyEXE = downloadPath + @"\" + fileNameNightlyEXE;

        public static string uninstallPathDirectory = @"Control Panel\Programs\Programs and Features";

        public static string downloadUrlNightlyEXE = @"https://releases.atlasti.com/dev-87fa7d2f-b398-4b13-96b5-d0b1a290061f/win/ATLASti-DEV.exe";
        public static string downloadUrlNightlyMSI = @"https://releases.atlasti.com/dev-87fa7d2f-b398-4b13-96b5-d0b1a290061f/win/ATLASti-DEV.msi";
        
        public static string downloadUrlRCMSI = @"https://releases.atlasti.com/rc-9710692f-a8c8-42a8-9fc4-ace17887b635/win/ATLASti.msi";
        public static string downloadUrlRCEXE = @"https://releases.atlasti.com/rc-9710692f-a8c8-42a8-9fc4-ace17887b635/win/ATLASti.exe";

        public static string downloadURLReleaseEXE = @"https://releases.atlasti.com/win/ATLASti.exe";
        public static string downloadURLReleaseMSI = @"https://releases.atlasti.com/win/ATLASti.msi";
      

    }
}
