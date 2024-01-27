using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.support
{
    public class SendSystemReport : BaseTestCase
    {

        [Test, Category("support")]
        public void TestSystemReport()
        {
            GetAppActions().OpenProject(SmokeTestVariables.smokeTestproject);

            bool reportState = GetAppActions().SendSystemReport("tester@atlasti.com");

            Assert.IsTrue(reportState);
        }



    }
}
