using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.util
{
    public class ExtractLibraries
    {

        public static void  extractSmokeTestLibs()
        {
            SystemActions systemActions = new SystemActions();


            //Add Method that automatically updates AtlastiVariables (need to be implemented)

            //Create Smoke Test Folder

            systemActions.CreateFolder(SmokeTestVariables.smokeTestFolderPath);
            systemActions.CreateFolder(SmokeTestVariables.smokeTestFolderPath + "\\Screenshots");
            systemActions.CreateFolder(SmokeTestVariables.smokeTestFolderPath + "\\Screenshots\\Failed");
            systemActions.CreateFolder(SmokeTestVariables.smokeTestFolderPath + "\\Screenshots\\Succeeded");



            //Extract Libraries

            systemActions.ExtractZip(SmokeTestLibraries.library1, SmokeTestVariables.smokeTestFolderPath);

            systemActions.ExtractZip(SmokeTestLibraries.library2, SmokeTestVariables.smokeTestFolderPath);

            systemActions.ExtractZip(SmokeTestLibraries.library3, SmokeTestVariables.smokeTestFolderPath);

        }

    }
}
