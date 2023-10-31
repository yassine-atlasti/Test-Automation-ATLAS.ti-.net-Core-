using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;


namespace Test_Automation_Core.src.pages.atlasti.ui.dialogs
{
    public class LiveChatDialog
    {
        private WindowsDriver<WindowsElement> _driver;
        private WindowsElement _dialog;

        public LiveChatDialog(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            /*+   var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
               _dialog = (WindowsElement?)wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("Chat")));**/

        }

        public void EnterChatText(string chatText)
        {
            var chatTextField = _driver.FindElementByName("Write chat message");
            chatTextField.Clear();
            chatTextField.SendKeys(chatText + Keys.Enter);
        }

        public void StartChat()
        {
            var startChatButton = _driver.FindElementByName("Chat We’re online right now, talk with our team in real-time");
            startChatButton.Click();
        }

        public void EndChat()
        {
            var endChatButton = _driver.FindElementByName("End Chat");
            endChatButton.Click();
        }
        // Add additional methods as needed, for example to receive chat responses, to check chat status etc.
    }

}
