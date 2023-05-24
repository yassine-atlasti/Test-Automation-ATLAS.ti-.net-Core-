

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
            // Launch the ATLAS.ti application
            AppiumOptions appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", @"C:\Program Files\Scientific Software\ATLASti.23\Atlasti23.exe");
            appOptions.AddAdditionalCapability("deviceName", "WindowsPC");
            appOptions.AddAdditionalCapability("appWaitActivity", "ATLAS.ti");

            _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appOptions);


        }

        /**
        [OneTimeTearDown]
        public static void ClassCleanup()
        {

            _driver.Quit();
        }
        **/

        static public void WaitForApplicationToOpen()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            wait.Until(driver => _driver.FindElementByName("Your Projects").Displayed);
        }

        private static bool IsApplicationRunning(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
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
            var libraryPath = @"C:\Users\yassinemahfoudh\Desktop\SmokeTestLibraryWin(Yanik)\ATLASti.8";

            appActions.SwitchLibrary(libraryPath);

        }
        **/

        //Test 2



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



    }
}
