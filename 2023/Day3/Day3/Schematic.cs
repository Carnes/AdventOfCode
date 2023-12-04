using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Day3.Enums;

namespace Day3
{
    public class Schematic
    {
        public Vector2 Size { get; private set; }
        private string[] _rows;
        private const char _emptyChar = '.';
        
        public Schematic(string[] rows)
        {
            _rows = rows;
            Size = new Vector2(rows[0].Length, rows.Length);
        }

        public char GetChar(Vector2 point) => GetChar((int)point.X, (int)point.Y);

        public char GetChar(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Size.X || y >= Size.Y)
                return _emptyChar;
            return _rows[y][x];
        }

        public bool IsSymbol(Vector2 point) => IsSymbol(GetChar(point));
        public bool IsSymbol(int x, int y) => IsSymbol(GetChar(x,y));

        public bool IsSymbol(char c)
        {
            if (Char.IsDigit(c)) return false;
            if (c == _emptyChar) return false;
            return true;
        }

        public List<int?> GetPartNumbers(int x, int y) => GetPartNumbers(new Vector2(x, y));
        public List<int?> GetPartNumbers(Vector2 point)
        {
            var nums = new List<int?>();
            if (IsSymbol(point))
            {
                foreach (var direction in Cardinal.All)
                {
                    var partNum = GetPartNumber(direction.Vector + point);
                    if (partNum.HasValue)
                        nums.Add(partNum.Value);
                }

            }

            return nums.Distinct().ToList();
        }

        public int? GetPartNumber(Vector2 point)
        {
            var c = GetChar(point);
            if (!Char.IsDigit(c)) return null;
            var partNumberStr = GetPartNumberSearch(point, Cardinal.West) + GetPartNumberSearch(point + Cardinal.East.Vector, Cardinal.East);
            if(int.TryParse(partNumberStr, out int partNumber))
                return partNumber;

            return null;
        }

        public string GetPartNumberSearch(Vector2 point, Cardinal direction)
        {
            var c = GetChar(point);
            if (c == _emptyChar) return string.Empty;
            if (Char.IsDigit(c))
            {
                var nextNumberPart = GetPartNumberSearch(point + direction.Vector, direction);
                if (direction.Direction == Direction.East)
                {
                    return c + nextNumberPart;
                }
                if (direction.Direction == Direction.West)
                {
                    return nextNumberPart + c;
                }
            }

            return string.Empty;
        }
    }
}