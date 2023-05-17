using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace Test_Automation_Core.UIElements.Dialogs
{
    public class FilePicker
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public FilePicker(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        public void EnterFilePath(string filePath)
        {
            driver.FindElementByClassName("Edit").SendKeys(filePath);
        }

        public void ClickOpenButton()
        {
            driver.FindElementByName("Open").Click();
        }

        public void ClickCancelButton()
        {
            driver.FindElementByName("Cancel").Click();
        }
        public void ClickSelectFolderButton()
        {
            driver.FindElementByName("Select Folder").Click();
        }

        public void ClickSaveButton()
        {
            driver.FindElementByName("Save").Click();
        }
    }
}
