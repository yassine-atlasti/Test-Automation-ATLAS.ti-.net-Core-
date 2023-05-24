using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using Test_Automation_Core.UIElements.Dialogs;
using Test_Automation_Core.UIElements.AtlasWindows;
using System.Xml.Linq;

namespace Test_Automation_Core.UIElements.WelcomeWindow
{
    public class WelcomeWindow
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public WelcomeWindow(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }




        public void ClickNewProjectButton()
        {
            driver.FindElementByName("New Project").Click();
        }


        public void ClickImportProjectButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("Import Project")));
            driver.FindElementByName("Import Project").Click();
        }
        public void ClickOptionsButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("Options Dialog Link")));
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

        public ImportProjectDialog WaitForImportAtlProjDialog()
        {
            // You can use an explicit wait to wait for the dialog to appear.
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("Project Name")));
            return new ImportProjectDialog(driver);
        }


        public void OpenProject(string projectName)
        {

            //Add a way to open the project if another project is already open


            SearchProject(projectName);

            var projectList = driver.FindElementByTagName("List");

            var project= projectList.FindElementByName(projectName);

            // Create an Actions object
            OpenQA.Selenium.Interactions.Actions actions = new OpenQA.Selenium.Interactions.Actions(driver);

            // Double click the element
            actions.DoubleClick(project).Perform();

            //Wait for the project to open by identifying a unique UI Element in the project Window
            // Add a delay to allow the application window to open
            Thread.Sleep(TimeSpan.FromSeconds(15));

        }


        public bool IsWelcomeWindowDisplayed()
        {
            try
            {
                // Assume that when the welcome window is displayed, an element with the name "WelcomeWindow" exists
                driver.FindElementByName("Your Projects");
                return true;  // If the element was found, the welcome window is displayed
            }
            catch (NoSuchElementException)
            {
                return false;  // If the element was not found, the welcome window is not displayed
            }
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
            //to implement

           

        }




        public void SelectProjectContextMenuOption(string projectName, string menuOption)
        {
            SearchProject(projectName);

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
