using NUnit.Engine;

public class TestRunner
{
    public static void RunTestByCategory(string testAssemblyPath, string targetNamespace, string folderName)
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
    }

}

