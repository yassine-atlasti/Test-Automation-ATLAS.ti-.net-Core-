using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using Test_Automation_Core.UIElements.Dialogs;
using Test_Automation_Core.UIElements.Wizards;

namespace Test_Automation_Core.UIElements.WelcomeWindow
{
    public class OptionsWindow
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public OptionsWindow(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }



        //Application Preferences
        public void ClickApplicationPreferences()
        {
            driver.FindElementByName("SSD.ATLASti.UI.Preferences.PreferenceCategory").Click();
        }

        public SwitchLibraryWizard ClickSwitchLibraryButton()
        {
            WindowsElement switchLibraryButton = driver.FindElementByName("Switch Library...");
            switchLibraryButton.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("Next >")));

            return new SwitchLibraryWizard(driver);
        }



        //ATLAS.ti Options
        public void ClickATLASti()
        {
            var lastTabItem = driver.FindElementByAccessibilityId("CategoriesTabControl").FindElementsByClassName("TabItem").LastOrDefault(); 
           
            if (lastTabItem != null)
            {
                // Now you can interact with the lastTabItem.
                // For instance, you could click it:
                lastTabItem.Click();
            }
            else
            {
                Console.WriteLine("TabItem not found");
            }

        }
        private void ClickReportProblemButton()
        {
            driver.FindElementByName("Report Problem").Click();
        }

        private void ClickSendSuggestionButton()
        {
            driver.FindElementByName("Send Suggestion").Click();
        }

        private void ClickCheckForUpdatesButton()
        {
            driver.FindElementByName("Check for Updates").Click();
        }

        public ReportProblemDialog OpenReportProblemDialog()
        {
            ClickReportProblemButton();
            //Could add code to Wait for a unique element in the Report Problem Dialog to appear.
            
            return new ReportProblemDialog(driver);
        }

        public SuggestionDialog OpenSendSuggestionDialog()
        {
            ClickSendSuggestionButton();
            // Could add code to Wait for a unique element in the Send Suggestion Dialog to appear.
            
            return new SuggestionDialog(driver);
        }

        public CheckForUpdatesDialog OpenCheckForUpdatesDialog()
        {
            ClickCheckForUpdatesButton();
            // Wait for a unique element in the Check for Updates Dialog to appear.
            // Replace "UniqueElementInCheckForUpdatesDialog" with an actual unique element name or locator.
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("UniqueElementInCheck")));

            return new CheckForUpdatesDialog(driver);


        }
    }
}
