using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.main.util;

namespace Test_Automation_Core.test.resources.test_suites
{
    public class UpdaterProduction
    {
        string testAssemblyPath = "TestAutomationFramework.dll";
        string targetNameSpaceUtil = "Test_Automation_Core.test.main.util";



        [Test, Order(1)]
        public void InstallProdMSI()
        {
            UpdateAtlasMSI.branch = "releaseMSI";
            bool success = TestRunner.RunTestByCategory(testAssemblyPath, targetNameSpaceUtil, "UpdateATLASMSI");
        }

        [Test, Order(2)]
       public void TestUpdaterMSI (){

            //run manually .reg script too change updateUrl in Registry edtior  (See TestingStuff => Smoke Test Data/Win)

            bool success = TestRunner.RunTestByCategory(testAssemblyPath, "Test_Automation_Core.test.main.tests.smoketests.support.Production", "prodMSI");


    }

}
}
