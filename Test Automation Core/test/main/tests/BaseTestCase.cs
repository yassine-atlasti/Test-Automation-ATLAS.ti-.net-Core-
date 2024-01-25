using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using Test_Automation_Core.src;
using Test_Automation_Core.src.pages.atlasti.actions;
using Test_Automation_Core.src.pages.atlasti.ui.windows;
using Test_Automation_Core.src.pages.backup;
using Test_Automation_Core.src.pages.updater;
using Test_Automation_Core.test.main.util;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.resources.test_data.winappdriver;
using Test_Automation_Core.test.resources.test_suites;
using Test_Automation_Core.test.utilities.util;
using TextCopy;

namespace Test_Automation_Core.test.main.tests
{
    public class BaseTestCase
    {//General
        private static WindowsDriver<WindowsElement> _driver;
        SystemActions systemActions = new SystemActions();
        
        
         

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

            //Enable Debug Mode
            SystemActions.SetLoadDeveloperModule();


        }

        

        public static void initReleaseTest()
        {
            ExtractLibraries.extractReleaseTestLibs();

        }

        
        [SetUp]
        public  void SetupATLAS()
        {
            if (TestRunnerEnabled==false)
        
            { initSmokeTest(); }
           RunAtlas();
        }

        public bool RunAtlas()
        {
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
            return isSuccessful;
        }


       
        public void SetupBackupApp()
        {
            _driver = systemActions.ClassInitialize(AtlasVariables.backUpPath);
            Thread.Sleep(2000);
            systemActions = new SystemActions(_driver);
            backUpActions = new BackUpActions(_driver);


        }

        public void SetUpSatelliteUpdater()
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



        

       [TearDown]
        public  void cleanUp() {



            // Screenshots are saved in distinct locations based on the execution context:
            // - If executed as part of a test suite, screenshots are stored in the corresponding test suite folder in Desktop.
            // - If executed individually from a test case, screenshots are saved in "Desktop/TestResults".
            BaseTestSuite.saveScreenshot();
            
           // _driver.Close();
            SystemActions.KillProcessByName("Atlasti" + AtlasVariables.vutMajor);
            SystemActions.KillProcessByName("SSD.ATLASti.Backup");
            SystemActions.KillProcessByName("WinAppDriver");
            SystemActions.KillProcessByName("SSD.ATLASti.Updater");

        }







    }
}
