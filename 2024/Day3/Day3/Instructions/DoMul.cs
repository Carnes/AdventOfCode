namespace Day3;

public class DoMul : InstructionBase
{
    public override string Name => "do";

    public override int TryExecute(string data, int index)
    {
        var startIndex = index + Name.Length;
        if (data[startIndex + 1] == ')')
        {
            State.IsMulAllowed = true;
            Print();
            return 1;
        }
        return 0;
    }
}