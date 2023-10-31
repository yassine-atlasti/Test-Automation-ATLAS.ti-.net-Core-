using OpenQA.Selenium.Appium.Windows;

namespace Test_Automation_Core.src.pages.atlasti.ui.appmenu.ribbons
{
    public class DeveloperRibbon
    {
        private WindowsDriver<WindowsElement> driver;

        public DeveloperRibbon(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        public void RaiseAtlasException()
        {

            driver.FindElementByAccessibilityId("RaiseException").Click();
            driver.FindElementByName("Raise Exception").Click();
        }




    }
}
