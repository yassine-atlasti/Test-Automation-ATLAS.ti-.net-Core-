using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.SmokeTestData;
using Test_Automation_Core.Data.SUT;

namespace Test_Automation_Core.Data.OneDrive.Projects
{
    public static class CHProjects
    {

        //Path of the C&H All Versions folder in OneDrive

        public static readonly string CHProjectsFolder = OneDriveConfig.testingStuffPath + @"\Test Data\Projects\C&H all versions";
        
        public static readonly string CHWinVUTProjectsFolder = CHProjectsFolder +@"\Win\VUT";
        public static readonly string CHMacVUTProjectsFolder = CHProjectsFolder +@"\Mac\VUT";
      
        public static readonly string CHWinProdProjectsFolder = CHProjectsFolder + @"\Win\current Win Release";
        public static readonly string CHMacProdProjectsFolder = CHProjectsFolder + @"\Mac\current Mac Release";

        public static readonly string CHWinPrevMajorProjectsFolder = CHProjectsFolder + @"\Win\A"+AtlasVariables.minor + @"\" +AtlasVariables.winPreviousMajor;
        public static readonly string CHMacPrevMajorProjectsFolder = CHProjectsFolder + @"\Mac\A"+AtlasVariables.minor;
        public static readonly string CHMacPrevMajorQDPXProjectsFolder = CHProjectsFolder + @"\Mac\A" + AtlasVariables.minor+ @"\" + "REFI QDA";
        
        //Actual and Previous CH Projects exported from Windows


        public static readonly string WinProductionAtlProj = AtlasVariables.winProduction + "-" + SmokeTestVariables.actualWinOS + "-" + SmokeTestVariables.smokeTestproject + ".atlproj" + AtlasVariables.major;
        public static readonly string WinProductionQDPX = AtlasVariables.winProduction + "-" + SmokeTestVariables.actualWinOS + "-" + SmokeTestVariables.smokeTestproject + ".QDPX";

        public static readonly string WinPrevious = AtlasVariables.winPreviousMajor + "-" + SmokeTestVariables.previousWinOS + "-" + SmokeTestVariables.smokeTestproject;
        public static readonly string WinPreviousAtlProj = WinPrevious + ".atlproj" + AtlasVariables.minor;
        public static readonly string WinPreviousQDPX = WinPrevious + ".QDPX";
        public static readonly string WinPreviousFolderMedia = CHWinPrevMajorProjectsFolder + @"\" + AtlasVariables.winPreviousMajor + " Media";


        //Actual and Previous CH Projects exported from Mac
        public static readonly string MacProductionAtlProj = AtlasVariables.macProduction + "-" + SmokeTestVariables.actualMacOS + "-" + SmokeTestVariables.smokeTestproject + ".atlproj" + AtlasVariables.major;
        public static readonly string MacProductionQDPX = AtlasVariables.macProduction + "-" + SmokeTestVariables.actualMacOS + "-" + SmokeTestVariables.smokeTestproject + ".QDPX";

        public static readonly string MacPrevious = AtlasVariables.macPreviousMajor + " - " + SmokeTestVariables.previousMacOS + " - " + SmokeTestVariables.smokeTestproject;
        public static readonly string MacPreviousAtlProj = MacPrevious + ".atlproj"+ AtlasVariables.minor;
        public static readonly string MacPreviousQDPX =MacPrevious + ".QDPX";
        public static readonly string MacPreviousFolderMedia= CHMacPrevMajorQDPXProjectsFolder + @"\" + MacPrevious + " Media";


        //C&H Exported from actual VUT
        public static readonly string winVUTAtlProj = AtlasVariables.winVUT + "-" + SmokeTestVariables.actualOS + "-" + SmokeTestVariables.smokeTestproject + ".atlproj" + AtlasVariables.major;
        public static readonly string winVUTQDPX = AtlasVariables.winVUT + "-" + SmokeTestVariables.actualOS + "-" + SmokeTestVariables.smokeTestproject + ".QDPX";
        //Remove Spaces from file name


        //Get the projects path by using the getfilePath method in SystemActions


    }
}
