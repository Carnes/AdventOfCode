using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    public class Game
    {
        public int IdNumber { get; private set; }
        public List<Round> Rounds { get; private set; }

        //The power of a set of cubes is equal to the numbers of red, green, and blue cubes multiplied together.
        public int Power => GetMinCubes().Values.Aggregate((c1, c2) => c1 * c2);

        public Game(string input)
        {
            SetGameData(input);
        }

        public bool IsPossible(int red, int green, int blue)
        {
            return Rounds.All(r => r.IsPossible(red, green, blue));
        }

        private Dictionary<string, int> GetMinCubes()
        {
            var cubes = new Dictionary<string, int>();
            Colors.All.ForEach(color=>cubes.Add(color,Rounds.Max(r => r.GetCube(color))));
            return cubes;
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
            Console.Write($"Power {Power}");
            Console.WriteLine();
        }
    }
}