using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;
using static Test_Automation_Core.src.pages.atlasti.actions.ApplicationActions;

namespace Test_Automation_Core.test.main.tests.smoketests
{


    public class AExportCHVUT:BaseTestCase
    {
        string fileName = AtlasVariables.InstalledVersion + "-" + SmokeTestVariables.actualWinOS + "-" + SmokeTestVariables.smokeTestproject;

        [Test, Order(1), Category("vut")]

       

        public void exportAtlProj()
        {
          
            //Atlproj export

            //The export method has problem to locate the Project Bundle Button to do the export.
            bool atlProjExportState = GetAppActions().ExportProject(CHProjects.CHWinVUTProjectsFolder, ExportType.ATLPROJ, SmokeTestVariables.smokeTestproject, fileName);
            Assert.IsTrue(atlProjExportState);


        }
        [Test, Order(2), Category("vut")]
        public void exportQDPX()
        {
            //QDPX export

            bool qdpxExportState = GetAppActions().ExportProject(CHProjects.CHWinVUTProjectsFolder, ExportType.QDPX, SmokeTestVariables.smokeTestproject, fileName);
            Assert.IsTrue(qdpxExportState);


        }
    }
}
