using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.resources.test
{
    public class SmokeTestVariables
    {
        //OS Versions Used for Smoke Tests
        public static  string actualWinOS { get => SystemActions.GetOperatingSystemVersion(); }



        //Smoke Test Folder Path 

        public static readonly string smokeTestFolder = "SmokeTest_" + AtlasVariables.InstalledVersion;
        public static readonly string smokeTestFolderPath = SystemActions.GetDesktopPath()+"\\" + smokeTestFolder;


        //Libraries  Names used for Smoke Tests
        public static readonly string library1 = "emptyWinA22library";
        public static readonly string library2 = "SmokeTestLibraryWin(Yanik)";
        public static readonly string library3 = "Win-SmokeTestLibraryContainingC&H+hierarchy";


        //File Paths of the extracted Smoke test libraries
        public static readonly string library1Extracted = smokeTestFolderPath + @"\" + library1;
        public static readonly string library2Extracted = smokeTestFolderPath + @"\" + "ATLASti.8";
        public static readonly string library3Extracted = smokeTestFolderPath + @"\" + library3 + @"\ATLASti.22";


        //´Project Name

        public static readonly string smokeTestproject = "C&H II + hierarchy";



    }
}
