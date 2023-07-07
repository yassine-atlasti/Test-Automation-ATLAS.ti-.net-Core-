using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;

namespace Test_Automation_Core.Tests.Smoke_Tests.CHImports
{
    public class ImportWinProd
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();
        [Test]
        public void importWinProd()
        {
            smokeTestClass.initATLAS();

            //Atlproj import

            bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHWinProdProjectsFolder, "AtlProj", CHProjects.WinProductionAtlProj.Replace(" ", ""));
            Assert.IsTrue(atlprojImportState);

            smokeTestClass.GetAppActions().CloseProjectAsync();

            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHWinProdProjectsFolder, "QDPX", CHProjects.WinProductionQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);

        }
        [Test]
        public void ImportWinProdQDPX()
        {
            smokeTestClass.initATLAS();

            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHWinProdProjectsFolder, "QDPX", CHProjects.WinProductionQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);
        }
    }
}
