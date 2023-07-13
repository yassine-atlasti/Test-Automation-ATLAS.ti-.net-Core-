using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.SmokeTestData;

namespace Test_Automation_Core.Tests.Smoke_Tests.Support
{
    public class CrashTest
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();
     //  [Test, Order(1)]
        public void RaiseException()
        {
            smokeTestClass.initATLAS();
            smokeTestClass.GetAppActions().OpenProject(SmokeTestVariables.smokeTestproject);
             smokeTestClass.GetAppActions().RaiseException();
            Thread.Sleep(15000);
        }
        [Test, Order(2)]
        public void CrashReportVisible() {

            smokeTestClass.initATLAS();
             bool crashReportVisible=  smokeTestClass.GetSystemActions().WaitForElementToBeDisplayedByTagName(smokeTestClass.GetDriver(),
"Window", "ATLAS.ti Problem",3);

           

            Assert.IsTrue(crashReportVisible);

        }
      //  [Test, Order(3)]
        public void SendCrashReport()
        {
            smokeTestClass.initATLAS();

            smokeTestClass.GetAppActions().SendCrashReport("tester@atlasti.com", "QA Test, please Ignore");

            //Wait for Crash in AppCenter and Close it
        }




    }
}
