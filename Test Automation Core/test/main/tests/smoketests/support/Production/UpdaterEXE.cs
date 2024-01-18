using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.test.main.tests.smoketests.support.Production
{
    public class UpdaterEXE
    {
        [Test, Order(1), Category("ProdUpdaterEXE")]
        public void TestSatelliteUpdaterEXE()
        {
            BaseTestCase test = new BaseTestCase();

            test.SetupUpdater();

            //Write code that start download and then stop it when it starts

            test.cleanUp();


        }

        [Test, Order(2), Category("ProdUpdaterEXE")]
        public void TestInternalUpdaterEXE()
        {
            BaseTestCase test = new BaseTestCase();

            bool result = test.GetAppActions().CheckForUpdates();

            //Write code that start download and then stop it when it starts


            test.cleanUp();


        }

    }
}
