#region Information

// AdventOfCode: libChristmasLightsGrid.ViewModel
// Created: 2015-12-06
// Modified: 2015-12-06 9:04 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System;
using System.Text.RegularExpressions;
using libChristmasLight;

#endregion

namespace libChristmasLightsGrid.ViewModel
{
    public partial class ChristmasLightsGrid
    {
        #region  Fields
        public const string InvalidInstruction = "Invalid instruction received";
        #endregion

        /// <summary>
        ///     Create a grid Columns wide x Rows high
        /// </summary>
        private void CreateGrid()
        {
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    Lights.Add(new ChristmasLight(i, j));
                }
            }
        }

        /// <summary>
        ///     Perform a given set of instructions
        /// </summary>
        private void PerformInstructions()
        {
            foreach (string instruction in Instructions)
            {
                PerformInstruction(instruction);
            }
        }

        /// <summary>
        ///     Perform a given instruction
        /// </summary>
        /// <param name="s">Instruction string to perform</param>
        private void PerformInstruction(string s)
        {
            // turn on 0,0 through 999,999
            Regex stepRegex = new Regex(@"^\D"); // Get instruction
            Regex rangeRegex = new Regex(@"[\D+]\d+"); // Get first and last range.
            string step = stepRegex.Match(s).Value;
            switch (step.ToLower())
            {
                case "turn on":
                    break;
                case "turn off":
                    break;
                case "toggle":
                    break;
                default:
                    throw new ApplicationException($"{InvalidInstruction}: {step}");
            }
            MatchCollection matches = rangeRegex.Matches(s);
            if (matches.Count == 2)
            {
                RangeToModify = new Range(matches[0].Value, matches[1].Value);
            }
            else
            {
                throw new ApplicationException(
                    $"Not enough matches found in instruction. Expected 2, found {matches.Count}. Input string {s}.");
            }
        }
    }
}