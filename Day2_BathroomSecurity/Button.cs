#region Information

// AdventOfCode: Day2_BathroomSecurity
// Created: 2016-12-02
// Modified: 2016-12-02 9:57 PM
#endregion

#region Using Directives
using System.Drawing;

#endregion

namespace Day2_BathroomSecurity
{
    /// <summary>
    ///     Represents a Keypad Button.
    /// </summary>
    public class Button
    {
        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Button" /> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="value">The keypad button value.</param>
        public Button(int x, int y, int value) : this(new Point(x, y), value) {}

        /// <summary>
        ///     Initializes a new instance of the <see cref="Button" /> class.
        /// </summary>
        /// <param name="point">The button coordinates.</param>
        /// <param name="value">The keypad button value.</param>
        public Button(Point point, int value)
        {
            ButtonCoordinates = point;
            Value = value;
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets or sets the button coordinates.
        /// </summary>
        /// <value>
        ///     The button coordinates.
        /// </value>
        public Point ButtonCoordinates { get; set; }

        /// <summary>
        ///     Gets or sets the Keypad Button value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public int Value { get; set; }
        #endregion
    }
}