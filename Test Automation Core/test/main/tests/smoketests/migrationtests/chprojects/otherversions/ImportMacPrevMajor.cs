using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.otherversions
{
    public class ImportMacPrevMajor
    {
        InitTests smokeTestClass = new InitTests();
        [Test, Order(1), Category("otherversions")]
        public void ImportAtlProj()
        {

            smokeTestClass.initATLAS();


            //Atlproj import

            bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.MacPreviousAtlProjPath, "AtlProj");
            Assert.IsTrue(atlprojImportState);

            //Close Project
            smokeTestClass.GetAppActions().CloseProjectAsync();




        }
        [Test, Order(2), Category("otherversions")]
        public void ImportQDPX()
        {
            smokeTestClass.initATLAS();

            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.MacPreviousQDPXPath, "QDPX", CHProjects.MacPreviousFolderMedia);
            Assert.IsTrue(qdpxImportState);

            smokeTestClass.GetAppActions().CloseProjectAsync();

        }
    }
}
