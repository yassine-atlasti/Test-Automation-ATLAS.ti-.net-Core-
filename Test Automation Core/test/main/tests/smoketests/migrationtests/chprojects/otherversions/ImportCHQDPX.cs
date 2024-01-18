using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.otherversions;

public class ImportCHQDPX:BaseTestCase
{


    public static IEnumerable<TestCaseData> QDPXTestData()
    {
        yield return new TestCaseData(CHProjects.MacPreviousQDPXPath, "QDPX", CHProjects.MacPreviousFolderMedia).SetName("MacPrevMajorQDPX");
        yield return new TestCaseData(CHProjects.MacProductionQDPXPath, "QDPX", "").SetName("MacProductionQDPX");
        yield return new TestCaseData(CHProjects.WinPreviousQDPXPath, "QDPX", CHProjects.WinPreviousFolderMedia).SetName("WinPrevMajorQDPX");
        yield return new TestCaseData(CHProjects.WinProductionQDPXPath, "QDPX", "").SetName("WinProductionQDPX");

        // You can add more cases or read them from an external source
    }


    [Test, Category("otherversions")]
    [TestCaseSource(nameof(QDPXTestData))]

    public void ImportQDPX(string filePath, string type, string mediaFolder)
    {

        //QDPX Import
        bool qdpxImportState = GetAppActions().ImportProject(filePath, type, mediaFolder);
        Assert.IsTrue(qdpxImportState);


    }
}
