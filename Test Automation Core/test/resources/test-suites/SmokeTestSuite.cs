using Test_Automation_Core.test.main.util;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.resources.test_data.releasetestdata;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.tests.smoketests
{
    public class SmokeTestSuite 
    {
        string testAssemblyPath = "TestAutomationFramework.dll";
        string targetNameSpace = "Test_Automation_Core.test.main.tests.smoketests";
        string targetNameSpaceUtil = "Test_Automation_Core.test.main.util";



       // [OneTimeSetUp]
        public void downloadRC()
        {
            bool success =true;
            if (AtlasVariables.winRC != AtlasVariables.InstalledVersion)
            {
                UpdateAtlasti.branch = "rc";
                success= TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpaceUtil, "UpdateATLAS");

            }

            Assert.IsTrue(success);


        }
      [SetUp]
        public void setUp()
        {
            InitTests._testSuiteFolder = SmokeTestVariables.smokeTestFolderPath;
        }

        [Test, Order(1)]
        public  void initTestData()
        {
          InitTests.initSmokeTest();

        }




          [Test, Order(2)]
        public void Test1()
        {
          bool success=  TestRunner.RunTestByCategory(testAssemblyPath, "Test_Automation_Core.test.main.tests.smoketests.migrationtests.libraries", "OpenEmptyLibA22");

            Assert.IsTrue(success);
        }

       
        [Test, Order(3)]
        public void Test3()
        {
           bool success = TestRunner.RunTestByCategory(testAssemblyPath, "Test_Automation_Core.test.main.tests.smoketests.migrationtests.libraries", "OpenYanikLib");
            Assert.IsTrue(success);

        }

        [Test, Order(4)]
        public void Test4()

        {
          bool success=  TestRunner.RunTestByCategory(testAssemblyPath, "Test_Automation_Core.test.main.tests.smoketests.backuptests", "backuptests");
            Assert.IsTrue(success);


        }

        [Test, Order(5)]
        public void Test5()
        {
           bool success= TestRunner.RunTestByCategory(testAssemblyPath, "Test_Automation_Core.test.main.tests.smoketests.migrationtests.libraries", "OpenLibCH");

            Assert.IsTrue(success);




        }

       // [Test, Order(5)]
       //Devs need to add Automation IDs to the Export Project Buttons in the ExportControls
        public void Test6()
        {
           bool success= TestRunner.RunTestByCategory(testAssemblyPath, "Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.vut", "vut");


        Assert.IsTrue(success);

        }

        [Test, Order(6)]
        public void Test7()
        {
           bool success= TestRunner.RunTestByCategory(testAssemblyPath, "Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.otherversions", "otherversions");

            Assert.IsTrue(success);


        }







    }
}
