using OpenQA.Selenium.Appium.Windows;

namespace Test_Automation_Core.src.pages.atlasti.ui.appmenu.file
{
    public class FileTab
    {
        private WindowsDriver<WindowsElement> _driver;

        public FileTab(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }


        public void ClickSave()
        {
            var saveButton = _driver.FindElementByName("Save");
            saveButton.Click();
        }

        public void ClickOpen()
        {
            var openButton = _driver.FindElementByName("Open");
            openButton.Click();
        }

        public ExportControl ClickExport()
        {
            var exportButton = _driver.FindElementByName("Export");
            exportButton.Click();
            return new ExportControl(_driver);
        }

        public void ClickClose()
        {
            var closeButton = _driver.FindElementByName("Close");
            closeButton.Click();
        }
        // ... add other methods for other controls within the tab.
    }

}
