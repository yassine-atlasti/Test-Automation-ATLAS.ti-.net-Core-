﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.resources.test_suites
{
    public class BatchProjectImportSuite:BaseTestSuite
    {

        string testAssemblyPath = "TestAutomationFramework.dll";




        [SetUp]
        public void setUp()
        {
            testType = "BatchProjectImport";
            testRunnerEnabled = true;
            SetUpTestSuiteFolder();

        }




        [Test, Order(1)]
        public void Test1()
        {
            bool success = TestRunnerUtil.RunTestByCategory(testAssemblyPath, "Test_Automation_Core.test.main.tests.specialtests", "specialtests");

            Assert.IsTrue(success);
        }













    }
}
