using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests
{
    public class OpenLibCH
    {
        InitTests smokeTestClass = new InitTests();

        [Category("OpenLibCH")]

        [Test]

        public void openLibraryCH()
        {
            smokeTestClass.initSmokeTest();
            smokeTestClass.initATLAS();

            //Open ATLAS.ti with empty A22 Library
            smokeTestClass.GetAppActions().SwitchLibrary(SmokeTestVariables.library3Extracted);

            // Wait for 20 second for Library Switch
            Thread.Sleep(20000);

            smokeTestClass.initATLAS();

            bool crashState = smokeTestClass.GetWelcomeWindow().HasAtlasCrashed(TimeSpan.FromSeconds(60));

            Assert.IsFalse(crashState);


        }
    }
}
