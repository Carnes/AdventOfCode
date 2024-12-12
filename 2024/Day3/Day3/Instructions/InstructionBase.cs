namespace Day3;

public abstract class InstructionBase
{
    public abstract string Name { get; }

    public bool IsInstruction(string data, int index)
    {
        try
        {
            return data.Substring(index, Name.Length + 1) == $"{Name}(";
        }
        catch
        {
            return false;
        }
    }

    public abstract int TryExecute(string data, int index);

    public virtual void Print()
    {
        Console.WriteLine(Name);
    }
}