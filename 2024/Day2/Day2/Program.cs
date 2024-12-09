using Day2;

var input = await File.ReadAllLinesAsync("input.txt");
var numSafe = 0;

foreach (var reportData in input)
{
    var r = new Report(reportData.Split(" ").Select(x=> Int32.Parse(x)).ToList());
    r.Print();
    if (r.IsSafe)
        numSafe++;
}

Console.WriteLine($"Total safe: {numSafe}");
