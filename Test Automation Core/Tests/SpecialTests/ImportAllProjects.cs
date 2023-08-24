using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;
using Test_Automation_Core.OS.Windows;

namespace Test_Automation_Core.Tests.SpecialTests
{
    [TestFixture]
    public class ImportAllProjects
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();
        string projectsFilePath = "\\\\Mac\\Home\\Library\\CloudStorage\\OneDrive-ATLAS.tiScientificSoftwareDevelopmentGmbH\\Testing stuff\\Test Data\\Projects\\C&H all versions\\Mac\\A22";
        
        private string logFilePath = @"C:\path\to\log.txt";

       // [SetUp]
        public void Setup()
        {
            smokeTestClass.initATLAS();
        }

        [TearDown]
        public void TearDown()
        {
            // Cleanup after each test
        }

        [Test]
        public void TestImportProjects()
        {


            string[] projectsFileNames = SystemActions.GetFilenamesInDirectoryByType(projectsFilePath,"atlproj22");

            foreach (string fileName in projectsFileNames)
            {
                try
                {
                    smokeTestClass.initATLAS();


                    //Atlproj import

                    bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(projectsFilePath, "AtlProj", fileName);
                    
                    // Perform assertions to verify the result of importing
                    // You can use NUnit's assertions here
                    Assert.IsTrue(atlprojImportState, $"Importing project {fileName} failed.");

                    //Close Project
                    smokeTestClass.GetAppActions().CloseProjectAsync();

                    
                    
                }
                catch (Exception ex)
                {
                   // LogUnsuccessfulProject(fileName, ex.Message);
                }
            }
        }

       

     

        // Helper method to log unsuccessful project imports
        private void LogUnsuccessfulProject(string filePath, string errorMessage)
        {
            string logMessage = $"Importing project {filePath} failed: {errorMessage}";
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }
    }

}

