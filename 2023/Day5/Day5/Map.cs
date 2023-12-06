namespace Day5;

public class Map
{
    public Category To { get; set; }
    public Category From { get; set; }
    public List<Mapping> Mappings { get; set; } = new();

    public Map(string input)
    {
        var fromAndTo = input.Split(" ")[0].Split("-to-");
        From = Enum.Parse<Category>(fromAndTo[0]);
        To = Enum.Parse<Category>(fromAndTo[1]);
    }

    public Int64 GetTo(Int64 from)
    {
        foreach (var m in Mappings)
        {
            if (m.SourceStart <= from && m.SourceStart + m.RangeLength >= from)
            {
                var to = from - m.SourceStart + m.DestinationStart;
                return to;        
            }
        }

        return from;
    }
}