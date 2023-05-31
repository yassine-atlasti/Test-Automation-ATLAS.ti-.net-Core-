using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.OS.Windows;

namespace Test_Automation_Core.Installer
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

        
        public bool InstallATLASti(string installerPath, string majorVersion) {


            //Wait for Installer to be displayed
            SystemActions systemActions = new SystemActions();
            bool installerState = systemActions.WaitForElementToBeDisplayedByTagName(driver, "Window", $"Setup - ATLAS.ti {majorVersion}", 80);

            if (installerState) {
                //Add 1 second sleep between each page change in the Installer Wizard

                var window = driver.FindElementByTagName("Window").FindElementByName($"Setup - ATLAS.ti {majorVersion}");

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
