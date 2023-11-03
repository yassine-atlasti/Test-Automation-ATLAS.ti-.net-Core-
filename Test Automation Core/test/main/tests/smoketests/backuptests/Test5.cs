using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.tests.smoketests.backuptests
{
    internal class Test5:InitTests
    {
        [Category("backuptests")]

        [Test, Order(5)]
        public void OpenRestoredProject()
        {
            
            bool projectRestored = GetAppActions().OpenProject("Geo Project");
            Assert.IsTrue(projectRestored);
        }
    }
}
