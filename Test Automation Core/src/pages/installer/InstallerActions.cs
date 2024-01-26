using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Test_Automation_Core.test.resources.test;
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


        public bool InstallATLASti()
        {


            //Wait for Installer to be displayed
            SystemUtil systemActions = new SystemUtil();
            bool installerState = systemActions.WaitForElementToBeDisplayedByTagName(driver, "Window", $"Setup - ATLAS.ti {AtlasVariables.rcMajor}", 120);

            if (installerState)
            {
                //Add 1 second sleep between each page change in the Installer Wizard
               



                driver.FindElementByName("Next").Click();

                Thread.Sleep(1000);

                driver.FindElementByTagName("CheckBox").Click();
                driver.FindElementByName("Next").Click();

                Thread.Sleep(1000);

                driver.FindElementByName("Next").Click();

                Thread.Sleep(1000);

                driver.FindElementByName("Install").Click();

                Thread.Sleep(1000);
                installerState = systemActions.WaitForElementToBeDisplayedByTagName(driver, "CheckBox", "Launch ATLAS.ti", 80);

                // window.FindElementByTagName("CheckBox").Click() ;

                driver.FindElementByName("Close").Click();

            }
            else { installerState = false; }

            return installerState;
        }

       











    }
}
