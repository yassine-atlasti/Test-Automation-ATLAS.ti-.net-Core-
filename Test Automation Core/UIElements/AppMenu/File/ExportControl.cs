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
            // Locate the TabItem by name
            var tabItem = _driver.FindElementByAccessibilityId("TransferBundleTab");

            // Find the button within the TabItem
            var button = tabItem.FindElementByName("Project Bundle");

            // Click the button
            button.Click();
        }

        public void ClickQDPXProjectBundleTabItem()
        {
            
            // Locate the TabItem by name
            var tabItem = _driver.FindElementByAccessibilityId("QDPXBundleTab");

            // Find the button within the TabItem
            var button = tabItem.FindElementByName("QDPX Project Bundle");

            // Click the button
            button.Click();
        }

        public FilePicker ClickProjectBundleButton(string tabType)
        {


            // Locate the TabItem by name
            var tabItem = _driver.FindElementByAccessibilityId(tabType).FindElementByTagName("Button");

            // Find the button within the TabItem
            var button = tabItem.FindElementByName("Project Bundle");

            // Click the button
            button.Click();
            return new FilePicker(_driver);
        }
        // ... add other methods for other controls within the ExportControl.
    }

}
