var inputs = await File.ReadAllLinesAsync("input.txt");
var outputs = new List<string>();
var total = 0;
foreach (var input in inputs)
{
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