var input = await File.ReadAllLinesAsync("data_prod.txt");

var numbersLeft = new List<int>();
var numbersRight = new List<int>();
var totalDist = 0;
var totalSimilarity = 0;

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
    var leftNum = numbersLeft[i];
    var rightNum = numbersRight[i];
    var dist = Math.Abs(leftNum - rightNum);
    var similarity = leftNum * numbersRight.Count(x => x == leftNum);
    totalDist += dist;
    totalSimilarity += similarity;
    Console.WriteLine($"L: {leftNum}, R: {rightNum}, Dist: {dist}, Sim: {similarity}");
}

Console.WriteLine($"Total Dist: {totalDist}, Similarity: {totalSimilarity}");
