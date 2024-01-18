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
    public class UpdaterProductionTest
    {
        string testAssemblyPath = "TestAutomationFramework.dll";
        string targetNameSpaceUtil = "Test_Automation_Core.test.main.util";

        [SetUp]
        public void setUp()
        {
                BaseTestCase._testSuiteFolder = SmokeTestVariables.smokeTestFolderPath;
            SystemActions.CreateFolder(SmokeTestVariables.smokeTestFolderPath);


        }

        [Test, Order(1)]
        public void InstallProdMSI()
        {
            UpdateAtlasMSI.branch = "releaseMSI";
            bool success = TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpaceUtil, "UpdateATLASMSI");
        }

        [Test, Order(2)]
       public void TesProdtUpdaterMSI (){

            //run manually .reg script too change updateUrl in Registry edtior  (See TestingStuff => Smoke Test Data/Win)

            bool success = TestRunner.RunTestByCategory(testAssemblyPath, "Test_Automation_Core.test.main.tests.smoketests.support.Production", "ProdUpdaterMSI");


    }
        

        [Test, Order(3)]
        public void InstallProdEXE()
        {

            UpdateAtlasEXE.branch = "releaseEXE";
            bool success = TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpaceUtil, "UpdateATLASEXE");

        }



        [Test, Order(4)]
        public void TestProdUpdaterEXE()
        {

            //run manually .reg script too change updateUrl in Registry edtior  (See TestingStuff => Smoke Test Data/Win)

            bool success = TestRunner.RunTestByCategory(testAssemblyPath, "Test_Automation_Core.test.main.tests.smoketests.support.Production", "ProdUpdaterEXE");


        }

    }
}
