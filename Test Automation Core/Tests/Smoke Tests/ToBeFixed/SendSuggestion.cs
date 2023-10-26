using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.Tests.ToBeFixed
{
    public class SendSuggestion
    {
        SmokeTestClass smokeTestClass = new SmokeTestClass();

        [Test]
        public void test()
        {
            smokeTestClass.initATLAS();
            bool suggestionState = smokeTestClass.GetAppActions().SendSuggestion("Test", "tester@atlasti.com");
            Assert.IsTrue(suggestionState);
        }

    }
}
