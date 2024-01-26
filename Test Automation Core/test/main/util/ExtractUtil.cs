using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.resources.test_data.onedrive.libraries;
using Test_Automation_Core.test.resources.test_data.releasetestdata;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.util
{
    public class ExtractUtil
    {

        public static void  extractReleaseTestLibs()
        {
            SystemUtil systemActions = new SystemUtil();


            //Add Method that automatically updates AtlastiVariables (need to be implemented)

            //Create Smoke Test Folder

            SystemUtil.CreateFolder(ReleaseTestVariables.releaseTestFolderPath);
            SystemUtil.CreateFolder(ReleaseTestVariables.releaseTestFolderPath + "\\"+ ReleaseTestVariables.library1);

            SystemUtil.CreateFolder(ReleaseTestVariables.releaseTestFolderPath + "\\Screenshots");
            SystemUtil.CreateFolder(ReleaseTestVariables.releaseTestFolderPath + "\\Screenshots\\Failed");
            SystemUtil.CreateFolder(ReleaseTestVariables.releaseTestFolderPath + "\\Screenshots\\Succeeded");



            //Extract Libraries

            systemActions.ExtractZip(ReleaseTestLibraries.library1, ReleaseTestVariables.library1Extracted);

           

        }

        public static void extractSmokeTestLibs()
        {
            SystemUtil systemActions = new SystemUtil();


            //Add Method that automatically updates AtlastiVariables (need to be implemented)

            //Create Smoke Test Folder

            SystemUtil.CreateFolder(SmokeTestVariables.smokeTestFolderPath);
            



            //Extract Libraries

            systemActions.ExtractZip(SmokeTestLibraries.library1, SmokeTestVariables.smokeTestFolderPath);

            systemActions.ExtractZip(SmokeTestLibraries.library2, SmokeTestVariables.smokeTestFolderPath);

            systemActions.ExtractZip(SmokeTestLibraries.library3, SmokeTestVariables.smokeTestFolderPath);

        }

    }
}
