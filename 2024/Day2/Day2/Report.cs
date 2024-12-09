namespace Day2;

public class Report
{
    public List<int> Levels;
    public bool? _isSafe = null;

    public Report(List<int> levels)
    {
        Levels = levels;
    }

    public bool IsSafe
    {
        get
        {
            if(_isSafe == null)
                _isSafe = CalcIsSafe(new Stack<int>(Levels));
            return _isSafe.Value;
        }
    }

    public void Print()
    {
        var prevColor = Console.ForegroundColor;
        if(IsSafe) Console.ForegroundColor = ConsoleColor.Green;
            
        Console.Write($"IsSafe: {IsSafe}, ");
        foreach (var level in Levels)
            Console.Write($"{level} ");
        
        Console.WriteLine();
        Console.ForegroundColor = prevColor;
    }

    private static bool CalcIsSafe(Stack<int> remainingLevels, bool? isAscending = null)
    {
        var current = remainingLevels.Pop();
        var next = remainingLevels.Peek();
        isAscending = isAscending ?? current < next;
        if (isAscending == null) return false;
        if (isAscending != current < next) return false;
        if (current == next) return false;
        if (Math.Abs(current - next) > 3) return false;
        
        if (remainingLevels.Count == 1) return true;
        return CalcIsSafe(remainingLevels, isAscending);
    }
}