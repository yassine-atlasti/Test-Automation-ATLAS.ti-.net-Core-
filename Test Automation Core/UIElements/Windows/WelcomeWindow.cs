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
            // Get the parent control
            WindowsElement parentControl = driver.FindElementByAccessibilityId("TheWelcomeControl");

            // Find all image elements within the control
            var images = parentControl.FindElementsByTagName("Image").Take(4).ToArray();



            // Click the third image (0-based index, so index 2 is the third image)
            images[2].Click();
        }


        public void ClickImportProjectButton()
        {

            // Get the parent control
            WindowsElement parentControl = driver.FindElementByAccessibilityId("TheWelcomeControl");

            // Find all image elements within the control
            var images = parentControl.FindElementsByTagName("Image").Take(4).ToArray();

           
            
                // Click the third image (0-based index, so index 3 is the fourth image)
                images[3].Click();
            
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

        public ImportProjectDialog WaitForImportAtlProjDialog()
        {
            // You can use an explicit wait to wait for the dialog to appear.
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("Project Name")));
            return new ImportProjectDialog(driver);
        }


        public void OpenProject(string projectName)
        {

            

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
            var welcomeWindowElements = driver.FindElementsByName("Your Projects");
            return welcomeWindowElements.Count > 0;
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
