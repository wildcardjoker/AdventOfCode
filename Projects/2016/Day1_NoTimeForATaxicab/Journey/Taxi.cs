// AdventOfCode: Day1_NoTimeForATaxicab
// Created: 2016-12-02
// Modified: 2016-12-02 1:49 PM

#region Using Directives
using System;
using System.Collections.Generic;

#endregion

namespace Day1_NoTimeForATaxicab.Journey
{
    public partial class Journey
    {
        /// <summary>
        ///     Traverse path provided by Moves.
        /// </summary>
        public void Travel()
        {
            foreach (string move in Moves)
            {
                string instruction = move.Trim();
                string direction = instruction[0].ToString().ToLower();
                string blocks = instruction.Substring(1);
                CurrentDirection = GetDirection(direction);
                Move(Convert.ToInt32(blocks));
            }
        }

        /// <summary>
        ///     Moves the specified blocks.
        /// </summary>
        /// <param name="blocks">The blocks.</param>
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
            Sb.AppendLine(string.Join(",", CurrentDirection.ToString(), blocks.ToString(), X.ToString(), Y.ToString()));
            Console.WriteLine(
                $"Travelled {blocks.ToString().PadLeft(6)} blocks {CurrentDirection.ToString().PadRight(10)} from {startPoint.PadRight(5)} to {Coordinates.PadRight(8)}");
        }

        private Direction GetDirection(string direction)
        {
            var currentDirection = (int) CurrentDirection;
            int newDirection;
            if (direction.Equals("l"))
            {
                currentDirection = currentDirection == 0 ? 360 : currentDirection;
                newDirection = currentDirection - 90;
            }
            else
            {
                newDirection = currentDirection + 90;
            }
            return (Direction) (newDirection == 360 ? 0 : newDirection);
        }

        private static IEnumerable<string> GetMoves(string moves) => moves.Split(',');
    }
}