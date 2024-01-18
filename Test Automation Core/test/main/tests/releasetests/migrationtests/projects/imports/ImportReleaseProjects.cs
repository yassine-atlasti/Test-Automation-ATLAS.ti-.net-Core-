using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.resources.test_data.onedrive.projects;

namespace Test_Automation_Core.test.main.tests.releasetests.migrationtests.projects.imports
{
    public class ImportReleaseProjects:BaseTestCase
    {
       


        public static IEnumerable<TestCaseData> ReleaseProjectsData()
        {
          //  yield return new TestCaseData(ReleaseTestProjects.A7AtlCB, "AtlCB").SetName("A7ProjectAtlCB");
            yield return new TestCaseData(ReleaseTestProjects.A7AtlPac, "AtlProj").SetName("A7ProjectAtlPac");
            yield return new TestCaseData(ReleaseTestProjects.A8Mac, "AtlProj").SetName("A8MacAtlProj");
            yield return new TestCaseData(ReleaseTestProjects.A8Win, "AtlProj").SetName("A8WinAtlProj");
            yield return new TestCaseData(ReleaseTestProjects.A9Win, "AtlProj").SetName("A9WinAtlProj");
           // yield return new TestCaseData(ReleaseTestProjects.Android, "mobile").SetName("AndroidProject");
            yield return new TestCaseData(ReleaseTestProjects.Cloud, "AtlProj").SetName("CloudProject");
         //   yield return new TestCaseData(ReleaseTestProjects.NewIPad, "mobile").SetName("IpadNewProject");
          //  yield return new TestCaseData(ReleaseTestProjects.OldIPad, "mobile").SetName("IpadOldProject");
            yield return new TestCaseData(ReleaseTestProjects.TestProjectA22, "AtlProj").SetName("TestProjectA22");



            //In order to import mobile projects with automation, This bug need to be fixed in ATLAS https://dev.azure.com/atlas-ti/ATLASti/_workitems/edit/19708



            // You can add more cases or read them from an external source
        }


        [Test, Category("ImportReleaseProjects")]
        [TestCaseSource(nameof(ReleaseProjectsData))]
        public void ImportAtlProj(string filePath, string type)
        {



            //Atlproj import

            bool atlprojImportState = GetAppActions().ImportProject(filePath, "AtlProj");

            Assert.IsTrue(atlprojImportState);






        }
    }
}
