#region Information

// AdventOfCode: libChristmasLightsGrid.ViewModel
// Created: 2015-12-06
// Modified: 2015-12-06 7:16 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System.Collections.Generic;

#endregion

namespace libChristmasLightsGrid.ViewModel
{
    public class Range
    {
        #region Constructors
        public Range() : this(0, 0, 0, 0) {}

        public Range(string startCoordinates, string endCoordinates)
        {
            List<string> coordinates = new List<string>();
            coordinates.AddRange(startCoordinates.Split(','));
            coordinates.AddRange(endCoordinates.Split(','));
        }

        public Range(int startX, int startY, int endX, int endY)
        {
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
        }
        #endregion

        #region Properties
        public
            int EndX { get; set; }

        public
            int EndY { get; set; }

        public
            int StartX { get; set; }

        public
            int StartY { get; set; }
        #endregion
    }
}