using OpenQA.Selenium.Appium.Windows;
using Test_Automation_Core.src;
using Test_Automation_Core.src.pages.atlasti.actions;
using Test_Automation_Core.src.pages.atlasti.ui.windows;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.tests
{
    [TestFixture]
    public class NUnitTestClass
    {
        private static WindowsDriver<WindowsElement> _driver;
        App appControl;
        ApplicationActions appActions;
        WelcomeWindow welcomeWindow;
        string major = "23";
        SystemActions systemActions = new SystemActions();



        [Test]
        public void test()
        {
            TestRunner.RunTestByCategory("TestAutomationFramework.dll", "Test_Automation_Core.test.resources.test", "backuptests");
        }






    }



}
