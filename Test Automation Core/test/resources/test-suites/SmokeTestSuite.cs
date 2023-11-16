using Test_Automation_Core.test.main.util;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.tests.smoketests
{
    public class SmokeTestSuite 
    {
        string testAssemblyPath = "TestAutomationFramework.dll";
        string targetNameSpace = "Test_Automation_Core.test.main.tests";
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

        [Test, Order(1)]
        public  void initTestData()
        {
          InitTests.initSmokeTest();

        }




          [Test, Order(2)]
        public void Test1()
        {
          bool success=  TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "OpenEmptyLibA22");

            Assert.IsTrue(success);
        }

       
        [Test, Order(3)]
        public void Test3()
        {
           bool success = TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "OpenYanikLib");
            Assert.IsTrue(success);

        }

        [Test, Order(4)]
        public void Test4()

        {
          bool success=  TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "backuptests");
            Assert.IsTrue(success);


        }

        [Test, Order(5)]
        public void Test5()
        {
           bool success= TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "OpenLibCH");

            Assert.IsTrue(success);




        }

       // [Test, Order(5)]
        public void Test6()
        {
           bool success= TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "vut");


        Assert.IsTrue(success);

        }

        [Test, Order(6)]
        public void Test7()
        {
           bool success= TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "otherversions");

            Assert.IsTrue(success);


        }







    }
}
