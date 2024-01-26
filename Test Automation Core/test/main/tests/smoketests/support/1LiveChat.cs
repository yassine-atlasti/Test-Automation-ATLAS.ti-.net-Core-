using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.support
{
    public class LiveChat : BaseTestCase
    {
        BaseTestCase smokeTestClass = new BaseTestCase();

        [Test, Category("support")]
        public void testLiveChat()
        {
            GetAppActions().OpenProject(SmokeTestVariables.smokeTestproject);
            bool liveChat = GetAppActions().LiveChat("QA Test, Please Ignore");

            Assert.IsTrue(liveChat);
        }
    }
}
