using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.resources.test_data.releasetestdata;

namespace Test_Automation_Core.test.resources.test_data.onedrive.libraries
{
    public class ReleaseTestLibraries
    {
        //Path of the Smoke Test Libraries folder in OneDrive
        public static readonly string releaseTestLibraries = OneDriveConfig.testingStuffPath + @"\Test Data\Release Tests data\Win\";

        public static readonly string library1 = releaseTestLibraries + ReleaseTestVariables.library1 + ".zip";
    }
}
