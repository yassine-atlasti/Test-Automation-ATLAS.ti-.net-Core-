using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;
using Test_Automation_Core.OS.Windows;

namespace Test_Automation_Core.Tests.Smoke_Tests.Importe
{
    public class ImportMacPrevMajor
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();
        [Test]
        public void ImportAtlProj()
        {

            smokeTestClass.initATLAS();


            //Atlproj import

            bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHMacPrevMajorProjectsFolder, "AtlProj", CHProjects.MacPreviousAtlProj.Replace(" ", ""));
            Assert.IsTrue(atlprojImportState);

            //Close Project
            smokeTestClass.GetAppActions().CloseProjectAsync();


            

        }
        [Test]
        public void ImportQDPX()
        {
            smokeTestClass.initATLAS();

            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHMacPrevMajorProjectsFolder, "QDPX", CHProjects.MacPreviousQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);

            smokeTestClass.GetAppActions().CloseProjectAsync();

        }
    }
}
