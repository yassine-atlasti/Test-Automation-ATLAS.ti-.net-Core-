using System;
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
            driver.FindElementByName("Application Preferences").Click();
        }

        public SwitchLibraryWizard ClickSwitchLibraryButton()
        {
            WindowsElement switchLibraryButton = driver.FindElementByName("Switch Library...");
            switchLibraryButton.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("UniqueElementInSwitchLibraryWizard")));

            return new SwitchLibraryWizard(driver);
        }



        //ATLAS.ti Options
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
            // Wait for a unique element in the Report Problem Dialog to appear.
            // Replace "UniqueElementInReportProblemDialog" with an actual unique element name or locator.
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("UniqueElementInReportProblemDialog")));
            return new ReportProblemDialog(driver);
        }

        public SendSuggestionDialog OpenSendSuggestionDialog()
        {
            ClickSendSuggestionButton();
            // Wait for a unique element in the Send Suggestion Dialog to appear.
            // Replace "UniqueElementInSendSuggestionDialog" with an actual unique element name or locator.
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("UniqueElementInSendSuggestionDialog")));
            return new SendSuggestionDialog(driver);
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
