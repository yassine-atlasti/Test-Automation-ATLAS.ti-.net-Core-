using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;
using static Test_Automation_Core.test.resources.test.AtlasVariables;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.vut
{
    public class CImportCHVUT:BaseTestCase
    {
        [Test,  Category("vut")]
        public void ImportAtlProj()
        {



            //Atlproj import

            bool atlprojImportState = GetAppActions().ImportProject(CHProjects.winVUTAtlProjPath, AtlasVariables.rcExportType);
          
            Assert.IsTrue(atlprojImportState);
           


        }

     //   [Test, Order(2)]
        public void ImportQDPX()
        {


            //QDPX Import
            bool qdpxImportState = GetAppActions().ImportProject(CHProjects.winVUTQDPXPath, "QDPX");
            Assert.IsTrue(qdpxImportState);
           

        }
    }
}
