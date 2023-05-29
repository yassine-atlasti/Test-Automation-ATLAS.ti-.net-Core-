using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.UIElements.Dialogs
{
    public class ExportResults
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public ExportResults(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        public void CancelQDPXResultsExport()
        {
            driver.FindElementByName("Cancel").Click();

                    }







       
        



    }
}
