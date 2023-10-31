using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.tests
{
    public class Test1
    {
        InitTests SmokeTestClass = new InitTests();

        [Category("backuptests")]

        [Test, Order(1)]
        public void CheckWarning()
        {
            //Test 1 
            string backUp = AtlasVariables.winVUT + "_BackUp";

            SmokeTestClass.initATLAS();

            SmokeTestClass.initBackUpApp();

            bool warningTrue = SmokeTestClass.GetBackUpActions().CheckWarning();
            Assert.IsTrue(warningTrue);

            SmokeTestClass.closeDriver();
            SystemActions.KillProcessByName("Atlasti" + AtlasVariables.actualMajor);
            SystemActions.KillProcessByName("SSD.ATLASti.Backup");
        }
    }
}

