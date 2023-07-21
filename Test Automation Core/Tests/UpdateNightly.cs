using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.ATLAS.ti.UIActions;
using Test_Automation_Core.Installer;
using Test_Automation_Core.OS.Windows;
using Test_Automation_Core.UIElements.WelcomeWindow;
using Test_Automation_Core.Data.SUT;

namespace Test_Automation_Core.Tests
{
    [TestFixture]

    public class UpdateNightly
    {
        private static WindowsDriver<WindowsElement> _driver;
        App appControl;
        ApplicationActions appActions;
        WelcomeWindow welcomeWindow;
        string major = "23";

        SystemActions systemActions = new SystemActions();
        // [OneTimeSetUp]


        public void initATLAS()
        {
            string appPath = @"C:\Program Files\Scientific Software\ATLASti." + this.major + @"\Atlasti" + this.major + ".exe";

            _driver = systemActions.ClassInitialize(appPath);
            appControl = new App(_driver);
            appActions = new ApplicationActions(appControl);
            welcomeWindow = appControl.GetWelcomeControl();


        }


        [Test]
        public async Task Update()
        {

            _driver = systemActions.ClassInitialize("Root");


            //Uninstall ATLAS.ti

            systemActions = new SystemActions(_driver);

            // systemActions.MinimizeAllWindows(_driver);

            systemActions.UninstallApp(AtlasVariables.uninstallPath);

            //Download 
            string downloadUrl = @"https://cdn.atlasti.com/win/nightly/23-C4E24425-7597-4DB4-BEAC-4C2CFBBB7A7C/develop/Atlasti_Nightly_develop.exe";

            await systemActions.DownloadFileAsync(downloadUrl, AtlasVariables.fileNameNightly);

            _driver.Quit();



            //Install
            string windowName = "Setup - ATLAS.ti " + AtlasVariables.major;

            _driver = systemActions.ClassInitialize(AtlasVariables.installerPathNightly);



            InstallerActions installer = new InstallerActions(_driver);
            installer.InstallATLASti(AtlasVariables.installerPathNightly, AtlasVariables.major);
        }
    }
}
