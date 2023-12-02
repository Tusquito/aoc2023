namespace AdventOfCode2023.Day1;

public static class StringExtensions
{
    public static List<int> AllIndexesOf(this string str, string search)
    {
        int minIndex = str.IndexOf(search, StringComparison.Ordinal);
        List<int> indexes = new List<int>();
        while (minIndex != -1)
        {
            indexes.Add(minIndex);
            minIndex = str.IndexOf(search, minIndex + search.Length, StringComparison.Ordinal);
        }

        return indexes;
    }
}