namespace Test_Automation_Core.test.main.tests.smoketests.support.ToBeFixed
{
    public class ReportProblem
    {
        InitTests smokeTestClass = new InitTests();

        [Test]
        public void test()
        {
            smokeTestClass.initATLAS();
            bool reportState = smokeTestClass.GetAppActions().ReportProblem("Test", "tester@atlasti.com");

            Assert.IsTrue(reportState);
        }



    }
}
