using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.support
{
    public class LiveChat : BaseTest
    {
        BaseTest smokeTestClass = new BaseTest();

        [Test, Category("support")]
        public void testLiveChat()
        {
            GetAppActions().OpenProject(SmokeTestVariables.smokeTestproject);
            bool liveChat = GetAppActions().LiveChat("QA Test, Please Ignore");

            Assert.IsTrue(liveChat);
        }
    }
}
