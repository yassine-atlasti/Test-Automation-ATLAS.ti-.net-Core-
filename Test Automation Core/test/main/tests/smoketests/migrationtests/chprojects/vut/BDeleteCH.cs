using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;

namespace Test_Automation_Core.test.main.tests.smoketests.migrationtests.chprojects.vut
{

    public class BDeleteCH:BaseTestCase
    {
        [Test, Category("vut")]
        public async Task deleteCHProject()
        {



            //Delete VUT

         bool isDeleted=  GetAppActions().DeleteProject(SmokeTestVariables.smokeTestproject);

            Assert.IsTrue(isDeleted);

 
        }
    }
}
