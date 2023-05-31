
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
using TextCopy;
using NUnit.Framework.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test_Automation_Core.OS.Windows
{


    public class SystemActions
    {

        WindowsDriver<WindowsElement> driver;
        public SystemActions() { }

        public SystemActions(WindowsDriver<WindowsElement> driver) { this.driver = driver; }

        //This method fails to copy the download file to the destination path " System.UnauthorizedAccessException : Access to the path 'C:\Users\yassinemahfoudh\Desktop\Test1' "

        public async Task DownloadFileAsync(string url, string fileName)
        {
            // 1. Create HttpClient.
            var httpClient = new HttpClient();

            // 2. Send a GET request to the provided url.
            using var response = await httpClient.GetAsync(url);

            // 3. Ensure the request was successful.
            response.EnsureSuccessStatusCode();

            // 4. Try to get the name of the file from the ContentDisposition header.

            // 5. If the file name wasn't provided in the response headers, try to extract it from the URL.
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = Path.GetFileName(new Uri(url).AbsolutePath);
            }

            // 6. If the file name still wasn't provided, throw an exception.
            if (string.IsNullOrEmpty(fileName))
            {
                throw new InvalidOperationException("The file name could not be determined.");
            }

            // 7. Get the path to the Downloads folder.
            var downloadFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\";

            // 8. Combine the Downloads folder path and file name to form the full file path.
            var filePath = Path.Combine(downloadFolder, fileName);

            // 9. If the file already exists in the Downloads folder, delete it.
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // 10. Create a new file and write the response content into it.
            using var fileStream = File.Create(filePath);
            await response.Content.CopyToAsync(fileStream);

            Console.WriteLine($"File downloaded to {filePath}");
        }




        public void UninstallApp( string uninstallPath)
        {

            ClipboardService.SetText(uninstallPath);
            System.Threading.Thread.Sleep(1000);


            // Launch the 'Add or Remove Programs' window

            // Create an instance of Actions class
            var action = new OpenQA.Selenium.Interactions.Actions(driver);

            // Press Win key
            action.KeyDown(Keys.Meta);

            // Press R key
            action.SendKeys("e");

            // Release Win key
            action.KeyUp(Keys.Meta);

            // Perform the action
            action.Perform();


            Thread.Sleep(1000);


            // Use CTRL+L to focus on the address bar, then paste the clipboard content 
            action.KeyDown(Keys.Control).SendKeys("l").KeyUp(Keys.Control).SendKeys(Keys.Control + "v").KeyUp(Keys.Control).SendKeys(Keys.Enter).Perform();

            //Wait for app to uninstall
            Thread.Sleep(90000);





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


        public void KillProcessByName(string processName)
        {
            // Get all processes with the exact name
            Process[] processes = Process.GetProcessesByName(processName);

            foreach (Process process in processes)
            {
                try
                {
                    process.Kill(); // Forcefully terminate the process
                    process.WaitForExit(); // Optionally wait for the process to exit
                }
                catch (Exception e)
                {
                    // Log or handle the exception as needed
                    Console.WriteLine($"Error killing process: {e.Message}");
                }
            }
        }


        public void CloseAppByWindowName(string windowName)
        {
            // Find the window by its name
            var window = driver.FindElementByTagName("Window").FindElementByName(windowName);


            window.SendKeys(Keys.Alt + "F4");
          
        }



    }

}





