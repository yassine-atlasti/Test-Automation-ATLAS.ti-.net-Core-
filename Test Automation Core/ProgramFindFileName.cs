using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation_Core
{
    using System;
    using System.IO;
    using Test_Automation_Core.Data.OneDrive.Projects;
    using Test_Automation_Core.Data.SUT;

    public class ProgramFindFileName
    {
        public static void go()
        {
            string directoryPath = CHProjects.CHWinProdProjectsFolder;
            string partialFileName = AtlasVariables.winProduction;
            string fileExtension = ".atlproj23"; // Replace with the extension you know

            FindFilesByPartialName(directoryPath, partialFileName, fileExtension);
        }

        static  void FindFilesByPartialName(string directoryPath, string partialFileName, string fileExtension)
        {
            if (Directory.Exists(directoryPath))
            {
                // Search in the current directory
                string searchPattern = "*" + fileExtension;
                string[] files = Directory.GetFiles(directoryPath, searchPattern);

                foreach (string file in files)
                {
                    if (Path.GetFileName(file).Contains(partialFileName))
                    {
                        Console.WriteLine($"Found: {file}");
                        return;  // Stop searching if file is found
                    }
                }

                // If not found, look in the subdirectories
                string[] subDirectories = Directory.GetDirectories(directoryPath);
                foreach (string subDirectory in subDirectories)
                {
                    FindFilesByPartialName(subDirectory, partialFileName, fileExtension);
                }
            }
            else
            {
                Console.WriteLine("Directory not found.");
            }
        }
    }

}
