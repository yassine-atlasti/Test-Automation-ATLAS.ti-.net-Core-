

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

namespace Test_Automation_Core.Tests
{
    [TestFixture]
    public class NUnitTestClass
    {
        private static WindowsDriver<WindowsElement> _driver;
        private static WindowsDriver<WindowsElement> driver2;

      // [OneTimeSetUp]
        public static void ClassInitialize(string appPath)
        {
            //string applicationPath = @"C:\Program Files\Scientific Software\ATLASti.23\Atlasti23.exe";
            string applicationPath = appPath;
            /**
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
            **/
            // Now initialize the WindowsDriver
            AppiumOptions appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", applicationPath);
            appOptions.AddAdditionalCapability("deviceName", "WindowsPC");

            // Set the command timeout to a higher value
            appOptions.AddAdditionalCapability("newCommandTimeout", 30000);  // Timeout in seconds

            _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appOptions);

        }

        public void InitializeWindowsDriver()
        {

            // Set the desired capabilities for the application
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Root");
            options.AddAdditionalCapability("deviceName", "WindowsPC");

             _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);



            
        }
        public void initBackUpApp()
        {
            var applicationPath2 = @"C:\Program Files\Scientific Software\ATLASti.23\SSD.ATLASti.Backup.exe";
            var appOptions2 = new AppiumOptions();
            appOptions2.AddAdditionalCapability("app", applicationPath2);
            appOptions2.AddAdditionalCapability("deviceName", "WindowsPC");

             driver2 = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4725"), appOptions2);
            // Perform automation for the second application

        }

        
       // [OneTimeTearDown]
        public static void ClassCleanup()
        {

            _driver.Quit();
        }






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
            string downloadUrl = @"https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&workload=dotnet-dotnetwebcloud&passive=false#dotnet";
            string major = "23";
            string downloadPath = @"C:\Users\yassinemahfoudh\Downloads";
            SystemActions systemActions = new SystemActions();
            await systemActions.DownloadFileAsync(downloadUrl, "VisualStudioSetup.exe");


            /**
            //get the most recently downloaded file from Download Path
            var directory = new DirectoryInfo(downloadPath);
            var myFile = directory.GetFiles()
                         .OrderByDescending(f => f.LastWriteTime)
                         .First();
            string installerFileName = myFile.Name;


            //Set the installer Path and start installation 
            string installerPath = downloadPath + "\\" + installerFileName;

            **/
        }
        

        /**

        [Test]

        public void TestMethod2()
        {
            //Install ATLAS.ti
            
            var majorVersion = "23";

              string installerPath = @"C:\Users\yassinemahfoudh\Downloads\Atlasti_Nightly_develop.exe";
              ClassInitialize(installerPath);
              InstallerActions installerActions = new InstallerActions(_driver);

              installerActions.InstallATLASti(installerPath, "23");

            _driver.Quit();

            //Uninstall ATLAS.ti
            InitializeWindowsDriver();

            string appName = @"Control Panel\Programs\Programs and Features\ATLAS.ti 23";
            SystemActions systemActions = new SystemActions(_driver);


            systemActions.UninstallApp(appName);
            

            

        }
        **/
       



    }
}
