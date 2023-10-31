using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests
{

    public class BDeleteCH
    {
        InitTests smokeTestClass = new InitTests();
        public async Task deleteCHProject()
        {
            smokeTestClass.initATLAS();

            await smokeTestClass.GetAppActions().CloseProjectAsync();


            //Delete VUT

            smokeTestClass.GetAppActions().DeleteProject(SmokeTestVariables.smokeTestproject);

            //It's actually not working after closing a project. Delete works actually only when project is closed=>Invesitagte

        }
    }
}
