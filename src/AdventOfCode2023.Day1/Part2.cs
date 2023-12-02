namespace AdventOfCode2023.Day1;

public static class Part2
{
    public static void Run()
    {
        string[] lines = File.ReadAllLines("../../../input.txt");

        int total = 0;

        string[][] intValues =
        {
            new[] { "one", "1" },
            new[] { "two", "2" }, 
            new[] { "three", "3" }, 
            new[] { "four", "4" },
            new[] { "five", "5" },
            new[] { "six", "6" },
            new[] { "seven", "7" },
            new[] { "eight", "8" },
            new[] { "nine", "9" }
        };

        Dictionary<int, List<int>> intValuesDict = new Dictionary<int, List<int>>();

        foreach (string line in lines)
        {
            for (int i = 1; i < intValues.Length + 1; i++)
            {
                intValuesDict.Add(i, new List<int>());
            }
    
            for (int i = 1; i < intValues.Length + 1; i++)
            {
                intValuesDict[i].AddRange(line.AllIndexesOf(intValues[i - 1][0]));
                intValuesDict[i].AddRange(line.AllIndexesOf(intValues[i - 1][1]));
        
                if(intValuesDict[i].Count == 0)
                    continue;
        
                // Remove sort
                intValuesDict[i] = intValuesDict[i].OrderBy(x => x).ToList();
            }

            // Get first & last int according to overall index
            int firstInt = intValuesDict.Where(x => x.Value.Any()).MinBy(x => x.Value.First()).Key;
            int lastInt = intValuesDict.Where(x => x.Value.Any()).MaxBy(x => x.Value.Last()).Key;

            total += int.Parse($"{firstInt}{lastInt}");
            intValuesDict.Clear();
    
            Console.WriteLine($"Line: {line} - Value: {firstInt}{lastInt} - Total: {total}");
        }
    }
}