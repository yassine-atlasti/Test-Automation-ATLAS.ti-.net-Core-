


using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using TextCopy;

namespace Test_Automation_Core.ATLAS.ti.UIElements.Dialogs

{
    public class CrashReportDialog
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public CrashReportDialog(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        // Add methods for interacting with Report Problem Dialog elements as needed

        public void EnterProblemDescription(string problemDescription)
        {
            WindowsElement problemDescriptionTextField = driver.FindElementByAccessibilityId("DescriptionTextField");

            problemDescriptionTextField.Click();
           
            ClipboardService.SetText(problemDescription);

            // Create a new Actions object
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(driver);

            Thread.Sleep(1000);

            action.SendKeys(Keys.Control + "v").KeyUp(Keys.Control).Perform();
        }

        public void EnterEmail(string email)
        {
            WindowsElement emailTextField = driver.FindElementByAccessibilityId("EmailTextField");
            emailTextField.Click();
            emailTextField.Clear();

            ClipboardService.SetText(email);

            // Create a new Actions object
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(driver);

            Thread.Sleep(1000);

            action.SendKeys(Keys.Control + "v").KeyUp(Keys.Control).Perform();
        }

        public void ClickSendErrorButton()
        {
            driver.FindElementByName("Send Error Report").Click();
        }

        public void ClickCancelButton()
        {
            driver.FindElementByName("Don't Send").Click();
        }

        public void CloseConfirmationDialog()
        {

            driver.FindElementByName("OK\\").Click();

        }

        

    }
}
