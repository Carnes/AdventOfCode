using System.Collections.Generic;
using System.Numerics;
using Day3.Enums;

namespace Day3
{
    public class Cardinal
    {
        public Direction Direction { get; private set; } 
        public Vector2 Vector { get; private set; }

        private Cardinal(Direction direction, Vector2 vector)
        {
            Direction = direction;
            Vector = vector;
        }
        
        public static Cardinal North = new Cardinal(Direction.North, new Vector2(0, -1));
        public static Cardinal South = new Cardinal(Direction.South, new Vector2(0, 1));
        public static Cardinal East = new Cardinal(Direction.East, new Vector2(1, 0));
        public static Cardinal West = new Cardinal(Direction.West, new Vector2(-1, 0));
        
        public static Cardinal NorthEast = new Cardinal(Direction.NorthEast, new Vector2(1, -1));
        public static Cardinal SouthEast = new Cardinal(Direction.SouthEast, new Vector2(1, 1));
        public static Cardinal NorthWest = new Cardinal(Direction.NorthWest, new Vector2(-1, -1));
        public static Cardinal SouthWest = new Cardinal(Direction.SouthWest, new Vector2(-1, 1));

        public static List<Cardinal> All = new List<Cardinal>
        {
            North,South,East,West,
            NorthEast, NorthWest,SouthEast, SouthWest,
        };

    }
}