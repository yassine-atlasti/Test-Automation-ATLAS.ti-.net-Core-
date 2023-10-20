using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;
using Test_Automation_Core.Data.SmokeTestData;
using Test_Automation_Core.Data.SUT;

namespace Test_Automation_Core.Tests.Smoke_Tests.Exports
{
    public class ExportWinVUT
    {
        SmokeTestClass smokeTestClass= new SmokeTestClass();
        string fileName = AtlasVariables.winVUT + "-" + SmokeTestVariables.actualOS + "-" + SmokeTestVariables.smokeTestproject;


        [Test]
        public void exportAtlProj()
        {
            smokeTestClass.initATLAS();
            //Atlproj export
            

            bool atlProjExportState = smokeTestClass.GetAppActions().ExportProject(CHProjects.CHWinVUTProjectsFolder, "Atlproj", SmokeTestVariables.smokeTestproject,fileName);
            Assert.IsTrue(atlProjExportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();

          
        }
        [Test]
        public void exportQDPX()
        {
            smokeTestClass.initATLAS();
            //QDPX export

            bool qdpxExportState = smokeTestClass.GetAppActions().ExportProject(CHProjects.CHWinVUTProjectsFolder, "QDPX", SmokeTestVariables.smokeTestproject,fileName);
            Assert.IsTrue(qdpxExportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();


        }
    }
}
