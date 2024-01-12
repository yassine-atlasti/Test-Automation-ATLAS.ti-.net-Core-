using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using TextCopy;

namespace Test_Automation_Core.src.pages.atlasti.ui.dialogs
{
    public class FeedBackDialog
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public FeedBackDialog(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        // Add methods for interacting with Send Suggestion Dialog elements as needed
        public void EnterFeedBack(string suggestionDescription)
        {
            WindowsElement suggestionDescriptionTextField = driver.FindElementByAccessibilityId("FeedbackText");
            suggestionDescriptionTextField.Click();

            ClipboardService.SetText(suggestionDescription);

            // Create a new Actions object
            Actions action = new Actions(driver);

            
           
            // Paste the clipboard content
            action.SendKeys(Keys.Control + "v").KeyUp(Keys.Control).Perform();

        }

        public void EnterEmail(string email)
        {
            WindowsElement emailTextField = driver.FindElementByAccessibilityId("EMailAddress");
            emailTextField.Click();
            emailTextField.Clear();
            emailTextField.SendKeys(email);
        }

        public void ClickSendButton()
        {
            driver.FindElementByName("Send").Click();
        }

        public void ClickCancelButton()
        {
            driver.FindElementByName("Cancel").Click();
        }

        public void CloseConfirmationDialog()
        {

            driver.FindElementByName("OK\\").Click();

        }

        public void ClickYes()
        {

            driver.FindElementByName("Yes").Click();

        }

        public void ClickNo()
        {

            driver.FindElementByName("No").Click();

        }
    }
}
