
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Test_Automation_Core.Installer;

namespace Test_Automation_Core.OS.Windows
{


    public class SystemActions
    {

       

        //This method fails to copy the download file to the destination path " System.UnauthorizedAccessException : Access to the path 'C:\Users\yassinemahfoudh\Desktop\Test1' "

        public async Task DownloadAtlasAsync(string url, string destinationPath)
        {
            using HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(15); // Increase the timeout duration to 15 minutes

            var response = await client.GetAsync(url);

            using var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None);
            await response.Content.CopyToAsync(fileStream);
            

            Console.WriteLine($"File downloaded to {destinationPath}");
        }


        //This requires Viusal Studio to  run as an admin, find another way to install it , an msi file should make more sense , or use UI (See InstallerActions.cs)

        public void InstallAtlas(string downloadPath, string installPath)
        {
            Process process = new Process();

            process.StartInfo.FileName = downloadPath;
            process.StartInfo.Arguments = $"/S /D={installPath}";

            process.Start();

            process.WaitForExit();

            Console.WriteLine($"ATLAS.ti installed at {installPath}");
        }

        //This requires Viusal Studio to run as an admin, find another way to uninstall it , an msi file should make more sense ,or use UI (See InstallerActions.cs)
        public void UninstallAtlas(string majorVersion)
        {
            string applicationPath = $@"C:\Program Files\Scientific Software\ATLASti.{majorVersion}\Atlasti{majorVersion}\.exe";
            string applicationName = Path.GetFileNameWithoutExtension(applicationPath);
            // Close the application before uninstalling
            Process[] processes = Process.GetProcessesByName(applicationName);
            foreach (Process process in processes)
            {
                process.CloseMainWindow();
                process.WaitForExit(5000); // Wait for the application to exit gracefully for a maximum of 5 seconds
                if (!process.HasExited)
                {
                    process.Kill(); // Forcefully terminate the application if it doesn't exit within the given time
                }
            }

            // Uninstall the application
            Process.Start("cmd.exe", $"/C wmic product where name=\"ATLAS.ti {majorVersion}\" call uninstall");
        }


        public void CreateFolder(string folderName)
        {
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
        }

        public void ExtractZip(string zipPath, string extractPath)
        {
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }

        //Empty Bin

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, uint dwFlags);

        const uint SHERB_NOCONFIRMATION = 0x00000001;
        const uint SHERB_NOPROGRESSUI = 0x00000002;
        const uint SHERB_NOSOUND = 0x00000004;

        public void EmptyRecycleBin()
        {
            SHEmptyRecycleBin(IntPtr.Zero, null, SHERB_NOCONFIRMATION | SHERB_NOPROGRESSUI | SHERB_NOSOUND);
        }


        public bool WaitForElementToBeDisplayed(WindowsDriver<WindowsElement> driver, string accessibilityId, int timeoutInSeconds)
        {
            for (int i = 0; i < timeoutInSeconds; i++)
            {
                try
                {
                    var element = driver.FindElementByAccessibilityId(accessibilityId);
                    if (element.Displayed)
                    {
                        return true;
                    }
                }
                catch (WebDriverException)
                {
                    // Swallow the exception that element is not found, because we will try again
                }

                // wait for 1 second before trying again
                Thread.Sleep(1000);
            }

            return false; // element was not found within the time limit
        }

        public bool WaitForElementToBeDisplayedByName(WindowsDriver<WindowsElement> driver, string name, int timeoutInSeconds)
        {
            for (int i = 0; i < timeoutInSeconds; i++)
            {
                try
                {
                    var element = driver.FindElementByName(name);

                    if (element.Displayed)
                    {
                        return true;
                    }

                }
                catch (WebDriverException)
                {
                    // Ignore the exception, and try again
                }

                // Wait for 1 second before trying again
                Thread.Sleep(1000);
            }

            return false; // element was not found within the time limit
        }
        public bool WaitForElementToBeDisplayedByTagName(WindowsDriver<WindowsElement> driver, string tagName, string name, int timeoutInSeconds)
        {
            for (int i = 0; i < timeoutInSeconds; i++)
            {
                try
                {
                    var element = driver.FindElementByTagName(tagName).FindElementByName(name);

                    if (element.Displayed)
                    {
                        return true;
                    }

                }
                catch (WebDriverException)
                {
                    // Ignore the exception, and try again
                }

                // Wait for 1 second before trying again
                Thread.Sleep(1000);
            }

            return false; // element was not found within the time limit
        }


        public void CloseAtlasTiProcesses(string majorVersion)
        {
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                if (process.ProcessName.StartsWith($"ATLAS.ti {majorVersion}"))
                {
                    process.CloseMainWindow();
                    process.WaitForExit(5000); // Wait for the process to exit gracefully for a maximum of 5 seconds
                    if (!process.HasExited)
                    {
                        process.Kill(); // Forcefully terminate the process if it doesn't exit within the given time
                    }
                }
            }
        }
    }


    
}

