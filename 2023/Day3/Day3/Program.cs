﻿using System;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var sumOfParts = 0;
            var schematic = new Schematic(File.ReadAllLines("input.txt"));
            for (var y = 0; y < schematic.Size.Y; y++)
            for (var x = 0; x < schematic.Size.X; x++)
            {
                if (schematic.IsSymbol(x, y))
                {
                    var partNums = schematic.GetPartNumbers(x, y);
                    sumOfParts += partNums.Sum() ?? 0;

                    Console.Write($"{schematic.GetChar(x, y)}: ");
                    partNums.ForEach(p => Console.Write($"{p},"));
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"Sum of parts: {sumOfParts}");
        }
    }
}