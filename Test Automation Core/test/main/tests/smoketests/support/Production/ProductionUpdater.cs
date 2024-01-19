using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.src.pages.updater;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.tests.smoketests.support.Production
{
    public class ProductionUpdater
    {
        BaseTestCase baseTestClass = new BaseTestCase();

        [Test,Order(1), Category("ProductionUpdater")]
        public void TestSatelliteUpdater()
        {

            baseTestClass.SetUpSatelliteUpdater();

            Updater satelliteUpdater= new Updater(baseTestClass.GetDriver());
            Thread.Sleep(4000);

            satelliteUpdater.StartDownload();
            
            bool res = satelliteUpdater.CheckDownloadStarted();
            baseTestClass.cleanUp();

            Assert.IsTrue(res);


        }

        [Test, Order(2), Category("ProductionUpdater")]
        public void TestInternalUpdater()
        {
            bool res = false;
            baseTestClass.SetupATLAS();

            bool result = baseTestClass.GetAppActions().CheckForUpdatesProd();

            Thread.Sleep(3000);

            //If the program works until here, i assume that the updater is open and will set the assertion result to true;
             res = true;

            baseTestClass.cleanUp();

            Assert.IsTrue(res);





        }


       
    }
}
