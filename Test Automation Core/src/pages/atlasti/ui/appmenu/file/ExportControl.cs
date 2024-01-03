using OpenQA.Selenium.Appium.Windows;
using Test_Automation_Core.src.pages.windowsos;

namespace Test_Automation_Core.src.pages.atlasti.ui.appmenu.file
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
            var tabItem = _driver.FindElementByAccessibilityId("TheExportControl");

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

            //Replace Locator
         
            WindowsElement checkBox = _driver.FindElementByName("CheckBox Locator");
            checkBox.Click();


        }


    }

}
