


using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using TextCopy;

namespace Test_Automation_Core.src.pages.atlasti.ui.dialogs

{
    public class CrashReportDialog
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public CrashReportDialog(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }


        // Add methods for interacting with Report Crash Dialog elements as needed



        public void EnterCrashDescription(string problemDescription)
        {
            var CrashDialogElement = driver.FindElementByTagName("Window").FindElementByName("ATLAS.ti Problem");


            var problemDescriptionTextField = CrashDialogElement.FindElementByAccessibilityId("DescriptionTextField");

            problemDescriptionTextField.Click();

            ClipboardService.SetText(problemDescription);

            // Create a new Actions object
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(driver);

            Thread.Sleep(1000);

            action.SendKeys(Keys.Control + "v").KeyUp(Keys.Control).Perform();
        }

        public void EnterEmail(string email)
        {
            var CrashDialogElement = driver.FindElementByTagName("Window").FindElementByName("ATLAS.ti Problem");

            var emailTextField = CrashDialogElement.FindElementByAccessibilityId("EmailTextField");
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
            var CrashDialogElement = driver.FindElementByTagName("Window").FindElementByName("ATLAS.ti Problem");

            CrashDialogElement.FindElementByName("Send Error Report").Click();
        }

        public void moveDialogToForeground()
        {
            // driver.ActivateApp("15260");
        }



    }
}
