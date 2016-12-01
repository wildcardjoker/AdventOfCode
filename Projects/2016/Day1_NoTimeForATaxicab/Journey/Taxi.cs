#region Information

// AdventOfCode: Day1_NoTimeForATaxicab
// Created: 2016-12-01
// Modified: 2016-12-01 11:00 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;

#endregion

namespace Day1_NoTimeForATaxicab.Journey
{
    public partial class Journey
    {
        public void Travel()
        {
            foreach (string move in Moves)
            {
                var instruction = move.Trim();
                var direction = instruction[0].ToString().ToLower();
                var blocks = instruction.Substring(1);
                CurrentDirection = GetDirection(direction);
                Move(Convert.ToInt32(blocks));
            }
        }

        private void Move(int blocks)
        {
            string startPoint = Coordinates;
            switch (CurrentDirection)
            {
                case Direction.East:
                    X += blocks;
                    break;
                case Direction.West:
                    X -= blocks;
                    break;
                case Direction.North:
                    Y += blocks;
                    break;
                case Direction.South:
                    Y -= blocks;
                    break;
            }
            Console.WriteLine($"Travelled from {startPoint} to {Coordinates}");
        }

        private Direction GetDirection(string direction)
        {
            int currentDirection = (int) CurrentDirection;
            int newDirection = 0;
            if (direction.Equals("l"))
            {
                currentDirection = currentDirection == 0 ? 360 : currentDirection;
                newDirection = currentDirection - 90;
            }
            else
            {
                newDirection = currentDirection + 90;
            }
            return (Direction) newDirection;
        }

        private IEnumerable<string> GetMoves(string moves) => moves.Split(',');
    }
}