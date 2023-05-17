

using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using Test_Automation_ATLAS.ti.WelcomeWindow;
using TestAutomationFramework;

using System;

namespace Test_Automation_ATLAS.ti
{
    [TestFixture]
    public class NUnitTestClass
    {
        private static WindowsDriver<WindowsElement> _driver;

        [OneTimeSetUp]
        public static void ClassInitialize()
        {
            // Launch the Windows calculator application
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

        public void WaitForApplicationToOpen()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => _driver.FindElementByAccessibilityId("Large_CreateNewProjectButton").Displayed);
        }

        [Test]
        public void TestMethod1()
        {
            WelcomeControl welcomeWindow = new WelcomeControl(_driver);
            OptionsWindow optionsWindow = welcomeWindow.OpenOptionsWindow();
            optionsWindow.ClickSwitchLibraryButton();
        }

        //Test
    }
}
