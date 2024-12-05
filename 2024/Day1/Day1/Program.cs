var input = await File.ReadAllLinesAsync("data_sample.txt");

var numbersLeft = new List<int>();
var numbersRight = new List<int>();
var numbersDist = new List<int>();
foreach (var line in input)
{
    var lineSplit = line.Split("   ");
    numbersLeft.Add(Convert.ToInt32(lineSplit[0]));
    numbersRight.Add(Convert.ToInt32(lineSplit[1]));
}
numbersLeft.Sort();
numbersRight.Sort();

for (var i = 0; i < input.Length; i++)
{
    var dist = Math.Abs(numbersLeft[i] - numbersRight[i]);
    numbersDist.Add(dist);
    Console.WriteLine($"L: {numbersLeft[i]}, R: {numbersRight[i]}, Dist: {dist}");
}

var totalDist = numbersDist.Sum();
Console.WriteLine(totalDist);
