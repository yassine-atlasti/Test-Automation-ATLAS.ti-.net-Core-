using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.UIElements.Dialogs;

namespace Test_Automation_Core.UIElements.AppMenu.File
{
    public class ExportControl
    {
        private WindowsDriver<WindowsElement> _driver;

        public ExportControl(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        public void ClickProjectBundleTabItem()
        {
            var projectBundleTabItem = _driver.FindElementByName("Project Bundle Item");
            projectBundleTabItem.Click();
        }

        public void ClickQDPXProjectBundleTabItem()
        {
            var qdpxProjectBundleTabItem = _driver.FindElementByName("QDPX Project Bundle Item");
            qdpxProjectBundleTabItem.Click();
        }

        public FilePicker ClickProjectBundleButton()
        {
            var ProjectBundleButton = _driver.FindElementByName("Project Bundle Button");
            ProjectBundleButton.Click();
            return new FilePicker(_driver);
        }
        // ... add other methods for other controls within the ExportControl.
    }

}
