

using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;

using System;
using Test_Automation_Core.UIElements.WelcomeWindow;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Diagnostics;
using Test_Automation_Core.OS.Windows;
using Test_Automation_Core.Installer;
using OpenQA.Selenium.Appium.Enums;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Test_Automation_Core.ATLAS.ti.UIActions;
using Test_Automation_Core.ATLAS.ti.UIElements.Dialogs;
using NUnit.Framework.Internal;
using Test_Automation_Core.BackUpApp;
using System.Drawing;
using Test_Automation_Core.Data.SmokeTestData;
using Test_Automation_Core.Data.OneDrive.Libraries;
using Test_Automation_Core.Data.SUT;
using Test_Automation_Core.Data.OneDrive.Projects;
using Test_Automation_Core.UIElements.AppMenu.File;
using Test_Automation_Core.Tests.Smoke_Tests;

namespace Test_Automation_Core.Tests
{
    [TestFixture]
    public class SmokeTestClass
    {
        //General
        private static WindowsDriver<WindowsElement> _driver;
        SystemActions systemActions=new SystemActions();


        //ATLAS.ti
        App appControl;
         ApplicationActions appActions;
        WelcomeWindow welcomeWindow;

        
        //BackUpApp
        BackUpActions backUpActions;
        public ApplicationActions GetAppActions()
        {
            return appActions;
   }
        public BackUpActions GetBackUpActions() { 
            return backUpActions;
        }
        public WelcomeWindow GetWelcomeWindow() { return welcomeWindow;}
        public SystemActions GetSystemActions() { return systemActions; }

        public WindowsDriver<WindowsElement> GetDriver() { return _driver; }
        //Should maybe go to SmokeTest Data
        public void initSmokeTest()
        {
            ExtractLibraries.extractSmokeTestLibs();


        }

        [OneTimeSetUp]
        public void initATLAS()
        {
            //initSmokeTest();

            _driver = systemActions.ClassInitialize(AtlasVariables.appPath);
            systemActions= new SystemActions(_driver);
            appControl= new App(_driver);
        appActions = new ApplicationActions(appControl);
        welcomeWindow = appControl.GetWelcomeControl();

            try
            {
                _driver.Manage().Window.Maximize();
            }
            catch (System.InvalidOperationException ex)
            {
                // Log or display a message indicating that maximizing the window is not supported
                Console.WriteLine("Window maximize is not supported in the current context: " + ex.Message);
            }

        }

        public  void initBackUpApp()
        {
           _driver= systemActions.ClassInitialize(AtlasVariables.backUpPath);
            systemActions = new SystemActions(_driver);
            backUpActions = new BackUpActions(_driver);
            _driver.Manage().Window.Maximize();


        }








    }
            }
