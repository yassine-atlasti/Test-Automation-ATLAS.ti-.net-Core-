using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;
using Test_Automation_Core.src;
using Test_Automation_Core.src.pages.atlasti.actions;
using Test_Automation_Core.src.pages.atlasti.ui.windows;
using Test_Automation_Core.src.pages.installer;
using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.util
{
    [TestFixture]
    [Category("UpdateATLAS")]
    public class UpdateAtlas
    {


      public static SystemUtil systemActions = new SystemUtil();


        // Default branch is "devMSI", value can be  changed from the test suites
        public static string branch = "devMSI";
        // Default installer is "MSI"
        public static string installerType = "msi";
        private static string installerPath;
        private static string fileName;
        private static string downloadUrl;

        private static readonly Dictionary<string, (string installerPath, string fileName, string downloadUrl, string installerType)> BranchMappings =
            new Dictionary<string, (string, string, string, string)>
            {
        {"devMSI", (AtlasVariables.installerPathNightlyMSI, AtlasVariables.fileNameNightlyMSI, AtlasVariables.downloadUrlNightlyMSI, "msi")},
        {"rcMSI", (AtlasVariables.installerPathRCMSI, AtlasVariables.fileNameRCMSI, AtlasVariables.downloadUrlRCMSI, "msi")},
        {"releaseMSI", (AtlasVariables.installerPathRCMSI, AtlasVariables.fileNameRCMSI, AtlasVariables.downloadURLReleaseMSI, "msi")},
        {"devEXE", (AtlasVariables.installerPathNightlyEXE, AtlasVariables.fileNameNightlyEXE, AtlasVariables.downloadUrlNightlyEXE, "exe")},
        {"rcEXE", (AtlasVariables.installerPathRCEXE, AtlasVariables.fileNameRCEXE, AtlasVariables.downloadUrlRCEXE, "exe")},
        {"releaseEXE", (AtlasVariables.installerPathRCEXE, AtlasVariables.fileNameRCEXE, AtlasVariables.downloadURLReleaseEXE, "exe")}
            };

        [SetUp]
        public void SetUp()
        {
            if (BranchMappings.TryGetValue(branch, out var mapping))
            {
                (installerPath, fileName, downloadUrl, installerType) = mapping;
            }
            // Handle default case or raise an error if needed
        }

        [Test,Order(1)]
        public async Task DownloadAtlas()
        {

            //Download 

            await systemActions.DownloadFileAsync(downloadUrl, fileName);
        }

        [Test, Order(2),Category("UninstallMSI")]
        public static void UninstallATLAS()
        { 
                 systemActions.UninstallAtlasManually(AtlasVariables.uninstallPath);
           
        }




        [Test, Order(3)]
        public void InstallATLAS()
        {
            if (installerType == "msi")
            {
                string installDir = AtlasVariables.installationPath;

                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = "msiexec";
                processStartInfo.Arguments = $"/qb /i \"{installerPath}\" INSTALLDIR=\"{installDir}\"";
                processStartInfo.UseShellExecute = false;

                try
                {
                    Process process = Process.Start(processStartInfo);
                    process.WaitForExit(); // Wait for the installation process to complete
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            else
                if (installerType == "exe")
            {
                 InstallerActions installerActions = new InstallerActions(systemActions.ClassInitialize(installerPath));

                installerActions.InstallATLASti();
            }
             
              
            


        }



    }
}
