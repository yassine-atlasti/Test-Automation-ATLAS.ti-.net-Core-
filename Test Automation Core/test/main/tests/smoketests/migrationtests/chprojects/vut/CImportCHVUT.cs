using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests
{
    public class CImportCHVUT:BaseTestCase
    {
        public void ImportAtlProj()
        {



            //Atlproj import

            bool atlprojImportState = GetAppActions().ImportProject(CHProjects.winVUTAtlProjPath, "AtlProj");
            Assert.IsTrue(atlprojImportState);
            GetAppActions().CloseProjectAsync();



        }

        [Test, Order(2)]
        public void ImportQDPX()
        {


            //QDPX Import
            bool qdpxImportState = GetAppActions().ImportProject(CHProjects.winVUTQDPXPath, "QDPX");
            Assert.IsTrue(qdpxImportState);
            GetAppActions().CloseProjectAsync();

        }
    }
}
