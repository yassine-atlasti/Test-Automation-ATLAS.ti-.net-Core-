using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.src.pages.installer
{
    public class InstallerActions
    {

        WindowsDriver<WindowsElement> driver;
        string eula;
        public InstallerActions(WindowsDriver<WindowsElement> driver) { this.driver = driver; }
        public InstallerActions() { }
        public void OpenInstaller(string filePath)
        {
            Process.Start(filePath);
        }


        public bool InstallATLASti(string installerPath, string majorVersion)
        {


            //Wait for Installer to be displayed
            SystemActions systemActions = new SystemActions();
            bool installerState = systemActions.WaitForElementToBeDisplayedByTagName(driver, "Window", $"Setup - ATLAS.ti {majorVersion}", 120);

            if (installerState)
            {
                //Add 1 second sleep between each page change in the Installer Wizard
                string windowName = $"Setup - ATLAS.ti {majorVersion}";
                var window = driver.FindElementByTagName("Window").FindElementByName(windowName);



                window.FindElementByName("Next").Click();

                Thread.Sleep(1000);

                window.FindElementByTagName("CheckBox").Click();
                window.FindElementByName("Next").Click();

                Thread.Sleep(1000);

                window.FindElementByName("Next").Click();

                Thread.Sleep(1000);

                window.FindElementByName("Install").Click();

                Thread.Sleep(1000);
                installerState = systemActions.WaitForElementToBeDisplayedByTagName(driver, "CheckBox", "Launch ATLAS.ti", 80);

                // window.FindElementByTagName("CheckBox").Click() ;

                window.FindElementByName("Close").Click();

            }
            else { installerState = false; }

            return installerState;
        }











    }
}
