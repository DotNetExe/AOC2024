using System.Reflection;
using AOC2024.Day01;

namespace AOC2024;

class Program
{
    static void Main(string[] args)
    {
        var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (directory == null)
            throw new IOException("Directory could not be found");

        const bool isExample = false;
        var path = Path.Combine(directory, "Day01", "Datasets", isExample ? "example.txt" :  "day01_data.txt");
        
        var inputData = TotalDistance.ReadInTestData(path);
        
        TotalDistance.CalculateDistance(inputData);
        TotalDistance.CalculateSimilarity(inputData);
    }
}