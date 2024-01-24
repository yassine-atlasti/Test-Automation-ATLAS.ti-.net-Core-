using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.main.util;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.resources.test_data.releasetestdata;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.resources.test_suites
{
    public class BaseTestSuite

    {
        public static string testAssemblyPath = "TestAutomationFramework.dll";
        public static string targetNameSpaceUtil = "Test_Automation_Core.test.main.util";
        public static string testType="";
        public static string testSuiteFolder="";
        public static string passedTestsPath="";

        public static string failedTestsPath="";
     
        
        
        public static void SetUpTestFolder()
        {

            switch (testType)
            {
                case "SmokeTest":
                    testSuiteFolder = SmokeTestVariables.smokeTestFolderPath;
                    BaseTestCase.initSmokeTest();
                    break;

                case "ReleaseTest":
                    testSuiteFolder = ReleaseTestVariables.releaseTestFolderPath;
                    BaseTestCase.initReleaseTest();
                    break;

                case "ProdTest":
                case "devTest":
                case "vanillaState":
                    testSuiteFolder = SmokeTestVariables.smokeTestFolderPath;
                    SystemActions.CreateFolder(testSuiteFolder);
                    break;
                case "BatchProjectImport":
                    testSuiteFolder = SystemActions.GetDesktopPath() + "\\" + "BatchProjectImport" + AtlasVariables.InstalledVersion;
                    SystemActions.CreateFolder(testSuiteFolder);
                    break;
                default:
                    // Handle unexpected testType, possibly throw an exception or log a warning
                    testType = DateTime.Now.ToString("HH-mm-ss");
                    testSuiteFolder = SystemActions.GetDesktopPath();
                    break;
            }
        }
        //This method is called by the cleanup method in BaseTestCase.cs
        public static void saveScreenshot()
        {
            SystemActions systemActions = new SystemActions();
            WindowsDriver<WindowsElement> _rootdriver= systemActions.ClassInitialize("Root");



            var screenShotFileName = DateTime.Now.ToString("HH-mm-ss") + "-" + TestContext.CurrentContext.Test.Name + ".png";

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                // The test failed
                SystemActions.TakeScreenshot(_rootdriver, failedTestsPath, screenShotFileName);

            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                // The test passed
                SystemActions.TakeScreenshot(_rootdriver, passedTestsPath, screenShotFileName);
            }

            _rootdriver.Close();

        }

        //This method is called by the cleanup method in BaseTestCase.cs
        public  static void InitTestResults(string testCategory)
        {
            SetUpTestFolder();
            string testName= testType;
            if (testCategory != null)
            {
                testName = testCategory;

            }

            // Construct a unique folder path for the test run
            string uniqueTestRunFolder = Path.Combine(testSuiteFolder + "\\TestResults", $"TestRun_{testName}");

            if (Directory.Exists(uniqueTestRunFolder))
            {
                Directory.Delete(uniqueTestRunFolder, recursive: true);
            }
            // Create the main directory for the test run
            Directory.CreateDirectory(uniqueTestRunFolder);

            // Create subdirectories for passed and failed tests
            passedTestsPath = Path.Combine(uniqueTestRunFolder, "Passed");

            failedTestsPath = Path.Combine(uniqueTestRunFolder, "Failed");

            Directory.CreateDirectory(passedTestsPath);
            Directory.CreateDirectory(failedTestsPath);


            // Optional: Create an additional directory for logs or other artifacts
            string logsPath = Path.Combine(uniqueTestRunFolder, "Logs");
            Directory.CreateDirectory(logsPath);






        }

    }
}
