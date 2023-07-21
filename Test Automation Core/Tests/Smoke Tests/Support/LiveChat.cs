using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.Tests.Smoke_Tests
{
    public class LiveChat
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();

        [Test]
        public void test()
        {
            smokeTestClass.initATLAS();
             smokeTestClass.GetAppActions().LiveChat("QA Test, Please Ignore");

           // Assert.IsTrue(reportState);
        }
    }
}
