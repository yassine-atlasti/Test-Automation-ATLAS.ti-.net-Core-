using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.resources.test_data.releasetestdata
{
    public class ReleaseTestVariables
    {
        //OS Versions Used for Smoke Tests
        public static string actualWinOS { get => SystemUtil.GetOperatingSystemVersion(); }



        //Release Test Folder Path 

        public static readonly string releaseTestFolder = "ReleaseTest_" + AtlasVariables.InstalledVersion;
        public static readonly string releaseTestFolderPath = SystemUtil.GetDesktopPath() + "\\" + releaseTestFolder;


        //Libraries  Names used for Release Tests
        public static readonly string library1 = "Win 22.2.4 (fixed)";
       


        //File Paths of the extracted Release test libraries
        public static readonly string library1Extracted = releaseTestFolderPath + @"\" + library1;
    }
}
