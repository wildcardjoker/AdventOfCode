// AdventOfCode: Day1_NoTimeForATaxicab
// Created: 2016-12-02
// Modified: 2016-12-02 2:24 PM

namespace Day1_NoTimeForATaxiCab
{
    public class Point
    {
        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Point" /> class.
        /// </summary>
        public Point() : this(0, 0) {}

        /// <summary>
        ///     Indicates a point on a grid.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets the x-axis value.
        /// </summary>
        /// <value>
        ///     The x-axis value.
        /// </value>
        public int X { get; set; }

        /// <summary>
        ///     Gets the y-axis value.
        /// </summary>
        /// <value>
        ///     The y-axis value.
        /// </value>
        public int Y { get; set; }
        #endregion
    }
}