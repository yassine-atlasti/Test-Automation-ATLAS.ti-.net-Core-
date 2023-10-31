using Test_Automation_Core.test.main.tests;

namespace Test_Automation_Core.test.main.tests
{
    public class CrashTest
    {
        InitTests smokeTestClass = new InitTests();
        [Test, Order(1)]
        public void RaiseException()
        {
            smokeTestClass.initATLAS();
            // smokeTestClass.GetAppActions().OpenProject(SmokeTestVariables.smokeTestproject);
            smokeTestClass.GetAppActions().RaiseException();
            Thread.Sleep(25000);
        }
        [Test, Order(2)]
        public void CrashReportVisible()
        {

            smokeTestClass.initATLAS();

            bool crashState = smokeTestClass.GetWelcomeWindow().HasAtlasCrashed(TimeSpan.FromSeconds(5));


            Assert.IsTrue(crashState);

        }
        [Test, Order(3)]
        public void SendCrashReport()
        {
            smokeTestClass.initATLAS();

            smokeTestClass.GetAppActions().SendCrashReport("tester@atlasti.com", "QA Test, please Ignore");

            //Wait for Crash in AppCenter and Close it
        }




    }
}
