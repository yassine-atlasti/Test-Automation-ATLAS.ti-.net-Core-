using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace Test_Automation_Core.UIElements.ProjectWindow
{
    public class AtlasProjectWindow
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public AtlasProjectWindow(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        // Add methods for interacting with Project Window elements as needed
    }
}
