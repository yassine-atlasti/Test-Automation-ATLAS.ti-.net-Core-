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
    [Category("UpdateATLASMSI")]
    public class UpdateAtlasMSI
    {


        SystemActions systemActions = new SystemActions();


        //default branch is dev
        public static string branch = "devMSI";



        private static string installerPath;
        private static string fileName;
        private static string downloadUrl;

        [SetUp]
        public void SetUp()
        {

            if (String.Equals("devMSI", branch, StringComparison.OrdinalIgnoreCase))
            {
                installerPath = AtlasVariables.installerPathNightlyMSI;
                fileName = AtlasVariables.fileNameNightlyMSI;
                downloadUrl = AtlasVariables.downloadUrlNightlyMSI;
            }
            else

            if (String.Equals("rcMSI", branch, StringComparison.OrdinalIgnoreCase))
            {
                installerPath = AtlasVariables.installerPathRCMSI;
                fileName = AtlasVariables.fileNameRCMSI;
                downloadUrl = AtlasVariables.downloadUrlRCMSI;
            }
            else
             if (String.Equals("releaseMSI", branch, StringComparison.OrdinalIgnoreCase))
            {
                installerPath = AtlasVariables.installerPathRCMSI;
                fileName = AtlasVariables.fileNameRCMSI;
                downloadUrl = AtlasVariables.downloadURLReleaseMSI;

            }
             

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
            if (String.Equals("devEXE", branch, StringComparison.OrdinalIgnoreCase))
            {
                SystemActions.UninstallAtlas(AtlasVariables.installerPathNightlyMSI);
            }

            else

                      if (String.Equals("rcEXE", branch, StringComparison.OrdinalIgnoreCase))
            {
                SystemActions.UninstallAtlas(AtlasVariables.installerPathRCMSI);

            }
            else
                       if (String.Equals("releaseEXE", branch, StringComparison.OrdinalIgnoreCase))
            {
                SystemActions.UninstallAtlas(AtlasVariables.installerPathRCMSI);


            }
        }




        [Test, Order(3)]
        public void InstallATLAS()
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



    }
}
