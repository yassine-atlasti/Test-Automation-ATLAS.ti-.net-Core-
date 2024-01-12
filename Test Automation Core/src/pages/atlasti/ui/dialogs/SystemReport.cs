using OpenQA.Selenium.Appium.Windows;

namespace Test_Automation_Core.src.pages.atlasti.ui.dialogs

{
    public class SystemReport
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public SystemReport(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        // Add methods for interacting with Report Problem Dialog elements as needed

       

        public void EnterEmail(string email)
        {
            WindowsElement emailTextField = driver.FindElementByAccessibilityId("EmailTextField");
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


    }
}
