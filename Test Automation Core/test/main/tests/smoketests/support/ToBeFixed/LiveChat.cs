namespace Test_Automation_Core.test.main.tests.smoketests.support.ToBeFixed
{
    public class LiveChat : BaseTest
    {
        BaseTest smokeTestClass = new BaseTest();

        [Test]
        public void test()
        {
            GetAppActions().LiveChat("QA Test, Please Ignore");

            // Assert.IsTrue(reportState);
        }
    }
}
