﻿using System;
using System.IO;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var cards = input.Select(c => new Card(c)).ToList();
            var totalScore = cards.Sum(c => c.GetScore());
            cards.ForEach(c=>c.Print());

            var totalCards = new CardProcessor().Process(cards);
            
            Console.WriteLine($"TotalScore: {totalScore}");
            Console.WriteLine($"TotalCards: {totalCards}");
        }
    }
}