﻿using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.Data.SmokeTestData;
using Test_Automation_Core.Data.SUT;
using Test_Automation_Core.OS.Windows;

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

        public static readonly string CHWinPrevMajorProjectsFolder = CHProjectsFolder + @"\Win\A"+AtlasVariables.previousMajor + @"\" +AtlasVariables.winPreviousMajor;
        public static readonly string CHMacPrevMajorProjectsFolder = CHProjectsFolder + @"\Mac\A"+AtlasVariables.previousMajor;
        public static readonly string CHMacPrevMajorQDPXProjectsFolder = CHProjectsFolder + @"\Mac\A" + AtlasVariables.previousMajor + @"\" + "REFI QDA";

        //Actual CH Projects exported from Windows

        public static readonly string WinProductionAtlProjPath = SystemActions.FindFilesByPartialName(CHWinProdProjectsFolder, AtlasVariables.winProduction, ".atlproj" + AtlasVariables.actualMajor, out bool isFound);
        public static readonly string WinProductionQDPXPath = SystemActions.FindFilesByPartialName(CHWinProdProjectsFolder, AtlasVariables.winProduction, ".qdpx" , out bool isFound);

        //Previous Major CH Projects exported from Windows
        public static readonly string WinPreviousAtlProjPath = SystemActions.FindFilesByPartialName(CHWinPrevMajorProjectsFolder, AtlasVariables.winPreviousMajor, ".atlproj" + AtlasVariables.previousMajor, out bool isFound);
        public static readonly string WinPreviousQDPXPath = SystemActions.FindFilesByPartialName(CHWinPrevMajorProjectsFolder, AtlasVariables.winPreviousMajor, ".qdpx" , out bool isFound);
        public static readonly string WinPreviousFolderMedia = CHWinPrevMajorProjectsFolder + @"\" + Path.GetFileNameWithoutExtension(WinPreviousQDPXPath)+ " Media";


        //Actual CH Projects exported from Mac
        public static readonly string MacProductionAtlProjPath = SystemActions.FindFilesByPartialName(CHMacProdProjectsFolder, AtlasVariables.macProduction, ".atlproj" + AtlasVariables.actualMajor, out bool isFound);
        public static readonly string MacProductionQDPXPath = SystemActions.FindFilesByPartialName(CHMacProdProjectsFolder, AtlasVariables.macProduction, ".qdpx" , out bool isFound);


        //Previous CH Projects exported from Mac
        public static readonly string MacPreviousAtlProjPath = SystemActions.FindFilesByPartialName(CHMacPrevMajorProjectsFolder, AtlasVariables.macPreviousMajor, ".atlproj" + AtlasVariables.previousMajor, out bool isFound);
        public static readonly string MacPreviousQDPXPath = SystemActions.FindFilesByPartialName(CHMacPrevMajorProjectsFolder, AtlasVariables.macPreviousMajor, ".qdpx" , out bool isFound); 
        public static readonly string MacPreviousFolderMedia= CHMacPrevMajorQDPXProjectsFolder + @"\" + Path.GetFileNameWithoutExtension(MacPreviousQDPXPath) + " Media";


        //C&H Exported from actual VUT
        public static readonly string winVUTAtlProjPath = SystemActions.FindFilesByPartialName(CHWinVUTProjectsFolder, AtlasVariables.winVUT, ".atlproj" + AtlasVariables.actualMajor, out bool isFound);
        public static readonly string winVUTQDPXPath = SystemActions.FindFilesByPartialName(CHWinVUTProjectsFolder, AtlasVariables.winVUT, ".qdpx", out bool isFound);



    }
}
