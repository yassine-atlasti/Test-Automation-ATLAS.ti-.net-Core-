using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.libraries;

public class OpenLibCH : InitTests
{

    [Test, Category("OpenLibCH")]

    public void openLibraryCH()
    {


        //Open ATLAS.ti with empty A22 Library
        GetAppActions().SwitchLibrary(SmokeTestVariables.library3Extracted);

        //We need to change the driver because the application will restart after library switch
        initATLAS(); ;

        bool crashState = GetWelcomeWindow().HasAtlasCrashed(TimeSpan.FromSeconds(60));

        Assert.IsFalse(crashState);



    }



}
