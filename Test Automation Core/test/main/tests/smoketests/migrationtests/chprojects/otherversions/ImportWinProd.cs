using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests
{
    [TestFixture]
    public class ImportWinProd
    {
        InitTests smokeTestClass = new InitTests();
        [Test, Order(1), Category("otherversions")]
        public void ImportAtlProj()
        {

            smokeTestClass.initATLAS();

            // string WinProductionAtlProjPath = SystemActions.FindFilesByPartialName(CHProjects.CHWinProdProjectsFolder, AtlasVariables.winProduction, ".atlproj" + AtlasVariables.major, out bool isFound );

            //Atlproj import

            bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.WinProductionAtlProjPath, "AtlProj");
            Assert.IsTrue(atlprojImportState);

            smokeTestClass.GetAppActions().CloseProjectAsync();



        }
        [Test, Order(2), Category("otherversions")]
        public void ImportQDPX()
        {
            smokeTestClass.initATLAS();

            //QDPX Import
            bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.WinProductionQDPXPath, "QDPX");
            Assert.IsTrue(qdpxImportState);
            smokeTestClass.GetAppActions().CloseProjectAsync();

        }
    }
}
