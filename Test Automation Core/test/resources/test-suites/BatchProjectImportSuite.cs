using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.resources.test_suites
{
    public class BatchProjectImportSuite
    {

        string testAssemblyPath = "TestAutomationFramework.dll";




        [SetUp]
        public void setUp()
        {
            BaseTest._testSuiteFolder = SystemActions.GetDesktopPath() + "\\" + "BatchProjectImport" + AtlasVariables.InstalledVersion;
        }




        [Test, Order(1)]
        public void Test1()
        {
            bool success = TestRunner.RunTestByCategory(testAssemblyPath, "Test_Automation_Core.TestPositiveFeedBack.main.tests.specialtests", "specialtests");

            Assert.IsTrue(success);
        }













    }
}
