using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;
namespace Test_Automation_Core.test.main.tests
{
    //this class should not extend the Init class. We don't want to run the setup method in this Test Case

    internal class Test4
    {
        InitTests SmokeTestClass = new InitTests();
        [Category("backuptests")]

        [Test, Order(4)]
        public void RestoreBackUp()
        {
            SmokeTestClass.cleanUp();

           // SystemActions.KillProcessByName("Atlasti" + AtlasVariables.actualMajor);
            string backUp = AtlasVariables.winVUT + "_BackUp";
            SmokeTestClass.initBackUpApp();
            bool restoreState = SmokeTestClass.GetBackUpActions().RestoreLibrary(SmokeTestVariables.smokeTestFolderPath, backUp);
            Assert.IsTrue(restoreState);
            SmokeTestClass.cleanUp();

            SystemActions.KillProcessByName("SSD.ATLASti.Backup");

           
        }
    }
}
