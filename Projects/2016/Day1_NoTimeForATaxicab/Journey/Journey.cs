// AdventOfCode: Day1_NoTimeForATaxicab
// Created: 2016-12-02
// Modified: 2016-12-02 1:50 PM

#region Using Directives
using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Day1_NoTimeForATaxicab.Journey
{
    /// <summary>
    ///     Advent of Code Day 1
    ///     Class for Taxi journey.
    /// </summary>
    public partial class Journey
    {
        #region Direction enum
        /// <summary>
        ///     Possible Directions
        /// </summary>
        public enum Direction
        {
            /// <summary>
            ///     North
            /// </summary>
            North = 0,

            /// <summary>
            ///     East
            /// </summary>
            East = 90,

            /// <summary>
            ///     South
            /// </summary>
            South = 180,

            /// <summary>
            ///     West
            /// </summary>
            West = 270
        }
        #endregion

        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Journey" /> class.
        /// </summary>
        /// <param name="route">The route to be taken.</param>
        public Journey(string route)
        {
            X = Y = 0;
            Moves = GetMoves(route);
            CurrentDirection = Direction.North;
            Sb = new StringBuilder("Direction,Blocks,X,Y\n");
        }
        #endregion

        #region Properties
        /// <summary>
        ///     How far away from our start point are we?
        /// </summary>
        /// <value>
        ///     The blocks from start.
        /// </value>
        public int BlocksFromStart => Math.Abs(X) + Math.Abs(Y);

        /// <summary>
        ///     Gets the current coordinates.
        /// </summary>
        /// <value>
        ///     The coordinates.
        /// </value>
        public string Coordinates => $"{X},{Y}";

        /// <summary>
        ///     Gets or sets the current direction.
        /// </summary>
        /// <value>
        ///     The current direction.
        /// </value>
        public Direction CurrentDirection { get; set; }

        /// <summary>
        ///     Gets the log.
        /// </summary>
        /// <value>
        ///     The log.
        /// </value>
        public string Log => Sb.ToString();

        private IEnumerable<string> Moves { get; }
        private StringBuilder Sb { get; }

        /// <summary>
        ///     Gets or sets the x-axis value.
        /// </summary>
        /// <value>
        ///     The x.
        /// </value>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the y-axis value.
        /// </summary>
        /// <value>
        ///     The y.
        /// </value>
        public int Y { get; set; }
        #endregion
    }
}