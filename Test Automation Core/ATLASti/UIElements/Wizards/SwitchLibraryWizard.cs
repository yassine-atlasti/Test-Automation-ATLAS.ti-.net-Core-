using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.ObjectModel;
using Test_Automation_Core.OS.Windows;

namespace Test_Automation_Core.UIElements.Wizards
{
    public class SwitchLibraryWizard
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public SwitchLibraryWizard(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        public void ClickNextButton()
        {
            driver.FindElementByName("Next >").Click();
        }

        public void ClickCancelButton()
        {
            driver.FindElementByName("Cancel").Click();
        }

        public void ClickFinishButton()
        {
            driver.FindElementByName("Finish").Click();
        }

        public void SelectOption(string optionName)
        {
            driver.FindElementByName(optionName).Click();
        }

        public FilePicker OpenFilePicker()
        {

            // Code to identify file picker button until new Autmation Properties are set
            WindowsElement wizard = driver.FindElementByClassName("LibraryLocationWizard"); // replace with actual locator

            var allImagesInWizard = wizard.FindElementsByTagName("Image");
            if (allImagesInWizard.Count > 0)
            {
                var imageElement = allImagesInWizard[0];
                imageElement.Click();
            }



            return new FilePicker(driver);
        }

        public bool IsElementDisplayed(string uiElement)
        {
            try
            {
               
                driver.FindElementByName(uiElement);
                return true;  
            }
            catch (NoSuchElementException)
            {
                return false; 
            }
        }
    }
}
