var corruptedData = await File.ReadAllTextAsync("input_sample.txt");
var possibleInstructions = corruptedData.Split("mul(");
var sumOfMul = 0;

foreach (var instruction in possibleInstructions)
{
    sumOfMul += TryMulInstruction(instruction) ?? 0;
}

Console.WriteLine(sumOfMul);
int? TryMulInstruction(string instruction)
{
    var endArgs = instruction.IndexOf(")");
    if (endArgs < 1) return null;
    var argsCombined = instruction.Substring(0,endArgs);
    var args = argsCombined.Split(",");
    if (!int.TryParse(args[0], out int x)) return null;
    if (!int.TryParse(args[1], out int y)) return null;
    return x * y;
}