using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.otherversions;

public class ImportCHAtlProj:BaseTestCase
{

    public static IEnumerable<TestCaseData> AtlProjTestData()
    {
        yield return new TestCaseData(CHProjects.MacPreviousAtlProjPath, "AtlProj").SetName("MacPrevMajorAtlProj");
        yield return new TestCaseData(CHProjects.MacProductionAtlProjPath, "AtlProj").SetName("MacProductionAtlProj");
        yield return new TestCaseData(CHProjects.WinPreviousAtlProjPath, "AtlProj").SetName("WinPrevMajorAtlProj");
        yield return new TestCaseData(CHProjects.WinProductionAtlProjPath, "AtlProj").SetName("WinProductionAtlProj");

        // You can add more cases or read them from an external source
    }

    [Test, Category("otherversions")]
    [TestCaseSource(nameof(AtlProjTestData))]
    public void ImportAtlProj(string filePath,string type)
    {



        //Atlproj import

        bool atlprojImportState = GetAppActions().ImportProject(filePath, "AtlProj");
        
        Assert.IsTrue(atlprojImportState);

        




    }


}
