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

    public class ProgramFindFileName
    {
        public static void Main()
        {
            string directoryPath = CHProjects.CHWinVUTProjectsFolder;
            string partialFileName = "23.3.2.28723";
            string fileExtension = ".atlproj"; // Replace with the extension you know

            FindFilesByPartialName(directoryPath, partialFileName, fileExtension);
        }

        static void FindFilesByPartialName(string directoryPath, string partialFileName, string fileExtension)
        {
            if (Directory.Exists(directoryPath))
            {
                // Add wildcard character '*' to find files of a particular extension
                string searchPattern = "*" + fileExtension;
                string[] files = Directory.GetFiles(directoryPath, searchPattern);

                foreach (string file in files)
                {
                    if (Path.GetFileName(file).Contains(partialFileName))
                    {
                        Console.WriteLine($"Found: {file}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Directory not found.");
            }
        }
    }

}
