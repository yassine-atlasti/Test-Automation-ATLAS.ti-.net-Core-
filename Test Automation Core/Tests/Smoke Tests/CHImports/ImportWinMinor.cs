using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;

namespace Test_Automation_Core.Tests.Smoke_Tests.CHImports
{
    public class ImportWinMinor
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();
        [Test]
        public void importWinMinor()
        {
            smokeTestClass.initATLAS();

            //Atlproj import

            bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHWinMinorProjectsFolder, "AtlProj", CHProjects.WinPreviousAtlProj.Replace(" ", ""));
            Assert.IsTrue(atlprojImportState);


            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHWinMinorProjectsFolder, "QDPX", CHProjects.WinPreviousQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);

        }
    }
}
