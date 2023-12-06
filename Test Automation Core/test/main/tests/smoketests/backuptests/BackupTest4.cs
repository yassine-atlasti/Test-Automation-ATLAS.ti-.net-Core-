﻿using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Appium.Windows;
using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;
namespace Test_Automation_Core.test.main.tests.smoketests
{
    //this class should not extend the Init class. We don't want to run the setup method in this Test Case

    internal class BackupTest4
    {
        InitTests SmokeTestClass = new InitTests();
        [Category("backuptests")]

        [Test,Order(1)]
        public void RestoreBackUp()
        {

           // SystemActions.KillProcessByName("Atlasti" + AtlasVariables.actualMajor);
            string backUp = AtlasVariables.InstalledVersion + "_BackUp";
            SmokeTestClass.initBackUpApp();
            bool restoreState = SmokeTestClass.GetBackUpActions().RestoreLibrary(SmokeTestVariables.smokeTestFolderPath, backUp);
            Assert.IsTrue(restoreState);


           
        }

        [Category("backuptests")]

        [Test,Order(2)]
        public void OpenRestoredProject()
        {
            SmokeTestClass.initATLAS();
            bool projectRestored = SmokeTestClass.GetAppActions().OpenProject("Geo Project");
            Assert.IsTrue(projectRestored);
        }



        [TearDown]
        public void cleanUp()
        {

            SmokeTestClass.cleanUp();

        }
    }
}
