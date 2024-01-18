using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.test.resources.test_suites
{
    public class VanillaStateTest:BaseTestSuite
    {
        [Test]
        public void OpenEmptyLibTest()
        {
            bool success = TestRunner.RunTestByCategory(testAssemblyPath, " Test_Automation_Core.test.main.tests.smoketests.migrationtests.libraries", "OpenEmptyLibA22");

            Assert.IsTrue(success);
        }

    }
}
