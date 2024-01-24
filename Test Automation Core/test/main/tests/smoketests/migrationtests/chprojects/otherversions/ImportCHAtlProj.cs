using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.otherversions;

public class ImportCHAtlProj:BaseTestCase
{

    public static IEnumerable<TestCaseData> AtlProjTestData()
    {
        yield return new TestCaseData(CHProjects.MacPreviousAtlProjPath, AtlasVariables.previousExportType).SetName("MacPrevMajor"+ AtlasVariables.previousExportType);
        yield return new TestCaseData(CHProjects.MacProductionAtlProjPath, AtlasVariables.prodExportType).SetName("MacProduction"+ AtlasVariables.prodExportType);
        yield return new TestCaseData(CHProjects.WinPreviousAtlProjPath, AtlasVariables.previousExportType).SetName("WinPrevMajor"+ AtlasVariables.previousExportType);
        yield return new TestCaseData(CHProjects.WinProductionAtlProjPath, AtlasVariables.prodExportType).SetName("WinProduction"+ AtlasVariables.prodExportType);

        // You can add more cases or read them from an external source
    }

    [Test, Category("otherversions")]
    [TestCaseSource(nameof(AtlProjTestData))]
    public void ImportAtlProj(string filePath,string type)
    {



        //Atlproj import

        bool atlprojImportState = GetAppActions().ImportProject(filePath, AtlasVariables.prodExportType);
        
        Assert.IsTrue(atlprojImportState);

        




    }


}
