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

    public class Test2
    {

        SmokeTestClass SmokeTestClass = new SmokeTestClass();
        [Test, Order(2)]

        public void CreateBackUp()
        {
            SystemActions.KillProcessByName("Atlasti" + AtlasVariables.actualMajor);

            SmokeTestClass.initBackUpApp();
            string backUp = AtlasVariables.winVUT + "_BackUp" ;

            if (SmokeTestClass.GetBackUpActions().CheckWarning())
            {
                Thread.Sleep(2000);

            }
            Thread.Sleep(2000);


            bool backUpState = SmokeTestClass.GetBackUpActions().CreateBackUp(SmokeTestVariables.smokeTestFolderPath, backUp);
            Assert.IsTrue(backUpState);
            SmokeTestClass.closeDriver();

            SystemActions.KillProcessByName("SSD.ATLASti.Backup");
            SmokeTestClass.initATLAS();

           

        }
      
    }
}
