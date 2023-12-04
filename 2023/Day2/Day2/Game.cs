using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    public class Game
    {
        public int IdNumber { get; private set; }
        public List<Round> Rounds { get; private set; }
        
        public Game(string input)
        {
            SetGameData(input);
        }

        public bool IsPossible(int red, int green, int blue)
        {
            return Rounds.All(r => r.IsPossible(red, green, blue));
        }

        private void SetGameData(string input)
        {
            var gameNumberAndRounds = input.Split(":");
            var gameNumber = gameNumberAndRounds[0].Split(" ");
            IdNumber = int.Parse(gameNumber[1]);
            SetRounds(gameNumberAndRounds[1]);
        }

        private void SetRounds(string roundsData)
        {
            Rounds = roundsData.Split(";").Select(r => new Round(r)).ToList();
        }

        public void Print()
        {
            Console.Write($"Game {IdNumber}: ");
            Rounds.ForEach(r=>r.Print());
            Console.WriteLine();
        }
    }
}