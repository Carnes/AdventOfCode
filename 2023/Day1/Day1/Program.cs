//using System.Text.RegularExpressions;
//string pattern = @"\ba\w*\b";
//string input = "An extraordinary day dawns with each new day.";
//Match m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
var inputs = await File.ReadAllLinesAsync("input.txt");
var outputs = new List<string>();
var total = 0;
foreach (var input in inputs)
{
    //var input = "nvfive8hvdth6fgnfgh";
    //var p1 = input.ToArray();
    //var p2 = p1.Where(x => int.TryParse(x.ToString(), out var y));
    var numbers = input.ToArray()
        .Select(x => x.ToString())
        .Where(x => int.TryParse(x.ToString(), out var y))
        .ToList();
    var result = numbers.First() + numbers.Last();
    outputs.Add(result);
    total += int.Parse(result);
    Console.WriteLine($"input: {input}, output: {result}");
}
Console.WriteLine($"total: {total}");
File.WriteAllLines("output.txt", outputs);
Console.ReadKey();