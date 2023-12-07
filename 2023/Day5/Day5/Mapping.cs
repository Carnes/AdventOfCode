using static System.Int64;

namespace Day5;

public class Mapping
{
    public readonly long DestinationStart;
    public readonly long SourceStart;
    public readonly long RangeLength;

    public Mapping(string input)
    {
        var parts = input.Split(" ").Where(x=>x.Any()).ToList();
        DestinationStart = Parse(parts[0]);
        SourceStart = Parse(parts[1]);
        RangeLength = Parse(parts[2]);
    }
}