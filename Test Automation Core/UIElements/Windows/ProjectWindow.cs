using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using Test_Automation_Core.UIElements.AppMenu;
using System;

namespace Test_Automation_Core.UIElements.AtlasWindows
{
    public class ProjectWindow
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public ProjectWindow(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }
        public bool IsProjectOpen(string uniqueElement)
        {
            try
            {
                // Assume that when a project is open, a unique element of the project window exists
                var projectElement = driver.FindElementByName(uniqueElement + " - ATLAS.ti");
                return projectElement != null;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }





        public void WaitForProjectToDisplay(string projectName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60)); // Set the maximum wait time

            // Define the expected condition
            Func<IWebDriver, bool> condition = (drv) =>
            {
                try
                {
                    var titleElement = ((WindowsDriver<WindowsElement>)drv).FindElementByAccessibilityId("PART_RibbonTitleBar").FindElementByName(projectName+" - ATLAS.ti");
                    return titleElement.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            };

            // Wait until the condition is met
            wait.Until(condition);
        }


        public Menu getAppMenu()
        {
            return new Menu(driver);
        }

        // Add methods for interacting with Project Window elements as needed
    }
}
