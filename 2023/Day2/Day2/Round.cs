using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Day2
{
    public class Round
    {
        private Dictionary<string, int> _cubes = new();
        public int Red => GetCube(Colors.Red);
        public int Green => GetCube(Colors.Green);
        public int Blue => GetCube(Colors.Blue);
        
        public Round(string input)
        {
            input.Split(",").ToList().ForEach(AddCube);
        }
        
        public bool IsPossible(int red, int green, int blue)
        {
            if (Red > red) return false;
            else if (Green > green) return false;
            else if (Blue > blue) return false;
            return true;
        }

        private int GetCube(string color)
        {
            if (_cubes.TryGetValue(color, out int cubes))
                return cubes;
            return 0;
        }

        private void AddCube(string input)
        {
            var x = input.Trim().Split(" ");
            _cubes.Add(x[1], int.Parse(x[0]));
        }

        public void Print()
        {
            Console.Write($"{Red} Red, {Green} Green, {Blue} Blue; ");
        }
    }
}