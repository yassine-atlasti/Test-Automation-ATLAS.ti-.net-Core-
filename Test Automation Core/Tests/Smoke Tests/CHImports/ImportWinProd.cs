using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;
using Test_Automation_Core.Data.SUT;
using Test_Automation_Core.OS.Windows;

namespace Test_Automation_Core.Tests.Smoke_Tests.CHImports
{
    [TestFixture]
    public class ImportWinProd
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();
        [Test, Order(1)]
        public void ImportAtlProj()
        {

            smokeTestClass.initATLAS();

          // string WinProductionAtlProjPath = SystemActions.FindFilesByPartialName(CHProjects.CHWinProdProjectsFolder, AtlasVariables.winProduction, ".atlproj" + AtlasVariables.major, out bool isFound );

        //Atlproj import

        bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.WinProductionAtlProjPath, "AtlProj");
            Assert.IsTrue(atlprojImportState);

            smokeTestClass.GetAppActions().CloseProjectAsync();

          

        }
        [Test, Order(2)]
        public void ImportQDPX()
        {
            smokeTestClass.initATLAS();

            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.WinProductionQDPXPath, "QDPX");
            Assert.IsTrue(qdpxImportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();

        }
    }
}
