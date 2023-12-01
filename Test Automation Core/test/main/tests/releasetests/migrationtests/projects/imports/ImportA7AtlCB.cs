using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.resources.test_data.onedrive.projects;

namespace Test_Automation_Core.test.main.tests.releasetests.migrationtests.projects.imports
{
    public class ImportA7AtlCB:InitTests
    {
        // This bug need to be fixed in ATLAS https://dev.azure.com/atlas-ti/ATLASti/_workitems/edit/19708
        // [Test, Category("ImportReleaseProjects")]
        public void ImportA7AtlCBTest()
        { 

            bool importState = GetAppActions().ImportProject(ReleaseTestProjects.A7AtlCB, "AtlCB");

            Assert.IsTrue(importState);
        }
    }
}
