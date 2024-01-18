using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.main.util;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.resources.test_data.releasetestdata;

namespace Test_Automation_Core.test.resources.test_suites
{
    public class BaseTestSuite
    {
        public static string testAssemblyPath = "TestAutomationFramework.dll";
        public static string targetNameSpaceUtil = "Test_Automation_Core.test.main.util";
        public static string testType;


        // [OneTimeSetUp]
        public static void downloadRCMSI()
        {
            bool success = true;
            if (AtlasVariables.winRC != AtlasVariables.InstalledVersion)
            {
                UpdateAtlasMSI.branch = "rcMSI";
                success = TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpaceUtil, "UpdateATLASMSI");

            }

            Assert.IsTrue(success);


        }
        [SetUp]
        public void setUp()
        {
            if (testType == "SmokeTest")
            {
                BaseTestCase._testSuiteFolder = SmokeTestVariables.smokeTestFolderPath;
                BaseTestCase.initSmokeTest();


            }
            else
                 if (testType == "ReleaseTest")
            {
                BaseTestCase._testSuiteFolder = ReleaseTestVariables.releaseTestFolderPath;
                BaseTestCase.initReleaseTest();


            }

        }

        
    }
}
