namespace Test_Automation_Core.test.main.tests.smoketests.support
{
    public class InternalUpdater : BaseTest
    {


        [Test, Category("support")]
        public void TestBuiltInUpdater()
        {
            bool result = GetAppActions().CheckForUpdates();
            Assert.IsTrue(result);
        }
    }
}
