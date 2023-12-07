namespace Day5;

public class Map
{
    public readonly Category To;
    public readonly Category From;
    private Mapping[] _mappings = Array.Empty<Mapping>();

    public Map(string input)
    {
        var fromAndTo = input.Split(" ")[0].Split("-to-");
        From = Enum.Parse<Category>(fromAndTo[0]);
        To = Enum.Parse<Category>(fromAndTo[1]);
    }

    public void AddMapping(Mapping m)
    {
        var mappings = _mappings.ToList();
        mappings.Add(m);
        _mappings = mappings.OrderByDescending(x => x.SourceStart).ToArray();
    }

    public long GetTo(long from)
    {
        foreach (var m in _mappings)
        {
            if (m.SourceStart > from || m.SourceStart + m.RangeLength < from) continue;
            var to = from - m.SourceStart + m.DestinationStart;
            return to;
        }

        return from;
    }
}