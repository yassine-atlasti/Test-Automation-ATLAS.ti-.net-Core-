using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Automation_Core.UIElements.WelcomeWindow;
using Test_Automation_Core.UIElements.Dialogs;
using Test_Automation_Core.UIElements.Wizards;
using Test_Automation_Core.UIElements.AtlasWindows;
using Test_Automation_Core.UIElements.AppMenu.File;
using Test_Automation_Core.UIElements.AppMenu;

namespace Test_Automation_Core
{
    public class App
    {
        private static WindowsDriver<WindowsElement> _driver;
        private static readonly TimeSpan _timeout = TimeSpan.FromSeconds(10);

        public App(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        public WelcomeWindow GetWelcomeControl()
        {
           

            return new WelcomeWindow(_driver);
        }

        public OptionsWindow GetOptionsWindow()
        {
          
            return new OptionsWindow(_driver);
        }

        public ProjectWindow GetProjectWindow()
        {
           
            return new ProjectWindow(_driver);
        }



        //Get Dialogs
        public FilePicker GetFilePickerDialog()
        {
            return new FilePicker(_driver);
        }

        public ImportProjectDialog GetImportProjectDialog()
        {
            return new ImportProjectDialog(_driver);
        }

        public NewProjectDialog GetNewProjectDialog()
        {
            return new NewProjectDialog(_driver);
        }

        public CheckForUpdatesDialog GetCheckForUpdatesDialog()
        {
            return new CheckForUpdatesDialog(_driver);
        }

        public SendSuggestionDialog GetSendSuggestionDialog()
        {
            return new SendSuggestionDialog(_driver);
        }

        public ReportProblemDialog GetReportProblemDialog()
        {
            return new ReportProblemDialog(_driver);
        }

        public ExportResults GetExportResultsDialog()
        {
            return new ExportResults(_driver);
        }
        //Get Wizzards
        public SwitchLibraryWizard GetSwitchLibraryWizard()
        {
            return new SwitchLibraryWizard(_driver);
        }


        //App Menu

        public FileTab GetFileTab()
        {
            return new FileTab(_driver);
        }


        // other methods to get other windows...
    }

}
