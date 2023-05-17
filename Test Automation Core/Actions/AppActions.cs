using OpenQA.Selenium.Support.UI;
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
    public class Actions
    {
        private readonly App _app;

        public Actions(App app)
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



        public void ExportProject(string filePath, string exportType)
        {
            var fileTab = _app.GetFileTab();
            var atlasProjectWindow = _app.GetProjectWindow();

            // Assume that each method performs the action that its name suggests
            fileTab.ClickFile();
            ExportControl exportControl = fileTab.ClickExport();

            if (exportType == "QDPX")
            {
                exportControl.ClickQDPXProjectBundleTabItem();
            }
            else if (exportType == "AtlProj")
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


    }

}
