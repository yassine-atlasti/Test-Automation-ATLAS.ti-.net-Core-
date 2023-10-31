using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests;

public class ImportMacProd
{
    InitTests smokeTestClass = new InitTests();
    [Test, Order(1), Category("otherversions")]
    public void ImportAtlProj()

    {

        smokeTestClass.initATLAS();

        //Atlproj import

        bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.MacProductionAtlProjPath, "AtlProj");
        Assert.IsTrue(atlprojImportState);

        smokeTestClass.GetAppActions().CloseProjectAsync();


    }
    [Test, Order(2), Category("otherversions")]
    public void ImportQDPX()
    {
        smokeTestClass.initATLAS();


        //QDPX Import
        bool qdpxImportState = smokeTestClass.GetAppActions().ImportProject(CHProjects.MacProductionQDPXPath, "QDPX");
        Assert.IsTrue(qdpxImportState);
        smokeTestClass.GetAppActions().CloseProjectAsync();

    }
}
