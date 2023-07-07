

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
            _driver.Manage().Window.Maximize();


        }

        public  void initBackUpApp()
        {
           _driver= systemActions.ClassInitialize(AtlasVariables.backUpPath);
            systemActions = new SystemActions(_driver);
            backUpActions = new BackUpActions(_driver);


        }
       
     

       // [Test]

        public void RunATLASWithEmptyLib()
        {

            bool crashState = welcomeWindow.HasAtlasCrashed(TimeSpan.FromSeconds(60));
         
            Assert.IsFalse(crashState);


           

        }
        //[Test]
        public void openEmptyLibrary()
        {
            initATLAS();

            //Open ATLAS.ti with empty A22 Library
            appActions.SwitchLibrary(SmokeTestVariables.library1Extracted);

            // Wait for 20 second for Library Switch
            Thread.Sleep(20000);

            initATLAS();

            bool crashState = welcomeWindow.HasAtlasCrashed(TimeSpan.FromSeconds(60));

            Assert.IsFalse(crashState);


        }

         // [Test]
        public void ReportProblem()
        {
           bool reportState= appActions.ReportProblem("Test", "tester@atlasti.com");

            Assert.IsTrue(reportState);
        }

        //[Test]
        public void SendSuggestion()
        {

            bool suggestionState = appActions.SendSuggestion("Test", "tester@atlasti.com");
            Assert.IsTrue(suggestionState);
        }



       
       [Test]
        public void importWinProd()
        {
            //Atlproj import

            bool atlprojImportState = appActions.ImportProject(CHProjects.CHProjectsFolder, "AtlProj", CHProjects.WinProductionAtlProj.Replace(" ", ""));
            Assert.IsTrue(atlprojImportState);

            //QDPX Import
            bool qdpxImportState = appActions.ImportProject(CHProjects.CHProjectsFolder, "QDPX", CHProjects.WinProductionQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);


        }
        [Test]
        public void importMacProd()
        {
            
            //Atlproj import

            bool atlprojImportState = appActions.ImportProject(CHProjects.CHProjectsFolder, "AtlProj", CHProjects.MacProductionAtlProj.Replace(" ", ""));
            Assert.IsTrue(atlprojImportState);

            //QDPX Import
            bool qdpxImportState = appActions.ImportProject(CHProjects.CHProjectsFolder, "QDPX", CHProjects.MacProductionQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);



        }

        public void importWinPreviousMajor()
            {
            appControl = new App(_driver);
            appActions = new ApplicationActions(appControl);
            //Atlproj import

            bool atlprojImportState = appActions.ImportProject(CHProjects.CHProjectsFolder, "AtlProj", CHProjects.WinPreviousAtlProj.Replace(" ", ""));
            Assert.IsTrue(atlprojImportState);

            //QDPX Import
            bool qdpxImportState = appActions.ImportProject(CHProjects.CHProjectsFolder, "QDPX", CHProjects.WinPreviousQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);



        }
        [Test]
        public void importMacPreviousMajor()
        {
            //Atlproj import

            bool atlprojImportState = appActions.ImportProject(CHProjects.CHProjectsFolder, "AtlProj", CHProjects.MacPreviousAtlProj.Replace(" ", ""));
            Assert.IsTrue(atlprojImportState);

            //QDPX Import
            bool qdpxImportState = appActions.ImportProject(CHProjects.CHProjectsFolder, "QDPX", CHProjects.MacPreviousQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);



        }




    }
            }
