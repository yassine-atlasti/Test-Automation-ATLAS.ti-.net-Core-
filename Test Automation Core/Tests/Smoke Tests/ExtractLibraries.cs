using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Libraries;
using Test_Automation_Core.Data.SmokeTestData;
using Test_Automation_Core.OS.Windows;

namespace Test_Automation_Core.Tests.Smoke_Tests
{
    internal class ExtractLibraries
    {

        [Test]
        public static void extractSmokeTestLibs()
        {
            SystemActions systemActions = new SystemActions();


            //Add Method that automatically updates AtlastiVariables (need to be implemented)

            //Create Smoke Test Folder

            systemActions.CreateFolder(SmokeTestVariables.smokeTestFolder);

            //Extract Libraries

            systemActions.ExtractZip(SmokeTestLibraries.library1, SmokeTestVariables.smokeTestFolderPath);

            systemActions.ExtractZip(SmokeTestLibraries.library2, SmokeTestVariables.smokeTestFolderPath);

            systemActions.ExtractZip(SmokeTestLibraries.library3, SmokeTestVariables.smokeTestFolderPath);

        }

    }
}
