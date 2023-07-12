using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;

namespace Test_Automation_Core.Tests.Smoke_Tests.CHImports
{
    public class ImportWinPrevMajor
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();
        [Test]
        public void ImportAtlProj()
        {
            smokeTestClass.GetAppActions().CloseProjectAsync();

            smokeTestClass.initATLAS();

            //Atlproj import

            bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHWinPrevMajorProjectsFolder, "AtlProj", CHProjects.WinPreviousAtlProj.Replace(" ", ""));
            Assert.IsTrue(atlprojImportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();


           
        }

        [Test]
        public void ImportQDPX()
        {
            smokeTestClass.initATLAS();

            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHWinPrevMajorProjectsFolder, "QDPX", CHProjects.WinPreviousQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();

        }


    }
}
