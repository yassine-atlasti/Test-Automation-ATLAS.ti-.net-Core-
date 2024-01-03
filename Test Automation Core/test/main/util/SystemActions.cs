
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Test_Automation_Core.test.resources.test;
using Test_Automation_Core.test.resources.test_data.winappdriver;
using TextCopy;
using System.Diagnostics;
using System.Management;
using System.Text.RegularExpressions;
using System.Globalization;

using System.Windows.Forms;


namespace Test_Automation_Core.test.utilities.util
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


        private void StartWinAppDriver()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = WinAppDriverConfig.winAppDriverPath, // Replace with the correct path
                WindowStyle = ProcessWindowStyle.Hidden, // Hide the window
                CreateNoWindow = true // Do not create a window
            };

            // Check if the application is already running
            Process[] processes = Process.GetProcessesByName(WinAppDriverConfig.winAppDriverAppName);

            if (processes.Length == 0)
            {
                Process.Start(startInfo);
                Thread.Sleep(2000);

            }
        }

        public WindowsDriver<WindowsElement> ClassInitialize(string appPath, int maxRetryCount = 10)
        {
            string applicationPath = appPath;
            string applicationName = Path.GetFileNameWithoutExtension(applicationPath);
            WindowsDriver<WindowsElement> driver = null;

            StartWinAppDriver(); // start the WinAppDriver service

            if (appPath == AtlasVariables.appPath)
            {
                OpenApp(applicationPath, applicationName);
            }

            AppiumOptions appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", applicationPath);
            appOptions.AddAdditionalCapability("deviceName", "WindowsPC");

            int attempt = 0;
            bool isDriverInitialized = false;

            while (attempt < maxRetryCount && !isDriverInitialized)
            {
                try
                {
                    driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appOptions);

                    if (driver != null)
                    {
                        // Perform a simple operation to check if the driver is responding
                        if (driver.WindowHandles.Count > 0)
                        {
                            isDriverInitialized = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Console.WriteLine($"Attempt {attempt + 1}: Driver initialization failed. {ex.Message}");

                    // Increment the attempt counter and possibly wait before retrying
                    attempt++;
                    Thread.Sleep(2000); // Wait for 2 seconds before retrying
                }
            }

            if (!isDriverInitialized)
            {
                throw new Exception("Unable to initialize the WindowsDriver after multiple attempts.");
            }

            return driver;
        }



        public int OpenApp(string applicationPath, string applicationName)
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
                    Thread.Sleep(intervalInMilliseconds);
                    elapsedWaitTimeInMilliseconds += intervalInMilliseconds;
                }
            }
            else
            {
                // If the application is already running, attach to the first instance
                process = processes[0];
            }
            return process.Id;
        }



        public async Task DownloadFileAsync(string url, string fileName, int maxRetries = 10)
        {
            // Create HttpClient to send HTTP requests
            using var httpClient = new HttpClient();


            // Create the full file path
            var filePath = Path.Combine(AtlasVariables.downloadPath, fileName);

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
                catch (Exception ex) when (ex is HttpRequestException || ex is IOException && ex.InnerException is SocketException)
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




        public void UninstallAtlas()
        {
            KillProcessByName("Atlasti" + AtlasVariables.actualMajor);

            if (Directory.Exists(AtlasVariables.installationPath))
            {
                List<string> foundPrograms = FindProgram("ATLAS.ti " + AtlasVariables.actualMajor);
                string firstProgram = "";
                if (foundPrograms.Count > 0)
                {
                    firstProgram = foundPrograms[0];
                    Console.WriteLine("First program found: " + firstProgram);
                }


                string uninstallPath = AtlasVariables.uninstallPathDirectory + "\\" + firstProgram;

                ClipboardService.SetText(uninstallPath);
                Thread.Sleep(1000);


                // Launch the 'Add or Remove Programs' window

                // Create an instance of Actions class
                var action = new Actions(driver);

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



            // MinimizeAllWindows(driver);
            KillProcessByName("Setup - ATLAS.ti " + AtlasVariables.actualMajor + " (32 bit)");

            KillProcessByName("explorer");


        }



        public void MinimizeAllWindows(WindowsDriver<WindowsElement> driver)
        {
            // Create an instance of the Actions class
            var actions = new Actions(driver);

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


        public static string GetDesktopPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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
            bool state = false;
            for (int i = 0; i < timeoutInSeconds; i++)
            {
                try
                {
                    var element = driver.FindElementByTagName(tagName).FindElementByName(name);

                    if (element.Displayed)
                    {
                        state = true;
                        element.Click();
                        break;


                    }

                }
                catch (WebDriverException)
                {
                    // Ignore the exception, and try again
                }

                // Wait for 1 second before trying again
                Thread.Sleep(1000);
            }

            return state;
        }


        public static void KillProcessByName(string processName)
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






        public static string[] GetFilenamesInDirectoryByType(string directoryPath, string fileType)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException($"The directory {directoryPath} does not exist.");
            }

            // Ensure fileType starts with a dot for consistency
            if (!fileType.StartsWith("."))
            {
                fileType = "." + fileType;
            }

            // Fetching full paths and converting them to just filenames
            string[] fullPaths = Directory.GetFiles(directoryPath, $"*{fileType}*");
            for (int i = 0; i < fullPaths.Length; i++)
            {
                fullPaths[i] = Path.GetFileName(fullPaths[i]);
            }
            return fullPaths;
        }


        // Locate a file within a folder by using its file path, extension, and a substring of its name.
        // This provides a flexible way to find files without being sensitive to naming conventions.
        public static string FindFilesByPartialName(string directoryPath, string partialFileName, string fileExtension, out bool isFound)
        {
            isFound = false;

            if (Directory.Exists(directoryPath))
            {
                string searchPattern = "*" + fileExtension;
                string[] files = Directory.GetFiles(directoryPath, searchPattern);

                foreach (string file in files)
                {
                    if (Path.GetFileName(file).Contains(partialFileName))
                    {
                        isFound = true;
                        return file; // Return the found file
                    }
                }

                // If not found, look in the subdirectories
                string[] subDirectories = Directory.GetDirectories(directoryPath);
                foreach (string subDirectory in subDirectories)
                {
                    string foundFile = FindFilesByPartialName(subDirectory, partialFileName, fileExtension, out isFound);
                    if (isFound)
                    {
                        return foundFile; // Return the found file from the subdirectory
                    }
                }
            }

            return null; // Return null if not found
        }

        // Helper method to take a screenshot
        public static void TakeScreenshot(WindowsDriver<WindowsElement> driver, string logFolderPath, string screenshotFileName)
        {

            Screenshot screenshot = driver.GetScreenshot();

            string screenshotPath = Path.Combine(logFolderPath, screenshotFileName);
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
        }

        public static string GetOneDrivePath()
        {
            string oneDrivePath = null;

            // For consumer accounts, the path is usually in the following registry key
            oneDrivePath = (string)Registry.GetValue(
                @"HKEY_CURRENT_USER\Software\Microsoft\OneDrive",
                "UserFolder",
                null);

            // For business accounts, you might need to look at another location
            if (string.IsNullOrEmpty(oneDrivePath))
            {
                oneDrivePath = (string)Registry.GetValue(
                    @"HKEY_CURRENT_USER\Software\Microsoft\OneDrive\Accounts\Business1",
                    "UserFolder",
                    null);
            }

            return oneDrivePath;
        }





        public static List<string> FindProgram(string programName)
        {
            List<string> programNames = new List<string>();

            try
            {
                // Query to fetch installed programs
                string wmiQuery = "SELECT * FROM Win32_Product WHERE Name LIKE '%" + programName + "%'";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery);
                ManagementObjectCollection results = searcher.Get();

                // Add the found programs to the list
                foreach (ManagementObject result in results)
                {
                    programNames.Add(result["Name"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return programNames;
        }



public static string GetCurrentInstalledVersion()
    {
        // Check if the directory exists
        if (!Directory.Exists(AtlasVariables.installationPath))
        {
            Console.WriteLine("Installation path does not exist.");
            return ""; // Return empty string as the directory does not exist
        }

        try
        {
            string versionFilePath = Path.Combine(AtlasVariables.installationPath, "ATLAS.ti.txt");

            if (!File.Exists(versionFilePath))
            {

                Console.WriteLine("Version file does not exist.");
                return ""; // Return empty string as the file does not exist
            }

            string content = File.ReadAllText(versionFilePath);
            // This regex matches a version number pattern like "23.3.28949.2"
            Match match = Regex.Match(content, @"\d+(\.\d+)+");

            if (match.Success)
            {

                    return match.Value; // Return the matched version string
            }
            else
            {

                    Console.WriteLine("No version number found in the file.");
            }
        }
        catch (Exception ex)
        {

                Console.WriteLine("Error reading version file: " + ex.Message);
        }

        return ""; // Return empty string if unable to read version or other issues
    }

        public static string GetOperatingSystemVersion()
        {
            var os = Environment.OSVersion;
            var version = os.Version;

            // Windows version numbers: https://docs.microsoft.com/en-us/windows/win32/sysinfo/operating-system-version
            // Note: These version numbers are subject to change and might not always match the actual OS name due to OS version number reporting changes in newer Windows versions.
            if (os.Platform == PlatformID.Win32NT)
            {
                if (version.Major == 10)
                {
                    if (version.Build < 22000)
                    {
                        return "Windows 10";
                    }
                    else
                    {
                        return "Windows 11";
                    }
                }
            }

            // Return a generic OS version string if not Windows 10 or 11
            return os.VersionString;
        }

        public static string GetDownloadsFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
        }
        

    }
}





