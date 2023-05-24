﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.UIElements.AppMenu.File;
using Test_Automation_Core.UIElements.Dialogs;

namespace Test_Automation_Core.Actions
{
    public class ApplicationActions
    {
        private readonly App _app;

        public ApplicationActions(App app)
        {
            _app = app;
        }

        public void ImportProject(string filePath, string importType, string projectName)
        {
            var welcomeControlWindow = _app.GetWelcomeControl();
            var filePickerDialog = _app.GetFilePickerDialog();
            var importProjectDialog = _app.GetImportProjectDialog();
            var atlasProjectWindow = _app.GetProjectWindow();

            // Assume that each method performs the action that its name suggests
            welcomeControlWindow.ClickImportProjectButton();
            filePickerDialog.EnterFilePath(filePath);
            filePickerDialog.ClickOpenButton();

            // If import type is QDPX and the MediaFolderButton is visible, handle the media folder selection
            if (importType == "QDPX" && importProjectDialog.IsMediaFolderButtonVisible())
            {
                // Assume media folder is in the same directory as the QDPX file
                string mediaFolderPath = Path.GetDirectoryName(filePath);

                importProjectDialog.ClickBrowseMediaFolderButton();
                filePickerDialog.EnterFilePath(mediaFolderPath);
                filePickerDialog.ClickSelectFolderButton();

            }

            // Set project name
            importProjectDialog.EnterProjectName(projectName);

            importProjectDialog.ClickImportAndWaitForProjectWindow();

            // You can add more actions or checks here, such as validating that the project was imported correctly
        }



        public void ExportProject(string filePath, string exportType, string projectName)
        {
            var welcomeWindow= _app.GetWelcomeControl();
            var fileTab = _app.GetFileTab();
            var atlasProjectWindow = _app.GetProjectWindow();

            //check if welcome Window is displayed, if yes open the project that should be exported

            if(welcomeWindow.IsWelcomeWindowDisplayed())
            {
                welcomeWindow.OpenProject(projectName);

            }

            // Assume that each method performs the action that its name suggests
            fileTab.ClickFile();
            ExportControl exportControl = fileTab.ClickExport();
            string exportTypeLower = exportType.ToLower();

            if (exportTypeLower == "qdpx")
            {
                exportControl.ClickQDPXProjectBundleTabItem();
            }
            else if (exportTypeLower == "atlproj")
            {
                exportControl.ClickProjectBundleTabItem();
            }
            else
            {
                throw new ArgumentException("Invalid export type: " + exportType);
            }

            FilePicker filePickerDialog = exportControl.ClickProjectBundleButton();

            filePickerDialog.EnterFilePath(filePath);
            filePickerDialog.ClickSaveButton();

            //handle QDPX Export Results
            if (exportType == "QDPX")
            {
                var exportResultsDialog = _app.GetExportResultsDialog();
                exportResultsDialog.CancelQDPXResultsExport();

            }
            // You can add more actions or checks here, such as validating that the project was exported correctly
        }



        public void SwitchLibrary(string libraryPath)
        {
            var welcomeWindow = _app.GetWelcomeControl();
            var optionsWindow = _app.GetOptionsWindow();
            var switchLibraryWizard = _app.GetSwitchLibraryWizard();


            // Open the options window and click the 'Switch Library' button
            welcomeWindow.ClickOptionsButton();
            optionsWindow.ClickApplicationPreferences();
            optionsWindow.ClickSwitchLibraryButton();

            // In the Switch Library Wizard, click the 'Next' button
            switchLibraryWizard.ClickNextButton();
            //Select open an existing library option
            switchLibraryWizard.SelectOption("Open an existing library");

            // In the Switch Library Wizard, click the 'Next' button
            switchLibraryWizard.ClickNextButton();

            //If the current library is not the Default Library, the user should select "Choose Library Location
            string uiElement = "Choose Library Location";
            
           if(switchLibraryWizard.IsElementDisplayed(uiElement))
            {
                switchLibraryWizard.SelectOption(uiElement);

            }

            // Open the File Picker dialog, enter the path of the new library and click 'Select Folder'
            var filePickerDialog = switchLibraryWizard.OpenFilePicker();

            filePickerDialog.EnterFilePath(libraryPath);
            filePickerDialog.ClickSelectFolderButton();

            // Back in the Switch Library Wizard, click the 'Next' button
            switchLibraryWizard.ClickNextButton();

            // Confirm the switch by clicking the 'Finish' button
            switchLibraryWizard.ClickFinishButton();

            // You can add more actions or checks here, such as validating that the library was switched correctly
           
        }



        public void OpenProject(string projectName)
        {
            var welcomeWindow = _app.GetWelcomeControl();
            var projectWindow = _app.GetProjectWindow();

            // Open project
            welcomeWindow.OpenProject(projectName);

            // Verify if the project is open
            bool isOpen = projectWindow.IsProjectOpen(projectName);

            if (!isOpen)
            {
                throw new Exception($"Failed to open the project {projectName}");
            }

            Console.WriteLine($"Project {projectName} opened successfully");
        }




        public void CloseProject()
        {
            var fileTab = _app.GetFileTab();
            var welcomeWindow = _app.GetWelcomeControl();

            // Assume that each method performs the action that its name suggests
            fileTab.ClickFile();
            fileTab.ClickClose();

            // You can add more actions or checks here, such as validating that the project was closed correctly
            if (welcomeWindow.IsWelcomeWindowDisplayed())
            {
                Console.WriteLine("Project successfully closed");
            }
            else
            {
                Console.WriteLine("Failed to close project");
            }
        }
        public void ReportProblem(string description, string email)
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
            var wait = new WebDriverWait(_app.getDriver(), TimeSpan.FromSeconds(60));
            try
            {
                wait.Until(drv => drv.FindElement(By.Name("Problem Report Sent")));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("The problem report was not successfully sent");
            }


            // Once confirmation dialog is found, confirm the dialog
            Console.WriteLine("The problem report was  successfully sent");
            reportProblemDialog.CloseConfirmationDialog();
            
        }




        public void SendSuggestion(string description, string email)
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
            var wait = new WebDriverWait(_app.getDriver(), TimeSpan.FromSeconds(60));
            try
            {
                wait.Until(drv => drv.FindElement(By.Name("Suggestion Sent")));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("The suggestion was not successfully sent");
            }

            // Once confirmation dialog is found, confirm the dialog
            Console.WriteLine("The suggestion was  successfully sent");
            suggestionDialog.CloseConfirmationDialog();
        }

        public void LiveChat(string chatText)
        {
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




    }
}
