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

            OpenInstaller(installerPath);

            //Wait for Installer to be displayed
            SystemActions systemActions = new SystemActions();
            bool installerState = systemActions.WaitForElementToBeDisplayedByTagName(driver, "Window", $"Setup - ATLAS.ti {majorVersion}", 60);

            if (installerState) {
                //Add 1 second sleep between each page change in the Installer Wizard

            driver.FindElementByTagName("Button").FindElementByName("Next").Click();
                
                Thread.Sleep(1000);

                driver.FindElementByTagName("CheckBox").Click();
                driver.FindElementByTagName("Button").FindElementByName("Next").Click();

                Thread.Sleep(1000);

                driver.FindElementByTagName("Button").FindElementByName("Next").Click();

                Thread.Sleep(1000);

                driver.FindElementByTagName("Button").FindElementByName("Install").Click();

                Thread.Sleep(1000);
                installerState = systemActions.WaitForElementToBeDisplayedByTagName(driver, "CheckBox", "Launch ATLAS.ti", 60);

                driver.FindElementByTagName("CheckBox").Click() ;
                
                driver.FindElementByTagName("Button").FindElementByName("Close").Click();

            }
            else { installerState = false; }

            return installerState;
        }




        public void UninstallATLASti(string majorVersion)
        {
            string controlPanelCommand = "control";
            string programsAndFeaturesCommand = "appwiz.cpl";
            string atlasEntryDisplayName = $"ATLAS.ti {majorVersion}";

            Process.Start(controlPanelCommand, $"{programsAndFeaturesCommand},::{atlasEntryDisplayName}\\Uninstall");
        

        // Delay for 60 seconds
        //Thread.Sleep(60000);

        //We need to kill all ATLAS.ti processes to close the installer.
        //closeInstaller(majorVersion);


    }



        public void closeInstaller(string majorVersion)
        {
            SystemActions systemActions = new SystemActions();

            systemActions.CloseAtlasTiProcesses(majorVersion);

        }

    }
}
