using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.libraries
{
    public class OpenEmptyLibA22
    {
        InitTests smokeTestClass = new InitTests();
        [Category("OpenEmptyLibA22")]

        [Test]

        public void openEmptyLibA22()
        {
            smokeTestClass.initSmokeTest();
            smokeTestClass.initATLAS();

            //Open ATLAS.ti with empty A22 Library
            smokeTestClass.GetAppActions().SwitchLibrary(SmokeTestVariables.library1Extracted);

            // Wait for 20 second for Library Switch
            Thread.Sleep(20000);

            smokeTestClass.initATLAS();

            bool crashState = smokeTestClass.GetWelcomeWindow().HasAtlasCrashed(TimeSpan.FromSeconds(60));

            Assert.IsFalse(crashState);


        }
    }
}
