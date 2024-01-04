using OpenQA.Selenium;
using Test_Automation_Core.src.pages.atlasti.ui.appmenu.file;
using Test_Automation_Core.src.pages.atlasti.ui.dialogs;
using Test_Automation_Core.src.pages.windowsos;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.src.pages.atlasti.actions
{
    public class ApplicationActions
    {
        private readonly App _app;

        public ApplicationActions(App app)
        {
            _app = app;
        }

        public bool ImportProject(string filePath, string importType, string mediaFolder = "")
        {
            var welcomeControlWindow = _app.GetWelcomeControl();
            var filePickerDialog = _app.GetFilePickerDialog();
            var importProjectDialog = _app.GetImportProjectDialog();
            var atlasProjectWindow = _app.GetProjectWindow();
            bool importState;
            string projectName = Path.GetFileName(filePath);


            // Assume that each method performs the action that its name suggests
            int retryCount = 0;
            int maxRetries = 3;  // Adjust the maximum number of retries as needed
            bool isSuccessful = false;

            while (retryCount < maxRetries && !isSuccessful)
            {
                try
                {
                    welcomeControlWindow.ClickImportProjectButton(); // Attempt to click the button
                    isSuccessful = true; // If it reaches here, no exception was thrown, and the click was successful
                }
                catch (Exception ex) // Catch a general exception or a more specific one if you know what to expect
                {
                    Console.WriteLine("Attempt " + (retryCount + 1) + " failed: " + ex.Message);
                    retryCount++;
                    Thread.Sleep(1000);  // Wait for 1 second before retrying. Adjust the delay as needed.
                }
            }


            Thread.Sleep(1000);

            filePickerDialog.EnterFileName(filePath);

            filePickerDialog.ClickOpenButton();

            //Wait 5 seconds for Import dialog to appear
            Thread.Sleep(5000);

             importState = importProjectDialog.IsProjectLoaded(importType);



            if (importState)
            {

                // If import type is QDPX and the MediaFolderButton is visible, handle the media folder selection
                if (importType == "QDPX" && importProjectDialog.IsMediaFolderButtonVisible())
                {
                    // Assume media folder is in the same directory as the QDPX file

                    importProjectDialog.ClickBrowseMediaFolderButton();
                    filePickerDialog.EnterFilePath(mediaFolder);
                    filePickerDialog.ClickSelectFolderButton();

                }

                // Set project name
                if (importType != "AtlCB" && importType != "mobile") { importProjectDialog.EnterProjectName(projectName); }
               
                importProjectDialog.ClickImportButton();



                // You can add more actions or checks here, such as validating that the project was imported correctly

                // if (!CheckForImportProjectErrors())  => continue;

                SystemActions systemActions = new SystemActions();
                string windowName = projectName + " - ATLAS.ti";

                //Don't check for mobile and atlcb project until bug with project names is fixed
                if (importType != "AtlCB" && importType != "mobile")
                {
                    importState = systemActions.WaitForElementToBeDisplayedByTagName(_app.getDriver(), "Window", windowName, 35);
                } else {
                    //false until bug with project names is fixed (Bug 19708)
                        importState = false; }

            }



            return importState;
        }



        public enum ExportType
        {
            QDPX,
            ATLPROJ
        }

        public bool ExportProject(string filePath, ExportType exportType, string projectName, string fileName = "")
        {
            const int shortDelay = 1500;
            const int mediumDelay = 2000;
            const int longDelay = 3000;

            OpenProject(projectName); // Assume this method exists

            var projectWindow = _app.GetProjectWindow();
            var appMenu = projectWindow.getAppMenu();
            var fileTab = appMenu.ClickFile();
            Thread.Sleep(shortDelay); // Consider replacing with a more robust synchronization

            ExportControl exportControl = fileTab.ClickExport();
            Thread.Sleep(shortDelay); // Consider replacing with a more robust synchronization

            FilePicker filePickerDialog = HandleExportType(exportControl, exportType);

            Thread.Sleep(longDelay); // Consider replacing with a more robust synchronization

            fileName = string.IsNullOrEmpty(fileName) ? projectName : fileName;
            filePickerDialog.EnterFileName(Path.Combine(filePath, fileName));
            filePickerDialog.ClickSaveButton();

            Thread.Sleep(mediumDelay); // Consider replacing with a more robust synchronization

            return DetermineExportState(exportType);
        }

        private FilePicker HandleExportType(ExportControl exportControl, ExportType exportType)
        {
            switch (exportType)
            {
                case ExportType.QDPX:
                    exportControl.ClickQDPXProjectBundleTabItem();
                    //Or ExportBackstageTab
                    return exportControl.ClickProjectBundleButton("ExportBackstageTab");
                case ExportType.ATLPROJ:
                    // exportControl.UnselectCheckBox(); // If needed
                    return exportControl.ClickProjectBundleButton("TheExportControl");
                default:
                    throw new ArgumentException($"Invalid export type: {exportType}");
            }
        }

        private bool DetermineExportState(ExportType exportType)
        {
            SystemActions systemActions = new SystemActions();

            if (exportType == ExportType.QDPX)
            {
                var exportResultsDialog = _app.GetExportResultsDialog();
                bool exportState = systemActions.WaitForElementToBeDisplayedByName(_app.getDriver(), "Cancel", 30);
                exportResultsDialog.CancelQDPXResultsExport();
                return exportState;
            }
            else if (exportType == ExportType.ATLPROJ)
            {
                return systemActions.WaitForElementToBeDisplayedByTagName(_app.getDriver(), "TabItem", "Home", 30);
            }

            return false;
        }



        public void SwitchLibrary(string libraryPath)
        {
            var welcomeWindow = _app.GetWelcomeControl();
            var optionsWindow = _app.GetOptionsWindow();
            var switchLibraryWizard = _app.GetSwitchLibraryWizard();



            // Open the options window and click the 'Switch Library' button
            welcomeWindow.ClickOptionsButton();
            Thread.Sleep(500);

            optionsWindow.ClickApplicationPreferences();
            Thread.Sleep(500);

            optionsWindow.ClickSwitchLibraryButton();

            Thread.Sleep(500);

            // In the Switch Library Wizard, click the 'Next' button
            switchLibraryWizard.ClickNextButton();
            Thread.Sleep(500);

            //Select open an existing library option
            switchLibraryWizard.SelectOption("Open an existing library");
            Thread.Sleep(500);

            // In the Switch Library Wizard, click the 'Next' button
            switchLibraryWizard.ClickNextButton();
            Thread.Sleep(500);

            //If the current library is not the Default Library, the user should select "Choose Library Location
            string uiElement = "Choose Library Location";

            if (switchLibraryWizard.IsElementDisplayed(uiElement))
            {
                switchLibraryWizard.SelectOption(uiElement);

            }
            Thread.Sleep(500);

            // Open the File Picker dialog, enter the path of the new library and click 'Select Folder'
            var filePickerDialog = switchLibraryWizard.OpenFilePicker();

            filePickerDialog.EnterFilePath(libraryPath);
            Thread.Sleep(500);

            filePickerDialog.ClickSelectFolderButton();
            Thread.Sleep(500);

            // Back in the Switch Library Wizard, click the 'Next' button
            switchLibraryWizard.ClickNextButton();
            Thread.Sleep(500);

            // Confirm the switch by clicking the 'Finish' button
            switchLibraryWizard.ClickFinishButton();


            //The App will restart so the connection with the driver will be lost. We need to compare the results in another method ValidateLibSwitch() that will be called in the test method after reinitilazing the WinAppDriver parameters
            /**
            // You can add more actions or checks here, such as validating that the library was switched correctly 

            //We should check that there are no errors or crashes (the solution below is a temporary solution for testing purposes)

            SystemActions systemActions = new SystemActions();
            bool switchLibState = systemActions.WaitForElementToBeDisplayed(_app.getDriver(), "SearchControl", 35);

            return switchLibState;
            **/

            // Wait for 20 second for Library Switch
            Thread.Sleep(20000);
        }

        public bool ValidateLibSwitch()
        {

            // You can add more actions or checks here, such as validating that the library was switched correctly 

            //We should check that there are no errors or crashes (the solution below is a temporary solution for testing purposes)

            SystemActions systemActions = new SystemActions();
            bool switchState = systemActions.WaitForElementToBeDisplayed(_app.getDriver(), "SearchControl", 35);
            return switchState;

        }


        public bool OpenProject(string projectName)
        {
            var welcomeWindow = _app.GetWelcomeControl();
            var projectWindow = _app.GetProjectWindow();

           
            // Open project
            welcomeWindow.OpenProject(projectName);
            // You can add more actions or checks here, such as validating that the project was imported correctly

            SystemActions systemActions = new SystemActions();
            string windowName = projectName + " - ATLAS.ti";
            bool openState = systemActions.WaitForElementToBeDisplayedByTagName(_app.getDriver(), "Window", windowName, 35);

            //Check if project recovery dialog appears , if yes click it
            systemActions.WaitForElementToBeDisplayedByTagName(_app.getDriver(), "Button", "OK", 1);


            return openState;
        }




        public async Task CloseProjectAsync()
        {
            var welcomeWindow = _app.GetWelcomeControl();
            var projectWindow = _app.GetProjectWindow();
            var appMenu = projectWindow.getAppMenu();

            if (!welcomeWindow.IsWelcomeWindowDisplayed())
            {
                // Assume that each method performs the action that its name suggests
                var fileTab = appMenu.ClickFile();
                Thread.Sleep(1000);
                fileTab.ClickSave();
                Thread.Sleep(500);
                fileTab.ClickClose();


                /**  // You can add more actions or checks here, such as validating that the project was closed correctly
                  SystemActions systemActions = new SystemActions();
                  string windowName = "ATLAS.ti";
                  systemActions.WaitForElementToBeDisplayedByTagName(_app.getDriver(), "Name", "Your Projects", 30);
                  **/
                Thread.Sleep(10000);


            }


        }

        public void DeleteProject(string projectName)
        {

            var welcomeWindow = _app.GetWelcomeControl();
            var projectWindow = _app.GetProjectWindow();

            welcomeWindow.SelectProjectContextMenuOption(projectName, "Delete");
           
            Thread.Sleep(1000);
            //Confirm Delete in Dialog
            _app.getDriver().FindElementByTagName("Button").FindElementByName("Delete").SendKeys(Keys.Enter);

            //Wait 2 second to ensure that the project is deleted
            Thread.Sleep(2000);

            //Check if project is deleted


        }




        public bool ReportProblem(string description, string email)
        {
            ReportProblemDialog reportProblemDialog;

            if (_app.GetWelcomeControl().IsWelcomeWindowDisplayed())
            {
                // Reporting problem from welcome window
                var optionsWindow = _app.GetWelcomeControl().OpenOptionsWindow();
                optionsWindow.ClickATLASti();

                reportProblemDialog = optionsWindow.OpenReportProblemDialog();
            }
            else
            {
                // Reporting problem from project window
                var appMenu = _app.GetProjectWindow().getAppMenu();
                var helpRibbon = appMenu.ClickHelp();

                reportProblemDialog = helpRibbon.OpenReportProblemDialog();
            }

            reportProblemDialog.EnterProblemDescription(description);
            reportProblemDialog.EnterEmail(email);
            reportProblemDialog.ClickReportProblemButton();

            // Waiting for confirmation dialog to appear



            SystemActions systemActions = new SystemActions();

            bool reportState = systemActions.WaitForElementToBeDisplayedByName(_app.getDriver(), "Problem Report Sent", 30);

            // Once confirmation dialog is found, confirm the dialog
            reportProblemDialog.CloseConfirmationDialog();

            // Send the ESC key press to the active window
            _app.getDriver().Keyboard.SendKeys(Keys.Escape);

            return reportState;

        }




        public bool SendSuggestion(string description, string email)
        {
            SuggestionDialog suggestionDialog;

            if (_app.GetWelcomeControl().IsWelcomeWindowDisplayed())
            {
                // Sending suggestion from welcome window
                var optionsWindow = _app.GetWelcomeControl().OpenOptionsWindow();
                optionsWindow.ClickATLASti();

                suggestionDialog = optionsWindow.OpenSendSuggestionDialog();
            }
            else
            {
                // Sending suggestion from project window
                var appMenu = _app.GetProjectWindow().getAppMenu();
                var helpRibbon = appMenu.ClickHelp();

                suggestionDialog = helpRibbon.OpenSendSuggestionDialog();
            }

            suggestionDialog.EnterSuggestionDescription(description);
            suggestionDialog.EnterEmail(email);
            suggestionDialog.ClickSendSuggestionButton();

            // Waiting for confirmation dialog to appear


            SystemActions systemActions = new SystemActions();
            bool reportState = systemActions.WaitForElementToBeDisplayedByName(_app.getDriver(), "Suggestion Sent", 30);


            // Once confirmation dialog is found, confirm the dialog
            suggestionDialog.CloseConfirmationDialog();

            // Send the ESC key press to the active window
            _app.getDriver().Keyboard.SendKeys(Keys.Escape);
            return reportState;
        }

        public void LiveChat(string chatText)
        {
            if (_app.GetWelcomeControl().IsWelcomeWindowDisplayed())
            {
                OpenProject(SmokeTestVariables.smokeTestproject);
            }

            // Open the project window's app menu
            var appMenu = _app.GetProjectWindow().getAppMenu();

            // Click on 'Help' to get the HelpRibbon
            var helpRibbon = appMenu.ClickHelp();

            // Open the live chat dialog
            var liveChatDialog = helpRibbon.OpenLiveChatDialog();

            //  Start the chat and enter the chat text 
            liveChatDialog.StartChat();

            liveChatDialog.EnterChatText(chatText);
            liveChatDialog.EndChat();
            // Additional actions or checks can be added here



        }


        public bool RaiseException()
        {
            // Open the project window's app menu
            var appMenu = _app.GetProjectWindow().getAppMenu();

            // Click on 'Developer' to get the HelpRibbon
            var developerRibbon = appMenu.ClickDeveloper();

            developerRibbon.RaiseAtlasException();
            Thread.Sleep(25000);

            return true;


        }
        public void SendCrashReport(string email, string description)
        {

            CrashReportDialog reportCrashDialog = new CrashReportDialog(_app.getDriver());
            reportCrashDialog.moveDialogToForeground();

            reportCrashDialog.EnterEmail(email);
            reportCrashDialog.EnterCrashDescription(description);

            reportCrashDialog.ClickSendErrorButton();


        }







        public void CloseErrorDialog()
        {
            try
            {
                // If "OK" not found, try to find and click the "Cancel" button
                var cancelButton = _app.getDriver().FindElementByName("Cancel");
                cancelButton.Click();
            }
            catch (NoSuchElementException)
            {
                try
                {

                    // Try to find and click the "OK" button
                    var okButton = _app.getDriver().FindElementByName("OK");
                    okButton.Click();
                }
                catch (NoSuchElementException ex)
                {
                    Console.WriteLine("Neither 'OK' nor 'Cancel' button found: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while trying to click 'Cancel' button: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while trying to click 'OK' button: " + ex.Message);
            }
        }


        public void CloseATLAS(string windowName = "ATLAS.ti")
        {
            // Find the window by its name
            var window = _app.getDriver().FindElementByTagName("Window").FindElementByName(windowName);
            window.SendKeys(Keys.Control + "s");

            window.SendKeys(Keys.Alt + "F4");

        }
    }
}
