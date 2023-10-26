using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.BackUpApp;
using Test_Automation_Core.Data.SUT;
using Test_Automation_Core.OS.Windows;

namespace Test_Automation_Core.Tests.Smoke_Tests.BackUpTests
{
    public class Test1
    {
        SmokeTestClass SmokeTestClass = new SmokeTestClass();

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

