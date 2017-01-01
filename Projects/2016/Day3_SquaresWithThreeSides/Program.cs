#region Information

// AdventOfCode: Day3_SquaresWithThreeSides
// Created: 2016-12-03
// Modified: 2016-12-03 10:46 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace Day3_SquaresWithThreeSides
{
    /// <summary>
    ///     Day 3 - Squares with three sides
    ///     Given a list of triangles (three sides of varying length),
    ///     calculate the number of records which may be a triangle
    ///     i.e. how many records have a set of numbers where the
    ///     two smallest numbers are larger than the largest number.
    /// </summary>
    class Program
    {
        #region  Fields
        private static List<string> _input;
        private static List<Triangle> _triangles;
        #endregion

        static void Main(string[] args)
        {
            // Test cases
            //_input = new List<string> {"5 10 25", "5 20 25", "10 20 25"};
            // Part 2 Test Cases
            //_input = new List<string>
            //         {
            //             "101 301 501",
            //             "102 302 502",
            //             "103 303 503",
            //             "201 401 601",
            //             "202 402 602",
            //             "203 403 603"
            //         };

            _input = File.ReadAllLines("input.txt").ToList();

            // Convert input to Triangle objects.
            ProcessInputPart1();
            Console.WriteLine(
                $"Part 1 - Number of possible triangles found: {_triangles.Count(x => x.IsValidTriangle)}.");
            ProcessInputPart2();
            Console.WriteLine(
                $"Part 2 - Number of possible triangles found: {_triangles.Count(x => x.IsValidTriangle)}.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        ///     create list of Triangles using single line for lengths.
        /// </summary>
        private static void ProcessInputPart1()
        {
            _triangles = new List<Triangle>();
            foreach (string possibleTriangle in _input)
            {
                _triangles.Add(new Triangle(possibleTriangle));
            }
        }

        /// <summary>
        ///     Process input vertically.
        /// </summary>
        /// <remarks>
        ///     For-loop modified from code posted to reddit.com/r/adventofcode by /u/IcyHammer
        ///     http://pastebin.com/uyZLg8f0
        /// </remarks>
        private static void ProcessInputPart2()
        {
            _triangles = new List<Triangle>();
            var lengths = new int[3];
            var lengthCount = 0;
            for (var i = 0; i < 3; i++)
            {
                foreach (string t in _input)
                {
                    string[] line = t.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    lengths[lengthCount] = Convert.ToInt32(line[i]);
                    lengthCount++;
                    if (lengthCount != 3) continue;
                    lengthCount = 0;
                    _triangles.Add(new Triangle(lengths));
                }
            }
        }
    }
}