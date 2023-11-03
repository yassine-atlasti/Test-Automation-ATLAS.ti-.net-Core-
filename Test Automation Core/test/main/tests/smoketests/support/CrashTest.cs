using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests
{
    public class CrashTest:InitTests
    {
        [Test, Order(1)]
        public void RaiseException()
        {
            GetAppActions().OpenProject(SmokeTestVariables.smokeTestproject);
            GetAppActions().RaiseException();
            initATLAS();

            bool crashState = GetWelcomeWindow().HasAtlasCrashed(TimeSpan.FromSeconds(5));
            Assert.IsTrue(crashState);

            GetAppActions().SendCrashReport("tester@atlasti.com", "QA Test, please Ignore");


        }

        




    }
}
