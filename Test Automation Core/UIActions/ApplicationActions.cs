using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.UIElements.AppMenu.File;
using Test_Automation_Core.UIElements.Dialogs;
using OpenQA.Selenium.Appium.Windows;

namespace Test_Automation_Core.Actions
{
    public class ApplicationActions
    {
        private readonly App _app;

        public ApplicationActions(App app)
        {
            _app = app;
        }

        public bool ImportProject(string filePath, string importType, string projectName)
        {
            var welcomeControlWindow = _app.GetWelcomeControl();
            var filePickerDialog = _app.GetFilePickerDialog();
            var importProjectDialog = _app.GetImportProjectDialog();
            var atlasProjectWindow = _app.GetProjectWindow();

            if(!welcomeControlWindow.IsWelcomeWindowDisplayed()) { CloseProject();
                System.Threading.Thread.Sleep(5000);
            }

            // Assume that each method performs the action that its name suggests
            welcomeControlWindow.ClickImportProjectButton();
            System.Threading.Thread.Sleep(2000);
            filePickerDialog.EnterFileName(filePath);

            filePickerDialog.ClickOpenButton();

            //Wait 5 seconds for Import dialog to appear
            System.Threading.Thread.Sleep(3000);

            // If import type is QDPX and the MediaFolderButton is visible, handle the media folder selection
            if (importType == "QDPX" && importProjectDialog.IsMediaFolderButtonVisible())
            {
                // Assume media folder is in the same directory as the QDPX file
                string mediaFolderPath = Path.GetDirectoryName(filePath);

                importProjectDialog.ClickBrowseMediaFolderButton();
                filePickerDialog.EnterFilePath(mediaFolderPath);
                filePickerDialog.ClickOpenButton() ;

            }

            // Set project name
            importProjectDialog.EnterProjectName(projectName);

            importProjectDialog.ClickImportButton();



            // You can add more actions or checks here, such as validating that the project was imported correctly

            SystemActions systemActions = new SystemActions();
            string windowName = projectName + " - ATLAS.ti";
          bool importState=  systemActions.WaitForElementToBeDisplayedByTagName(_app.getDriver(),"Window", windowName, 35);

            return importState;
        }



        public bool ExportProject(string filePath, string exportType, string projectName)
        {
            var welcomeWindow= _app.GetWelcomeControl();
           
            var projectWindow = _app.GetProjectWindow();
            var appMenu= projectWindow.getAppMenu();

            //check if welcome Window is displayed or another project is actually open, if yes open the project that should be exported

            if(welcomeWindow.IsWelcomeWindowDisplayed() || !projectWindow.IsProjectOpen(projectName))
            {
                OpenProject(projectName);

            }


          

            // Assume that each method performs the action that its name suggests
            var fileTab = appMenu.ClickFile();

            ExportControl exportControl = fileTab.ClickExport();
            string exportTypeLower = exportType.ToLower();
            FilePicker filePickerDialog ;

            if (exportTypeLower == "qdpx")
            {
                exportControl.ClickQDPXProjectBundleTabItem();
                 filePickerDialog = exportControl.ClickProjectBundleButton("QDPXBundleTab");

            }
            else if (exportTypeLower == "atlproj")
            {
                filePickerDialog = exportControl.ClickProjectBundleButton("TransferBundleTab");
            }
            else
            {
                throw new ArgumentException("Invalid export type: " + exportType);
            }


            // Add a delay of 2 seconds
            Thread.Sleep(2000); // Delay in milliseconds

            filePickerDialog.EnterFilePath(filePath);
            filePickerDialog.ClickSaveButton();

            //handle QDPX Export Results
            // You can add more actions or checks here, such as validating that the project was exported correctly

            bool exportState = false;

            if (exportTypeLower == "qdpx")
            {
                var exportResultsDialog = _app.GetExportResultsDialog();

                SystemActions systemActions = new SystemActions();

                //for now , if the QDPX project was successfully exported we will see the Cancel Button of the Export Results. But in Future we should check that there are no errors or crashes 

                exportState = systemActions.WaitForElementToBeDisplayedByName(_app.getDriver(),  "Cancel", 30);
                    exportResultsDialog.CancelQDPXResultsExport();
                
            }
            else if (exportTypeLower == "atlproj")
            {
                //for now , if the project was successfully exported we will see the Home Menu Item. But in Future we should check that there are no errors or crashes 

                SystemActions systemActions = new SystemActions();
                exportState = systemActions.WaitForElementToBeDisplayedByTagName(_app.getDriver(),"TabItem", "Home", 30);

              
            }

            return exportState;





        }



        public void SwitchLibrary(string libraryPath)
        {
            var welcomeWindow = _app.GetWelcomeControl();
            var optionsWindow = _app.GetOptionsWindow();
            var switchLibraryWizard = _app.GetSwitchLibraryWizard();


            if (!welcomeWindow.IsWelcomeWindowDisplayed())
            {
                CloseProject();
            }


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


            //The App will restart so the connection with the driver will be lost. We need to compare the results in another method ValidateLibSwitch() that will be called in the test method after reinitilazing the WinAppDriver parameters
            /**
            // You can add more actions or checks here, such as validating that the library was switched correctly 

            //We should check that there are no errors or crashes (the solution below is a temporary solution for testing purposes)

            SystemActions systemActions = new SystemActions();
            bool switchLibState = systemActions.WaitForElementToBeDisplayed(_app.getDriver(), "SearchControl", 35);

            return switchLibState;
            **/
             
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

            if (welcomeWindow.IsWelcomeWindowDisplayed()==false)
            {
                CloseProject();

            }
            // Open project
            welcomeWindow.OpenProject(projectName);
            // You can add more actions or checks here, such as validating that the project was imported correctly

            SystemActions systemActions = new SystemActions();
            string windowName = projectName + " - ATLAS.ti";
            bool openState = systemActions.WaitForElementToBeDisplayedByTagName(_app.getDriver(), "Window", windowName, 35);

            return openState;
        }




        public bool CloseProject()
        {
            var welcomeWindow = _app.GetWelcomeControl();
            var projectWindow=_app.GetProjectWindow();
            var appMenu = projectWindow.getAppMenu();
            var fileTab = appMenu.ClickFile();

            // Assume that each method performs the action that its name suggests
            fileTab.ClickClose();

            // You can add more actions or checks here, such as validating that the project was closed correctly
            SystemActions systemActions = new SystemActions();
            string windowName =   "ATLAS.ti";
            bool closeState = systemActions.WaitForElementToBeDisplayedByTagName(_app.getDriver(), "Window", windowName, 20);

            return closeState;
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

            bool reportState = systemActions.WaitForElementToBeDisplayedByName(_app.getDriver(),  "The problem report was not successfully sent", 30);

            // Once confirmation dialog is found, confirm the dialog
            reportProblemDialog.CloseConfirmationDialog();

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

            return reportState;
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
