using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using Test_Automation_Core.UIElements.Dialogs;

namespace Test_Automation_Core.UIElements.WelcomeWindow
{
    public class WelcomeControl
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public WelcomeControl(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }




        public void ClickNewProjectButton()
        {
            driver.FindElementByName("New Project").Click();
        }


        public void ClickImportProjectButton()
        {
            driver.FindElementByName("Import Project").Click();
        }
        public void ClickOptionsButton()
        {
            WindowsElement optionsButton = driver.FindElementByName("Options Dialog Link");
            optionsButton.Click();


        }

        public OptionsWindow OpenOptionsWindow()
        {
            ClickOptionsButton();
            // Wait for a unique element in the Options Window to appear.
            // Replace "UniqueElementInOptionsWindow" with an actual unique element name or locator.
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("Switch Library...")));
            return new OptionsWindow(driver);
        }

        public ImportAtlProjDialog WaitForImportAtlProjDialog()
        {
            // You can use an explicit wait to wait for the dialog to appear.
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("Project Name")));
            return new ImportAtlProjDialog(driver);
        }










        public WindowsElement FindProjectByName(string projectName)
        {
            return driver.FindElementByName(projectName);
        }

        public void SearchProject(string projectName)
        {
            WindowsElement searchField = driver.FindElementByAccessibilityId("SearchControl");
            searchField.Clear();
            searchField.SendKeys(projectName);
        }
        public void ClearSearch()
        {
            WindowsElement searchField = driver.FindElementByAccessibilityId("SearchControl");
            searchField.Clear();
        }
        public void RightClickProject(string projectName)

        {
            SearchProject(projectName);
            WindowsElement projectElement = driver.FindElementByName(projectName);

            Actions actions = new Actions(driver);
            actions.ContextClick(projectElement).Perform();
        }



        public void SelectProjectContextMenuOption(string projectName, string menuOption)
        {
            RightClickProject(projectName);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name(menuOption)));

            driver.FindElementByName(menuOption).Click();
        }
        // Add methods to handle the resulting actions or dialogs from the context-menu options as needed.








        public NewProjectDialog OpenNewProjectDialog()
        {
            ClickNewProjectButton();
            return new NewProjectDialog(driver);
        }
        public FilePicker OpenProjectFilePicker()
        {
            ClickImportProjectButton();
            return new FilePicker(driver);
        }






    }
}
