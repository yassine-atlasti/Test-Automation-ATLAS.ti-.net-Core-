using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.test.main.tests.smoketests.backuptests
{
    public class BackupTest5:BaseTest
    {
        [Category("backuptests")]

        [Test]
        public void OpenRestoredProject()
        {
            bool projectRestored = GetAppActions().OpenProject("Geo Project");
            Assert.IsTrue(projectRestored);
        }
    }
}
