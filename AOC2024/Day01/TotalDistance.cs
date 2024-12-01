namespace AOC2024.Day01;

public static class TotalDistance
{
    public static int[][] ReadInTestData(string path)
    {
        var resultingArray = File.ReadAllLines(path)
            .Select(line => line.Split(" ")
                .Where(x => x.Length > 0)
                .Select(int.Parse)
                .ToArray())
            .ToArray();
        
        var rows = Enumerable.Range(0, resultingArray.GetLength(0))
            .Select(i => new int[] { resultingArray[i][0], resultingArray[i][1] })
            .ToArray();
        
        var sortedRows = rows
            .OrderBy(row => row[0])
            .ThenBy(row => row[1])
            .ToArray();
        
        var secondColumn = sortedRows
            .Select(row => row[1])
            .OrderBy(x => x)
            .ToArray();
        
        for (var i = 0; i < sortedRows.Length; i++)
            sortedRows[i][1] = secondColumn[i];
        
        for (var i = 0; i < sortedRows.Length; i++)
        {
            resultingArray[i][0] = sortedRows[i][0];
            resultingArray[i][1] = sortedRows[i][1];
        }

        return resultingArray;
    }
    
    /// <summary>
    /// Part 01
    /// </summary>
    /// <param name="input"></param>
    public static void CalculateDistance(int[][] input)
    {
        var sum = input.Select(row => row)
            .Select(x => Math.Abs(x[0] - x[1]))
            .Sum();
        
        Console.WriteLine($"Part01 - {sum}");
    }
    
    /// <summary>
    /// Part 2
    /// </summary>
    /// <param name="input"></param>
    public static void CalculateSimilarity(int[][] input)
    {
        var similarities = new List<int>();

        var secondCol = Enumerable.Range(0, input.GetLength(0))
            .Select(i => input[i][1] )
            .ToArray();
        
        for (var row = 0; row < input.GetLength(0); row++)
        {
            var leftCol = input[row][0];
            var amountInRight = secondCol.Count(x => x == leftCol);

            similarities.Add(leftCol * amountInRight);
        }

        var sum = similarities.Sum();
        
        Console.WriteLine($"Part02 - {sum}");
    }
}