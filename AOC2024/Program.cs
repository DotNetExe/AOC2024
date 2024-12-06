using System.Reflection;
using AOC2024.Day01;
using AOC2024.Day02;
using AOC2024.Day03;
using AOC2024.Day06;

namespace AOC2024;

class Program
{
    static void Main(string[] args)
    {
        //RunDay01();
        //RunDay02();
        // RunDay03();
        RunDay06();
    }

    private static void RunDay01()
    {
        const bool isExample = false;
        var path = GetFilePath("Day01", isExample);
        
        var inputData = TotalDistance.ReadInTestData(path);
        
        TotalDistance.CalculateDistance(inputData);
        TotalDistance.CalculateSimilarity(inputData);
    }

    private static void RunDay02()
    {
        const bool isExample = true;
        var path = GetFilePath("Day02", isExample);
        
        var inputData = Reports.ReadInTestData(path);
        Reports.CheckForSafeness(inputData);
    }

    private static void RunDay03()
    {
        const bool isExample = false;

        var path = GetFilePath("Day03", isExample);
        
        Mul.DoMul(Mul.GetTestData(path));
        Mul.DoMulWithDoAndDont(Mul.GetTestData(path));
    }

    private static void RunDay06()
    {
        const bool isExample = false;

        var path = GetFilePath("Day06", isExample);
        
        var room = GuardGallivant.GetRoom(path, out var guardStartCoordinate);
        GuardGallivant.WalkRoom(room, guardStartCoordinate);
    }

    private static string GetRuntimeDir()
    {
        var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (directory == null)
            throw new IOException("Directory could not be found");
        
        return directory;
    }

    private static string GetFilePath(string day, bool isExample)
    {
        var directory = GetRuntimeDir();
        return Path.Combine(directory, day, "Datasets", isExample ? "example.txt" :  $"{day.ToLower()}_data.txt");
    }
}