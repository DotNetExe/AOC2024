using System.Reflection;
using AOC2024.Day01;
using AOC2024.Day02;

namespace AOC2024;

class Program
{
    static void Main(string[] args)
    {
        //RunDay01();
        RunDay02();
    }

    private static void RunDay01()
    {
        var directory = GetRuntimeDir();

        const bool isExample = false;
        var path = Path.Combine(directory, "Day01", "Datasets", isExample ? "example.txt" :  "day01_data.txt");
        
        var inputData = TotalDistance.ReadInTestData(path);
        
        TotalDistance.CalculateDistance(inputData);
        TotalDistance.CalculateSimilarity(inputData);
    }

    private static void RunDay02()
    {
        var directory = GetRuntimeDir();

        const bool isExample = true;
        var path = Path.Combine(directory, "Day02", "Datasets", isExample ? "example.txt" :  "day02_data.txt");
        
        var inputData = Reports.ReadInTestData(path);
        Reports.CheckForSafeness(inputData);
    }

    private static string GetRuntimeDir()
    {
        var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (directory == null)
            throw new IOException("Directory could not be found");
        
        return directory;
    }
}