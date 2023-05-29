using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.UIElements.AppMenu.Ribbons
{

    public class HomeRibbon {
         private readonly WindowsDriver<WindowsElement> _driver;

    public HomeRibbon(WindowsDriver<WindowsElement> driver)
    {
        _driver = driver;
    }

    public void ClickDocuments()
    {
        // Locate the Documents element and perform the click action
        var documentsElement = _driver.FindElementByName("Documents");
        documentsElement.Click();

      
    }

    // Similarly for the other elements...

}
   
}
