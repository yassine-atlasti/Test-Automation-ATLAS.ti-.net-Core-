using NUnit.Framework.Internal;
using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.tests.specialtests

{
    [TestFixture]
    public class ImportAllProjects : BaseTestCase
    {
      public const string projectsFilePath = "C:\\Test Data\\Projects";





 


        public static IEnumerable<TestCaseData> AtlProjTestData()
        {
            string[] projectsFileNames = SystemActions.GetFilenamesInDirectoryByType(projectsFilePath, "atlproj");

            foreach (var fileName in projectsFileNames)
            {
                yield return new TestCaseData(fileName, "AtlProj").SetName($"Project{fileName}");
            }


        }

        [Test, Category("specialtests")]
        [TestCaseSource(nameof(AtlProjTestData))]
        public void ImportAtlProj(string fileName, string type)
        {


            string filePath = projectsFilePath + "\\" + fileName;
            //Atlproj import

            bool atlprojImportState = GetAppActions().ImportProject(filePath, "AtlProj");

            Assert.IsTrue(atlprojImportState);






        }

    }
}
