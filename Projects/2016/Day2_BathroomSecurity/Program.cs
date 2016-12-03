#region Information

// AdventOfCode: Day2_BathroomSecurity
// Created: 2016-12-02
// Modified: 2016-12-03 5:55 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Day2_BathroomSecurity
{
    /// <summary>
    ///     Advent of Code Day 2
    /// </summary>
    partial class Program
    {
        #region  Fields
        private static int _padMax;
        private static List<Button> _keyPad = new List<Button>();
        private static int _padX = 1;
        private static int _padY = 1;
        private static readonly StringBuilder Sb = new StringBuilder();
        private static Button _lastButton;
        private static bool _squareKeypad;
        #endregion

        /// <summary>
        ///     Launch the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            // Set up instructions
            var testInstructions = new[] {"ULL", "RRDDD", "LURDL", "UUUUD"};
            string[] puzzleInstructions = File.ReadAllLines("input.txt");
            Console.WriteLine("Part 1");

            //Part 1 Test
            _squareKeypad = true;
            _padMax = 2;
            Console.Write("Test: ");
            SolveKeypad(testInstructions);

            // Part 1 Puzzle
            Console.Write("Puzzle: ");
            SolveKeypad(puzzleInstructions);

            // Part 2 Test
            Console.WriteLine("Part 1");
            _squareKeypad = false;
            _padMax = 4;
            Console.Write("Test: ");
            SolveKeypad(testInstructions);

            // Part 2 Puzzle
            Console.Write("Puzzle: ");
            SolveKeypad(puzzleInstructions);

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        /// <summary>
        ///     Solves the keypad by following the instructions.
        /// </summary>
        /// <param name="instructions">The instructions.</param>
        private static void SolveKeypad(IEnumerable<string> instructions)
        {
            Sb.Clear();
            GenerateKeyPad();
            foreach (string instruction in instructions)
            {
                FollowInstructions(instruction);
            }
            Console.WriteLine($"I think the combination is {Sb}");
        }

        /// <summary>
        ///     Follows an individual set of instructions and add the resulting Button value to the answer.
        /// </summary>
        /// <param name="instruction">The instruction.</param>
        private static void FollowInstructions(string instruction)
        {
            foreach (char c in instruction)
            {
                Move(c);
            }
            Button buttonToPress = GetButtonByCoordinates();
            Sb.Append(buttonToPress.Value);
        }

        /// <summary>
        ///     Move to the next button.
        ///     If no button exists at these coordinates, remain in the previous position.
        /// </summary>
        /// <returns></returns>
        private static Button GetButtonByCoordinates()
        {
            // Get the button matching the X and Y coordinates. 
            // If no button exists at these coordinates, use the position of the last button we did reach.
            Button button =
                _keyPad.FirstOrDefault(x => x.ButtonCoordinates.X == _padX && x.ButtonCoordinates.Y == _padY) ??
                _lastButton;
            _padX = button.ButtonCoordinates.X;
            _padY = button.ButtonCoordinates.Y;
            return button;
        }

        /// <summary>
        ///     Move in the specified direction.
        /// </summary>
        /// <param name="c">The c.</param>
        private static void Move(char c)
        {
            _lastButton = GetButtonByCoordinates();
            switch (c)
            {
                case 'U':
                    _padY++;
                    break;
                case 'D':
                    _padY--;
                    break;
                case 'L':
                    _padX--;
                    break;
                case 'R':
                    _padX++;
                    break;
                default:
                    Debug.WriteLine($"Unknown direction: {c}");
                    break;
            }

            // Is there a button at these coordinates?
            // If yes, set this button as the origin point for the next move.
            if (_keyPad.Any(x => x.ButtonCoordinates.X == _padX && x.ButtonCoordinates.Y == _padY))
            {
                _lastButton = GetButtonByCoordinates();
            }
        }
    }
}