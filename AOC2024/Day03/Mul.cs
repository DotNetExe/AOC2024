using System.Text.RegularExpressions;

namespace AOC2024.Day03;

public class Mul
{
    private static readonly Regex MulDetect = new Regex(@"mul\((\d+),(\d+)\)", RegexOptions.Compiled);
    public static string GetTestData(string path)
    {
        var result = File.ReadAllText(path);
        return result;
    }

    public static void DoMul(string input)
    {
        var matches = MulDetect.Matches(input);
        var sum = 0;
        foreach (Match match in matches)
        {
            var first = int.Parse(match.Groups[1].Value);
            var secondGroup = int.Parse(match.Groups[2].Value);
            
            var multiply = first * secondGroup;
            sum += multiply;
        }
        Console.WriteLine(sum);
    }

    public static void DoMulWithDoAndDont(string input)
    {
        var split = Regex.Split(input, @"(do\(\)|don't\(\))");

        var insideDo = true;
        var results = new List<string>();
        foreach (var section in split)
        {
            if (section.StartsWith("do()"))
                insideDo = true;
            else if (section.StartsWith("don't()"))
                insideDo = false;
            
            if (insideDo)
                results.Add(section);
        }

        DoMul(string.Join("", results));
    }
}