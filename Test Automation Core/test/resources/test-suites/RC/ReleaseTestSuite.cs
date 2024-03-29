﻿using System;
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
    public class ReleaseTestSuite:BaseTestSuite
    {
        string testAssemblyPath = "TestAutomationFramework.dll";
        string targetNameSpace = "Test_Automation_Core.TestPositiveFeedBack.main.tests.releasetests";
        string targetNameSpaceUtil = "Test_Automation_Core.TestPositiveFeedBack.main.util";


        [SetUp]
        public void setUp()
        {
            testType = "ReleaseTest";
            testRunnerEnabled = true;
            SetUpTestSuiteFolder();
        }
       


        [Test, Order(1)]
        public void Test1()
        {
            bool success = TestRunnerUtil.RunTestByCategory(testAssemblyPath, "Test_Automation_Core.test.main.tests.releasetests.migrationtests.projects.imports", "ImportReleaseProjects");

            Assert.IsTrue(success);
        }
    }
}
