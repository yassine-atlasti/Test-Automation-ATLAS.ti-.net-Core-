using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace Test_Automation_Core.UIElements.Dialogs
{
    public class SuggestionDialog
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public SuggestionDialog(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        // Add methods for interacting with Send Suggestion Dialog elements as needed
        public void EnterSuggestionDescription(string suggestionDescription)
        {
            WindowsElement suggestionDescriptionTextField = driver.FindElementByName("SuggestionDescription");
            suggestionDescriptionTextField.Clear();
            suggestionDescriptionTextField.SendKeys(suggestionDescription);
        }

        public void EnterEmail(string email)
        {
            WindowsElement emailTextField = driver.FindElementByName("Email");
            emailTextField.Clear();
            emailTextField.SendKeys(email);
        }

        public void ClickSendSuggestionButton()
        {
            driver.FindElementByName("Send Suggestion").Click();
        }

        public void ClickCancelButton()
        {
            driver.FindElementByName("Cancel").Click();
        }

        public void CloseConfirmationDialog()
        {
            driver.FindElementByName("OK").Click();

        }
    }
}
