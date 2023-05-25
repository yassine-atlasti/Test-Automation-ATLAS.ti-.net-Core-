using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using Test_Automation_Core.UIElements.AppMenu;
using System;
using Test_Automation_Core.Actions;

namespace Test_Automation_Core.UIElements.AtlasWindows
{
    public class ProjectWindow
    {
        private readonly WindowsDriver<WindowsElement> driver;
        public ProjectWindow(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }
        public bool IsProjectOpen(string projectName)
        {

                SystemActions systemActions = new SystemActions();
            string windowName = projectName + " - ATLAS.ti";
            bool projectState = systemActions.WaitForElementToBeDisplayedByTagName(driver,"Window", windowName, 2);
            return projectState;
        }





        



        public Menu getAppMenu()
        {
            return new Menu(driver);
        }

        // Add methods for interacting with Project Window elements as needed
    }
}
