#region Information

// AdventOfCode: Day19_AnElephantNamedJoseph
// Created: 2016-12-19
// Modified: 2016-12-19 8:11 PM
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
        #region  Fields

        // Number of elves at the White Elephant party. (puzzle input)
        private const uint NumEleves = 3001330;
        #endregion

        static void Main(string[] args)
        {
            PartOne();
            Console.WriteLine("press any key.");
            Console.ReadKey();
        }

        private static void PartOne()
        {
            // Get the highest power of two that is less than the number of Elves.
            uint highestPowerOfTwo = GetHighestPowerOfTwo(NumEleves);
            uint elfId = (NumEleves - highestPowerOfTwo) * 2 + 1;
            Console.WriteLine($"Part 1: Elf {elfId} steals all the presents!");
        }

        /// <summary>
        ///     Get highest power of two that is less than the input.
        /// </summary>
        /// <param name="x">The number being processed.</param>
        /// <returns></returns>
        private static uint GetHighestPowerOfTwo(uint x)
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