

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

namespace Test_Automation_Core.Tests
{
    [TestFixture]
    public class SmokeTestClass
    {
        private static WindowsDriver<WindowsElement> _driver;
        SystemActions systemActions = new SystemActions();
        App appControl;
        ApplicationActions appActions;
        WelcomeWindow welcomeWindow;
        string major = "23";
        string vut = "23.2.0";
        string library1;
        string library2;
        string library3;



        //Should maybe go to SmokeTest Data
        public void initSmokeTestLibraries()
        {
            string smokeTestFolder = "SmokeTest_" + vut;

            systemActions.CreateFolder(smokeTestFolder);


            string smokeTestFolderPath = "C:\\Users\\yassinemahfoudh\\Desktop\\"+smokeTestFolder;

            string emptyA22Library = @"\\Mac\Home\Library\CloudStorage\OneDrive-ATLAS.tiScientificSoftwareDevelopmentGmbH\Testing stuff\Test Data\Smoke Tests data\Win\Smoke Test Libraries\emptyWinA22library.zip";
            string libraryYanik = @"\\Mac\Home\Library\CloudStorage\OneDrive-ATLAS.tiScientificSoftwareDevelopmentGmbH\Testing stuff\Test Data\Smoke Tests data\Win\Smoke Test Libraries\SmokeTestLibraryWin(Yanik).zip";
            string libraryCH = @"\\Mac\Home\Library\CloudStorage\OneDrive-ATLAS.tiScientificSoftwareDevelopmentGmbH\Testing stuff\Test Data\Smoke Tests data\Win\Smoke Test Libraries\Win-SmokeTestLibraryContainingC&H+hierarchy.zip";
         

            systemActions.ExtractZip(emptyA22Library, smokeTestFolderPath);
            library1 = smokeTestFolderPath + @"\emptyWinA22library";

            systemActions.ExtractZip(libraryYanik, smokeTestFolderPath);
            library2 = smokeTestFolderPath + @"\ATLASti.8";

            systemActions.ExtractZip(libraryCH, smokeTestFolderPath);
            library3 = smokeTestFolderPath + @"\Win-SmokeTestLibraryContainingC&H+hierarchy\ATLASti.22";

           


        }

        
        public void initRC()
        {
            string appPath = @"C:\Program Files\Scientific Software\ATLASti." + this.major + @"\Atlasti" + this.major + ".exe";

            _driver = systemActions.ClassInitialize(appPath);
            appControl= new App(_driver);
        appActions = new ApplicationActions(appControl);
        welcomeWindow = appControl.GetWelcomeControl();


        }

        
   // [Test]
            
            public async Task DownloadAndInstallRC(){
        

          _driver=  systemActions.ClassInitialize("Root");

            

            //Download 
            string downloadUrl = @"https://cdn.atlasti.com/win/" + this.major +  "/Atlasti_" + this.vut + ".exe" ;
            string downloadPath = @"C:\Users\yassinemahfoudh\Downloads";
            string fileName = "Atlasti_"+this.vut +".exe";

            await systemActions.DownloadFileAsync(downloadUrl, fileName);


            _driver.Quit();


            //Install
            string installerPath = downloadPath + "\\" + fileName;
            string windowName = "Setup - ATLAS.ti " + major;

            _driver = systemActions.ClassInitialize(installerPath);

            InstallerActions installer = new InstallerActions(_driver);
            installer.InstallATLASti(installerPath, major);
        }

     

       // [Test]

        public void RunATLASWithEmptyLib()
        {
           initRC();

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
            initSmokeTestLibraries();
            initRC();

            appActions.SwitchLibrary(library2);

            // Wait for 20 second for Library Switch
            Thread.Sleep(20000);

            initRC();

            bool crashState = welcomeWindow.HasAtlasCrashed(TimeSpan.FromSeconds(60));

            Assert.IsFalse(crashState);


        }


    }
}
