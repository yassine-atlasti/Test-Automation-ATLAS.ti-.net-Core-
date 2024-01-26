using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.src.pages.atlasti.ui.dialogs
{
    public class LiveChatDialog
    {
        private WindowsDriver<WindowsElement> _driver;
        private WindowsElement _dialog;
        SystemUtil systemActions = new SystemUtil();

        public LiveChatDialog(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            /*+   var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
               _dialog = (WindowsElement?)wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("Chat")));**/

        }

       
        public bool StartChat()
        {

            // systemActions.WaitForElementToBeDisplayedByName(_driver, "Chat We’re online right now, talk with our team in real-time", 5);

            //var startChatButton = _driver.FindElementByName("Chat We’re online right now, talk with our team in real-time");

            var liveChatWindow = _driver.FindElementByName("Support – Live Chat");
                liveChatWindow.SendKeys(Keys.Tab);
            liveChatWindow.SendKeys(Keys.Tab);
            liveChatWindow.SendKeys(Keys.Tab);
            liveChatWindow.SendKeys(Keys.Tab);
            liveChatWindow.SendKeys(Keys.Tab);

            liveChatWindow.SendKeys(Keys.Enter);

            Thread.Sleep(2000);
            liveChatWindow.SendKeys("QA Test,Please ignore this!" + Keys.Enter);

           bool res= systemActions.WaitForElementToBeDisplayedByName(_driver, "End Chat", 5);

            return res;
        }

        public void EndChat()
        {
            var endChatButton = _driver.FindElementByName("End Chat");
            endChatButton.Click();
        }
        // Add additional methods as needed, for example to receive chat responses, to check chat status etc.
    }

}
