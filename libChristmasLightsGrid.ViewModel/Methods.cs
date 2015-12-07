#region Information

// AdventOfCode: libChristmasLightsGrid.ViewModel
// Created: 2015-12-06
// Modified: 2015-12-07 8:50 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
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
            Lights = new List<ChristmasLight>();
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    Lights.Add(new ChristmasLight(i, j));
                }
            }
        }

        private void HighlightCorners()
        {
            var lights = Lights.Where(l => (l.PosX == 0 || l.PosX == Columns - 1) && (l.PosY == 0 || l.PosY == Rows - 1));
            foreach (ChristmasLight light in lights)
            {
                light.TurnOn();
            }
        }

        /// <summary>
        ///     Perform a given set of instructions
        /// </summary>
        private void PerformInstructions()
        {
            foreach (string instruction in Instructions)
            {
                FollowInstruction(instruction);
            }
        }

        /// <summary>
        ///     Perform a given set of instructions
        /// </summary>
        private void PerformBrightnessInstructions()
        {
            foreach (string instruction in Instructions)
            {
                FollowBrightnessInstruction(instruction);
            }
        }

        /// <summary>
        ///     Perform a given instruction
        /// </summary>
        /// <param name="s">Instruction string to perform</param>
        private void FollowInstruction(string s)
        {
            // example: turn on 0,0 through 999,999
            Regex stepRegex = new Regex(@"^\D+"); // Get instruction
            Regex rangeRegex = new Regex(@"[\D+]\d+"); // Get first and last range.
            MatchCollection matches = rangeRegex.Matches(s);
            List<int> rangeInts = new List<int>();
            for (int i = 0; i < matches.Count; i++)
            {
                rangeInts.Add(Convert.ToInt32(matches[i].Value.Replace(',', ' ').Replace(" ", "")));
            }
            if (rangeInts.Count == 4)
            {
                RangeToModify = new Range(rangeInts);
            }
            else
            {
                throw new ApplicationException(
                    $"Not enough matches found in instruction. Expected 2, found {matches.Count}. Input string {s}.");
            }

            IEnumerable<ChristmasLight> range =
                Lights.Where(
                    light =>
                    light.PosX <= RangeToModify.EndX && light.PosX >= RangeToModify.StartX &&
                    light.PosY >= RangeToModify.StartY && light.PosY <= RangeToModify.EndY);

            string step = stepRegex.Match(s).Value;
            switch (step.ToLower().Trim())
            {
                case "turn on":
                    TurnOnRange(range);
                    break;
                case "turn off":
                    TurnOffRange(range);
                    break;
                case "toggle":
                    ToggleRange(range);
                    break;
                default:
                    throw new ApplicationException($"{InvalidInstruction}: {step}");
            }
        }

        /// <summary>
        ///     Perform a given instruction
        /// </summary>
        /// <param name="s">Instruction string to perform</param>
        /// <remarks>
        ///     Possible instructions are:
        ///     Turn on:    increate brightness of light by 1
        ///     Turn off:   descrease brightness of light by 1, to a minimum of 0
        ///     Toggle:     increase the brightness of those lights by 2
        /// </remarks>
        private void FollowBrightnessInstruction(string s)
        {
            // example: turn on 0,0 through 999,999
            Regex stepRegex = new Regex(@"^\D+"); // Get instruction
            Regex rangeRegex = new Regex(@"[\D+]\d+"); // Get first and last range.
            MatchCollection matches = rangeRegex.Matches(s);
            List<int> rangeInts = new List<int>();
            for (int i = 0; i < matches.Count; i++)
            {
                rangeInts.Add(Convert.ToInt32(matches[i].Value.Replace(',', ' ').Replace(" ", "")));
            }
            if (rangeInts.Count == 4)
            {
                RangeToModify = new Range(rangeInts);
            }
            else
            {
                throw new ApplicationException(
                    $"Not enough matches found in instruction. Expected 2, found {matches.Count}. Input string {s}.");
            }

            IEnumerable<ChristmasLight> range =
                Lights.Where(
                    light =>
                    light.PosX <= RangeToModify.EndX && light.PosX >= RangeToModify.StartX &&
                    light.PosY >= RangeToModify.StartY && light.PosY <= RangeToModify.EndY);

            string step = stepRegex.Match(s).Value;
            switch (step.ToLower().Trim())
            {
                case "turn on":
                    TurnOnBrightnessRange(range);
                    break;
                case "turn off":
                    TurnOffBrightnessRange(range);
                    break;
                case "toggle":
                    ToggleBrightnessRange(range);
                    break;
                default:
                    throw new ApplicationException($"{InvalidInstruction}: {step}");
            }
        }
    }
}