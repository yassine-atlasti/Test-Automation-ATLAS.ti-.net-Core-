using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.SmokeTestData;

namespace Test_Automation_Core.Tests.Smoke_Tests.BackUpTests
{
    public class Test3
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();

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
