using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.OS.Windows;

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

        public void UnselectCheckBox()
        {
            

            // Navigate through the UI tree
            WindowsElement ribbon = _driver.FindElementByName("Ribbon");
            WindowsElement menu = (WindowsElement)ribbon.FindElementByName("PART_RibbonBackstage");
            WindowsElement tabListItem = (WindowsElement)menu.FindElementByName("Export");
            WindowsElement customElement = (WindowsElement)tabListItem.FindElementByAccessibilityId("TheExportControl");
            WindowsElement tabControl = (WindowsElement)customElement.FindElementByClassName("TabControl");
            WindowsElement tabItem = (WindowsElement)tabControl.FindElementByName("System.Windows.Controls.TabItem Header: Content:");
            WindowsElement dataGrid = (WindowsElement)tabItem.FindElementByClassName("ListView");
            WindowsElement headerRow = (WindowsElement)dataGrid.FindElementByClassName("GridViewHeaderRowPresenter");
            WindowsElement columnDefinition =   (WindowsElement)headerRow.FindElementByName("ColumnDefinition #Selection");
            columnDefinition.Click();

           
        }


        // ... add other methods for other controls within the ExportControl.
    }

}
