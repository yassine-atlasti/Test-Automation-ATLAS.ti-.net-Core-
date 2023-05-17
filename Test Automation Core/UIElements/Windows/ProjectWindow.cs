using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace Test_Automation_Core.UIElements.AtlasWindows
{
    public class ProjectWindow
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public ProjectWindow(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }
        public bool IsProjectOpen(string projectName)
        {
            try
            {
                // Assume that when a project is open, an element with the name of the project exists
                var projectElement = driver.FindElementByName(projectName);
                return projectElement != null;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // Add methods for interacting with Project Window elements as needed
    }
}
