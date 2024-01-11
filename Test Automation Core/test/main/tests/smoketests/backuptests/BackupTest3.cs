using Test_Automation_Core.test.main.tests;

namespace Test_Automation_Core.test.main.tests.smoketests.backuptests;

public class BackupTest3:BaseTest
{
    [Category("backuptests")]

    [Test]
    public void deleteProject()
    {



        //Delete VUT

        GetAppActions().DeleteProject("Geo Project");

        //It's actually not working after closing a project. Delete works actually only when project is closed=>Invesitagte

    }

}
