namespace Day5;

public class Mapping
{
    public Int64 DestinationStart;
    public Int64 SourceStart;
    public Int64 RangeLength;

    public Mapping(string input)
    {
        var parts = input.Split(" ").Where(x=>x.Any()).ToList();
        DestinationStart = Int64.Parse(parts[0]);
        SourceStart = Int64.Parse(parts[1]);
        RangeLength = Int64.Parse(parts[2]);
    }
}