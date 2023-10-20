using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;

namespace Test_Automation_Core.Tests.Smoke_Tests.Importe
{
    public class ImportWinVUT
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();
        [Test, Order(1)]
        public void ImportAtlProj()
        {

            smokeTestClass.initATLAS();


            //Atlproj import

            bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.winVUTAtlProjPath, "AtlProj");
            Assert.IsTrue(atlprojImportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();

          

        }

        [Test, Order(2)]
        public void ImportQDPX()
        {

            smokeTestClass.initATLAS();

            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.winVUTQDPXPath, "QDPX");
            Assert.IsTrue(qdpxImportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();

        }
    }
}
