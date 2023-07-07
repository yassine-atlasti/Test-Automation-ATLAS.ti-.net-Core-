using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.SmokeTestData;

namespace Test_Automation_Core.Tests.Smoke_Tests.LibSwitch
{
    internal class OpenYanikLib
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();

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
