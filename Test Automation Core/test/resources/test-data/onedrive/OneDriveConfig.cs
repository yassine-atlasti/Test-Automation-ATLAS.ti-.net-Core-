using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.resources.test
{
    public static class OneDriveConfig
    {

        //Get the one drive path automatically 
        public static string testingStuffPath = SystemActions.GetOneDrivePath() + "\\Testing stuff";

        //Set the one drive path manually
        // public static string testingStuffPath =  @"\\Mac\Home\Library\CloudStorage\OneDrive-ATLAS.tiScientificSoftwareDevelopmentGmbH\Testing stuff";




    }
}
