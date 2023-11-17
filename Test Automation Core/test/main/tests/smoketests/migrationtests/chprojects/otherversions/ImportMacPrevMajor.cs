using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests
{
    public class ImportMacPrevMajor:InitTests
    {
        [Test, Order(1), Category("otherversions")]
        public void ImportAtlProj()
        {



            //Atlproj import

            bool atlprojImportState = GetAppActions().ImportProject(CHProjects.MacPreviousAtlProjPath, "AtlProj");
            
            Assert.IsTrue(atlprojImportState);

            




        }
        [Test, Order(2), Category("otherversions")]
        public void ImportQDPX()
        {

            //QDPX Import
            bool qdpxImportState = GetAppActions().ImportProject(CHProjects.MacPreviousQDPXPath, "QDPX", CHProjects.MacPreviousFolderMedia);
            Assert.IsTrue(qdpxImportState);


        }
    }
}
