using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Appium.Windows;
using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;
namespace Test_Automation_Core.test.main.tests.smoketests.backuptests;


//this class should not extend the Init class. We don't want to run the setup method in this Test Case
    public class BackupTest2
    {

        BaseTest SmokeTestClass = new BaseTest();
        [Category("backuptests")]

        [Test]

        public void CreateBackUp()
        {

            SmokeTestClass.SetupBackupApp();
            string backUp = AtlasVariables.InstalledVersion + "_BackUp";

            if (SmokeTestClass.GetBackUpActions().CheckWarning())
            {
                Thread.Sleep(2000);

            }
            Thread.Sleep(2000);


            bool backUpState = SmokeTestClass.GetBackUpActions().CreateBackUp(SmokeTestVariables.smokeTestFolderPath, backUp);
            Assert.IsTrue(backUpState);





    }


    [TearDown]
    public void cleanUp()
    {
        SmokeTestClass.cleanUp();

    }


}

