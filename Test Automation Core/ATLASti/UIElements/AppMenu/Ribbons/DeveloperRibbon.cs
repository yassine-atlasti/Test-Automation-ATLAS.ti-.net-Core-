using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.ATLASti.UIElements.AppMenu.Ribbons
{
    public class DeveloperRibbon
    {
        private WindowsDriver<WindowsElement> driver;

        public DeveloperRibbon(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        public void RaiseAtlasException()
        {

            driver.FindElementByAccessibilityId("RaiseException").Click();
            driver.FindElementByName("Raise Exception").Click();
        }




    }
}
