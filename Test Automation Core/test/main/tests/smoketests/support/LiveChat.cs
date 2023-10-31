using Test_Automation_Core.test.main.tests;

namespace Test_Automation_Core.test.main.tests.smoketests.support
{
    public class LiveChat
    {
        InitTests smokeTestClass = new InitTests();

        [Test]
        public void test()
        {
            smokeTestClass.initATLAS();
            smokeTestClass.GetAppActions().LiveChat("QA Test, Please Ignore");

            // Assert.IsTrue(reportState);
        }
    }
}
