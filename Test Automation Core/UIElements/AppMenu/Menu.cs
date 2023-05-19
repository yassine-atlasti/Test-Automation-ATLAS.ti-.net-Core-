using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.UIElements.AppMenu.Ribbons;

namespace Test_Automation_Core.UIElements.AppMenu
{
    public class Menu
    {
        private WindowsDriver<WindowsElement> _driver;

        public Menu(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        public FileTab ClickFile()
        {
            // Locate the File Menu item and perform the click action
            var fileMenu = _driver.FindElementByName("File");
            fileMenu.Click();

            // Return a new FileTab object
            return new FileTab(_driver);
        }


        public HomeRibbon ClickHome()
        {
            // Locate the Home Menu item and perform the click action
            var homeMenu = _driver.FindElementByName("Home");
            homeMenu.Click();

            // Return a new HomeRibbon object
            return new HomeRibbon(_driver);
        }

        public SearchCodeRibbon ClickSearchCode()
        {
            _driver.FindElementByName("Search & Code").Click();
            return new SearchCodeRibbon(_driver);
        }

        public AnalyzeRibbon ClickAnalyze()
        {
            _driver.FindElementByName("Analyze").Click();
            return new AnalyzeRibbon(_driver);
        }

        public ImportExportRibbon ClickImportExport()
        {
            _driver.FindElementByName("Import & Export").Click();
            return new ImportExportRibbon(_driver);
        }

        public ToolsRibbon ClickTools()
        {
            _driver.FindElementByName("Tools").Click();
            return new ToolsRibbon(_driver);
        }

        public HelpRibbon ClickHelp()
        {
            _driver.FindElementByName("Help").Click();
            return new HelpRibbon(_driver);
        }


    }
}
