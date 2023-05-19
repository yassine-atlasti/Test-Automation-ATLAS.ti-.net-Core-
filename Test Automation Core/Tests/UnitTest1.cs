

using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;

using System;
using Test_Automation_Core.UIElements.WelcomeWindow;
using Test_Automation_Core.Actions;

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
            _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appOptions);
            
        }

        [OneTimeTearDown]
        public static void ClassCleanup()
        {
            _driver.Quit();
        }

       static public void WaitForApplicationToOpen()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            wait.Until(driver => _driver.FindElementByAccessibilityId("Large_CreateNewProjectButton").Displayed);
        }

        [Test]
        public void TestMethod1()
        {
            WaitForApplicationToOpen();
            App appControl = new App(_driver);
            ApplicationActions appActions = new ApplicationActions(appControl);
            var libraryPath = @"C:\Users\yassinemahfoudh\Desktop\Win-SmokeTestLibraryContainingC&H+hierarchy\ATLASti.22";

            appActions.SwitchLibrary(libraryPath);

        }

        //Test 2
    }
}
