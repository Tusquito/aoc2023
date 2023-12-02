namespace AdventOfCode2023.Day2;

public class Part1
{
    public static void Run()
    {
        string[] lines = File.ReadAllLines("../../../input.txt");
        int total = 0;

        Dictionary<string, int> maxValues = new Dictionary<string, int>
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };
        
        // line format: Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
        foreach (string line in lines)
        {
            int gameNo = int.Parse(line.Substring(line.IndexOf(' '), line.IndexOf(':') - line.IndexOf(' ')));
            string[] gameSets = line[(line.IndexOf(':') + 2)..].Split(';');
            bool isValid = true;

            foreach (string set in gameSets)
            {
                string[] setDraws = set.Trim().Split(", ");

                foreach (string draw in setDraws)
                {
                    string[] drawParts = draw.Split(' ');
                    int drawValue = int.Parse(drawParts[0]);
                    string drawColor = drawParts[1];

                    if (drawValue <= maxValues[drawColor])
                    {
                        continue;
                    }
                    
                    isValid = false;
                    break;
                }
            }
            
            if (isValid)
            {
                total += gameNo;
            }

            Console.WriteLine($"Line: {line} - IsValid: {isValid} - Total: {total}");
        }
    }
}