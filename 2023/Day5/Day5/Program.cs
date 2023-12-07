using System.Diagnostics;
using Day5;

var sw = new Stopwatch();
sw.Start();

var ip = new MapProcessor("input.txt");
var minLocation = Int64.MaxValue;
var minSeed = Int64.MaxValue;

foreach (var seedRange in ip.GetSeedsAsRange())
{
    Console.Write($"Seed: {seedRange.Item1} + {seedRange.Item2}");
    for (var seed = seedRange.Item1; seed <= seedRange.Item1 + seedRange.Item2; seed++)
    {
        var seedLocation = ip.Get(Category.seed, Category.location, seed);
        if (seedLocation < minLocation)
        {
            minLocation = seedLocation;
            minSeed = seed;
        }
    }
    Console.WriteLine($" :: {sw.Elapsed.GetHumanReadableString()}");
}

sw.Stop();
Console.WriteLine($"MinSeed: {minSeed} at MinLocation: {minLocation}");
Console.WriteLine($"{sw.Elapsed.GetHumanReadableString()}");


