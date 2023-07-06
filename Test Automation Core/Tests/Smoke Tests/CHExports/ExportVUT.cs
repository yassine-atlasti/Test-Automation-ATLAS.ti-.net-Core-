using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;
using Test_Automation_Core.Data.SmokeTestData;

namespace Test_Automation_Core.Tests.Smoke_Tests.Exports
{
    public class ExportVUT
    {
        SmokeTestClass smokeTestClass= new SmokeTestClass();
       
        [Test]
        public void exportVUT()
        {
            smokeTestClass.initATLAS();
            //Atlproj export

            bool atlProjExportState = smokeTestClass.GetAppActions().ExportProject(CHProjects.CHWinVUTProjectsFolder, "Atlproj", SmokeTestVariables.smokeTestproject);
            Assert.IsTrue(atlProjExportState);
            //QDPX export

            bool qdpxExportState = smokeTestClass.GetAppActions().ExportProject(CHProjects.CHWinVUTProjectsFolder, "QDPX", SmokeTestVariables.smokeTestproject);
            Assert.IsTrue(qdpxExportState);
        }
    }
}
