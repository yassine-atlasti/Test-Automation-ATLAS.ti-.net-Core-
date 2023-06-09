﻿using NUnit.Framework.Internal;
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
        

      

        //Actual and Previous CH Projects exported from Windows


        public static readonly string WinProductionAtlProj = AtlasVariables.winProduction + "-" + SmokeTestVariables.actualWinOS + "-" + SmokeTestVariables.smokeTestproject + ".atlproj" + AtlasVariables.major;
        public static readonly string WinProductionQDPX = AtlasVariables.winProduction + "-" + SmokeTestVariables.actualWinOS + "-" + SmokeTestVariables.smokeTestproject + ".QDPX";


        public static readonly string WinPreviousAtlProj = AtlasVariables.winPreviousMajor + "-" + SmokeTestVariables.previousWinOS + "-" + SmokeTestVariables.smokeTestproject + ".atlproj" + AtlasVariables.winPreviousMajor;
        public static readonly string WinPreviousQDPX = AtlasVariables.winPreviousMajor + "-" + SmokeTestVariables.previousWinOS + "-" + SmokeTestVariables.smokeTestproject + ".QDPX";



        //Actual and Previous CH Projects exported from Mac
        public static readonly string MacProductionAtlProj = AtlasVariables.macProduction + "-" + SmokeTestVariables.actualMacOS + "-" + SmokeTestVariables.smokeTestproject + ".atlproj" + AtlasVariables.major;
        public static readonly string MacProductionQDPX = AtlasVariables.macProduction + "-" + SmokeTestVariables.actualMacOS + "-" + SmokeTestVariables.smokeTestproject + ".QDPX";

        public static readonly string MacPreviousAtlProj = AtlasVariables.macPreviousMajor + "-" + SmokeTestVariables.previousMacOS + "-" + SmokeTestVariables.smokeTestproject + ".atlproj" + AtlasVariables.winPreviousMajor;
        public static readonly string MacPreviousQDPX = AtlasVariables.macPreviousMajor + "-" + SmokeTestVariables.previousMacOS + "-" + SmokeTestVariables.smokeTestproject + ".QDPX";
            

        
       
        //Get the projects path by using the getfilePath method in SystemActions


    }
}
