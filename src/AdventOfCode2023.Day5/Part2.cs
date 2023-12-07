namespace AdventOfCode2023.Day5;

public static class Part2
{
    public static void Run(string[] lines)
    {
        long[] seeds = lines[0].Split(' ').Skip(1).Select(long.Parse).ToArray();
        List<(long Start, long Length)> seedRanges = new();
        long minLocation , curr = 0;
        Dictionary<string, List<MapValue>> maps = new Dictionary<string, List<MapValue>>();
        string lastMapKey = string.Empty;
        
        //add pairs 2 by 2
        for (int i = 0; i < seeds.Length; i++)
        {
            if (i % 2 == 0)
            {
                seedRanges.Add((seeds[i], seeds[i + 1]));
            }
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

        minLocation = long.MaxValue;
        for (int j = 0; j < seedRanges.Count; j++)
        {
            (long Start, long Length) seedRange = seedRanges[j];
            
            for (long h = 0; h < seedRange.Length; h++)
            {
                curr = seedRange.Start + h;
                for (int i = 0; i < maps.Count; i++)
                {
                    var map = maps.ElementAt(i);
                    MapValue? mapValue = null;
                    
                    for (int k = 0; k < map.Value.Count; k++)
                    {
                        MapValue x = map.Value[k];
                        if (curr >= x.SourceRangeStart && curr <= x.SourceRangeStart + x.RangeLength)
                        {
                            mapValue = x;
                            break;
                        }
                    }
                    
                    if(mapValue == null)
                    {
                        continue;
                    }
                    
                    curr = mapValue.DestinationRangeStart + (curr - mapValue.SourceRangeStart);
                }
                if(curr < minLocation)
                    minLocation = curr;
            }
        }
        
        Console.WriteLine("Part 2: " + minLocation);
    }
}