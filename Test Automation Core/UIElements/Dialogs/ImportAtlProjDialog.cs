using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Test_Automation_ATLAS.ti.ProjectWindow;

namespace Test_Automation_Core.UIElements.Dialogs
{
    public class ImportAtlProjDialog
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public ImportAtlProjDialog(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        public void EnterProjectName(string projectName)
        {
            driver.FindElementByName("Project Name").SendKeys(projectName);
        }

        public void ClickImportButton()
        {
            driver.FindElementByName("Import").Click();
        }

        public void ClickCancelButton()
        {
            driver.FindElementByName("Cancel").Click();
        }


        public ProjectWindow.AtlasProjectWindow ClickImportAndWaitForProjectWindow()
        {
            ClickImportButton();
            // Wait for a unique element in the Project Window to appear.
            // Replace "UniqueElementInProjectWindow" with an actual unique element name or locator.
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("UniqueElementInProjectWindow")));
            return new ProjectWindow.AtlasProjectWindow(driver);
        }


    }
}
