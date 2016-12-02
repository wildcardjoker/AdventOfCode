// AdventOfCode: Day1_NoTimeForATaxicab
// Created: 2016-12-02
// Modified: 2016-12-02 2:51 PM

#region Using Directives
using System;
using System.Collections.Generic;
using System.Text;
using Day1_NoTimeForATaxiCab;

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
            CurrentPoint = new Point();
            Moves = GetMoves(route);
            CurrentDirection = Direction.North;
            Sb = new StringBuilder("Direction,Blocks,X,Y\n");
            Points = new List<Point>();
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets the current coordinates.
        /// </summary>
        /// <value>
        ///     The coordinates.
        /// </value>
        public string Coordinates => $"{CurrentPoint.X},{CurrentPoint.Y}";

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

        /// <summary>
        ///     Gets or sets the maximum point.
        /// </summary>
        /// <value>
        ///     The maximum point.
        /// </value>
        public int MaxPointX { get; set; }

        /// <summary>
        ///     Gets or sets the maximum point y.
        /// </summary>
        /// <value>
        ///     The maximum point y.
        /// </value>
        public int MaxPointY { get; set; }

        /// <summary>
        ///     Gets or sets the minimum point.
        /// </summary>
        /// <value>
        ///     The minimum point.
        /// </value>
        public int MinPointX { get; set; }

        /// <summary>
        ///     Gets or sets the minimum point y.
        /// </summary>
        /// <value>
        ///     The minimum point y.
        /// </value>
        public int MinPointY { get; set; }

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
        ///     How far away from our start point are we?
        /// </summary>
        /// <value>
        ///     The blocks from start.
        /// </value>
        public int BlocksFromStart() => BlocksFromStart(CurrentPoint);

        public int BlocksFromStart(Point point) => Math.Abs(point.X) + Math.Abs(point.Y);
    }
}