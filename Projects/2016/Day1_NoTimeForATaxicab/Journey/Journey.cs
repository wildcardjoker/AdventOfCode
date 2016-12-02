#region Information

// AdventOfCode: Day1_NoTimeForATaxicab
// Created: 2016-12-01
// Modified: 2016-12-02 7:40 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Drawing;
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
            North,

            /// <summary>
            ///     East
            /// </summary>
            East,

            /// <summary>
            ///     South
            /// </summary>
            South,

            /// <summary>
            ///     West
            /// </summary>
            West
        }
        #endregion

        #region Constructors
        /// <summary>
        ///     Initialises a new instance of the <see cref="Journey" /> class.
        /// </summary>
        /// <param name="route">The route to be taken.</param>
        public Journey(string route)
        {
            CurrentPoint = new Point(0, 0);
            Moves = GetMoves(route);
            CurrentDirection = Direction.North;
            Sb = new StringBuilder("Direction,Blocks,X,Y\n");
            Points = new List<Point>();
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets or sets the current direction.
        /// </summary>
        /// <value>
        ///     The current direction.
        /// </value>
        public Direction CurrentDirection { get; set; }

        /// <summary>
        ///     Gets or sets the current point.
        /// </summary>
        /// <value>
        ///     The current point.
        /// </value>
        public Point CurrentPoint { get; set; }

        /// <summary>
        ///     Gets or sets the first revisited point.
        /// </summary>
        /// <value>
        ///     The first revisited point.
        /// </value>
        public Point FirstRevisitedPoint { get; set; }

        /// <summary>
        ///     Gets the log.
        /// </summary>
        /// <value>
        ///     The log.
        /// </value>
        public string Log => Sb.ToString();

        private IEnumerable<string> Moves { get; }

        /// <summary>
        ///     Gets the points.
        /// </summary>
        /// <value>
        ///     The points.
        /// </value>
        public List<Point> Points { get; }

        private StringBuilder Sb { get; }
        #endregion

        /// <summary>
        ///     Gets the coordinates of the specified point.
        /// </summary>
        /// <value>
        ///     The coordinates.
        /// </value>
        public string Coordinates(Point point) => $"{point.X},{point.Y}";

        /// <summary>
        ///     Gets the current coordinates.
        /// </summary>
        /// <returns></returns>
        public string Coordinates() => Coordinates(CurrentPoint);

        /// <summary>
        ///     How far away from our start point are we?
        /// </summary>
        /// <value>
        ///     The blocks from start.
        /// </value>
        public int BlocksFromStart() => BlocksFromStart(CurrentPoint);

        /// <summary>
        ///     Number of blocks from start.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public int BlocksFromStart(Point point) => Math.Abs(point.X) + Math.Abs(point.Y);
    }
}