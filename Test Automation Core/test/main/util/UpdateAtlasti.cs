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
    public class UpdateAtlasti
    {


        SystemActions systemActions = new SystemActions();


        //default branch is dev
        public static string branch = "dev";



        private string installerPath;
        private string fileName;
        private string downloadUrl;

        [OneTimeSetUp]
        public void SetUp()
        {

            if (String.Equals("dev", branch, StringComparison.OrdinalIgnoreCase))
            {
                installerPath = AtlasVariables.installerPathNightly;
                fileName = AtlasVariables.fileNameNightly;
                downloadUrl = AtlasVariables.downloadUrlNightly;
            }
            else

            if (String.Equals("rc", branch, StringComparison.OrdinalIgnoreCase))
            {
                installerPath = AtlasVariables.installerPathRC;
                fileName = AtlasVariables.fileNameRC;
                downloadUrl = AtlasVariables.downloadUrlRC;
            }
        }

        [Test,Order(1)]
        public async Task DownloadAtlas()
        {

            //Download 

            await systemActions.DownloadFileAsync(downloadUrl, fileName);
        }

        [Test, Order(2)]
        public void UninstallATLAS()
        {

            WindowsDriver<WindowsElement> _driver = systemActions.ClassInitialize("Root");

            systemActions = new SystemActions(_driver);
            systemActions.UninstallAtlas();
            
            SystemActions.KillProcessByName("WinAppDriver");

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
