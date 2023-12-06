using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.libraries
{
    internal class OpenYanikLib:InitTests
    {
        [Category("OpenYanikLib")]

        [Test,Order(1)]

        public void openLibraryYanik()
        {

            //Open ATLAS.ti with empty A22 Library
            GetAppActions().SwitchLibrary(SmokeTestVariables.library2Extracted);

            Thread.Sleep(3000);
            //We need to change the driver because the application will restart after library switch
            initATLAS();
            
            bool crashState = GetWelcomeWindow().HasAtlasCrashed(TimeSpan.FromSeconds(60));

            Assert.IsFalse(crashState);


        }

        
    }
}
