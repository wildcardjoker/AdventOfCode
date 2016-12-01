#region Information

// AdventOfCode: Day1_NoTimeForATaxicab
// Created: 2016-12-01
// Modified: 2016-12-01 11:04 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;

#endregion

namespace Day1_NoTimeForATaxicab.Journey
{
    public partial class Journey
    {
        #region Direction enum
        public enum Direction
        {
            North = 0,
            East = 90,
            South = 180,
            West = 270
        }
        #endregion

        #region Constructors
        public Journey(string moves)
        {
            X = Y = 0;
            Moves = GetMoves(moves);
            CurrentDirection = Direction.North;
        }
        #endregion

        #region Properties
        public int BlocksFromStart => Math.Abs(X + Y);
        public string Coordinates => $"{X},{Y}";
        public Direction CurrentDirection { get; set; }
        private IEnumerable<string> Moves { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        #endregion
    }
}