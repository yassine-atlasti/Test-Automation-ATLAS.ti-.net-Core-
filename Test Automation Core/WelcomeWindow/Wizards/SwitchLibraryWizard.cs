using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using  Test_Automation_ATLAS.ti.WelcomeWindow.Dialogs;
namespace Test_Automation_ATLAS.ti.WelcomeWindow.Wizards
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
            driver.FindElementByName("Next").Click();
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
            driver.FindElementByName("File Picker").Click();
            return new FilePicker(driver);
        }
    }
}
