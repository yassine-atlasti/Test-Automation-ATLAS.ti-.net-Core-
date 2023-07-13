using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.ATLAS.ti.UIActions;
using Test_Automation_Core.Data.SUT;
using Test_Automation_Core.Installer;
using Test_Automation_Core.OS.Windows;
using Test_Automation_Core.UIElements.WelcomeWindow;

namespace Test_Automation_Core.Tests.Smoke_Tests
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
            string downloadUrl = @"https://cdn.atlasti.com/win/" + AtlasVariables.major + "/Atlasti_" + AtlasVariables.winVUT + ".exe";

            await systemActions.DownloadFileAsync(downloadUrl, AtlasVariables.fileNameRC);

            _driver.Quit();
            


            //Install
            string windowName = "Setup - ATLAS.ti " + AtlasVariables.major;

            _driver = systemActions.ClassInitialize(AtlasVariables.installerPathRC);

         

            InstallerActions installer = new InstallerActions(_driver);
            installer.InstallATLASti(AtlasVariables.installerPathRC, AtlasVariables.major);
        }

    }
}
