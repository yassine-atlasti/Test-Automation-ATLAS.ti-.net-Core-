using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests
{
    public class CImportCHVUT
    {
        InitTests smokeTestClass = new InitTests();
        public void ImportAtlProj()
        {

            smokeTestClass.initATLAS();


            //Atlproj import

            bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.winVUTAtlProjPath, "AtlProj");
            Assert.IsTrue(atlprojImportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();



        }

        [Test, Order(2)]
        public void ImportQDPX()
        {

            smokeTestClass.initATLAS();

            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.winVUTQDPXPath, "QDPX");
            Assert.IsTrue(qdpxImportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();

        }
    }
}
