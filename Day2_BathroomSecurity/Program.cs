#region Information

// AdventOfCode: Day2_BathroomSecurity
// Created: 2016-12-02
// Modified: 2016-12-02 10:00 PM
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
    class Program
    {
        #region  Fields
        private const int PadMax = 2;
        private static readonly List<Button> KeyPad = new List<Button>();
        private static int _padX = 1;
        private static int _padY = 1;
        private static readonly StringBuilder Sb = new StringBuilder();
        #endregion

        /// <summary>
        ///     Launch the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            GenerateKeyPad();
            string[] instructions = File.ReadAllLines("input.txt");
            foreach (string instruction in instructions)
            {
                FollowInstructions(instruction);
            }
            Console.WriteLine(Sb.ToString());
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        /// <summary>
        ///     Generates the key pad.
        /// </summary>
        private static void GenerateKeyPad()
        {
            var k = 1;
            for (int i = PadMax; i >= 0; i--)
            {
                for (var j = 0; j <= PadMax; j++)
                {
                    KeyPad.Add(new Button(j, i, k));
                    k++;
                }
            }
        }

        private static void FollowInstructions(string instruction)
        {
            foreach (char c in instruction)
            {
                Move(c);
            }
            Sb.Append(KeyPad.First(x => x.ButtonCoordinates.X == _padX && x.ButtonCoordinates.Y == _padY).Value);
        }

        /// <summary>
        ///     Move in the specified direction.
        /// </summary>
        /// <param name="c">The c.</param>
        private static void Move(char c)
        {
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
            _padX = _padX < 0 ? 0 : _padX > PadMax ? PadMax : _padX;
            _padY = _padY < 0 ? 0 : _padY > PadMax ? PadMax : _padY;
        }
    }
}