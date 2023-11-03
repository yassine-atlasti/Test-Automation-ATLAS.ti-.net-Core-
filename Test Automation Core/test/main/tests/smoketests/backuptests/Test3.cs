using Test_Automation_Core.test.main.tests;

namespace Test_Automation_Core.test.main.tests
{
    public class Test3:InitTests
    {
        [Category("backuptests")]

        [Test, Order(3)]
        public async Task deleteProject()
        {

            await GetAppActions().CloseProjectAsync();


            //Delete VUT

            GetAppActions().DeleteProject("Geo Project");

            //It's actually not working after closing a project. Delete works actually only when project is closed=>Invesitagte

        }

    }
}
