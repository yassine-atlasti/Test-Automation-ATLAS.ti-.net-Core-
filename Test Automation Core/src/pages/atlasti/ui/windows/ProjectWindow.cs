using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using Test_Automation_Core.src.pages.atlasti.ui.appmenu;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.src.pages.atlasti.ui.windows
{
    public class ProjectWindow
    {
        private readonly WindowsDriver<WindowsElement> driver;

         public ProjectWindow(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }
        public bool IsProjectOpen(string projectName)
        {

            SystemUtil systemActions = new SystemUtil();
            string windowName = projectName + " - ATLAS.ti";
            bool projectState = systemActions.WaitForElementToBeDisplayedByTagName(driver, "Window", windowName, 2);

            return projectState;
        }



        public bool IsErrorDialogDisplayed(string dialogAccessibilityId, string dialogName)
        {
            try
            {
                var errorDialog = driver.FindElementByAccessibilityId(dialogAccessibilityId);

                if (errorDialog != null && errorDialog.Displayed && errorDialog.Text.Contains(dialogName))
                {
                    return true;
                }

                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }



        public Menu getAppMenu()
        {
            return new Menu(driver);
        }

        // Add methods for interacting with Project Window elements as needed





    }
}
