using System;
using System.Diagnostics;

public class PythonRunner
{
    public (int, int) GetElementCoordinates(string referenceImagePath)
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = @"C:\Users\yassine.mahfoudh\AppData\Local\Programs\Python\Python311\python.exe";
        start.Arguments = $@"""C:\Users\yassine.mahfoudh\source\repos\Test Automation Core\Test Automation Core\test\main\util\element_locator.py"" ""{referenceImagePath}""";
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;

        using (Process process = Process.Start(start))
        {
            using (StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd().Trim();

                if (string.IsNullOrEmpty(result))
                {
                    Console.WriteLine("Python script did not return any output.");
                    return (-1, -1); // Indicates an error
                }

                var parts = result.Split(',');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Python script output is not in the expected format.");
                    return (-1, -1); // Indicates an error
                }

                if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
                {
                    Console.WriteLine("Unable to parse the coordinates returned by Python script.");
                    return (-1, -1); // Indicates an error
                }

                return (x, y);
            }
        }
    }

        [Test]
    public void test()
    {
       var result = GetElementCoordinates(@"C:\\Users\\yassine.mahfoudh\\Desktop\\Screenshot 2023-12-07 142451.png\");

        var j = result;
    }
}
