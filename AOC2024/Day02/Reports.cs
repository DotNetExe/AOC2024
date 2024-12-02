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
            var isSafe = HandleRowDataPart02(data[row]);

            if (isSafe)
                safeReports++;
        }

        Console.WriteLine($"Safe Reports: {safeReports}");
    }

    private static bool HandleRowDataPart01(int[] data)
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
    
    private static bool HandleRowDataPart02(int[] data)
    {
        var flag = ReportState.Unknown;
        var reference = data[^1];
        var results = new List<bool>();

        for (int ignoredIdx = 0; ignoredIdx < data.Length; ignoredIdx++)
        {
            for (int x = data.Length-1; x > 0; x--)
            {
                if (ignoredIdx == x)
                    continue;
                
                var current = data[x-1];
                var factor = Math.Abs(current - reference);

                if (factor > 3 || factor == 0)
                    results.Add(false);

                if (reference > current)
                {
                    if (flag != ReportState.Unknown && flag == ReportState.Increase)
                        results.Add(false);
                    flag = ReportState.Decrease;
                }
                else
                {
                    if (flag != ReportState.Unknown && flag == ReportState.Decrease)
                        results.Add(false);
                    flag = ReportState.Increase;
                }

                reference = current;
            }
        }

        if (results.Count == 0)
            return true;

        return false;
        
        // for (var i = 1; i < data.Length; i++)
        // {
        //     var current = data[i];
        //     var factor = Math.Abs(current - reference);
        //
        //     if (factor > 3 || factor == 0)
        //         return false;
        //
        //     if (reference > current)
        //     {
        //         if (flag != ReportState.Unknown && flag == ReportState.Increase)
        //             return false;
        //         flag = ReportState.Decrease;
        //     }
        //     else
        //     {
        //         if (flag != ReportState.Unknown && flag == ReportState.Decrease)
        //             return false;
        //         flag = ReportState.Increase;
        //     }
        //
        //     reference = current;
        // }
    }

    private enum ReportState
    {
        Increase,
        Decrease,
        Unknown
    }
}