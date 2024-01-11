namespace Test_Automation_Core.test.main.tests.smoketests.support.ToBeFixed
{
    public class ReportProblem
    {
        BaseTest smokeTestClass = new BaseTest();

        [Test]
        public void test()
        {
            smokeTestClass.SetupATLAS();
            bool reportState = smokeTestClass.GetAppActions().ReportProblem("Test", "tester@atlasti.com");

            Assert.IsTrue(reportState);
        }



    }
}
