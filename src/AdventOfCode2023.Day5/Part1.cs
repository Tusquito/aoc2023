namespace AdventOfCode2023.Day5;

public static class Part1
{
    public static void Run(string[] lines)
    {
        long[] seeds = lines[0].Split(' ').Skip(1).Select(long.Parse).ToArray();
        Dictionary<long, long> seedMap = new Dictionary<long, long>();
        Dictionary<string, List<MapValue>> maps = new Dictionary<string, List<MapValue>>();
        string lastMapKey = string.Empty;

        foreach (long seed in seeds)
        {
            seedMap[seed] = seed;
        }
        
        //format file
        foreach (string line in lines.Skip(2))
        {
            if(string.IsNullOrEmpty(line))
            {
                continue;
            }
            
            if(line.Contains(':'))
            {
                lastMapKey = line[..(line.IndexOf("map", StringComparison.Ordinal) - 1)];
                maps.Add(lastMapKey, new List<MapValue>());
                continue;
            }
            
            long[] mapValues = line.Split(' ').Select(long.Parse).ToArray();
            maps[lastMapKey].Add(new MapValue
            {
                DestinationRangeStart = mapValues[0],
                SourceRangeStart = mapValues[1],
                RangeLength = mapValues[2]
            });
        }

        for (int i = 0; i < maps.Count; i++)
        {
            var map = maps.ElementAt(i);
            foreach (long seed in seeds)
            {
                if(!map.Value.Any(x => seedMap[seed] >= x.SourceRangeStart && seedMap[seed] <= x.SourceRangeStart + x.RangeLength))
                {
                    continue;
                }
                
                MapValue mapValue = map.Value.First(x => seedMap[seed] >= x.SourceRangeStart && seedMap[seed] <= x.SourceRangeStart + x.RangeLength);

                seedMap[seed] = mapValue.DestinationRangeStart + (seedMap[seed] - mapValue.SourceRangeStart);
            }
        }
        
        Console.WriteLine("Part 1: " + seedMap.Min(x => x.Value));
    }
}

internal class MapValue
{
    public long DestinationRangeStart { get; init; }
    public long SourceRangeStart { get; init; }
    public long RangeLength { get; init; }
}