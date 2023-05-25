

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
                System.Threading.Thread.Sleep(20000); // Delay for 30 seconds
            }
            else
            {
                // If the application is already running, attach to the first instance
                process = processes[0];
            }

            // Now initialize the WindowsDriver
            AppiumOptions appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", @"C:\Program Files\Scientific Software\ATLASti.23\Atlasti23.exe");


            // Attach to the running app
            appOptions.AddAdditionalCapability("deviceName", "WindowsPC");

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
            var libraryPath = @"C:\Users\yassinemahfoudh\Desktop\SmokeTestLibraryWin(Yanik)\ATLASti.8";

            appActions.SwitchLibrary(libraryPath);

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
            appActions.ExportProject(exportPath, exportType, projectName);

        }
        **/

        [Test]
        public void TestMethod2()
        {
            App appControl = new App(_driver);
            ApplicationActions appActions = new ApplicationActions(appControl);
            string filePath = @"\\Mac\Home\Library\CloudStorage\OneDrive-ATLAS.tiScientificSoftwareDevelopmentGmbH\Testing stuff\Test Data\Projects\C&H all versions\Win\VUT\23.1.2-Windows11-C&HII+hierarchy.atlproj23"
;
            var importType = "atlproj";
            //Use a project name only with capital letters!
            string projectName = "CHJKSL";
            appActions.ImportProject(filePath, importType, projectName);

        }
    }
}
