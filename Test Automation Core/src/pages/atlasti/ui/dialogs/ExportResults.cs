using OpenQA.Selenium.Appium.Windows;

namespace Test_Automation_Core.src.pages.atlasti.ui.dialogs
{
    public class ExportResults
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public ExportResults(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        public void CancelQDPXResultsExport()
        {
            driver.FindElementByName("Cancel").Click();

        }












    }
}
