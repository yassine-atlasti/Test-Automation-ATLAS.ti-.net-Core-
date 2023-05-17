
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Test_Automation_Core.Actions
{


    public class SystemActions
    {

        public async Task DownloadAndInstallAtlasAsync(string downloadUrl, string downloadPath, string installPath)
        {
            await DownloadAtlasAsync(downloadUrl, downloadPath);
            InstallAtlas(downloadPath, installPath);
        }

        private async Task DownloadAtlasAsync(string url, string destinationPath)
        {
            using HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);

            using var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None);
            await response.Content.CopyToAsync(fileStream);

            Console.WriteLine($"File downloaded to {destinationPath}");
        }


        private void InstallAtlas(string downloadPath, string installPath)
        {
            Process process = new Process();

            process.StartInfo.FileName = downloadPath;
            process.StartInfo.Arguments = $"/S /D={installPath}";

            process.Start();

            process.WaitForExit();

            Console.WriteLine($"ATLAS.ti installed at {installPath}");
        }


        public void UninstallAtlas(string majorVersion)
        {
            Process.Start("cmd.exe", $"/C wmic product where name=\"ATLAS.ti {majorVersion}\" call uninstall");
            // Please replace "ATLAS.ti" with the exact name of the product as registered in the system
        }

        public void CreateFolder(string folderName)
        {
            Directory.CreateDirectory(folderName);
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



    }

}

