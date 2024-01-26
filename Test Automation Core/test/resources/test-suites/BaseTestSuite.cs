using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        //Default folder for TestResults is desktop
        public static string testSuiteFolder = SystemUtil.GetDesktopPath();
        public static string passedTestsPath = "";

        public static string failedTestsPath = "";
        public static string testCategory = "";
        public bool testRunnerEnabled;
        public static void SetUpTestResults(string testCategory)
        {
            InitTestResults(testCategory);
            ClearDirectory(passedTestsPath);
            ClearDirectory(failedTestsPath);
        }

        public static void SetUpTestSuiteFolder()
        {

            switch (testType)
            {
                case "SmokeTest":

                    testSuiteFolder = SmokeTestVariables.smokeTestFolderPath;
                    break;

                case "ReleaseTest":

                    testSuiteFolder = ReleaseTestVariables.releaseTestFolderPath;
                    break;

                case "ProdTest":
                case "devTest":
                case "vanillaState":
                    testSuiteFolder = SmokeTestVariables.smokeTestFolderPath;
                    SystemUtil.CreateFolder(testSuiteFolder);
                    break;
                case "BatchProjectImport":
                    testSuiteFolder = SystemUtil.GetDesktopPath() + "\\" + "BatchProjectImport" + AtlasVariables.InstalledVersion;
                    SystemUtil.CreateFolder(testSuiteFolder);
                    break;
                
            }
        }
        //This method is called by the cleanup method in BaseTestCase.cs
        public static void saveScreenshot()
        {
            //If a new test category is run, we setup the corresponding Test Results folder
            if (testCategory != TestContext.CurrentContext.Test.Properties["Category"].First().ToString())
            {
                testCategory= TestContext.CurrentContext.Test.Properties["Category"].First().ToString();
              SetUpTestResults(testCategory);     }
          

            SystemUtil systemActions = new SystemUtil();
            WindowsDriver<WindowsElement> _rootdriver = systemActions.ClassInitialize("Root");



            var screenShotFileName = DateTime.Now.ToString("HH-mm-ss") + "-" + TestContext.CurrentContext.Test.Name + ".png";

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                // The test failed
                SystemUtil.TakeScreenshot(_rootdriver, failedTestsPath, screenShotFileName);

            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                // The test passed
                SystemUtil.TakeScreenshot(_rootdriver, passedTestsPath, screenShotFileName);
            }

            _rootdriver.Close();

        }
        



        public static void InitTestResults(string testCategory)
        {
             
            string testName = testType;
            if (testCategory != null)
            {
                testName = testCategory;
            }

            // Construct a unique folder path for the test run
            string uniqueTestRunFolder = Path.Combine(testSuiteFolder + "\\TestResults", $"TestRun_{testName}");

            // Create the main directory for the test run if it doesn't exist
            if (!Directory.Exists(uniqueTestRunFolder))
            {
                Directory.CreateDirectory(uniqueTestRunFolder);
            }

            // Create or clear subdirectories for passed and failed tests
            passedTestsPath = Path.Combine(uniqueTestRunFolder, "Passed");
            failedTestsPath = Path.Combine(uniqueTestRunFolder, "Failed");



            // Optional: Create or clear an additional directory for logs or other artifacts
            string logsPath = Path.Combine(uniqueTestRunFolder, "Logs");
        }

        public static void ClearDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                // Delete existing screenshots
                var files = Directory.GetFiles(path, "*.png");
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }
            else
            {
                // Create directory if it doesn't exist
                Directory.CreateDirectory(path);
            }
        }


    }
}
