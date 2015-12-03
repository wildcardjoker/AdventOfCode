#region Information

// AdventOfCode: Day2_IWasToldThereWouldBeNoMath
// Created: 2015-12-03
// Modified: 2015-12-03 1:44 PM
// Last modified by: MOORE Jason (jasonmo)
#endregion

#region Using Directives
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Day2_IWasToldThereWouldBeNoMath
{
    internal class Present
    {
        #region Constructors
        public Present() : this(0, 0, 0) {}

        public Present(int length, int width, int height)
        {
            Height = height;
            Length = length;
            Width = width;
        }
        #endregion

        #region Properties
        public int Height { get; set; }
        public int Length { get; set; }
        public int Volume => Length * Width * Height;
        public int Width { get; set; }
        #endregion

        /// <summary>
        ///     Return the perimeter of the present, given the measurements of both sides.
        /// </summary>
        /// <param name="side1">Side A</param>
        /// <param name="side2">Side B</param>
        /// <returns></returns>
        private static int Perimeter(int side1, int side2) => 2 * (side1 + side2);

        /// <summary>
        ///     Return the smallest perimeter of the present.
        /// </summary>
        /// <returns></returns>
        public int SmallestPerimeter()
        {
            List<int> perimeters = new List<int>
                                   {
                                       Perimeter(Height, Length),
                                       Perimeter(Height, Width),
                                       Perimeter(Length, Width)
                                   };
            return perimeters.Min();
        }
    }
}