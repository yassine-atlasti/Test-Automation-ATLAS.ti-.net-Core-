using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.ATLASti.UIElements.Dialogs
{
    public class ErrorDialog
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public ErrorDialog(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        
        public bool CloseErrorDialog()
        {
            try
            {
                // Find the OK button in the error dialog
                WindowsElement okButton = driver.FindElementByName("OK");

                if (okButton.Displayed)
                {
                    // Click the OK button to close the dialog
                    okButton.Click();
                    return false;
                }
                else {return true; }

            }
            catch (NoSuchElementException)
            {
                // OK button not found, handle the situation as needed
                return true; // Error dialog was not found
            }
        }


    }
}
