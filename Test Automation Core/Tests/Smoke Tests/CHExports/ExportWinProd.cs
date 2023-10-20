using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;
using Test_Automation_Core.Data.SmokeTestData;

namespace Test_Automation_Core.Tests.Smoke_Tests.Exports
{
    public class ExportWinProd
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();

        [Test]
        public void exportAtlProj()
        {
            smokeTestClass.initATLAS();
            //Atlproj export

            bool atlProjExportState = smokeTestClass.GetAppActions().ExportProject(SmokeTestVariables.smokeTestFolderPath, "Atlproj", Path.GetFileNameWithoutExtension(CHProjects.WinProductionAtlProjPath));
            Assert.IsTrue(atlProjExportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();


        }
        [Test]
        public void exportQDPX()
        {
            smokeTestClass.initATLAS();
            //QDPX export

            bool qdpxExportState = smokeTestClass.GetAppActions().ExportProject(SmokeTestVariables.smokeTestFolderPath, "QDPX", Path.GetFileNameWithoutExtension(CHProjects.WinProductionQDPXPath));
            Assert.IsTrue(qdpxExportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();


        }
    }
}
