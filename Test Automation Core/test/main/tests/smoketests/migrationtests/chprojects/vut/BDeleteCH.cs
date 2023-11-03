using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests
{

    public class BDeleteCH:InitTests
    {
        public async Task deleteCHProject()
        {

            await GetAppActions().CloseProjectAsync();


            //Delete VUT

          GetAppActions().DeleteProject(SmokeTestVariables.smokeTestproject);

            //It's actually not working after closing a project. Delete works actually only when project is closed=>Invesitagte

        }
    }
}
