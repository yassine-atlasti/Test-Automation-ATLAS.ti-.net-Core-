using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.Tests.Smoke_Tests
{
    public class ReportProblem
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();

        [Test]
        public void test()
        {
            smokeTestClass.initATLAS();
            bool reportState = smokeTestClass.GetAppActions().ReportProblem("Test", "tester@atlasti.com");

            Assert.IsTrue(reportState);
        }



    }
}
