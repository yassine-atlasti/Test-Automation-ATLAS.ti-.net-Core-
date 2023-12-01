using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.resources.test_data.onedrive.projects;

namespace Test_Automation_Core.test.main.tests.releasetests.migrationtests.projects.imports
{
    public class ImportNewIpad:InitTests
    {
        [Test, Category("ImportReleaseProjects")]
        public void ImportNewIpadTest()
        {

            bool importState = GetAppActions().ImportProject(ReleaseTestProjects.NewIPad, "mobile");

            Assert.IsTrue(importState);
        }
    }
}
