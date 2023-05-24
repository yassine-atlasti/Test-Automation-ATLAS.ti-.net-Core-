using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

using Test_Automation_Core.UIElements.AtlasWindows;

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


        public ProjectWindow ClickImportAndWaitForProjectWindow(string projectName)
        {
            //Check if project name already exists 



            ClickImportButton();
            // Wait for a unique element in the Project Window to appear.
            // Replace "UniqueElementInProjectWindow" with an actual unique element name or locator.
           
            var projectWindow= new ProjectWindow(driver);
            projectWindow.WaitForProjectToDisplay(projectName);
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
