using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace Test_Automation_ATLAS.ti.WelcomeWindow.Dialogs
{
    public class NewProjectDialog
    {
        private readonly WindowsDriver<WindowsElement> driver;
        private string projectName;
        public NewProjectDialog(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
           
        }

        public void EnterProjectName(string projectName)
        {
            driver.FindElementByName("Project Name").SendKeys(projectName);
        }

        public void EnterComment(string comment)
        {
            driver.FindElementByName("Comment").SendKeys(comment);
        }

        public void ClickCreateButton()
        {
            driver.FindElementByName("Create").Click();
        }

        public void ClickCancelButton()
        {
            driver.FindElementByName("Cancel").Click();
        }
    }
}
