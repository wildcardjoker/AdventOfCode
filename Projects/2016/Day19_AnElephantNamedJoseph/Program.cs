#region Information

// AdventOfCode: Day19_AnElephantNamedJoseph
// Created: 2016-12-19
// Modified: 2016-12-19 9:06 PM
#endregion

#region Using Directives
using System;

#endregion

namespace Day19_AnElephantNamedJoseph
{
    /// <summary>
    ///     Thanks to https://www.reddit.com/r/adventofcode/comments/5j4lp1/2016_day_19_solutions/dbdf5yq/
    ///     and Numberphile: https://www.youtube.com/watch?v=uCsD3ZGzMgE
    ///     Part Two courtesy of reddit.com/u/mcosand
    ///     https://www.reddit.com/r/adventofcode/comments/5j4lp1/2016_day_19_solutions/dbdf5in/
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
            PartTwo();
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

        private static void PartTwo()
        {
            // Set starting Elf
            var startElf = new Elf(1);
            Elf currentElf = startElf;
            Elf targetElf = null;

            // Wait for all the guests to arrive
            for (var i = 1; i < NumEleves + 1; i++)
            {
                // Next elf arrives
                // Have we reached the guest limit?
                // If yes, the Next Elf is the first Elf (circle)
                // Otherwise, set up a new Elf (setting the last elf as the Previous Elf).
                currentElf.NextElf = i == NumEleves ? startElf : new Elf(i + 1) {PreviousElf = currentElf};

                // Next Elf sits next to current Elf.
                currentElf = currentElf.NextElf;

                // If we hit the half way point, this is our target elf.
                if (i == NumEleves / 2) targetElf = currentElf;
            }

            // The last guest sits next to the starting elf to complete the circle.
            startElf.PreviousElf = currentElf;

            // Set up a counter so we can keep track of where we are.
            uint count = NumEleves;

            // While there are still more than one elf
            while (currentElf.NextElf != currentElf)
            {
                // Remove the current elf
                targetElf.PreviousElf.NextElf = targetElf.NextElf;
                targetElf.NextElf.PreviousElf = targetElf.PreviousElf;

                // Set the next elf. If number of elves in circle is odd, set to the elf after next.
                targetElf = count % 2 == 1 ? targetElf.NextElf.NextElf : targetElf.NextElf;

                // Remove an elf.
                count--;

                // Move on to the next elf.
                currentElf = currentElf.NextElf;
            }

            // Only one elf remains.
            int elfId = currentElf.Id;
            Console.WriteLine($"Part 2: Elf {elfId} stole all the presents!");
        }
    }
}