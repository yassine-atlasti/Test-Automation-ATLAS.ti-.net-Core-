


using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;

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
            problemDescriptionTextField.SendKeys(problemDescription);
        }

        public void EnterEmail(string email)
        {
            WindowsElement emailTextField = driver.FindElementByAccessibilityId("EmailTextField");
            emailTextField.Click();
            emailTextField.Clear();
            emailTextField.SendKeys(email);
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
