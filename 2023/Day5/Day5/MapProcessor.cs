using System.Net;

namespace Day5;

public class MapProcessor
{
    public List<Int64> Seeds;
    
    public List<(Int64, Int64)> GetSeedsAsRange()
    {
        var seedRanges = new List<(Int64, Int64)>();
        for (var i = 0; i < Seeds.Count(); i += 2)
        {
            seedRanges.Add((Seeds[i], Seeds[i+1]));
        }

        return seedRanges;
    }
    public Dictionary<Category, Map> Maps { get; set; } = new();
    
    public MapProcessor(string file)
    {
        var data = File.ReadAllLines(file);
        var seeds = data[0].Split(":")[1].Split(" ").Where(x=>x.Any());
        Seeds = seeds.Select(x => Int64.Parse(x)).ToList();
        BuildMaps(data.Skip(2).ToList());
    }

    public Int64 Get(Category from, Category to, Int64 fromValue)
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
            map.Mappings.Add(mapping);
        }
        
        Maps.Add(map.From, map);
    }
    
    
}