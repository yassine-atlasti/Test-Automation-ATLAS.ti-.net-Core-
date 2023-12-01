using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.resources.test_data.onedrive.projects;

namespace Test_Automation_Core.test.main.tests.releasetests.migrationtests.projects.imports
{
    public class ImportA8Mac:InitTests
    {
        [Test, Category("ImportReleaseProjects")]
        public void ImportA8MacTest()
        { 

            bool importState = GetAppActions().ImportProject(ReleaseTestProjects.A8Mac, "AtlProj");

            Assert.IsTrue(importState);
        }
    }
}
