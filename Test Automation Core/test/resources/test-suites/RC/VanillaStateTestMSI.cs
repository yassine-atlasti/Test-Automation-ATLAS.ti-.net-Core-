using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.main.util;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.resources.test_suites
{
    public class VanillaStateTestMSI:BaseTestSuite
    {
        [SetUp]
        public void setUp()
        {
            testType = "vanillaState";
            SetUpTestData();


        }
        [Test, Order(1)]
        public void InstallRCMSI()
        {
            UpdateAtlasMSI.branch = "rcMSI";
            bool success = TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpaceUtil, "UpdateATLASMSI");
        }
        [Test, Order(2)]
        public void OpenAtlas()
        {
            BaseTestCase test = new BaseTestCase();
            bool success = test.RunAtlas();
            test.cleanUp();
            Assert.IsTrue(success);
        }


    }
}
