using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using Test_Automation_Core.src;
using Test_Automation_Core.src.pages.atlasti.actions;
using Test_Automation_Core.src.pages.atlasti.ui.windows;
using Test_Automation_Core.src.pages.backup;
using Test_Automation_Core.test.main.util;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.resources.test_data.winappdriver;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.tests
{
    public class BaseTest
    {//General
        private static WindowsDriver<WindowsElement> _driver;
        SystemActions systemActions = new SystemActions();
        
        
        public static string _testSuiteFolder;

        // Getter method for testSuiteFolder
        public static string TestSuiteFolder
        {
            get
            {
                return _testSuiteFolder;
            }
            set
            {
                // You can add validation or additional logic here if needed
                _testSuiteFolder = value;
            }
        }

        public static bool TestRunnerEnabled = false;


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
        public BackUpActions GetBackUpActions()
        {
            return backUpActions;
        }
        public WelcomeWindow GetWelcomeWindow() { return welcomeWindow; }
        public SystemActions GetSystemActions() { return systemActions; }

        public WindowsDriver<WindowsElement> GetDriver() { return _driver; }
        //Should maybe go to SmokeTest Data
       
        public static void initSmokeTest()
        {
             ExtractLibraries.extractSmokeTestLibs();
            Thread.Sleep(5000);

        }

        public static void initReleaseTest()
        {
            ExtractLibraries.extractReleaseTestLibs();

        }

        
        [SetUp]
        public void SetupATLAS()
        {
            initSmokeTest();
            _driver = systemActions.ClassInitialize(AtlasVariables.appPath);
            Thread.Sleep(3000);
            systemActions = new SystemActions(_driver);
            appControl = new App(_driver);
            appActions = new ApplicationActions(appControl);
            welcomeWindow = appControl.GetWelcomeControl();

            int retryCount = 0;
            int maxRetries = 5;  // You can adjust the maximum number of retries
            bool isSuccessful = false;

            while (retryCount < maxRetries && !isSuccessful)
            {
                try  
                {

                     welcomeWindow.MaximizeATLASti();
                     

                    _driver.FindElementByName("Options Dialog Link");



                    isSuccessful = true; // If it reaches here, no exception was thrown
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Attempt " + (retryCount + 1) + " failed: " + ex.Message);
                    retryCount++;
                    Thread.Sleep(1500);  // Wait for 1 second before retrying. Adjust the delay as needed.
                }
            }

            if (!isSuccessful)
            {
                // Log or throw an exception indicating that all retries have failed.
                Console.WriteLine("All attempts to interact with the window failed.");
            }
        }

        public void SetupBackupApp()
        {
            _driver = systemActions.ClassInitialize(AtlasVariables.backUpPath);
            Thread.Sleep(2000);
            systemActions = new SystemActions(_driver);
            backUpActions = new BackUpActions(_driver);


        }

        public void SetupUpdater()
        {
            _driver = systemActions.ClassInitialize(AtlasVariables.updaterPath);
            systemActions = new SystemActions(_driver);

        }
        public static void SwitchWindow(string windowName)
        {
            foreach (var handle in _driver.WindowHandles)
            {
                // Get the title of the window without switching to it
                string title = _driver.SwitchTo().Window(handle).Title;

                // If the title matches, switch to the window and return
                if (title == windowName)
                {
                    _driver.SwitchTo().Window(handle);
                    return;
                }
            }

            // Optionally, handle the case where no window with the given name is found
            throw new InvalidOperationException($"No window with title '{windowName}' found.");
        }



        //This saves screenshots in the test suite folder
        public void saveScreenshot()
        {
                WindowsDriver<WindowsElement> _rootdriver = systemActions.ClassInitialize("Root");


            var screenShotFileName = DateTime.Now.ToString("HH-mm-ss") +"-"+ TestContext.CurrentContext.Test.Name+".png";

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                // The test failed
                SystemActions.TakeScreenshot(_rootdriver, TestRunner.failedTestsPath, screenShotFileName);

            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                // The test passed
                SystemActions.TakeScreenshot(_rootdriver,TestRunner.passedTestsPath, screenShotFileName);
            }

            _rootdriver.Close();

        }

       [TearDown]
        public void cleanUp() {

           

            if (TestRunnerEnabled==true)
            {
                //We actually only save screenshots when the tests are triggered via the TestRunner, as in the SmokeTestSuite and ReleaseTestSuite
                saveScreenshot();
                Thread.Sleep(1000);
            }
           // _driver.Close();
            SystemActions.KillProcessByName("Atlasti" + AtlasVariables.actualMajor);
            SystemActions.KillProcessByName("SSD.ATLASti.Backup");
            SystemActions.KillProcessByName("WinAppDriver");
            SystemActions.KillProcessByName("SSD.ATLASti.Updater");

        }







    }
}
