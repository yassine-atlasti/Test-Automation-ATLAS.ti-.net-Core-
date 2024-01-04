using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.resources.test_data.onedrive.projects;

namespace Test_Automation_Core.test.main.tests.releasetests.migrationtests.projects.imports
{
    internal class ImportOldIPad:InitTests
    {
       // [Test, Category("ImportReleaseProjects")]
        public void ImportOldIPadTest()
        {

            bool importState = GetAppActions().ImportProject(ReleaseTestProjects.OldIPad, "mobile");

            Assert.IsTrue(importState);
        }
    }
}
