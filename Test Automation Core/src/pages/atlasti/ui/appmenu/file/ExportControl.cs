using OpenQA.Selenium.Appium.Windows;
using Test_Automation_Core.src.pages.windowsos;

namespace Test_Automation_Core.src.pages.atlasti.ui.appmenu.file
{
    public class ExportControl
    {
        private WindowsDriver<WindowsElement> _driver;


        // Devs need to automation IDs to the buttons needed for Project Export (Atlproj and QDPX

        public ExportControl(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        // Devs need to automation IDs to the buttons needed for Project Export (Atlproj and QDPX

        public void ClickProjectBundleTabItem()
        {
            // Locate the TabItem by name
            var tabItem = _driver.FindElementByAccessibilityId("TransferBundleTab");

            // Find the button within the TabItem
            var button = tabItem.FindElementByName("Project Bundle");

            // Click the button
            button.Click();
        }

        // Devs need to automation IDs to the buttons needed for Project Export (Atlproj and QDPX

        public void ClickQDPXProjectBundleTabItem()
        {
            // Locate the TabItem by name
            var tabItem = _driver.FindElementByAccessibilityId("TheExportControl");

            // Find the button within the TabItem
            var button = tabItem.FindElementByName("QDPX Project Bundle");

            // Click the button
            button.Click();
        }
        // Devs need to automation IDs to the buttons needed for Project Export (Atlproj and QDPX

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

        // Devs need to automation IDs to the buttons needed for Project Export (Atlproj and QDPX

        public void UnselectCheckBox()
        {

            //Replace Locator
         
            WindowsElement checkBox = _driver.FindElementByName("CheckBox Locator");
            checkBox.Click();


        }


    }

}
