


using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace Test_Automation_Core.UIElements.Dialogs

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
            WindowsElement problemDescriptionTextField = driver.FindElementByName("ProblemDescription");
            problemDescriptionTextField.Clear();
            problemDescriptionTextField.SendKeys(problemDescription);
        }

        public void EnterEmail(string email)
        {
            WindowsElement emailTextField = driver.FindElementByName("Email");
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
            driver.FindElementByName("OK").Click();

        }


    }
}
