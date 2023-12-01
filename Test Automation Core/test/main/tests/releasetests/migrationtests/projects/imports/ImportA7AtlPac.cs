using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.resources.test_data.onedrive.projects;

namespace Test_Automation_Core.test.main.tests.releasetests.migrationtests.projects.imports
{
    public class ImportA7AtlPac:InitTests
    {
        [Test, Category("ImportReleaseProjects")]
        public void ImportA7AtlPacTest()
        { 

            bool importState = GetAppActions().ImportProject(ReleaseTestProjects.A7AtlPac, "AtlProj");

            Assert.IsTrue(importState);
        }
    }
}
