using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextCopy;

namespace Test_Automation_Core.OS.Windows
{
    public class ControlPanel
    {
        private WindowsDriver<WindowsElement> driver;
        public void UninstallATLASti(string majorVersion)
        {
            string controlPanelCommand = "control";
            string programsAndFeaturesCommand = "appwiz.cpl";

            Process.Start(controlPanelCommand, $"{programsAndFeaturesCommand}");

            var fileName = "ATLAS.ti " + majorVersion;


            ClipboardService.SetText(fileName);

            // Create a new Actions object
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(driver);

            Thread.Sleep(1000);

            // Use CTRL+L to focus on the address bar, then paste the clipboard content 
            action.KeyDown(Keys.Control).SendKeys("f").KeyUp(Keys.Control).SendKeys(Keys.Control + "v").KeyUp(Keys.Control).SendKeys(Keys.Enter).Perform();


            var element = driver.FindElementByTagName("Edit").FindElementByName(fileName);
            action.DoubleClick(element).Perform();


        }

    }
}
