namespace Test_Automation_Core.test.main.tests.smoketests.support
{
    public class InternalUpdater : BaseTestCase
    {


        [Test, Category("support")]
        public void TestBuiltInUpdater()
        {
            bool result = GetAppActions().CheckForUpdatesRC();
            Assert.IsTrue(result);
        }
    }
}
