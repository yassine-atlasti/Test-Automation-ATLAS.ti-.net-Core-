using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.SmokeTestData;

namespace Test_Automation_Core.Tests.Smoke_Tests
{

    public class B_DeleteCH
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();
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
