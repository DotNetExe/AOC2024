namespace AOC2024.Day07;

public static class BridgeRepair
{
    public static string[] GetInput(string path)
    {
        return File.ReadAllLines(path);
    }

    public static void DoCombinations(string[] input)
    {
        Int128 finalSum = 0;
        foreach (var current in input)
        {
            var parts = current.Split(": ");
            var result = Int64.Parse(parts[0]);
            
            var queue = new Queue<int>(parts[1].Split(" ").Select(int.Parse));
            var operators= GenerateCombinations(queue.Count - 1);
            
            foreach (var op in operators)
            {
                var queueCopy = new Queue<int>(queue);
                Int128 sum = queueCopy.Dequeue();

                foreach (var currOperator in op)
                {
                    switch (currOperator)
                    {
                        case Operators.Add:
                            sum += queueCopy.Dequeue();
                            break;
                        case Operators.Multiply:
                            sum *= queueCopy.Dequeue();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                if (sum != result) 
                    continue;
                
                finalSum += sum;
                break;
            }
        }
        
        Console.WriteLine(finalSum);
    }
    
    private static List<Operators[]> GenerateCombinations(int n)
    {
        var result = new List<Operators[]>();
        GenerateCombinationsRecursive(n, new Operators[n], 0, result);
        return result;
    }
    
    private static void GenerateCombinationsRecursive(int n, Operators[] current, int index, List<Operators[]> result)
    {
        if (index == n)
        {
            result.Add((Operators[])current.Clone());
            return;
        }

        current[index] = Operators.Add;
        GenerateCombinationsRecursive(n, current, index + 1, result);

        current[index] = Operators.Multiply;
        GenerateCombinationsRecursive(n, current, index + 1, result);
    }

    private enum Operators
    {
        Add,
        Multiply
    }
}