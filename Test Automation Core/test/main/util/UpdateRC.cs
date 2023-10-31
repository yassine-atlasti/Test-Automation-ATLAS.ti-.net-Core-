using OpenQA.Selenium.Appium.Windows;
using Test_Automation_Core.src.pages.installer;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.util
{
    public class UpdateRC
    {
        //General
        private static WindowsDriver<WindowsElement> _driver;
        SystemActions systemActions = new SystemActions();




        [Test]

        public async Task UpdateRCs()
        {


            _driver = systemActions.ClassInitialize("Root");


            //Uninstall ATLAS.ti

            systemActions = new SystemActions(_driver);

            // systemActions.MinimizeAllWindows(_driver);

            systemActions.UninstallApp(AtlasVariables.uninstallPath);

            //Download 
            string downloadUrl = @"https://cdn.atlasti.com/win/" + AtlasVariables.actualMajor + "/Atlasti_" + AtlasVariables.winVUT + ".exe";

            await systemActions.DownloadFileAsync(downloadUrl, AtlasVariables.fileNameRC);

            _driver.Quit();



            //Install
            string windowName = "Setup - ATLAS.ti " + AtlasVariables.actualMajor;

            _driver = systemActions.ClassInitialize(AtlasVariables.installerPathRC);



            InstallerActions installer = new InstallerActions(_driver);
            installer.InstallATLASti(AtlasVariables.installerPathRC, AtlasVariables.actualMajor);
        }

    }
}
