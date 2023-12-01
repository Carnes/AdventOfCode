var inputs = await File.ReadAllLinesAsync("input.txt");
var outputs = new List<string>();
var total = 0;

var stringNumbers = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", };

static List<ResultSet> GetStringNumberIndexs(string stringNumber, string input, string number)
{
    var results = new List<ResultSet> { 
        new ResultSet{Index = input.IndexOf(stringNumber), Value = number},
        new ResultSet{Index = input.LastIndexOf(stringNumber), Value = number}
    };
    return results.Where(x => x.Index >= 0).DistinctBy(x=>x.Index).ToList();
}

foreach (var input in inputs)
{
    var numbers = input.ToArray()
        .Select((x, index) => new ResultSet { Value = x.ToString(), Index = index })
        .Where(x => int.TryParse(x.Value, out var y))
        .ToList();

    var stringNumbersFound = stringNumbers.SelectMany((x, index) => GetStringNumberIndexs(x, input, index.ToString()))
        .ToList();

    var results = numbers.Union(stringNumbersFound).OrderBy(o => o.Index);
    var result = results.First().Value + results.Last().Value;
    outputs.Add(result);
    total += int.Parse(result);
    Console.WriteLine($"input: {input}, output: {result}");
}
Console.WriteLine($"total: {total}");
File.WriteAllLines("output.txt", outputs);
Console.ReadKey();

public class ResultSet
{
    public string Value { get; set; }    
    public int Index { get; set; }
}