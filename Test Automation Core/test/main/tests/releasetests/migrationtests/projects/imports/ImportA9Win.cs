using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.resources.test_data.onedrive.projects;

namespace Test_Automation_Core.test.main.tests.releasetests.migrationtests.projects.imports
{
    public class ImportA9Win:InitTests
    {
        [Test, Category("ImportReleaseProjects")]
        public void ImportA9WinTest()
        {

            bool importState = GetAppActions().ImportProject(ReleaseTestProjects.A9Win, "AtlProj");

            Assert.IsTrue(importState);
        }
    }
}
