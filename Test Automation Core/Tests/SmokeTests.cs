

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

        //Should maybe go to SmokeTest Data
        public void initSmokeTest()
        {
            //Add Method that automatically updates AtlastiVariables (need to be implemented)

            //Create Smoke Test Folder

            systemActions.CreateFolder(SmokeTestVariables.smokeTestFolder);

            //Extract Libraries

            systemActions.ExtractZip(SmokeTestLibraries.library1, SmokeTestVariables.smokeTestFolderPath);

            systemActions.ExtractZip(SmokeTestLibraries.library2, SmokeTestVariables.smokeTestFolderPath);

            systemActions.ExtractZip(SmokeTestLibraries.library3, SmokeTestVariables.smokeTestFolderPath);

           


        }

        [OneTimeSetUp]
        public  void initATLAS()
        {

            _driver = systemActions.ClassInitialize(AtlasVariables.appPath);
            systemActions= new SystemActions(_driver);
            appControl= new App(_driver);
        appActions = new ApplicationActions(appControl);
        welcomeWindow = appControl.GetWelcomeControl();


        }

        public  void initBackUpApp()
        {
           _driver= systemActions.ClassInitialize(AtlasVariables.backUpPath);
            systemActions = new SystemActions(_driver);
            backUpActions = new BackUpActions(_driver);


        }
        // [Test]

        public async Task DownloadAndInstallRC(){
        

          _driver=  systemActions.ClassInitialize("Root");

            

            //Download 
            string downloadUrl = @"https://cdn.atlasti.com/win/" + AtlasVariables.winVUT +  "/Atlasti_" + AtlasVariables.winVUT + ".exe" ;
            string downloadPath = @"C:\Users\yassinemahfoudh\Downloads";
            string fileName = "Atlasti_"+AtlasVariables.winVUT +".exe";

            await systemActions.DownloadFileAsync(downloadUrl, fileName);


            _driver.Quit();


            //Install
            string installerPath = downloadPath + "\\" + fileName;
            string windowName = "Setup - ATLAS.ti " + AtlasVariables.major;

            _driver = systemActions.ClassInitialize(installerPath);

            InstallerActions installer = new InstallerActions(_driver);
            installer.InstallATLASti(installerPath, AtlasVariables.major);
        }

     

       // [Test]

        public void RunATLASWithEmptyLib()
        {
           initATLAS();

            bool crashState = welcomeWindow.HasAtlasCrashed(TimeSpan.FromSeconds(60));
         
            Assert.IsFalse(crashState);


           

        }


      //  [Test]
        public void ReportProblem()
        {
           bool reportState= appActions.ReportProblem("Test", "tester@atlasti.com");

            Assert.IsTrue(reportState);
        }

       // [Test]
        public void SendSuggestion()
        {

            bool suggestionState = appActions.SendSuggestion("Test", "tester@atlasti.com");
            Assert.IsTrue(suggestionState);
        }


        



        //[Test]
        public void openEmptyLibrary()
        {
            initSmokeTest();
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
        public void TestBackUp()
        {
            string backUp = AtlasVariables.winVUT + "_BackUp_" + System.DateTime.Now.Second.ToString();

            initATLAS();

            initBackUpApp();

            bool warningTrue = backUpActions.CheckWarning();
            Assert.IsTrue(warningTrue);

            systemActions.KillProcessByName("Atlasti" + AtlasVariables.major);
            systemActions.KillProcessByName("SSD.ATLASti.Backup");

            initBackUpApp();

            if (backUpActions.CheckWarning())
            {
                Thread.Sleep(2000);

            }


            bool backUpState = backUpActions.CreateBackUp("C:\\Users\\yassinemahfoudh\\Desktop\\SmokeTest_" + AtlasVariables.winVUT, backUp);
            Assert.IsTrue(backUpState);
            systemActions.KillProcessByName("SSD.ATLASti.Backup");

            initATLAS();
            appActions.DeleteProject(SmokeTestVariables.smokeTestproject);
            systemActions.KillProcessByName("Atlasti" + AtlasVariables.major);


            initBackUpApp();
            bool restoreState = backUpActions.RestoreLibrary(backUp);
            Assert.IsTrue(restoreState);
            systemActions.KillProcessByName("SSD.ATLASti.Backup");

            initATLAS();
            bool projectRestored = appActions.OpenProject(SmokeTestVariables.smokeTestproject);
            Assert.IsTrue(projectRestored);


        }
       // [Test]
        public void exportVUT()
        {
           
            //Atlproj export

           bool atlProjExportState= appActions.ExportProject(CHProjects.CHWinVUTProjectsFolder, "Atlproj", SmokeTestVariables.smokeTestproject);
            Assert.IsTrue(atlProjExportState);
            //QDPX export
         
          bool qdpxExportState= appActions.ExportProject(CHProjects.CHWinVUTProjectsFolder, "QDPX", SmokeTestVariables.smokeTestproject);
            Assert.IsTrue(qdpxExportState);
        }

       

        [Test]
        public async Task deleteVUT()
        {
            await appActions.CloseProjectAsync();


            //Delete VUT

            appActions.DeleteProject(SmokeTestVariables.smokeTestproject);

            //It's actually not working after closing a project. Delete works actually only when project is closed=>Invesitagte

        }

        public void importVUT()
        {

            //Atlproj import

          bool atlprojImportState=  appActions.ImportProject(CHProjects.CHWinVUTProjectsFolder, "AtlProj", CHProjects.winVUTAtlProj.Replace(" ", ""));
            Assert.IsTrue(atlprojImportState);

            //QDPX Import
            bool qdpxImportState= appActions.ImportProject(CHProjects.CHWinVUTProjectsFolder, "QDPX", CHProjects.winVUTQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);

        }
        public void importWinProd()
        {
            //Atlproj import

            bool atlprojImportState = appActions.ImportProject(CHProjects.CHProjectsFolder, "AtlProj", CHProjects.WinProductionAtlProj.Replace(" ", ""));
            Assert.IsTrue(atlprojImportState);

            //QDPX Import
            bool qdpxImportState = appActions.ImportProject(CHProjects.CHProjectsFolder, "QDPX", CHProjects.WinProductionQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);


        }
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
