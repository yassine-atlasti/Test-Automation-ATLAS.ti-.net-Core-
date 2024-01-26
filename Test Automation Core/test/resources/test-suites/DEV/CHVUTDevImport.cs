using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.vut;
using Test_Automation_Core.test.main.util;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.resources.test_suites.DEV
{
    public class CHVUTDevImport:BaseTestSuite
    {
        [SetUp]
        public void setUp()
        {
            testType = "devTest";
            testRunnerEnabled = true;
            SetUpTestSuiteFolder();

        }
        [Test, Order(1)]
        public void InstallDEVMSI()
        {
            UpdateAtlasMSI.branch = "devMSI";
            bool success = TestRunnerUtil.RunTestByCategory(testAssemblyPath, targetNameSpaceUtil, "UpdateATLASMSI");
        }
        [Test, Order(2)]
        public void ImportCHVUT()
        {
           
                bool success = TestRunnerUtil.RunTestByCategory(testAssemblyPath, " Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.vut", "DEVimportCHVUT");


            Assert.IsTrue(success);
        }
    }
}
