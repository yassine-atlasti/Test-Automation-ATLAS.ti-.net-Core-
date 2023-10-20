using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.OneDrive.Projects;
using Test_Automation_Core.Data.SUT;
using Test_Automation_Core.OS.Windows;

namespace Test_Automation_Core.Tests.SpecialTests
{
    [TestFixture]
    public class ImportAllProjects
    {
        string projectsFilePath = "C:\\Test Data\\Projects";

        SmokeTestClass smokeTestClass = new SmokeTestClass();
        
        private string logFolderPath;
  
        private string logFilePath ;

      

       
        [Test]
        public void TestImportAtlProjects()
        {
            //Setup the project folder and it's subfolders, this needs to be moved into another method
           
            string[] projectsFileNames = SystemActions.GetFilenamesInDirectoryByType(projectsFilePath, "atlproj");
            string successfulFolder = Path.Combine(projectsFilePath, "Successful");
            string failedFolder = Path.Combine(projectsFilePath, "Failed");
            logFolderPath = Path.Combine(projectsFilePath, "LogFolder");
            logFilePath = Path.Combine(logFolderPath, $"Log_starttime_{DateTime.Now:yyyyMMddHHmmss}.txt");


            // Create the "Successful" subfolder if it doesn't exist
            if (!Directory.Exists(successfulFolder))
            {
                Directory.CreateDirectory(successfulFolder);
            }

            // Create the "Failed" subfolder if it doesn't exist
            if (!Directory.Exists(failedFolder))
            {
                Directory.CreateDirectory(failedFolder);
            }

            //Create a logFolder if it doesn't exist
            if (!Directory.Exists(logFolderPath))
            {
                Directory.CreateDirectory(logFolderPath);
            }
         
            //Create a logFile if it doesn't exist

            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath);
            }


            foreach (string fileName in projectsFileNames)
            {
               
                    smokeTestClass.initATLAS();

                    // Atlproj import
                    bool atlprojImportState = smokeTestClass.GetAppActions().ImportProject(projectsFilePath+"\\"+fileName, "AtlProj");
               
                var timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");

                if (atlprojImportState)
                    {
                        // Move successful imports to the "Successful" subfolder
                        string sourcePath = Path.Combine(projectsFilePath, fileName);
                    string destinationPath = Path.Combine(successfulFolder, fileName);
                    System.IO.File.Move(sourcePath, destinationPath);

                        smokeTestClass.GetAppActions().CloseProjectAsync();
                    }  
                
                  if(atlprojImportState==false)  {
                    

                    SystemActions.TakeScreenshot(smokeTestClass.GetDriver(), logFolderPath, $"screenshot_{timeStamp}.png");

                    //Kill ATLAS to avoid System.IO.IOException while moving project to failed folder
                    SystemActions.KillProcessByName("Atlasti" + AtlasVariables.actualMajor);

                    Thread.Sleep(3000);



                    // Move failed imports to the "Failed" subfolder
                    string sourcePath = Path.Combine(projectsFilePath, fileName);
                    string destinationPath = Path.Combine(failedFolder, fileName);
                    System.IO.File.Move(sourcePath, destinationPath);
                      
                        
                        

                        LogUnsuccessfulProject(fileName, "Importing project failed." );


                    //re-start ATLAS.ti
                    smokeTestClass.initATLAS();



                }

                // Perform assertions to verify the result of importing
                // You can use NUnit's assertions here
                Assert.IsTrue(atlprojImportState, $"Importing project {fileName} failed. ");
                
                
            }
        }





        // Helper method to log unsuccessful project imports
        private void LogUnsuccessfulProject(string fileName, string errorMessage)
        {
           // string logFilePath = Path.Combine(logFolderPath, $"Log_{DateTime.Now:yyyyMMddHHmmss}.txt");
           
            // Write the error message to the log file
            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine($"Project: {fileName}");
                writer.WriteLine($"Error: {errorMessage}");
            }
        }
    }

}

