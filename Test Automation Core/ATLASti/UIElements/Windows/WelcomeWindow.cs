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
using Test_Automation_Core.OS.Windows;
using Test_Automation_Core.ATLAS.ti.UIElements.Dialogs;
using System.Diagnostics;
using TextCopy;

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

            ClipboardService.SetText(projectName);

            // Create a new Actions object
           // OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(driver);

            Thread.Sleep(1000);

            searchField.SendKeys(Keys.Control+"v");
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


        public bool IsErrorDialogDisplayed(string dialogAccessibilityId, string dialogName)
        {
            try
            {
                var errorDialog = driver.FindElementByAccessibilityId(dialogAccessibilityId);

                if (errorDialog != null && errorDialog.Displayed && errorDialog.Text.Contains(dialogName))
                {
                    return true;
                }

                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }




        public bool HasAtlasCrashed(TimeSpan timeout)
        {
            var watch = Stopwatch.StartNew();
            bool atlasWindowExists = false;

            while (watch.Elapsed < timeout)
            {
                // Reset the flag
                atlasWindowExists = false;

                // Go through all window handles
                foreach (var handle in driver.WindowHandles)
                {
                    // Switch to the current window
                    driver.SwitchTo().Window(handle);

                    // Check if the window's title is "ATLAS.ti"
                    if (driver.Title == "ATLAS.ti")
                    {
                        // ATLAS.ti window exists
                        atlasWindowExists = true;
                    }
                     Task.Delay(2000);

                    // Check if the window's title is "ATLAS.ti Problem"
                    if (driver.Title == "ATLAS.ti Problem")
                    {

                         
                        // If so, return true (there has been a crash)
                        return true;
                    }
                }

                // If the ATLAS.ti window exists but no crash window has been found, exit the loop
                if (atlasWindowExists)
                {
                    break;
                }

                // Wait for a short period before checking again
                Thread.Sleep(500);
            }

            // If no window with the title "ATLAS.ti Problem" was found within the timeout, return false
            return false;
        }


    }
}
