#region Information

// AdventOfCode: Day19_AnElephantNamedJoseph
// Created: 2016-12-19
// Modified: 2016-12-19 7:46 PM
#endregion

#region Using Directives
using System;

#endregion

namespace Day19_AnElephantNamedJoseph
{
    /// <summary>
    ///     Thanks to https://www.reddit.com/r/adventofcode/comments/5j4lp1/2016_day_19_solutions/dbdf5yq/
    ///     and Numberphile: https://www.youtube.com/watch?v=uCsD3ZGzMgE
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Number of elves at the White Elephant party. (puzzle input)
            uint numEleves = 3001330;

            // Get the highest power of two that is less than the number of Elves.
            uint highestPowerOfTwo = GethighestPowerOfTwo(numEleves);
            Console.WriteLine((numEleves - highestPowerOfTwo) * 2 + 1);
            Console.WriteLine("press any key.");
            Console.ReadKey();
        }

        /// <summary>
        ///     Get highest power of two that is less than the input.
        /// </summary>
        /// <param name="x">The number being processed.</param>
        /// <returns></returns>
        static UInt32 GethighestPowerOfTwo(UInt32 x)
        {
            x = x | (x >> 1);
            x = x | (x >> 2);
            x = x | (x >> 4);
            x = x | (x >> 8);
            x = x | (x >> 16);
            return x - (x >> 1);
        }
    }
}