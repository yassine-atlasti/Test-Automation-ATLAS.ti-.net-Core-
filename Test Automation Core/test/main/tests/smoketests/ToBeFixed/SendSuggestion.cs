using Test_Automation_Core.test.main.tests;

namespace Test_Automation_Core.test.main.tests.smoketests.ToBeFixed
{
    public class SendSuggestion
    {
        InitTests smokeTestClass = new InitTests();

        [Test]
        public void test()
        {
            smokeTestClass.initATLAS();
            bool suggestionState = smokeTestClass.GetAppActions().SendSuggestion("Test", "tester@atlasti.com");
            Assert.IsTrue(suggestionState);
        }

    }
}
