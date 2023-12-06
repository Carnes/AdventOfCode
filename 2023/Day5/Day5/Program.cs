using Day5;

// var ip = new MapProcessor("inputExample.txt");
var ip = new MapProcessor("input.txt");

var minLocation = Int64.MaxValue;
var minSeed = Int64.MaxValue;
foreach (var seed in ip.Seeds)
{
    var seedLocation = ip.Get(Category.seed, Category.location, seed);
    if (seedLocation < minLocation)
    {
        minLocation = seedLocation;
        minSeed = seed;
    }
}

Console.WriteLine($"MinSeed: {minSeed} at MinLocation: {minLocation}");


