using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System.Net;
using TextCopy;
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


            TextCopy.ClipboardService.SetText(filePath);

            // Create a new Actions object
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(driver);

            System.Threading.Thread.Sleep(1000);

            // Use CTRL+L to focus on the address bar, then paste the clipboard content 
            action.KeyDown(Keys.Control).SendKeys("l").KeyUp(Keys.Control).SendKeys(Keys.Control + "v").Perform();
        }



        public void EnterFileName(string fileName)
        {
            TextCopy.ClipboardService.SetText(fileName);

            // Create a new Actions object
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(driver);

            System.Threading.Thread.Sleep(1000);

            // Use Alt+N to focus on the address bar, then paste the clipboard content 
            action.SendKeys(Keys.Control + "v").Perform();
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
