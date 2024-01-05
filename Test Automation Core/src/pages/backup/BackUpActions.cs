using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;
using Test_Automation_Core.src.pages.windowsos;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.src.pages.backup
{
    public class BackUpActions
    {
        WindowsDriver<WindowsElement> driver;
        public BackUpActions(WindowsDriver<WindowsElement> driver) { this.driver = driver; }


        public void RunATLAStiBackupApp()
        {
            string appPath = @"C:\Program Files\Scientific Software\ATLASti.23\SSD.ATLASti.Backup.exe";

            Process.Start(appPath);
        }

        //Backup buttons in the BackupApp have no automation ids. So i tried to locate them,by navigating the UI Tree
        public void ClickFirstButtonInChooseActionView()
        {
            // Find the ChooseActionView element
            var chooseActionView = driver.FindElementByClassName("ChooseActionView");

            // Find the first Button element within the ChooseActionView
            var firstButton = chooseActionView.FindElementsByClassName("Button").FirstOrDefault();

            // Click on the first Button using Actions class
            firstButton.Click();
        }

        public void ClickSecondButtonInChooseActionView()
        {
            // Find the ChooseActionView element
            WindowsElement chooseActionView = driver.FindElementByClassName("ChooseActionView");

            // Find all button elements within the ChooseActionView
            var buttonElements = chooseActionView.FindElementsByClassName("Button");

            if (buttonElements.Count >= 2)
            {
                // Click on the second button
                buttonElements[1].Click();
            }
            else
            {
                Console.WriteLine("Not enough buttons found in the ChooseActionView");
            }
        }


        public bool CreateBackUp(string destinationPath, string fileName)
        {
            //Click the Create BackUp Button
            ClickFirstButtonInChooseActionView();

            Thread.Sleep(1000);
            FilePicker backUpDialog = new FilePicker(driver);

            backUpDialog.EnterFileName(fileName);

            backUpDialog.EnterFilePath(destinationPath);
            Thread.Sleep(2000);

            backUpDialog.ClickSaveButton();

            Thread.Sleep(500);

            backUpDialog.ClickYesIfVisible();
            //Wait for Back Up to be completed
            SystemActions systemActions = new SystemActions();
            bool backUpState = systemActions.WaitForElementToBeDisplayedByTagName(driver, "Text", "Backup Completed", 80);



            return backUpState;

        }

        public bool RestoreLibrary(string backUpPath, string backUpName)
        {
            ClickSecondButtonInChooseActionView();
            FilePicker backUpDialog = new FilePicker(driver);
            backUpDialog.EnterFilePath(backUpPath);
            backUpDialog.EnterFileName(backUpName);
            backUpDialog.ClickOpenButton();
            //Wait for Restore to be completed
            SystemActions systemActions = new SystemActions();
            bool restoreState = systemActions.WaitForElementToBeDisplayedByTagName(driver, "Text", "Restore Completed", 30);
            return restoreState;

        }
        //Test
        public bool CheckWarning()
        {

            SystemActions systemActions = new SystemActions();
            bool runingState = systemActions.WaitForElementToBeDisplayedByTagName(driver, "Text", "ATLAS.ti Is Running", 10);
            return runingState;
        }

        public void ExitBackUp()
        {
            driver.CloseApp();
        }


    }
}
