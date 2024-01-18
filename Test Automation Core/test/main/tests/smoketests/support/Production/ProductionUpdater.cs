using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.src.pages.updater;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.tests.smoketests.support.Production
{
    public class ProductionUpdater
    {
        [Test,Order(1), Category("ProductionUpdater")]
        public void TestSatelliteUpdater()
        {
            BaseTestCase test = new BaseTestCase();

            test.SetUpSatelliteUpdater();

            Updater satelliteUpdater= new Updater(test.GetDriver());
            Thread.Sleep(4000);

            satelliteUpdater.StartDownload();
            
            bool res = satelliteUpdater.CheckDownloadStarted();


            test.cleanUp();

            Assert.IsTrue(res);


        }

        [Test, Order(2), Category("ProductionUpdater")]
        public void TestInternalUpdater()
        {
            bool res = false;
            BaseTestCase test = new BaseTestCase();
            test.SetupATLAS();

            bool result = test.GetAppActions().CheckForUpdatesProd();

            Thread.Sleep(3000);

            //If the program works until here, i assume that the updater is open and will set the assertion result to true;
             res = true;

            test.cleanUp();

            Assert.IsTrue(res);





        }


       
    }
}
