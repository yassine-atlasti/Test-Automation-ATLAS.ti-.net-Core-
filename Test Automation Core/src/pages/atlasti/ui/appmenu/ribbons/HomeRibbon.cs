using OpenQA.Selenium.Appium.Windows;

namespace Test_Automation_Core.src.pages.atlasti.ui.appmenu.ribbons
{

    public class HomeRibbon
    {
        private readonly WindowsDriver<WindowsElement> _driver;

        public HomeRibbon(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        public void ClickDocuments()
        {
            // Locate the Documents element and perform the click action
            var documentsElement = _driver.FindElementByName("Documents");
            documentsElement.Click();


        }

        // Similarly for the other elements...

    }

}
