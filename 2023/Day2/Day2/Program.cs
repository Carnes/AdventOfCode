using System;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var red = 12;
            var green = 13;
            var blue = 14;
            
            var games = File.ReadAllLines("input.txt").Select(gi=> new Game(gi));
            var gamesPossible = games.Where(g => g.IsPossible(red, green, blue));
            var sumOfGameIds = gamesPossible.Sum(g => g.IdNumber);
            var sumOfPowers = games.Sum(g => g.Power);
            
            Console.WriteLine($"Part1: {gamesPossible.Count()} games possible.  Ids sum {sumOfGameIds}.");
            Console.WriteLine($"Part2: {sumOfPowers} Sum of power.");
        }
    }
}