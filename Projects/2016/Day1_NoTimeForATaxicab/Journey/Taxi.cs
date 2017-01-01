#region Information

// AdventOfCode: Day1_NoTimeForATaxicab
// Created: 2016-12-01
// Modified: 2016-12-03 5:48 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
                SetDirection(direction);
                Move(Convert.ToInt32(blocks));
            }
        }

        /// <summary>
        ///     Moves the specified blocks.
        /// </summary>
        /// <param name="blocks">The blocks.</param>
        private void Move(int blocks)
        {
            // Store starting point.
            string startPoint = Coordinates();

            for (var i = 0; i < blocks; i++)
            {
                // Move 1 block at a time - required for Part 2
                int x = CurrentPoint.X;
                int y = CurrentPoint.Y;
                switch (CurrentDirection)
                {
                    case Direction.East:
                        x++;
                        break;
                    case Direction.West:
                        x--;
                        break;
                    case Direction.North:
                        y++;
                        break;
                    case Direction.South:
                        y--;
                        break;
                    default:
                        Console.WriteLine(
                            $"Huh? It seems that you're trying to move in a non-standard direction. ({CurrentDirection})");
                        break;
                }

                // Set current position.
                CurrentPoint = new Point(x, y);

                // If there are any points in our log of previously visited points (X and Y coordinates match),
                // and we have not found a previously-visited block, set this block as our first revisited block.
                if (Points.Any(point => CurrentPoint.X == point.X && CurrentPoint.Y == point.Y) &&
                    FirstRevisitedPoint.X == 0 &&
                    FirstRevisitedPoint.Y == 0)
                {
                    FirstRevisitedPoint = CurrentPoint;
                }

                // Add the current point to our log of positions.
                Points.Add(CurrentPoint);
            }

            // Add the current movement to our log.
            Sb.AppendLine(string.Join(",", CurrentDirection.ToString(), blocks.ToString(), CurrentPoint.X.ToString(),
                                      CurrentPoint.Y.ToString()));
            Console.WriteLine(
                $"Travelled {blocks.ToString().PadLeft(6)} blocks {CurrentDirection.ToString().PadRight(10)} from {startPoint.PadRight(5)} to {Coordinates().PadRight(8)}");
        }

        /// <summary>
        ///     Sets the direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <remarks>
        ///     We need to handle turning from N->W and from W->N separately
        ///     or our direction will become out of range (360 or -90).
        /// </remarks>
        private void SetDirection(string direction)
        {
            if (CurrentDirection == Direction.North && direction.Equals("l"))
            {
                CurrentDirection = Direction.West;
                return;
            }
            if (CurrentDirection == Direction.West && direction.Equals("r"))
            {
                CurrentDirection = Direction.North;
                return;
            }
            if (direction.Equals("l"))
            {
                CurrentDirection--;
                return;
            }
            CurrentDirection++;
        }

        /// <summary>
        ///     Take a set of instructions and split them into individual instructions.
        /// </summary>
        /// <param name="moves">The moves.</param>
        /// <returns></returns>
        private static IEnumerable<string> GetMoves(string moves) => moves.Split(',');
    }
}