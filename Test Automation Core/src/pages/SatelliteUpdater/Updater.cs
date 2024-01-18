using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core.src.pages.updater
{
    public class Updater
    {
        WindowsDriver<WindowsElement> driver;
        
        public Updater(WindowsDriver<WindowsElement> driver) { this.driver = driver; }

        public void StartDownload()
        {
            driver.FindElementByName("Download").Click();
        }

        public void CancelDownload()
        {
            try { driver.FindElementByName("Cancel").Click(); }
            catch(Exception e) { }
        }

        public bool CheckDownloadStarted()
        {
            Thread.Sleep(5000);
            try { driver.FindElementByName("Downloading Updates");
                return true;
            }
            catch(Exception e){ return false; }
        }

    }
}
