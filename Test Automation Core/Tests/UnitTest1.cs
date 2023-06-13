

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

namespace Test_Automation_Core.Tests
{
    [TestFixture]
    public class NUnitTestClass
    {
        private static WindowsDriver<WindowsElement> _driver;
        App appControl;
        ApplicationActions appActions;
        WelcomeWindow welcomeWindow;
        string major = "23";

        SystemActions systemActions = new SystemActions();
        // [OneTimeSetUp]


        
           public void initBackUpApp()
           {
               var applicationPath2 = @"C:\Program Files\Scientific Software\ATLASti.23\SSD.ATLASti.Backup.exe";
               var appOptions2 = new AppiumOptions();
               appOptions2.AddAdditionalCapability("app", applicationPath2);
               appOptions2.AddAdditionalCapability("deviceName", "WindowsPC");

                _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4725"), appOptions2);
               // Perform automation for the second application

           }

        public void initATLAS()
        {
            string appPath = @"C:\Program Files\Scientific Software\ATLASti." + this.major + @"\Atlasti" + this.major + ".exe";

            _driver = systemActions.ClassInitialize(appPath);
            appControl = new App(_driver);
            appActions = new ApplicationActions(appControl);
            welcomeWindow = appControl.GetWelcomeControl();


        }


        // [OneTimeTearDown]
        public static void ClassCleanup()
        {

            _driver.Quit();
        }






        
        //Testing SendSuggestion Action
       // [Test]
        public void TestMethod1()
        {
            App appControl = new App(_driver);
            ApplicationActions appActions = new ApplicationActions(appControl);
            appActions.ReportProblem("Test", "tester@atlasti.com");

        }
        


        
     

        //Testing SwitchLibrary Action
      //  [Test]
        public void TestMethod2()
        {
            App appControl = new App(_driver);
            ApplicationActions appActions = new ApplicationActions(appControl);
            var libraryPath = @"C:\Users\yassinemahfoudh\Desktop\emptyWinA22library";
  appActions.SwitchLibrary(libraryPath);
            // Wait for the application to fully restart. The exact time will depend on your application.
            Thread.Sleep(TimeSpan.FromSeconds(5));

            bool switchResult = ValidateLibSwitch();

Assert.IsTrue(switchResult);

        }
        
        public bool ValidateLibSwitch()
        { 
            //Reinitialize WinAppDriver after ATLAS.ti restarts
           // systemActions.ClassInitialize();

            App appControl2 = new App(_driver);
            ApplicationActions appActions2 = new ApplicationActions(appControl2);
            bool switchResult = appActions2.ValidateLibSwitch();
            return switchResult;
        }
        

        //Test 2

        

       // [Test]
        public void TestMethod3()
        {
            App appControl = new App(_driver);
            ApplicationActions appActions = new ApplicationActions(appControl);
            var exportPath = @"C:\Users\yassinemahfoudh\Desktop";
            var exportType = "Atlproj";
            var projectName = "Survey Project";
            appActions.ExportProject(exportPath, exportType, projectName);

        }

        

        
        
       // [Test]
        public void TestMethod4()
        {
            App appControl = new App(_driver);
            ApplicationActions appActions = new ApplicationActions(appControl);
            var exportPath = @"C:\Users\yassinemahfoudh\Desktop";
            var exportType = "qdpx";
            var projectName = "Survey Project";
           bool exportResult= appActions.ExportProject(exportPath, exportType, projectName);

            Assert.IsTrue(exportResult);

        }
        

        
        //[Test]
        public void TestMetho5()
        {
            App appControl = new App(_driver);
            ApplicationActions appActions = new ApplicationActions(appControl);
            string filePath = @"\\Mac\Home\Library\CloudStorage\OneDrive-ATLAS.tiScientificSoftwareDevelopmentGmbH\Testing stuff\Test Data\Projects\C&H all versions\Win\VUT\23.1.2-Windows11-C&HII+hierarchy.atlproj23"
;
            var importType = "atlproj";
            //Use a project name only with capital letters!
            string projectName = "CHJKSLKSD";
          bool actual=  appActions.ImportProject(filePath, importType, projectName);

            Assert.IsTrue(actual);

        }
        

        //[Test]
        public void TestMethod6()
        {
            string folderPath = "C:\\Users\\yassinemahfoudh\\Desktop\\Test1";
            string zipFile = @"\\Mac\Home\Library\CloudStorage\OneDrive-ATLAS.tiScientificSoftwareDevelopmentGmbH\Testing stuff\Test Data\Smoke Tests data\Win\Smoke Test Libraries\SmokeTestLibraryWin(Yanik).zip";
        SystemActions systemActions = new SystemActions();
            systemActions.CreateFolder(folderPath);
            systemActions.ExtractZip(zipFile, folderPath);

        
        
        }
        
        
        
                
                [Test]

                public async Task UpdateNightly()
               {
            /**
            //Uninstall ATLAS.ti

           _driver= systemActions.ClassInitialize("Root");
            systemActions = new SystemActions(_driver);

            string appName = @"Control Panel\Programs\Programs and Features\ATLAS.ti 23";


            systemActions.UninstallApp(appName);
         **/

            //Download 
            string downloadUrl = @"https://cdn.atlasti.com/win/nightly/23-C4E24425-7597-4DB4-BEAC-4C2CFBBB7A7C/develop/Atlasti_Nightly_develop.exe";
                    string major = "23";
                    string downloadPath = @"C:\Users\yassinemahfoudh\Downloads";
                    string fileName = "Atlasti_Nightly_develop.exe";

            /**     await systemActions.DownloadFileAsync(downloadUrl, fileName);


                 // Close all File Explorer Windows and quit Root driver
                 systemActions.CloseAllFileExplorerWindows();
                 _driver.Quit();**/

            //Install
            string installerPath = downloadPath + "\\" + fileName;
                    string windowName = "Setup - ATLAS.ti " + major;
            _driver = systemActions.ClassInitialize(installerPath);
           
            systemActions.MinimizeAllWindows(_driver);

            InstallerActions installer = new InstallerActions(_driver);
                    installer.InstallATLASti(installerPath, major);
                }
                
                

        

      
        
        
        
       // [Test]

        public void TestMethod7()
        {
            string appPath = @"C:\Program Files\Scientific Software\ATLASti.23\Atlasti23.exe";


            _driver = systemActions.ClassInitialize(appPath);



            App appControl = new App(_driver);
            ApplicationActions appActions = new ApplicationActions(appControl);
            appActions.OpenProject("C&H II + hierarchy");
           appActions.RaiseException();

            // Wait for 20 second before trying again
            Thread.Sleep(20000);


            _driver = systemActions.ClassInitialize(appPath);


            appControl = new App(_driver);
            appActions = new ApplicationActions(appControl);
            var welcomeWindow = appControl.GetWelcomeControl();

            bool crashState = welcomeWindow.HasAtlasCrashed(TimeSpan.FromSeconds(60));
            Assert.IsTrue(crashState);


            CrashReportDialog crashReportDialog = new CrashReportDialog(_driver);
            crashReportDialog.EnterEmail("yassine.mahfoudh@atlasti.com");
            crashReportDialog.EnterProblemDescription("QA Test Ignore");
            crashReportDialog.ClickSendErrorButton();

        }
        
        
    }
}
