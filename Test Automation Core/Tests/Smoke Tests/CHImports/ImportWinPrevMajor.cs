using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;

namespace Test_Automation_Core.Tests.Smoke_Tests.CHImports
{
    public class ImportWinPrevMajor
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();
        [Test, Order(1)]
        public void ImportAtlProj()
        {

            smokeTestClass.initATLAS();

            //Atlproj import

            bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.WinPreviousAtlProjPath, "AtlProj");
            Assert.IsTrue(atlprojImportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();


        }

        [Test, Order(2)]
        public void ImportQDPX()
        {
            smokeTestClass.initATLAS();

            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.WinPreviousQDPXPath, "QDPX",CHProjects.WinPreviousFolderMedia);
            Assert.IsTrue(qdpxImportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();

        }


    }
}
