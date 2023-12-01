using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.resources.test_data.onedrive.projects;

namespace Test_Automation_Core.test.main.tests.releasetests.migrationtests.projects.imports
{
    public class ImportCloud:InitTests
    {
        [Test, Category("ImportReleaseProjects")]
        public void ImportcloudTest()
        {

            bool importState = GetAppActions().ImportProject(ReleaseTestProjects.Cloud, "AtlProj");

            Assert.IsTrue(importState);
        }
    }
}
