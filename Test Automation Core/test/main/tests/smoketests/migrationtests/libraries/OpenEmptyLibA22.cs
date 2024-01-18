using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.EventHandlers;
using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.libraries;

public class OpenEmptyLibA22:BaseTestCase
{
    

    

    [Test, Category("OpenEmptyLibA22")]
    public void OpenEmptyLib()
    {
        //Open ATLAS.ti with empty A22 Library
        GetAppActions().SwitchLibrary(SmokeTestVariables.library1Extracted);

        //We need to change the driver because the application will restart after library switch
        SetupATLAS();

        bool crashState = GetWelcomeWindow().HasAtlasCrashed(TimeSpan.FromSeconds(60));
        Assert.IsFalse(crashState);

    }

}
