using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.test.main.tests.smoketests.support
{
    public class ExternalUpdater
    {

        [Test, Category("support")]
        public void TestExternalUpdater()
        {
            BaseTest test= new BaseTest();

            test.SetupUpdater();


           bool updater= test.GetSystemActions().WaitForElementToBeDisplayedByName(test.GetDriver(),"You are running the latest version of ATLAS.ti.",4);
            
            test.cleanUp();
            Assert.IsTrue(updater);
            

        }
    }
}
