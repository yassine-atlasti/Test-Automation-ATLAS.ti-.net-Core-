using OpenQA.Selenium.Appium.Windows;
using Test_Automation_Core.src.pages.atlasti.ui.dialogs;

namespace Test_Automation_Core.src.pages.atlasti.ui.appmenu.ribbons
{
    public class HelpRibbon
    {
        private readonly WindowsDriver<WindowsElement> _driver;

        public HelpRibbon(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }



        public ReportProblemDialog OpenReportProblemDialog()
        {
            _driver.FindElementByName("Report Problem").Click();
            // Wait for a unique element in the Report Problem Dialog to appear.
            // Replace "UniqueElementInReportProblemDialog" with an actual unique element name or locator.
            /** var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
             wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("UniqueElementInReportProblemDialog")));**/
            return new ReportProblemDialog(_driver);
        }
        // Add methods here for interacting with elements under 'Help'...

        public SuggestionDialog OpenSendSuggestionDialog()
        {
            _driver.FindElementByName("Send Suggestion").Click();
            // Wait for a unique element in the Send Suggestion Dialog to appear.
            // Replace "UniqueElementInSendSuggestionDialog" with an actual unique element name or locator.
            /**  var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
              wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("UniqueElementInSendSuggestionDialog")));**/
            return new SuggestionDialog(_driver);
        }

        public LiveChatDialog OpenLiveChatDialog()
        {
            _driver.FindElementByName("Live Chat").Click();
            // Wait for a unique element in the Live Chat Dialog to appear.
            // Replace "UniqueElementInLiveChatDialog" with an actual unique element name or locator.
            /** var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
             wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("UniqueElementInLiveChatDialog")));**/
            Thread.Sleep(5000);
            return new LiveChatDialog(_driver);

        }

    }
}
