namespace AdventOfCode2023.Day4;

public static class Part2
{
    public static void Run(string[] lines)
    {
        Dictionary<int, int> finalRes = new Dictionary<int, int>();

        for (int i = 1; i < lines.Length + 1; i++)
        {
            finalRes[i] = 1;
        }
        
        //line format: Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
        foreach (string line in lines)
        {
            int cardNo = int.Parse(line.Substring(line.IndexOf(' '), line.IndexOf(':') - line.IndexOf(' ')));
            
            List<int> leftNumbers = line.Substring(line.IndexOf(':') + 1, line.IndexOf('|') - line.IndexOf(':') - 1)
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> rightNumbers = line[(line.IndexOf('|') + 1)..]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> results = rightNumbers.Intersect(leftNumbers).ToList();

            for (int i = 1; i < results.Count + 1; i++)
            {
                finalRes[cardNo + i] += finalRes[cardNo];
            }
        }
        
        Console.WriteLine("Part 2: " + finalRes.Sum(x => x.Value));
    }
}