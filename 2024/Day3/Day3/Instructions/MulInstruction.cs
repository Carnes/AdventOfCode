namespace Day3;

public class MulInstruction : InstructionBase
{
    public override string Name => "mul";

    public override int TryExecute(string data, int index)
    {
        try
        {
            var end = data.IndexOf(')', index);
            var argStart = index + Name.Length + 1;
            var argEnd = end - argStart;
            var argsCombined = data.Substring(argStart, argEnd);
            var args = argsCombined.Split(',');
            var x = int.Parse(args[0]);
            var y = int.Parse(args[1]);
            var mul = x * y;
            if (State.IsMulAllowed)
            {
                Print();
                State.MulSum += mul;
            }

            return end - index;
        }
        catch
        {
            return 0;
        }
    }
}