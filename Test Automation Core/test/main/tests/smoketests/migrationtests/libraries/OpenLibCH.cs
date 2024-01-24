using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.libraries;

public class OpenLibCH : BaseTestCase
{

    [Test,Order(1), Category("OpenLibCH")]

    public void openLibraryCH()
    {


        //Open ATLAS.ti with empty A22 Library
       bool libSwitch=  GetAppActions().SwitchLibrary(SmokeTestVariables.library3Extracted);
        SetupATLAS();
        Assert.IsTrue(libSwitch);
        



    }
    [Test, Order(2), Category("OpenLibCH")]

    public void HasAtlasCrashed()
    {

      

        bool crashState = GetWelcomeWindow().HasAtlasCrashed(TimeSpan.FromSeconds(60));

        Assert.IsFalse(crashState);



    }



}
