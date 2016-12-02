#region Information

// AdventOfCode: Day2_BathroomSecurity
// Created: 2016-12-02
// Modified: 2016-12-02 11:32 PM
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
        public Button(int x, int y, string value) : this(new Point(x, y), value) {}

        /// <summary>
        ///     Initializes a new instance of the <see cref="Button" /> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="value">The keypad button value.</param>
        public Button(int x, int y, int value) : this(new Point(x, y), value.ToString()) {}

        /// <summary>
        ///     Initializes a new instance of the <see cref="Button" /> class.
        /// </summary>
        /// <param name="point">The button coordinates.</param>
        /// <param name="value">The keypad button value.</param>
        public Button(Point point, string value)
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
        public string Value { get; set; }
        #endregion
    }
}