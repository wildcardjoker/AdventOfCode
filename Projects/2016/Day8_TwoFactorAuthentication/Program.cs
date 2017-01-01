#region Information

// AdventOfCode: Day8_TwoFactorAuthentication
// Created: 2016-12-08
// Modified: 2016-12-09 8:28 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

#endregion

namespace Day8_TwoFactorAuthentication
{
    class Program
    {
        #region  Fields
        private const int LcdWidth = 50;
        private const int LcdHeight = 6;
        private const int InstructionCountPad = 5;
        private const int PixelPad = 20;
        private const int InstructionPad = LcdWidth - PixelPad - InstructionCountPad;
        private static readonly Regex DigitRegex = new Regex(@"\d+");

        public static bool[,] Lcd = new bool[LcdHeight, LcdWidth];

        private static readonly List<string> TestInput = new List<string>
                                                         {
                                                             "rect 1x1",
                                                             "rotate row y=0 by 1",
                                                             "rotate column x=1 by 1",
                                                             "rotate row y=1 by 1",
                                                             "rotate column x=2 by 1",
                                                             "rotate row y=2 by 1",
                                                             "rotate column x=3 by 4",
                                                             "rotate column x=3 by 1",
                                                             "rotate column x=3 by 1"

                                                             // Puzzle example.
                                                             //"rect 3x2",
                                                             //"rotate column x=1 by 1",
                                                             //"rotate row y=0 by 4",
                                                             //"rotate column x=1 by 1"
                                                         };

        private static readonly List<string> Input = File.ReadAllLines("input.txt").ToList();
        #endregion

        static void Main(string[] args)
        {
            Console.Title = "Advent of Code 2016 - Day 8";
            Console.SetWindowSize(LcdWidth + 1, LcdHeight + 2);
            Console.SetBufferSize(LcdWidth + 1, LcdHeight + 2);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            var instructionCount = 1;

            // Wait for user input.
            Console.Clear();
            Console.Write("Press any key to begin...");
            Console.ReadKey();
            foreach (string s in Input)
            {
                Console.Clear();
                ProcessInput(s);
                DisplayLcd();
                Console.WriteLine(
                    $"{($"{GetNumberOfLitPixels()} lit pixels".PadRight(PixelPad))}{s.PadRight(InstructionPad)}{instructionCount.ToString().PadLeft(5)}");
                instructionCount++;

                Thread.Sleep(100);
            }

            Console.Write($"Number of pixels lit: {GetNumberOfLitPixels()}");
            Console.ReadKey();
        }

        private static int GetNumberOfLitPixels()
        {
            // Get "on" pixels
            var litPixels = 0;
            for (var i = 0; i < LcdHeight; i++)
            {
                for (var j = 0; j < LcdWidth; j++)
                {
                    if (Lcd[i, j])
                    {
                        litPixels++;
                    }
                }
            }
            return litPixels;
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

                var list = new List<bool>();
                for (var i = 0; i < LcdHeight; i++)
                {
                    list.Add(Lcd[i, columnToRotate]);
                }
                list.Reverse();
                for (var i = 0; i < rowMatch; i++)
                {
                    bool value = list.First();
                    list.RemoveAt(0);
                    list.Add(value);
                }
                list.Reverse();
                var count = 0;
                foreach (bool b in list)
                {
                    Lcd[count, columnToRotate] = b;
                    count++;
                }
            }
            else
            {
                int rowToRotate = Convert.ToInt32(matches[0].Value);
                int columnMatch = Convert.ToInt32(matches[1].Value);

                var list = new List<bool>();
                for (var i = 0; i < LcdWidth; i++)
                {
                    list.Add(Lcd[rowToRotate, i]);
                }

                list.Reverse();
                for (var i = 0; i < columnMatch; i++)
                {
                    bool value = list.First();
                    list.RemoveAt(0);
                    list.Add(value);
                }

                list.Reverse();
                var count = 0;
                foreach (bool b in list)
                {
                    Lcd[rowToRotate, count] = b;
                    count++;
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