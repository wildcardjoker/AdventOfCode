#region Information

// AdventOfCode: Day3_SquaresWithThreeSides
// Created: 2016-12-03
// Modified: 2016-12-03 9:41 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Day3_SquaresWithThreeSides
{
    /// <summary>
    ///     Three lengths representing the sides of a triangle.
    /// </summary>
    public class Triangle
    {
        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Triangle" /> class.
        /// </summary>
        /// <param name="lengths">The lengths.</param>
        public Triangle(string lengths)
        {
            Sides =
                lengths.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                       .Select(x => Convert.ToInt32(x)).OrderBy(x => x)
                       .ToList();
            LongestSide = Sides.Last();
            SumOfRemainingSides = Sides.OrderByDescending(x => x).Skip(1).Sum();
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets a value indicating whether this instance is a valid triangle.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is valid triangle; otherwise, <c>false</c>.
        /// </value>
        public bool IsValidTriangle => SumOfRemainingSides > LongestSide;

        /// <summary>
        ///     Gets the longest side.
        /// </summary>
        /// <value>
        ///     The longest side.
        /// </value>
        private int LongestSide { get; }

        /// <summary>
        ///     Gets or sets the sides of the triangle.
        /// </summary>
        /// <value>
        ///     The sides.
        /// </value>
        public List<int> Sides { get; set; }

        /// <summary>
        ///     Gets the sum of remaining sides.
        /// </summary>
        /// <value>
        ///     The sum of remaining sides.
        /// </value>
        private int SumOfRemainingSides { get; }
        #endregion
    }
}