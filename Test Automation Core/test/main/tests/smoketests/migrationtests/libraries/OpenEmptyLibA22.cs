using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.EventHandlers;
using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.libraries;

public class OpenEmptyLibA22:BaseTestCase
{
    

    

    [Test,Order(1), Category("OpenEmptyLibA22")]
    public void OpenEmptyLib()
    {
        //Open ATLAS.ti with empty A22 Library
       bool switchLib= GetAppActions().SwitchLibrary(SmokeTestVariables.library1Extracted);

        SetupATLAS();

        Assert.IsTrue(switchLib);

    }

    [Test, Order(2), Category("OpenEmptyLibA22")]

    public void HasAtlasCrashed()
    {




        bool crashState = GetWelcomeWindow().HasAtlasCrashed(TimeSpan.FromSeconds(60));

        Assert.IsFalse(crashState);



    }


}
