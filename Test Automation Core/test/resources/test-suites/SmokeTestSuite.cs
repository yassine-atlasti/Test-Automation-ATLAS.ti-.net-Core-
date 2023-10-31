using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.tests.smoketests
{
    public class SmokeTestSuite
    {
        string testAssemblyPath = "TestAutomationFramework.dll";
        string targetNameSpace = "Test_Automation_Core.test.main.tests";

        [Test, Order(1)]
        public void Test1()
        {
            TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "OpenEmptyLibA22");


        }

        [Test, Order(2)]
        public void Test2()
        {
            SystemActions.KillProcessByName("Atlasti" + AtlasVariables.actualMajor);


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

        [Test, Order(6)]
        public void Test6()
        {
            TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "vut");




        }

        [Test, Order(7)]
        public void Test7()
        {
            TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpace, "otherversions");




        }







    }
}
