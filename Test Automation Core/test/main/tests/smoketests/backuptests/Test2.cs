using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;
namespace Test_Automation_Core.test.main.tests;


//this class should not extend the Init class. We don't want to run the setup method in this Test Case
    public class Test2
    {

        InitTests SmokeTestClass = new InitTests();
        [Category("backuptests")]

        [Test, Order(2)]

        public void CreateBackUp()
        {

            SmokeTestClass.initBackUpApp();
            string backUp = AtlasVariables.winVUT + "_BackUp";

            if (SmokeTestClass.GetBackUpActions().CheckWarning())
            {
                Thread.Sleep(2000);

            }
            Thread.Sleep(2000);


            bool backUpState = SmokeTestClass.GetBackUpActions().CreateBackUp(SmokeTestVariables.smokeTestFolderPath, backUp);
            Assert.IsTrue(backUpState);
            SmokeTestClass.cleanUp();

            SystemActions.KillProcessByName("SSD.ATLASti.Backup");
            SmokeTestClass.initATLAS();



        }

    }

