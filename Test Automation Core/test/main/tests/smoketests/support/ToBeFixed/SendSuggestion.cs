namespace Test_Automation_Core.test.main.tests.smoketests.support.ToBeFixed
{
    public class SendSuggestion
    {
        BaseTest smokeTestClass = new BaseTest();

        [Test]
        public void test()
        {
            smokeTestClass.SetupATLAS();
            bool suggestionState = smokeTestClass.GetAppActions().SendSuggestion("Test", "tester@atlasti.com");
            Assert.IsTrue(suggestionState);
        }

    }
}
