using System.Net;

namespace Day5;

public class MapProcessor
{
    private List<long> _seeds;
    
    public List<(long, long)> GetSeedsAsRange()
    {
        var seedRanges = new List<(long, long)>();
        for (var i = 0; i < _seeds.Count; i += 2)
        {
            seedRanges.Add((_seeds[i], _seeds[i+1]));
        }

        return seedRanges;
    }

    private Dictionary<Category, Map> Maps { get; set; } = new();
    
    public MapProcessor(string file)
    {
        var data = File.ReadAllLines(file);
        var seeds = data[0].Split(":")[1].Split(" ").Where(x=>x.Any());
        _seeds = seeds.Select(long.Parse).ToList();
        BuildMaps(data.Skip(2).ToList());
    }

    public long Get(Category from, Category to, long fromValue)
    {
        while (true)
        {
            if (Maps.TryGetValue(from, out var map))
            {
                var toValue = map.GetTo(fromValue);
                if (map.To == to) return toValue;
                from = map.To;
                fromValue = toValue;
            }
            else
                throw new Exception($"Couldn't find map that starts with {from}");
        }
    }

    private void BuildMaps(List<string> input)
    {
        List<string> mapInput = new();
        foreach (var row in input)
        {
            if(row.Any())
                mapInput.Add(row);
            else if(mapInput.Any())
            {
                BuildMap(mapInput);
                mapInput.Clear();
            }
        }
        if(mapInput.Any())
            BuildMap(mapInput);
    }
    
    private void BuildMap(List<string> input)
    {
        var map = new Map(input[0]);
        input = input.Skip(1).ToList();
        
        foreach (var row in input)
        {
            var mapping = new Mapping(row);
            map.AddMapping(mapping);
        }
        
        Maps.Add(map.From, map);
    }
}