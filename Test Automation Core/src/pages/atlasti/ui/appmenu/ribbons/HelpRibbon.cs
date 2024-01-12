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



        public SystemReport OpenSendSystemReportDialog()
        {
            _driver.FindElementByAccessibilityId("OnlineResources").Click();

            _driver.FindElementByName("Send System Report").Click();

            return new SystemReport(_driver);
        }
        // Add methods here for interacting with elements under 'Help'...

        public FeedBackDialog OpenSendFeedBackDialog()
        {
            _driver.FindElementByName("Send Feedback").Click();
           
            return new FeedBackDialog(_driver);
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
