using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;

namespace Test_Automation_Core.Tests.Smoke_Tests.Importe
{
    public class ImportVUT
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();
        [Test]
        public void importVUT()
        {
            smokeTestClass.initATLAS();


            //Atlproj import

            bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHWinVUTProjectsFolder, "AtlProj", CHProjects.winVUTAtlProj.Replace(" ", ""));
            Assert.IsTrue(atlprojImportState);

            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHWinVUTProjectsFolder, "QDPX", CHProjects.winVUTQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);

        }
    }
}
