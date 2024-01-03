using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.resources.test_data.onedrive.libraries;
using Test_Automation_Core.test.resources.test_data.releasetestdata;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.util
{
    public class ExtractLibraries
    {

        public static void  extractReleaseTestLibs()
        {
            SystemActions systemActions = new SystemActions();


            //Add Method that automatically updates AtlastiVariables (need to be implemented)

            //Create Smoke Test Folder

            systemActions.CreateFolder(ReleaseTestVariables.releaseTestFolderPath);
            systemActions.CreateFolder(ReleaseTestVariables.releaseTestFolderPath + "\\"+ ReleaseTestVariables.library1);

            systemActions.CreateFolder(ReleaseTestVariables.releaseTestFolderPath + "\\Screenshots");
            systemActions.CreateFolder(ReleaseTestVariables.releaseTestFolderPath + "\\Screenshots\\Failed");
            systemActions.CreateFolder(ReleaseTestVariables.releaseTestFolderPath + "\\Screenshots\\Succeeded");



            //Extract Libraries

            systemActions.ExtractZip(ReleaseTestLibraries.library1, ReleaseTestVariables.library1Extracted);

           

        }

        public static void extractSmokeTestLibs()
        {
            SystemActions systemActions = new SystemActions();


            //Add Method that automatically updates AtlastiVariables (need to be implemented)

            //Create Smoke Test Folder

            systemActions.CreateFolder(SmokeTestVariables.smokeTestFolderPath);
            systemActions.CreateFolder(SmokeTestVariables.smokeTestFolderPath + "\\Screenshots");
            



            //Extract Libraries

            systemActions.ExtractZip(SmokeTestLibraries.library1, SmokeTestVariables.smokeTestFolderPath);

            systemActions.ExtractZip(SmokeTestLibraries.library2, SmokeTestVariables.smokeTestFolderPath);

            systemActions.ExtractZip(SmokeTestLibraries.library3, SmokeTestVariables.smokeTestFolderPath);

        }

    }
}
