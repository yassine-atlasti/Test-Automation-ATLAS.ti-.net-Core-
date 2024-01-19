using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System.Xml.Linq;
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
            // Locate the TabItem 
            var control = _driver.FindElementByClassName("TabControl");
            System.Console.WriteLine(control.Text);
            var tabItem =   control.FindElementByName("QDPX Project Bundle");
            System.Console.WriteLine(tabItem.Text);
            tabItem.Click();

            /**foreach (var element in control)
            {
                System.Console.WriteLine(element.Text);

                try
                {
                    if (element.Text.Equals("Project Bundle"))
                    {
                        // Element with text "x" found, return it
                        element.Click();
                    }
                }
                catch(Exception e) { }
            }**/

            //  var test = qdpxTabItem.Contains();

            // Find the button within the TabItem

            // Click the button
        }
        // Devs need to automation IDs to the buttons needed for Project Export (Atlproj and QDPX

        public FilePicker HitEnter(string tabType)
        {


            _driver.FindElementByName("Export").SendKeys(Keys.Enter);
            return new FilePicker(_driver);
        }

        // Devs need to automation IDs to the buttons needed for Project Export (Atlproj and QDPX

        public void UnselectCheckBox()
        {

            //Replace Locator
            try
            {
               // var columHeader = _driver.FindElementByClassName("GridViewColumnHeader");

                var checkBox = _driver.FindElementsByTagName("CheckBox");

                //checkBox.SendKeys(Keys.Space);
            }

            catch(Exception ex) { }
        }


    }

}
