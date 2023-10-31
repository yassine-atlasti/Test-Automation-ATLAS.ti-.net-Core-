using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests
{
    internal class OpenYanikLib
    {
        InitTests smokeTestClass = new InitTests();
        [Category("OpenYanikLib")]

        [Test]

        public void openLibraryYanik()
        {
            smokeTestClass.initSmokeTest();
            smokeTestClass.initATLAS();

            //Open ATLAS.ti with empty A22 Library
            smokeTestClass.GetAppActions().SwitchLibrary(SmokeTestVariables.library2Extracted);

            // Wait for 20 second for Library Switch
            Thread.Sleep(20000);

            smokeTestClass.initATLAS();

            bool crashState = smokeTestClass.GetWelcomeWindow().HasAtlasCrashed(TimeSpan.FromSeconds(60));

            Assert.IsFalse(crashState);


        }
    }
}
