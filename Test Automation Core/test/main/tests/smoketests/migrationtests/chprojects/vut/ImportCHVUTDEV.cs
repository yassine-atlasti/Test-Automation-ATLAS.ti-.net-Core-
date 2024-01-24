using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.vut
{
    public class CImportCHVUTDEV
    {
        BaseTestCase test = new BaseTestCase();

        [SetUp]
        public void SetUp()
        {
            test.RunAtlas();
        }
        [Test,  Category("DEVimportCHVUT")]
        public void ImportAtlProj()
        {



            //Atlproj import

            bool atlprojImportState = test.GetAppActions().ImportProject(CHProjects.winVUTAtlProjPath, AtlasVariables.rcExportType);
            Assert.IsTrue(atlprojImportState);
           


        }

     //   [Test, Order(2)]
        public void ImportQDPX()
        {


            //QDPX Import
            bool qdpxImportState = test.GetAppActions().ImportProject(CHProjects.winVUTQDPXPath, "QDPX");
            Assert.IsTrue(qdpxImportState);
           

        }

        [TearDown]
        public void CleanUp()
        {
            test.cleanUp();
        }
    }
}
