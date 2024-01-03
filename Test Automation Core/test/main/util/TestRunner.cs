using NUnit.Engine;
using System.Xml;
using Test_Automation_Core.test.main.tests;

public class TestRunner
{
    public static void InitializeTestRun(string testCategory)
    {
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string uniqueTestRunFolder = Path.Combine(InitTests._testSuiteFolder, $"TestRun_{testCategory}_{timestamp}");

       // Create subdirectories for passed and failed tests
        Directory.CreateDirectory(Path.Combine(uniqueTestRunFolder, "Passed"));
        Directory.CreateDirectory(Path.Combine(uniqueTestRunFolder, "Failed"));
    }
    public static bool RunTestByCategory(string testAssemblyPath, string targetNamespace, string folderName)
    {
        // Initialize the test engine
        var testEngine = TestEngineActivator.CreateInstance();

        // Create a simple test package
        var package = new TestPackage(testAssemblyPath);

        // Get a runner for the test package
        var runner = testEngine.GetRunner(package);

        // Create a filter to run tests only in the given namespace and folder (Category)
        var filterBuilder = new TestFilterBuilder();
        filterBuilder.SelectWhere($"namespace == {targetNamespace} && cat == {folderName}");
        var filter = filterBuilder.GetFilter();

        // Load and run the tests
        runner.Load();
        var result = runner.Run(null, filter);

        // Output results to the console
        Console.WriteLine($"Test Results: {result}");
        //


        bool res = AssertTestRun(result);
            return res; 
    }

    public static bool AssertTestRun(XmlNode result)
    {
        // Assuming result is an XmlNode, parse it to find the fail count
        var failedCountNode = result.SelectSingleNode("//test-suite/@failed");
        int failedCount = 0;
        if (failedCountNode != null && int.TryParse(failedCountNode.Value, out failedCount) && failedCount > 0)
        {
            Console.WriteLine($"Tests failed: {failedCount}");
            return false; // There are failed tests
        }

        Console.WriteLine("All tests passed.");
        return true; // No failed tests
    }
}

