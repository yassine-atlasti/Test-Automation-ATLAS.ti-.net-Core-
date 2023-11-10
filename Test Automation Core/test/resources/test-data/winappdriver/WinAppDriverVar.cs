using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.resources.test_data.winappdriver
{
    public class WinAppDriverVar
    {

        public static String winAppDriverPath = @"C:\Program Files\Windows Application Driver\WinAppDriver.exe";
        public static String winAppDriverAppName = Path.GetFileNameWithoutExtension(winAppDriverPath);
    }
}
