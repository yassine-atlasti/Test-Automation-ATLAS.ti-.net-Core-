using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.BackUpApp;
using Test_Automation_Core.Data.SmokeTestData;
using Test_Automation_Core.Data.SUT;
using Test_Automation_Core.OS.Windows;

namespace Test_Automation_Core.Tests.Smoke_Tests.BackUpTests
{
    internal class Test4
    {
        SmokeTestClass SmokeTestClass = new SmokeTestClass();
        [Test, Order(4)]
        public void RestoreBackUp()
        {
            SmokeTestClass.closeDriver();

            SystemActions.KillProcessByName("Atlasti" + AtlasVariables.actualMajor);
            string backUp = AtlasVariables.winVUT + "_BackUp";
            SmokeTestClass.initBackUpApp();
            bool restoreState = SmokeTestClass.GetBackUpActions().RestoreLibrary(SmokeTestVariables.smokeTestFolderPath,backUp);
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
