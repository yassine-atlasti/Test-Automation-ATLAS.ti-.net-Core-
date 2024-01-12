using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.support

{
    public class CrashTest:BaseTest
    {
        [Test, Order(1),Category("support")]
        public void TestCrash()
        {
            GetAppActions().OpenProject(SmokeTestVariables.smokeTestproject);
            GetAppActions().RaiseException();
            SetupATLAS();

            bool crashState = GetWelcomeWindow().HasAtlasCrashed(TimeSpan.FromSeconds(3));
            Assert.IsTrue(crashState);

            
                bool crashReport = GetAppActions().SendCrashReport("tester@atlasti.com", "QA Test, please Ignore");

                Assert.IsTrue(crashReport);

            }

       






    }
}
