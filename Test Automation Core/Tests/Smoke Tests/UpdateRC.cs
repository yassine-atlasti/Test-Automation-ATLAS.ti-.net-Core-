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



            systemActions.UninstallApp(AtlasVariables.uninstallPath);
            //Download 
            string downloadUrl = @"https://cdn.atlasti.com/win/" + AtlasVariables.major + "/Atlasti_" + AtlasVariables.winVUT + ".exe";
            string downloadPath = @"C:\Users\yassinemahfoudh\Downloads";
            string fileName = "Atlasti_" + AtlasVariables.winVUT + ".exe";
            systemActions.MinimizeAllWindows(_driver);

            await systemActions.DownloadFileAsync(downloadUrl, fileName);

            _driver.Quit();


            //Install
            string installerPath = downloadPath + "\\" + fileName;
            string windowName = "Setup - ATLAS.ti " + AtlasVariables.major;

            _driver = systemActions.ClassInitialize(installerPath);

            InstallerActions installer = new InstallerActions(_driver);
            installer.InstallATLASti(installerPath, AtlasVariables.major);
        }

    }
}
