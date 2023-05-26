

using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;

using System;
using Test_Automation_Core.UIElements.WelcomeWindow;
using Test_Automation_Core.Actions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Diagnostics;

namespace Test_Automation_Core.Tests
{
    [TestFixture]
    public class NUnitTestClass
    {
        private static WindowsDriver<WindowsElement> _driver;

       [OneTimeSetUp]
        public static void ClassInitialize()
        {
            string applicationPath = @"C:\Program Files\Scientific Software\ATLASti.23\Atlasti23.exe";
            string applicationName = Path.GetFileNameWithoutExtension(applicationPath);

            // Check if the ATLAS.ti application is already running
            Process[] processes = Process.GetProcessesByName(applicationName);

            Process process;
            if (processes.Length == 0)
            {
                // If the application is not running, start it
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = applicationPath,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                process = Process.Start(processStartInfo);

                // Wait for application to open
                int maxWaitTimeInMilliseconds = 30000;
                int intervalInMilliseconds = 500;
                int elapsedWaitTimeInMilliseconds = 0;
                while (elapsedWaitTimeInMilliseconds < maxWaitTimeInMilliseconds)
                {
                    processes = Process.GetProcessesByName(applicationName);
                    if (processes.Length > 0)
                    {
                        process = processes[0];
                        break;
                    }
                    System.Threading.Thread.Sleep(intervalInMilliseconds);
                    elapsedWaitTimeInMilliseconds += intervalInMilliseconds;
                }
            }
            else
            {
                // If the application is already running, attach to the first instance
                process = processes[0];
            }

            // Now initialize the WindowsDriver
            AppiumOptions appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", applicationPath);
            appOptions.AddAdditionalCapability("deviceName", "WindowsPC");

            // Set the command timeout to a higher value
            appOptions.AddAdditionalCapability("newCommandTimeout", 600);  // Timeout in seconds

            _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appOptions);

        }


        /**
        [OneTimeTearDown]
        public static void ClassCleanup()
        {

            _driver.Quit();
        }
        **/





        /**
        //Testing SendSuggestion Action
        [Test]
        public void TestMethod1()
        {
            App appControl = new App(_driver);
            ApplicationActions appActions = new ApplicationActions(appControl);
            appActions.ReportProblem("Test", "tester@atlasti.com");

        }
        **/


        /**
     

        //Testing SwitchLibrary Action
        [Test]
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
            ClassInitialize();
            App appControl2 = new App(_driver);
            ApplicationActions appActions2 = new ApplicationActions(appControl2);
            bool switchResult = appActions2.ValidateLibSwitch();
            return switchResult;
        }
        **/

        //Test 2

        /**

        [Test]
        public void TestMethod2()
        {
            App appControl = new App(_driver);
            ApplicationActions appActions = new ApplicationActions(appControl);
            var exportPath = @"C:\Users\yassinemahfoudh\Desktop";
            var exportType = "Atlproj";
            var projectName = "Survey Project";
            appActions.ExportProject(exportPath, exportType, projectName);

        }

        **/

        /**
        
        [Test]
        public void TestMethod2()
        {
            App appControl = new App(_driver);
            ApplicationActions appActions = new ApplicationActions(appControl);
            var exportPath = @"C:\Users\yassinemahfoudh\Desktop";
            var exportType = "qdpx";
            var projectName = "Survey Project";
           bool exportResult= appActions.ExportProject(exportPath, exportType, projectName);

            Assert.IsTrue(exportResult);

        }
        **/

        /**
        [Test]
        public void TestMethod2()
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

        }**/
        /**

        [Test]
        public void TestMethod2()
        {
            string folderPath = "C:\\Users\\yassinemahfoudh\\Desktop\\Test1";
            string zipFile = @"\\Mac\Home\Library\CloudStorage\OneDrive-ATLAS.tiScientificSoftwareDevelopmentGmbH\Testing stuff\Test Data\Smoke Tests data\Win\Smoke Test Libraries\SmokeTestLibraryWin(Yanik).zip";
        SystemActions systemActions = new SystemActions();
            systemActions.CreateFolder(folderPath);
            systemActions.ExtractZip(zipFile, folderPath);

        
        
        }
        **/

        [Test]

        public async Task TestMethod2()
        {
            string downloadUrl = @"https://cdn.atlasti.com/win/nightly/23-C4E24425-7597-4DB4-BEAC-4C2CFBBB7A7C/develop/Atlasti_Nightly_develop.exe";
            string major = "23";
            string downloadPath = @"C:\Users\yassinemahfoudh\Desktop\Test1";
            string installPath = @"C:\Program Files";
            SystemActions systemActions = new SystemActions();
           await systemActions.DownloadAtlasAsync(downloadUrl,downloadPath);
          // await systemActions.DownloadAndInstallAtlasAsync(downloadUrl, downloadPath, installPath);

        }


        }
}
