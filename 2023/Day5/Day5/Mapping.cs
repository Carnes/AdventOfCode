namespace Day5;

public class Mapping
{
    // public Category From { get; set; }
    // public Category To { get; set; }
    public Int64 DestinationStart { get; set; }
    public Int64 SourceStart { get; set; }
    public Int64 RangeLength { get; set; }

    public Mapping(string input)
    {
        var parts = input.Split(" ").Where(x=>x.Any()).ToList();
        DestinationStart = Int64.Parse(parts[0]);
        SourceStart = Int64.Parse(parts[1]);
        RangeLength = Int64.Parse(parts[2]);
    }
}