namespace Day2;

public class Report
{
    private readonly List<int> _levels;
    private bool? _isSafe = null;

    public Report(List<int> levels)
    {
        _levels = levels;
    }

    public bool IsSafe
    {
        get
        {
            if (_isSafe == null)
            {
                _isSafe = CalcIsSafe(new Stack<int>(_levels));
                if (_isSafe == false)
                    _isSafe = CalcDampenedIsSafe();
            }

            return _isSafe.Value;
        }
    }

    private bool CalcDampenedIsSafe()
    {
        List<int> dampedLevels;
        for (var i = 0; i < _levels.Count; i++)
        {
            dampedLevels = _levels.ToList();
            dampedLevels.RemoveAt(i);
            var isSafe = CalcIsSafe(new Stack<int>(dampedLevels));
            if (isSafe) return true;
        }

        return false;
    }

    public void Print()
    {
        var prevColor = Console.ForegroundColor;
        if(IsSafe) Console.ForegroundColor = ConsoleColor.Green;
            
        Console.Write($"IsSafe: {IsSafe}");
        foreach (var level in _levels)
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