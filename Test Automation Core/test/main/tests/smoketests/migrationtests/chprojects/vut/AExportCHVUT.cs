using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.vut
{


    public class AExportCHVUT
    {
        InitTests smokeTestClass = new InitTests();
        string fileName = AtlasVariables.winVUT + "-" + SmokeTestVariables.actualOS + "-" + SmokeTestVariables.smokeTestproject;

        [Test, Order(1), Category("vut")]


        public void exportAtlProj()
        {
            smokeTestClass.initATLAS();
            //Atlproj export


            bool atlProjExportState = smokeTestClass.GetAppActions().ExportProject(CHProjects.CHWinVUTProjectsFolder, "Atlproj", SmokeTestVariables.smokeTestproject, fileName);
            Assert.IsTrue(atlProjExportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();


        }
        [Test, Order(2), Category("vut")]
        public void exportQDPX()
        {
            smokeTestClass.initATLAS();
            //QDPX export

            bool qdpxExportState = smokeTestClass.GetAppActions().ExportProject(CHProjects.CHWinVUTProjectsFolder, "QDPX", SmokeTestVariables.smokeTestproject, fileName);
            Assert.IsTrue(qdpxExportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();


        }
    }
}
