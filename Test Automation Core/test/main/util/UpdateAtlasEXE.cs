using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.src.pages.installer;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.util
{
    [TestFixture]
    [Category("UpdateATLASEXE")]
    public class UpdateAtlasEXE
    {
        SystemActions systemActions = new SystemActions();
        private static WindowsDriver<WindowsElement> _driver;


        //default branch is dev
        public static string branch = "devEXE";



        private static string installerPath;
        private static string fileName;
        private static string downloadUrl;

        [SetUp]
        public void SetUp()
        {

            if (String.Equals("devEXE", branch, StringComparison.OrdinalIgnoreCase))
            {
                installerPath = AtlasVariables.installerPathNightlyEXE;
                fileName = AtlasVariables.fileNameNightlyEXE;
                downloadUrl = AtlasVariables.downloadUrlNightlyEXE;
            }
            else

            if (String.Equals("rcEXE", branch, StringComparison.OrdinalIgnoreCase))
            {
                installerPath = AtlasVariables.installerPathRCEXE;
                fileName = AtlasVariables.fileNameRCEXE;
                downloadUrl = AtlasVariables.downloadUrlRCEXE;
            }
            else
             if (String.Equals("releaseEXE", branch, StringComparison.OrdinalIgnoreCase))
            {
                installerPath = AtlasVariables.installerPathRCEXE;
                fileName = AtlasVariables.fileNameRCEXE;
                downloadUrl = AtlasVariables.downloadURLReleaseEXE;

            }


        }

        [Test, Order(1)]
        public async Task DownloadAtlas()
        {

            //Download 

            await systemActions.DownloadFileAsync(downloadUrl, fileName);
        }

        //Actually only works if there's an msi installer from same branch in downloads folder
        [Test, Order(2)]
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
        public void InstallATLASEXE()

        {
           _driver= systemActions.ClassInitialize(installerPath);
            InstallerActions installerActions = new InstallerActions(_driver);

            installerActions.InstallATLASti();
        }

    }
}
