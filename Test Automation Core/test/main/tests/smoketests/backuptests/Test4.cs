using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;
namespace Test_Automation_Core.test.main.tests.smoketests.backuptests
{
    internal class Test4
    {
        InitTests SmokeTestClass = new InitTests();
        [Category("backuptests")]

        [Test, Order(4)]
        public void RestoreBackUp()
        {
            SmokeTestClass.closeDriver();

            SystemActions.KillProcessByName("Atlasti" + AtlasVariables.actualMajor);
            string backUp = AtlasVariables.winVUT + "_BackUp";
            SmokeTestClass.initBackUpApp();
            bool restoreState = SmokeTestClass.GetBackUpActions().RestoreLibrary(SmokeTestVariables.smokeTestFolderPath, backUp);
            Assert.IsTrue(restoreState);
            SmokeTestClass.closeDriver();

            SystemActions.KillProcessByName("SSD.ATLASti.Backup");

            SmokeTestClass.initATLAS();
            bool projectRestored = SmokeTestClass.GetAppActions().OpenProject("Geo Project");
            Assert.IsTrue(projectRestored);
            SmokeTestClass.GetAppActions().CloseProjectAsync();
        }
    }
}
