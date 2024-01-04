using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.resources.test_data.onedrive.projects;

namespace Test_Automation_Core.test.main.tests.releasetests.migrationtests.projects.imports
{
    public class ImportTestProjectA22:InitTests
    {
        [Test,Category("ImportReleaseProjects")]
        public void ImportTestProject()
        {

            bool importState = GetAppActions().ImportProject(ReleaseTestProjects.TestProjectA22, "AtlProj");

            Assert.IsTrue(importState);
        }
    }
}
