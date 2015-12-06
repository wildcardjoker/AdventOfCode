#region Information

// AdventOfCode: libChristmasLightsGrid.ViewModel
// Created: 2015-12-06
// Modified: 2015-12-06 9:04 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using libChristmasLight;

#endregion

namespace libChristmasLightsGrid.ViewModel
{
    public partial class ChristmasLightsGrid
    {
        #region  Fields
        public const string ArgumentOutOfRangeMessage =
            "Value is out of range. Acceptable values are any positive integer.";

        private List<string> _instructions;
        #endregion

        #region Properties
        /// <summary>
        ///     Number of Columns in Grid
        /// </summary>
        public int Columns
        {
            get { return _columns; }
            set
            {
                if (value == _columns)
                {
                    return;
                }
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, ArgumentOutOfRangeMessage);
                }
                _columns = value;
                OnPropertyChanged();
            }
        }

        public List<string> Instructions
        {
            get { return _instructions; }
            set
            {
                if (Equals(value, _instructions))
                {
                    return;
                }
                _instructions = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     List representing a Grid of Christmas Lights
        /// </summary>
        public List<ChristmasLight> Lights
        {
            get { return _lights; }
            set
            {
                if (Equals(value, _lights))
                {
                    return;
                }
                _lights = value;
                OnPropertyChanged();
            }
        }

        public Range RangeToModify { get; set; }

        /// <summary>
        ///     Number of Rows in Grid
        /// </summary>
        public int Rows
        {
            get { return _rows; }
            set
            {
                if (value == _rows)
                {
                    return;
                }
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, ArgumentOutOfRangeMessage);
                }
                _rows = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}