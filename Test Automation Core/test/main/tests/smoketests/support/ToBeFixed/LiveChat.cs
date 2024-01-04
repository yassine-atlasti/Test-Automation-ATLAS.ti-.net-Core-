namespace Test_Automation_Core.test.main.tests.smoketests.support.ToBeFixed
{
    public class LiveChat : InitTests
    {
        InitTests smokeTestClass = new InitTests();

        [Test]
        public void test()
        {
            GetAppActions().LiveChat("QA Test, Please Ignore");

            // Assert.IsTrue(reportState);
        }
    }
}
