using OpenQA.Selenium.Appium.Windows;
using Test_Automation_Core.src.pages.atlasti.ui.appmenu.file;
using Test_Automation_Core.src.pages.atlasti.ui.dialogs;
using Test_Automation_Core.src.pages.atlasti.ui.windows;
using Test_Automation_Core.src.pages.atlasti.ui.wizards;
using Test_Automation_Core.src.pages.windowsos;

namespace Test_Automation_Core.src
{
    public class App
    {
        private static WindowsDriver<WindowsElement> _driver;
        private static readonly TimeSpan _timeout = TimeSpan.FromSeconds(10);


        public App(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        public WindowsDriver<WindowsElement> getDriver()
        {
            return _driver;
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

        public FeedBackDialog GetSendSuggestionDialog()
        {
            return new FeedBackDialog(_driver);
        }

        public SystemReport GetReportProblemDialog()
        {
            return new SystemReport(_driver);
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



    }

}
