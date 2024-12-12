namespace Day3;

public class DoNotMul : InstructionBase
{
    public override string Name => "don't";

    public override int TryExecute(string data, int index)
    {
        var startIndex = index + Name.Length;
        if (data[startIndex + 1] == ')')
        {
            State.IsMulAllowed = false;
            Print();
            return 1;
        }
        return 0;
    }
}