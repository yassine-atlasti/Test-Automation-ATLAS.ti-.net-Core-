using Test_Automation_Core.test.main.tests;

namespace Test_Automation_Core.test.main.tests
{
    public class Test3
    {
        InitTests smokeTestClass = new InitTests();
        [Category("backuptests")]

        [Test, Order(3)]
        public async Task deleteProject()
        {
            smokeTestClass.initATLAS();

            await smokeTestClass.GetAppActions().CloseProjectAsync();


            //Delete VUT

            smokeTestClass.GetAppActions().DeleteProject("Geo Project");

            //It's actually not working after closing a project. Delete works actually only when project is closed=>Invesitagte

        }

    }
}
