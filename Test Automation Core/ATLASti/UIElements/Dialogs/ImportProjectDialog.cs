using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Windows.Forms;

using Test_Automation_Core.UIElements.AtlasWindows;
using TextCopy;
using Test_Automation_Core.OS.Windows;

namespace Test_Automation_Core.UIElements.Dialogs
{
    public class ImportProjectDialog
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public ImportProjectDialog(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        public void EnterProjectName(string projectName)
        {


            var projectBox = driver.FindElementByAccessibilityId("NewProjectNameBox");
            projectBox.Clear();


            projectBox.Click();

            ClipboardService.SetText(projectName);

            // Create a new Actions object
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(driver);

            Thread.Sleep(1000);

            action.SendKeys(Keys.Control + "v").KeyUp(Keys.Control).Perform();
        }




        public void ClickImportButton()
        {
            driver.FindElementByName("Import").Click();
        }

        public void ClickCancelButton()
        {
            driver.FindElementByName("Cancel").Click();
        }


        public ProjectWindow ClickImportAndWaitForProjectWindow(string projectName)
        {
            //Check if project name already exists 



            ClickImportButton();
            // Wait for a unique element in the Project Window to appear.
            // Replace "UniqueElementInProjectWindow" with an actual unique element name or locator.
            System.Threading.Thread.Sleep(35000);

            var projectWindow = new ProjectWindow(driver);
            projectWindow.IsProjectOpen(projectName);
            return projectWindow;
        }


        public FilePicker ClickBrowseMediaFolderButton()
        {
            // Find the BrowseMediaFolderButton and click it
            var mediaFolderButton = driver.FindElementByName("File Picker Button");
            mediaFolderButton.Click();

            // Return a new FilePickerDialog object, assuming that clicking the button opens this dialog
            return new FilePicker(driver);
        }


        public bool IsMediaFolderButtonVisible()
        {
            try
            {
                // Try to find the MediaFolderButton
                var mediaFolderButton = driver.FindElementByName("Please choose a content folder.");

                // If the button is found and is displayed, return true
                return mediaFolderButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                // If the button is not found, it is not visible, so return false
                return false;
            }
        }

        




    }
}
