using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;

namespace Test_Automation_Core.Tests.Smoke_Tests.Importe
{
    public class ImportMacPrevMajor
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();
        [Test]
        public void importMacPrevMaj()
        {
            smokeTestClass.initATLAS();


            //Atlproj import

            bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHProjectsFolder, "AtlProj", CHProjects.MacPreviousAtlProj.Replace(" ", ""));
            Assert.IsTrue(atlprojImportState);

            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHProjectsFolder, "QDPX", CHProjects.MacPreviousQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);

        }
    }
}
