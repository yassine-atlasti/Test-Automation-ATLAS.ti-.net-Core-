using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test_Automation_Core.UIElements.Dialogs
{
    public class LiveChatDialog
    {
        private WindowsDriver<WindowsElement> _driver;
        private WindowsElement _dialog;

        public LiveChatDialog(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _dialog = (WindowsElement?)wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("UniqueElementInLiveChatDialog")));

        }

        public void EnterChatText(string chatText)
        {
            var chatTextField = _dialog.FindElementByName("Send message");
            chatTextField.Clear();
            chatTextField.SendKeys(chatText + Keys.Enter) ;
        }

        public void StartChat()
        {
            var startChatButton = _dialog.FindElementByName("Chat");
            startChatButton.Click();
        }

        public void EndChat()
        {
            var endChatButton = _dialog.FindElementByName("End Chat");
            endChatButton.Click();
        }
        // Add additional methods as needed, for example to receive chat responses, to check chat status etc.
    }

}
