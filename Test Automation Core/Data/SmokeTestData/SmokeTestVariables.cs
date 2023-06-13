using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.SUT;

namespace Test_Automation_Core.Data.SmokeTestData
{
    public  class SmokeTestVariables
    {
        //OS Versions Used for Smoke Tests
        public static readonly string actualWinOS = "Windows 11";
        public static readonly string previousWinOS = "Windows 10";

        public static readonly string actualMacOS = "Mac 13.1";
        public static readonly string previousMacOS = "";

        //Smoke Test Folder Path 

        public static readonly string  smokeTestFolder = "SmokeTest_" + AtlasVariables.winVUT;
      public static readonly string smokeTestFolderPath = "C:\\Users\\yassinemahfoudh\\Desktop\\" + smokeTestFolder;


        //Libraries  Names used for Smoke Tests
        public static readonly string library1="emptyWinA22library";
        public static readonly string library2 = "Atlasti8";
        public static readonly string library3 = "Win-SmokeTestLibraryContainingC&H+hierarchy";


        //File Paths of the extracted Smoke test libraries
        public static readonly string library1Extracted =smokeTestFolderPath + @"\"+ library1;
        public static readonly string library2Extracted =smokeTestFolderPath + @"\" + library2;
        public static readonly string library3Extracted = smokeTestFolderPath + @"\" + library3;


        //´Project Name

        public static readonly string smokeTestproject = "C&H II + hierarchy";

        //Back Up Name


    }
}
