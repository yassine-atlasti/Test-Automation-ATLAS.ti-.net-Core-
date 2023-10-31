using OpenQA.Selenium.Appium.Windows;

namespace Test_Automation_Core.src.pages.atlasti.ui.dialogs

{
    public class ReportProblemDialog
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public ReportProblemDialog(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        // Add methods for interacting with Report Problem Dialog elements as needed

        public void EnterProblemDescription(string problemDescription)
        {
            WindowsElement problemDescriptionTextField = driver.FindElementByAccessibilityId("FeedbackText");
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

        public void ClickReportProblemButton()
        {
            driver.FindElementByName("Report Problem").Click();
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
