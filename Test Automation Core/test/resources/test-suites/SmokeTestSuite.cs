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



        [OneTimeSetUp]
        public void downloadRC()
        {
            if (AtlasVariables.winRC != AtlasVariables.InstalledVersion)
            {
                UpdateAtlasti.branch = "rc";
                TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpaceUtil, "UpdateATLAS");

            }



        }

        [Test, Order(1)]
        public  void initTestData()
        {
          InitTests.initSmokeTest();

        }




          [Test, Order(2)]
        public void Test1()
        {
            TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "OpenEmptyLibA22");


        }

       
        [Test, Order(3)]
        public void Test3()
        {
            TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "OpenYanikLib");

        }

        [Test, Order(4)]
        public void Test4()

        {
            TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "backuptests");


        }

        [Test, Order(5)]
        public void Test5()
        {
            TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "OpenLibCH");




        }

       // [Test, Order(5)]
        public void Test6()
        {
            TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "vut");




        }

        [Test, Order(6)]
        public void Test7()
        {
            TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "otherversions");




        }







    }
}
