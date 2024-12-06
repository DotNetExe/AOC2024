namespace AOC2024.Day02;

public class Reports
{
    public static int[][] ReadInTestData(string path)
    {
        var resultingArray = File.ReadAllLines(path)
            .Select(line => line.Split(" ")
                .Where(x => x.Length > 0)
                .Select(int.Parse)
                .ToArray())
            .ToArray();

        return resultingArray;
    }

    public static void CheckForSafeness(int[][] data)
    {
        var safeReports = 0;
        for (int row = 0; row < data.Length; row++)
        {
            var isSafe = CheckRowSafety(data[row]);

            if (isSafe)
                safeReports++;
            else
            {
                var anySafeByRemovingIdx = CheckRowSafetyWithDampener(data[row]);
                if (anySafeByRemovingIdx)
                    safeReports++;
            }
        }
        
        Console.WriteLine($"Safe Reports: {safeReports}");
    }

    private static bool CheckRowSafety(int[] data)
    {
        var flag = ReportState.Unknown;
        var reference = data[0];
        for (var i = 1; i < data.Length; i++)
        {
            var current = data[i];
            var factor = Math.Abs(current - reference);

            if (factor > 3 || factor == 0)
                return false;

            if (reference > current)
            {
                if (flag == ReportState.Increase)
                    return false;
                flag = ReportState.Decrease;
            }
            else
            {
                if (flag == ReportState.Decrease)
                    return false;
                flag = ReportState.Increase;
            }

            reference = current;
        }

        return true;
    }

    private static bool CheckRowSafetyWithDampener(int[] data)
    {
        var permutations = new List<int[]>();
        for (var i = 0; i < data.Length; i++)
        {
            var copy = data.ToList();
            copy.RemoveAt(i);
            permutations.Add(copy.ToArray());
        }
        
        return permutations.Select(CheckRowSafety).Any(x => x);
    }

    private enum ReportState
    {
        Increase,
        Decrease,
        Unknown
    }
}