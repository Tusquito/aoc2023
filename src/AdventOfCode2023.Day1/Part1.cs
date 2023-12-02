namespace AdventOfCode2023.Day1;

public class Part1
{
    public static void Run()
    {
        string[] lines = File.ReadAllLines("../../../input.txt");

        int total = 0;

        foreach (var line in lines)
        {
            List<char> tmpIntOnlyLine = line.Where(char.IsDigit).ToList();
            int tmpValue;

            if(!tmpIntOnlyLine.Any())
                continue;

            if (tmpIntOnlyLine.Count == 1)
            {
                tmpValue = int.Parse($"{tmpIntOnlyLine.First()}{tmpIntOnlyLine.First()}");
                total += tmpValue;
                Console.WriteLine($"Line: {line} - Value: {tmpValue} - Total: {total}");
                continue;
            }

            tmpValue = int.Parse($"{tmpIntOnlyLine.First()}{tmpIntOnlyLine.Last()}");
            total += tmpValue;
            Console.WriteLine($"Line: {line} - Value: {tmpValue} - Total: {total}");
        }
    }
}