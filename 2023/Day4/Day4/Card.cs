using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class Card
    {
        public int Id { get; set; }
        public List<int> WinningNumbers { get; set; }
        public List<int> RandomNumbers { get; set; }
        public List<int> MatchingNumbers => RandomNumbers.Join(WinningNumbers, r => r, w => w, (r, w) => r).ToList();
        
        public int GetScore()
        {
            var mn = MatchingNumbers;
            if (mn.Count() < 2) 
                return mn.Count();
            var score = 1;
            for (var i = 1; i < mn.Count(); i++)
                score *= 2;
            return score;
        }

        public Card(string input)
        {
            var idAndData = input.Split(":");
            Id = int.Parse(idAndData[0].Split(" ").Where(n => n.Any()).ToArray()[1]);
            var winningNumbersAndPlayNumbers = idAndData[1].Split("|");
            
            WinningNumbers = winningNumbersAndPlayNumbers[0].Split(" ")
                .Where(n=>n.Any())
                .Select(n => int.Parse(n))
                .ToList();
            RandomNumbers = winningNumbersAndPlayNumbers[1].Split(" ")
                .Where(n=>n.Any())
                .Select(n => int.Parse(n))
                .ToList();
        }

        public void Print()
        {
            Console.WriteLine($"Card {Id}: {GetScore()}");
        }
    }
}