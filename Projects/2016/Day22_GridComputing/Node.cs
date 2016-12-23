#region Information

// AdventOfCode: Day22_GridComputing
// Created: 2016-12-23
// Modified: 2016-12-23 9:16 PM
#endregion

#region Using Directives
using System;
using System.Text.RegularExpressions;

#endregion

namespace Day22_GridComputing
{
    /// <summary>
    ///     Holds position, node size, and used space.
    /// </summary>
    public class Node
    {
        #region  Fields
        private static readonly Regex DigitRegex = new Regex(@"\d+");
        #endregion

        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Node" /> class.
        /// </summary>
        /// <param name="data">The data, represented as a string from the du command.</param>
        public Node(string data)
        {
            MatchCollection matches = DigitRegex.Matches(data);
            if (matches.Count != 6)
            {
                return;
            }
            PosX = Convert.ToInt32(matches[0].Value);
            PosY = Convert.ToInt32(matches[1].Value);
            Size = Convert.ToInt32(matches[2].Value);
            Used = Convert.ToInt32(matches[3].Value);
            Available = Convert.ToInt32(matches[4].Value);
            UsedPercent = Convert.ToInt32(matches[5].Value);
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets or sets the space available.
        /// </summary>
        /// <value>
        ///     The available.
        /// </value>
        public int Available { get; set; }

        /// <summary>
        ///     Gets or sets the position x.
        /// </summary>
        /// <value>
        ///     The position x.
        /// </value>
        public int PosX { get; set; }

        /// <summary>
        ///     Gets or sets the position y.
        /// </summary>
        /// <value>
        ///     The position y.
        /// </value>
        public int PosY { get; set; }

        /// <summary>
        ///     Gets or sets the size of the node.
        /// </summary>
        /// <value>
        ///     The size.
        /// </value>
        public int Size { get; set; }

        /// <summary>
        ///     Gets or sets the used space on the node.
        /// </summary>
        /// <value>
        ///     The used.
        /// </value>
        public int Used { get; set; }

        /// <summary>
        ///     Gets or sets the percentage of used space.
        /// </summary>
        /// <value>
        ///     The used percent.
        /// </value>
        public int UsedPercent { get; set; }
        #endregion
    }
}