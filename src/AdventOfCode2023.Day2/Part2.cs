namespace AdventOfCode2023.Day2;

public class Part2
{
    public static void Run()
    {
        string[] lines = File.ReadAllLines("../../../input.txt");
        int total = 0;

        // line format: Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
        foreach (string line in lines)
        {
            Dictionary<string, int> maxValues = new Dictionary<string, int>
            {
                { "red", 0 },
                { "green", 0 },
                { "blue", 0 }
            };

            int gameNo = int.Parse(line.Substring(line.IndexOf(' '), line.IndexOf(':') - line.IndexOf(' ')));
            string[] gameSets = line[(line.IndexOf(':') + 2)..].Split(';');

            foreach (string set in gameSets)
            {
                string[] setDraws = set.Trim().Split(", ");

                foreach (string draw in setDraws)
                {
                    string[] drawParts = draw.Split(' ');
                    int drawValue = int.Parse(drawParts[0]);
                    string drawColor = drawParts[1];

                    if (drawValue > maxValues[drawColor])
                    {
                        maxValues[drawColor] = drawValue;
                    }
                }
            }

            total += maxValues.Values.Aggregate((x, y) => x * y);

            Console.WriteLine(
                $"Game: {gameNo} - MaxValues: {maxValues["red"]}, {maxValues["green"]}, {maxValues["blue"]} - Total: {total}");
        }
    }
}