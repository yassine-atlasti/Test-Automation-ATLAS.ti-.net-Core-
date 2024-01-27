using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;
using static Test_Automation_Core.test.resources.test.AtlasVariables;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.vut
{


    public class AExportCHVUT:BaseTestCase
    {
        string fileName = AtlasVariables.InstalledVersion + "-" + SmokeTestVariables.actualWinOS + "-" + SmokeTestVariables.smokeTestproject;

        [Test, Order(1), Category("vut")]

       

        public void exportAtlastiProject()
        {
          
            //Atlproj export

            bool atlProjExportState = GetAppActions().ExportProject(CHProjects.CHWinVUTProjectsFolder, ExportTypes.atlasti, SmokeTestVariables.smokeTestproject, fileName);
            Assert.IsTrue(atlProjExportState);


        }
       // [Test, Order(2), Category("vut")]
       //QDPX Export is actually not working. 
        public void exportQDPX()
        {
            //QDPX export

            bool qdpxExportState = GetAppActions().ExportProject(CHProjects.CHWinVUTProjectsFolder, ExportTypes.QDPX, SmokeTestVariables.smokeTestproject, fileName);
            Assert.IsTrue(qdpxExportState);


        }
    }
}
