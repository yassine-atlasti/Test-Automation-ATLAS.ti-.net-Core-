using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.test.main.tests.smoketests.support.Production
{
    internal class UpdaterMSI
    {
        [Test,Order(1), Category("prodMSI")]
        public void TestSatelliteUpdaterMsi()
        {
            BaseTestCase test = new BaseTestCase();

            test.SetupUpdater();

            //Write code that start download and then stop it when it starts

            test.cleanUp();


        }

        [Test, Order(2), Category("prodMSI")]
        public void TestInternalUpdaterMsi()
        {
            BaseTestCase test = new BaseTestCase();

            bool result = test.GetAppActions().CheckForUpdates();

            //Write code that start download and then stop it when it starts


            test.cleanUp();


        }


       
    }
}
