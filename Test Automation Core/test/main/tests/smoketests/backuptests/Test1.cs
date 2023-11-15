using Test_Automation_Core.test.main.tests;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.main.tests
{
    public class Test1:InitTests
    {

        [Category("backuptests")]

       
        
        
        
        
        
        
        [Test]
        public void CheckWarning()
        {
            //Test 1 
            string backUp = AtlasVariables.InstalledVersion + "_BackUp";

            initBackUpApp();

            bool warningTrue = GetBackUpActions().CheckWarning();
            Assert.IsTrue(warningTrue);

        }
    }
}

