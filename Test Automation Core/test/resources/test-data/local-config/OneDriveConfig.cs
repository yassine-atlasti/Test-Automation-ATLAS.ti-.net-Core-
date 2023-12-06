using Test_Automation_Core.test.utilities.util;

namespace Test_Automation_Core.test.resources.test
{
    public static class OneDriveConfig
    {

        //Get the one drive path automatically 
        public static string testingStuffPath = SystemActions.GetOneDrivePath() + "\\Testing stuff";

        //If you need to set the one drive path manually , convert the line above to a comment, and the line below to code.

        // public static string testingStuffPath =  @"\\Mac\Home\Library\CloudStorage\OneDrive-ATLAS.tiScientificSoftwareDevelopmentGmbH\Testing stuff";




    }
}
