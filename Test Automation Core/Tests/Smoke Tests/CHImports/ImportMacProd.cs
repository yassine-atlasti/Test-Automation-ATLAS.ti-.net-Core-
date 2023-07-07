using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;

namespace Test_Automation_Core.Tests.Smoke_Tests.CHImports
{
    public class ImportMacProd
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();
        [Test]
        public void importWinProd()
        {
            smokeTestClass.initATLAS();

            //Atlproj import

            bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHMacProdProjectsFolder, "AtlProj", CHProjects.MacProductionAtlProj.Replace(" ", ""));
            Assert.IsTrue(atlprojImportState);


            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHMacProdProjectsFolder, "QDPX", CHProjects.MacProductionQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);

        }
    }
}
