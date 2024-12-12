using Day3;

var corruptedData = await File.ReadAllTextAsync("input.txt");

var instructions = new List<InstructionBase>
{
    new DoMul(), 
    new DoNotMul(), 
    new MulInstruction()
};

for (var i = 0; i < corruptedData.Length; i++)
{
    foreach(var instruction in instructions)
        if (instruction.IsInstruction(corruptedData, i))
        {
            i += instruction.TryExecute(corruptedData, i);
        }
}

Console.WriteLine($"MulSum: {State.MulSum}");