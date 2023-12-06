using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.otherversions;

public class ImportMacProd:InitTests
{
    
    [Test, Order(1), Category("otherversions")]
    public void ImportAtlProj()

    {


        //Atlproj import

        bool atlprojImportState = GetAppActions().ImportProject(CHProjects.MacProductionAtlProjPath, "AtlProj");
        Assert.IsTrue(atlprojImportState);



    }
   [Test, Order(2), Category("otherversions")]
    public void ImportQDPX()
    {


        //QDPX Import
        bool qdpxImportState = GetAppActions().ImportProject(CHProjects.MacProductionQDPXPath, "QDPX");
        Assert.IsTrue(qdpxImportState);

    }
}
