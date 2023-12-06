using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Appium.Windows;
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
    [TestFixture]
    public class InitTests
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
        public void initATLAS()

        {
            //initSmokeTest();
            _driver = systemActions.ClassInitialize(AtlasVariables.appPath);
            systemActions = new SystemActions(_driver);
            appControl = new App(_driver);
            appActions = new ApplicationActions(appControl);
            welcomeWindow = appControl.GetWelcomeControl();

            try
            {
                welcomeWindow.ClearSearch();
                _driver.Manage().Window.Maximize();
            }
            catch (InvalidOperationException ex)
            {
                // Log or display a message indicating that maximizing the window is not supported
                Console.WriteLine("Window maximize is not supported in the current context: " + ex.Message);
            }

        }

        public void initBackUpApp()
        {

            _driver = systemActions.ClassInitialize(AtlasVariables.backUpPath);
            systemActions = new SystemActions(_driver);
            backUpActions = new BackUpActions(_driver);


        }
       [TearDown]
        public void cleanUp() {
          /**  WindowsDriver<WindowsElement> _rootdriver = systemActions.ClassInitialize("Root");

            var screenShotFileName = TestContext.CurrentContext.Test.ClassName + "-" + TestContext.CurrentContext.Test.Name + DateTime.Now.ToString("HH-mm-ss") + ".png";

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                // The test failed
                SystemActions.TakeScreenshot(_rootdriver, _testSuiteFolder + "\\Screenshots\\Failed",screenShotFileName );

            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                // The test passed
                SystemActions.TakeScreenshot(_rootdriver, _testSuiteFolder + "\\Screenshots\\Succeeded", screenShotFileName);
            }

            _rootdriver.Close();**/

            _driver.Close();
            SystemActions.KillProcessByName("Atlasti" + AtlasVariables.actualMajor);
            SystemActions.KillProcessByName("SSD.ATLASti.Backup");
            SystemActions.KillProcessByName("WinAppDriver");


        }







    }
}
