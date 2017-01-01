#region Information

// AdventOfCode: Day13_AMazeOfTwistyLittleCubicles
// Created: 2016-12-13
// Modified: 2016-12-14 9:23 PM
#endregion

// Created by Reddit user /u/johanw213 (https://www.reddit.com/user/johanw123)
// See https://www.reddit.com/r/adventofcode/comments/5i1q0h/2016_day_13_solutions/db4wnvi/
// I take no credit for this solution

#region Using Directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

#endregion

namespace Day13_AMazeOfTwistyLittleCubicles
{
    class Program
    {
        #region  Fields
        private static readonly Size[] Directions = {new Size(-1, 0), new Size(1, 0), new Size(0, -1), new Size(0, 1)};
        private static Dictionary<Point, int> ShortestPath = new Dictionary<Point, int>();
        #endregion

        static void Main(string[] args)
        {
            const int width = 150;
            const int height = 150;
            const int puzzleInput = 1362;
            var map = new char[width, height];

            for (var y = 0; y < width; y++)
            {
                for (var x = 0; x < height; x++)
                {
                    int e = x * x + 3 * x + 2 * x * y + y + y * y + puzzleInput;

                    bool open = (Convert.ToString(e, 2).Count(c => c == '1') & 1) == 0;

                    map[y, x] = open ? '.' : '#';
                }
            }

            var target = new Point(31, 39);
            var start = new Point(1, 1);

            // Set initial count
            const int count = -1;

            //Find path
            Find(map, start, target, count);

            // Part 1
            Console.WriteLine("Shortest:" + ShortestPath[target]);

            // Part 2
            ShortestPath = new Dictionary<Point, int>();
            Find(map, start, target, count, false);

            Console.WriteLine("Locations:" + ShortestPath.Count);
            Console.ReadKey();
        }

        /// <summary>
        ///     Finds the specified map.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <param name="current">The current point.</param>
        /// <param name="target">The target point.</param>
        /// <param name="numSteps">The number of steps taken.</param>
        /// <param name="part1">Perform part 1 or 2</param>
        private static void Find(char[,] map, Point current, Point target, int numSteps, bool part1 = true)
        {
            numSteps++;

            if (part1)
            {
                // Part 1
                // If we have arrived at the target co-ordinates,
                // store the number of steps it took.
                if (current == target)
                {
                    ShortestPath[current] = numSteps;
                    return;
                }
            }
            else
            {
                // Part 2
                if (numSteps >= 50)
                {
                    ShortestPath[current] = numSteps;
                    return;
                }
            }

            // Have we been here before?
            if (ShortestPath.ContainsKey(current))
            {
                // If the number of steps taken to get here is less than
                // the number of steps we have taken so far
                // we've hit a dead end.
                if (ShortestPath[current] < numSteps)
                {
                    //Console.WriteLine("dead end:" + ShortestPath[current]);
                    return;
                }

                // Store the number of steps it has taken to reach this place.
                ShortestPath[current] = numSteps;
            }
            else

                // Add this point to the shortest path
                ShortestPath.Add(current, numSteps);

            // If we are at the starting point, the number of steps taken is 0
            if (current == new Point(1, 1))
                numSteps = 0;

            // Check each direction.
            for (var i = 0; i < 4; i++)
            {
                Point nm = Point.Add(current, Directions[i]);

                // If direction is open, travel in that direction.
                if (nm.X >= 0 && nm.Y >= 0 && map[nm.Y, nm.X] == '.')
                {
                    Find(map, nm, target, numSteps);
                }
            }
        }
    }
}