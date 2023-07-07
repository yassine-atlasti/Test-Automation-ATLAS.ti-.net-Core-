using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;
using Test_Automation_Core.OS.Windows;

namespace Test_Automation_Core.Tests.Smoke_Tests.Importe
{
    public class ImportMacMinor
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();
        [Test]
        public void importMacMinor()
        {
            smokeTestClass.initATLAS();

            //Atlproj import

            bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHMacMinorProjectsFolder, "AtlProj", CHProjects.MacPreviousAtlProj.Replace(" ", ""));
            Assert.IsTrue(atlprojImportState);


            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.CHMacMinorProjectsFolder, "QDPX", CHProjects.MacPreviousQDPX.Replace(" ", ""));
            Assert.IsTrue(qdpxImportState);

        }
    }
}
