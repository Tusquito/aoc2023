namespace AdventOfCode2023.Day4;

public static class Part1
{
    public static void Run(string[] lines)
    {
        int total = 0;
        //line format: Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
        foreach (string line in lines)
        {
            List<int> leftNumbers = line.Substring(line.IndexOf(':') + 1, line.IndexOf('|') - line.IndexOf(':') - 1)
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> rightNumbers = line[(line.IndexOf('|') + 1)..]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> results = rightNumbers.Intersect(leftNumbers).ToList();

            total += results.Count == 0 ? 0 : (int)Math.Pow(2, results.Count - 1);
        }
        Console.WriteLine("Part 1: " + total);
    }
}