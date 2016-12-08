#region Information

// AdventOfCode: Day8_TwoFactorAuthentication
// Created: 2016-12-08
// Modified: 2016-12-09 7:27 AM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

namespace Day8_TwoFactorAuthentication
{
    class Program
    {
        #region  Fields
        private const int LcdWidth = 50;
        private const int LcdHeight = 6;
        private static readonly Regex DigitRegex = new Regex(@"\d+");

        //private static List<Pixel> _lcd;
        public static bool[,] Lcd = new bool[LcdHeight, LcdWidth];

        private static readonly List<string> TestInput = new List<string>
                                                         {
                                                             "rect 3x2",
                                                             "rotate column x=1 by 1",
                                                             "rotate row y=0 by 4",
                                                             "rotate column x=1 by 1"
                                                         };

        private static readonly List<string> Input = File.ReadAllLines("input.txt").ToList();
        #endregion

        static void Main(string[] args)
        {
            foreach (string s in TestInput)
            {
                ProcessInput(s);
                DisplayLcd();
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static void DisplayLcd()
        {
            for (var row = 0; row < LcdHeight; row++)
            {
                for (var col = 0; col < LcdWidth; col++)
                {
                    Console.Write(Lcd[row, col] ? "#" : ".");
                }
                Console.WriteLine();
            }
        }

        private static void ProcessInput(string s)
        {
            if (s.StartsWith("rect"))
            {
                // Turn on pixels in rectangle
                SetRectangle(s);
            }
            else if (s.StartsWith("rotate row"))
            {
                // Shift row A B pixels to the right.
                Shift(s, Direction.Right);
            }
            else if (s.StartsWith("rotate column"))
            {
                // Shift column A B pixels down.
                Shift(s, Direction.Down);
            }
        }

        private static void Shift(string s, Direction direction)
        {
            MatchCollection matches = DigitRegex.Matches(s);
            if (direction.Equals(Direction.Down))
            {
                int columnToRotate = Convert.ToInt32(matches[0].Value);
                int rowMatch = Convert.ToInt32(matches[1].Value);

                for (var i = 0; i < rowMatch; i++)
                {
                    // Shift pixels down
                    for (int row = LcdHeight - 1; row >= 0; row--)
                    {
                        // Get value of first  pixel.
                        bool firstPixel = Lcd[0, columnToRotate];
                        bool lastPixel = Lcd[LcdHeight - 1, columnToRotate];
                        int previousRow = row - 1;
                        bool previousPixel = previousRow < 0 ? lastPixel : Lcd[previousRow, columnToRotate];
                        Lcd[row, columnToRotate] = previousPixel;
                    }
                }
            }
            else
            {
                int rowToRotate = Convert.ToInt32(matches[0].Value);
                int columnMatch = Convert.ToInt32(matches[1].Value);

                for (var i = 0; i < columnMatch; i++)
                {
                    // Shift pixels right
                    for (int col = LcdWidth - 1; col >= 0; col--)
                    {
                        // Get value of first  pixel.
                        bool firstPixel = Lcd[rowToRotate, 0];
                        bool lastPixel = Lcd[rowToRotate, LcdWidth - 1];
                        int previousCol = col - 1;
                        bool previousPixel = previousCol < 0 ? lastPixel : Lcd[rowToRotate, previousCol];
                        Lcd[rowToRotate, col] = previousPixel;
                    }
                }
            }
        }

        private static MatchCollection GetRegexMatches(string s) => DigitRegex.Matches(s);

        private static void SetRectangle(string s)
        {
            MatchCollection matches = GetRegexMatches(s);
            if (matches.Count == 2)
            {
                int width = Convert.ToInt32(matches[0].Value);
                int height = Convert.ToInt32(matches[1].Value);
                for (var row = 0; row < height; row++)
                {
                    for (var col = 0; col < width; col++)
                    {
                        Lcd[row, col] = true;
                    }
                }
            }
        }

        #region Nested type: Direction
        private enum Direction
        {
            Down,
            Right
        }
        #endregion
    }
}