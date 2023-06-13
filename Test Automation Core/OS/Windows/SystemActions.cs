
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
using System.Net.Sockets;
using System.Net.Http.Headers;
using OpenQA.Selenium.Appium;
using Test_Automation_Core.Data.SUT;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using static System.Net.WebRequestMethods;

namespace Test_Automation_Core.OS.Windows
{


    public class SystemActions
    {

       public WindowsDriver<WindowsElement> driver;
        public SystemActions() { }

        public SystemActions(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        private const int MaxRetries = 5;


        public WindowsDriver<WindowsElement> ClassInitialize(string appPath)
        {
            string applicationPath = appPath;

            //If the driver should not be assigned to Root Window of the OS then do following

            if (appPath == @"C:\Program Files\Scientific Software\ATLASti." + 23 + @"\Atlasti" + 23 + ".exe"  ) { 

            string applicationName = Path.GetFileNameWithoutExtension(applicationPath);

                OpenApp(applicationPath, applicationName);

     
            }
            // Now initialize the WindowsDriver
            AppiumOptions appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", applicationPath);
            appOptions.AddAdditionalCapability("deviceName", "WindowsPC");



            WindowsDriver<WindowsElement> driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appOptions);
             return driver;

        }

       

        public void OpenApp(string applicationPath,string applicationName)
        {

            // Check if the application is already running
            Process[] processes = Process.GetProcessesByName(applicationName);

            Process process;
            if (processes.Length == 0)
            {
                // If the application is not running, start it
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = applicationPath,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                process = Process.Start(processStartInfo);

                // Wait for application to open
                int maxWaitTimeInMilliseconds = 30000;
                int intervalInMilliseconds = 500;
                int elapsedWaitTimeInMilliseconds = 0;
                while (elapsedWaitTimeInMilliseconds < maxWaitTimeInMilliseconds)
                {
                    processes = Process.GetProcessesByName(applicationName);
                    if (processes.Length > 0)
                    {
                        process = processes[0];
                        break;
                    }
                    System.Threading.Thread.Sleep(intervalInMilliseconds);
                    elapsedWaitTimeInMilliseconds += intervalInMilliseconds;
                }
            }
            else
            {
                // If the application is already running, attach to the first instance
                process = processes[0];
            }
        }

        /**
        public void InitializeWindowsDriver()
        {

            // Set the desired capabilities for the application
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Root");
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);




        }

        **/


        public async Task DownloadFileAsync(string url, string fileName, int maxRetries = 3)
        {
            // Create HttpClient to send HTTP requests
            using var httpClient = new HttpClient();

            // Get the path of the downloads folder
            var downloadFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\";

            // Create the full file path
            var filePath = Path.Combine(downloadFolder, fileName);

            // If the file already exists, delete it before starting the download.
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            // Initialize retry counter
            int retryCount = 0;

            // Retry loop starts here
            while (retryCount <= maxRetries)
            {
                try
                {
                    // Determine the total bytes received to know if we're resuming a download or starting fresh
                    long totalBytes = System.IO.File.Exists(filePath) ? new FileInfo(filePath).Length : 0;

                    // Prepare the HTTP request message
                    using var request = new HttpRequestMessage { RequestUri = new Uri(url), Method = HttpMethod.Get };

                    // If we have received some bytes, set the 'Range' header so server sends from where it left off
                    if (totalBytes > 0)
                    {
                        request.Headers.Range = new RangeHeaderValue(totalBytes, null);
                    }

                    // Send the HTTP request and get the response
                    using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                    // Ensure we got a successful status code in response
                    response.EnsureSuccessStatusCode();

                    // Create or open the file for writing at the end of the file
                    using var fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None);

                    // Get the stream of the content of the response
                    using var contentStream = await response.Content.ReadAsStreamAsync();

                    // Prepare buffer to hold data read from the stream
                    var buffer = new byte[8192];
                    var bytesRead = 0;

                    // Read from stream and write to file stream
                    while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                        totalBytes += bytesRead;
                    }

                    // Log the successful download
                    Console.WriteLine($"File downloaded to {filePath}");

                    // Successfully downloaded, break out of the retry loop
                    break;
                }
                catch (Exception ex) when (ex is HttpRequestException || (ex is IOException && ex.InnerException is SocketException))
                {
                    // If maximum retries exceeded, throw exception
                    if (++retryCount > maxRetries)
                    {
                        Console.WriteLine($"Failed to download file after {maxRetries} attempts. Error: {ex.Message}");
                        throw;
                    }

                    // Calculate exponential back-off with jitter delay
                    var delay = TimeSpan.FromSeconds(Math.Pow(2, retryCount)) + TimeSpan.FromMilliseconds(new Random().Next(0, 1000));

                    // Log the retry attempt
                    Console.WriteLine($"Download failed, retrying in {delay.TotalSeconds} seconds... ({retryCount} of {maxRetries} retries)");

                    // Wait before next retry attempt
                    await Task.Delay(delay);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions as necessary here...
                    throw;
                }
            }
        }




        public void UninstallApp( string uninstallPath)
        {
            if (Directory.Exists(AtlasVariables.installationPath))
            {
                ClipboardService.SetText(uninstallPath);
                System.Threading.Thread.Sleep(1000);


                // Launch the 'Add or Remove Programs' window

                // Create an instance of Actions class
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                // Press Win key
                action.KeyDown(Keys.Meta);

                // Press E key
                action.SendKeys("e");

                // Release Win key
                action.KeyUp(Keys.Meta);

                // Perform the action
                action.Perform();


                Thread.Sleep(2000);


                SetFocusToFileExplorer();

                // Use CTRL+L to focus on the address bar, then paste the clipboard content 
                action.KeyDown(Keys.Control).SendKeys("l").KeyUp(Keys.Control).SendKeys(Keys.Control + "v").KeyUp(Keys.Control).SendKeys(Keys.Enter).Perform();

                //Wait for app to uninstall
                Thread.Sleep(90000);
            }






        }

        public void MinimizeAllWindows(WindowsDriver<WindowsElement> driver)
        {
            // Create an instance of the Actions class
            var actions = new OpenQA.Selenium.Interactions.Actions(driver);

            // Press the Windows key + D key combination
            actions.KeyDown(Keys.Meta).SendKeys("d").KeyUp(Keys.Meta).Perform();
        }
        public void SetFocusToFileExplorer()
        {
            

            // Locate the File Explorer window using the appropriate locator
            WindowsElement fileExplorerWindow = driver.FindElementByClassName("CabinetWClass"); // Example locator for File Explorer

            fileExplorerWindow.Click();
        }

        public void CloseAllFileExplorerWindows()
        {
            // Locate all File Explorer windows using the appropriate locator
            IReadOnlyCollection<WindowsElement> fileExplorerWindows = driver.FindElementsByClassName("CabinetWClass"); // Example locator for File Explorer

            // Iterate through the File Explorer windows and close them
            foreach (var fileExplorerWindow in fileExplorerWindows)
            {
                fileExplorerWindow.Click();
                fileExplorerWindow.SendKeys(Keys.Alt + "F4");
            }
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
            try
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath);

            }
            catch (IOException ex)
            {
                // Handle the IOException
                Console.WriteLine($"An IOException occurred: {ex.Message}");
                // Perform error handling or other necessary actions
                // ...
            }



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



        //Search the file in Folder and return the file path
        public static string getFilePath(string folder, string fileName)
        {

            return Path.Combine(folder, fileName);
        }


    }

}





