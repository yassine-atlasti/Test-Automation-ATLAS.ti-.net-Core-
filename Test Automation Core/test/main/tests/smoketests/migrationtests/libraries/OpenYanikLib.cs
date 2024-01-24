using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.libraries;

public class OpenYanikLib:BaseTestCase
{
    

    [Test,Order(1) ,Category("OpenYanikLib")]

    public void openLibraryYanik()
    {

        //Open ATLAS.ti with empty A22 Library
      bool switchLib=  GetAppActions().SwitchLibrary(SmokeTestVariables.library2Extracted);


        SetupATLAS();

        Assert.IsTrue(switchLib);
    }
    [Test, Order(2), Category("OpenYanikLib")]

    public void HasAtlasCrashed()
    {




        bool crashState = GetWelcomeWindow().HasAtlasCrashed(TimeSpan.FromSeconds(60));

        Assert.IsFalse(crashState);



    }



}
