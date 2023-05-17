using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.UIElements.AppMenu.File;

namespace Test_Automation_Core.UIElements.AppMenu
{
    public class FileTab
    {
        private WindowsDriver<WindowsElement> _driver;

        public FileTab(WindowsDriver<WindowsElement> driver )
        {
            _driver = driver;
        }

        public void ClickFile()
        {
            var FileButton = _driver.FindElementByName("File");
            FileButton.Click();
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

        // ... add other methods for other controls within the tab.
    }

}
