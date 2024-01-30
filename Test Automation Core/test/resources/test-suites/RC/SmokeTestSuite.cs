using Test_Automation_Core.test.main.util;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.resources.test_data.releasetestdata;
using Test_Automation_Core.test.resources.test_suites;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.tests.smoketests
{
    public class SmokeTestSuite:BaseTestSuite
    {
       
        [SetUp]
        public void setUp()
        {
            testType = "SmokeTest";
            testRunnerEnabled = true;
             SetUpTestSuiteFolder();

        }
        //[Test]
        public static void downloadRCMSI()
        {
            bool success = true;
            if (AtlasVariables.winRC != AtlasVariables.InstalledVersion)
            {
                UpdateAtlas.branch = "rcMSI";
                success = TestRunnerUtil.RunTestByCategory(testAssemblyPath, targetNameSpaceUtil, "UpdateATLAS");

            }

            Assert.IsTrue(success);


        }

        [Test, Order(1)]
        public void OpenYanikLibTest()
        {

           
            

            bool success = TestRunnerUtil.RunTestByCategory(testAssemblyPath, " Test_Automation_Core.test.main.tests.smoketests.migrationtests.libraries", "OpenYanikLib");
            Assert.IsTrue(success);

        }

        [Test, Order(2)]
        public void BackUpTests()

        {
            
            bool success=  TestRunnerUtil.RunTestByCategory(testAssemblyPath, " Test_Automation_Core.test.main.tests.smoketests.backuptests", "backuptests");
            Assert.IsTrue(success);


        }

        [Test, Order(3)]
        public void OpenCHLibTest()
        {
           bool success= TestRunnerUtil.RunTestByCategory(testAssemblyPath, " Test_Automation_Core.test.main.tests.smoketests.migrationtests.libraries", "OpenLibCH");

            Assert.IsTrue(success);




        }

        [Test, Order(4)]

        public void SupportTests()
        {
            bool success= TestRunnerUtil.RunTestByCategory(testAssemblyPath, " Test_Automation_Core.test.main.tests.smoketests.support", "support");
            Assert.IsTrue(success);
        }

       [Test, Order(5)]
       //Devs need to add Automation IDs to the Export Project Buttons in the ExportControls
        public void CHVUTTests()
        {
           bool success= TestRunnerUtil.RunTestByCategory(testAssemblyPath, " Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.vut", "vut");


        Assert.IsTrue(success);

        }

        [Test, Order(5)]
        public void OtherCHImportTests()
        {
           bool success= TestRunnerUtil.RunTestByCategory(testAssemblyPath, " Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.otherversions", "otherversions");

            Assert.IsTrue(success);


        }

      





    }
}
