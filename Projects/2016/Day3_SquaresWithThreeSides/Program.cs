#region Information

// AdventOfCode: Day3_SquaresWithThreeSides
// Created: 2016-12-03
// Modified: 2016-12-03 9:26 PM
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
        private static readonly List<Triangle> Triangles = new List<Triangle>();
        #endregion

        static void Main(string[] args)
        {
            // Test cases
            //_input = new List<string> {"5 10 25", "5 20 25", "10 20 25"};
            _input = File.ReadAllLines("input.txt").ToList();

            // Convert input to Triangle objects.
            ProcessInput();
            Console.WriteLine($"Number of possible triangles found: {Triangles.Count(x => x.IsValidTriangle)}.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void ProcessInput()
        {
            foreach (string possibleTriangle in _input)
            {
                Triangles.Add(new Triangle(possibleTriangle));
            }
        }
    }
}